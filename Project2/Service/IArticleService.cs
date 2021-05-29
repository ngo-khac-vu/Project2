using DataAccess.Dto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface IArticleService
    {
        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns>List of articles</returns>
        IList<Article> GetAllArticles();


        /// <summary>
        /// Get all articles with discount price.
        /// Discount price is calculated = sale price * (1 - discount price) * (1 + VAT ratio)
        /// If discount price less than net price then discount price is net price
        /// </summary>
        /// <param name="date">Date to check discount price is valid for article</param>
        /// <returns>Discount prices</returns>
        IList<ArticleDto> GetPriceAllArticlesByDate(DateTime date);
    }
}
