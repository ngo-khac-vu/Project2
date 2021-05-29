using DataAccess.Dto;
using DataAccess.Entities;
using DataAccess.Nhibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ArticleService : IArticleService
    {
        public IList<Article> GetAllArticles()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            IList<Article> articles;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    articles = session.QueryOver<Article>().List();
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
            return articles;
        }

        public IList<ArticleDto> GetPriceAllArticlesByDate(DateTime date)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            Article article = null;            
            var result = new List<ArticleDto>();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var articles = session.QueryOver<Article>(() => article).List();
                    tx.Commit();
                    foreach (var item in articles)
                    {
                        result.Add(new ArticleDto
                        {
                            Name = item.Name,
                            Slogan = item.Slogan,
                            Price = CalculatePriceWithVAT(item, date),
                            NetPrice = item.NetPrice
                        });
                    }
                }   
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
            return result;
        }

        /// <summary>
        /// Calculate price with VAT
        /// </summary>
        /// <param name="article">Article</param>
        /// <param name="date">Date to find discount</param>
        /// <returns>Price with VAT = price * (1 + VAT ratio)</returns>
        private decimal CalculatePriceWithVAT(Article article, DateTime date)
        {
            return CalculatePriceWithDiscount(article, date) * (1 + (decimal)article.VAT_ratio);
        }

        /// <summary>
        /// Calculate price with discount
        /// </summary>
        /// <param name="article">Article</param>
        /// <param name="date">Date to find discount</param>
        /// <returns>Price with discount = price * (1 - discount percent)</returns>
        private decimal CalculatePriceWithDiscount(Article article, DateTime date)
        {
            if (article.Discounts.Any())
            {
                // find a discount in valid date
                var discount = article.Discounts.FirstOrDefault(s => s.StartDate <= date && (s.EndDate == null | s.EndDate.Value >= date));
                if (discount != null)
                {
                    var discountPrice = (1 - (decimal)discount.DiscountPercent) * article.SalePrice;
                    return discountPrice > article.SalePrice ? discountPrice : article.SalePrice;
                }
            }
            return article.SalePrice;
        }
    }
}
