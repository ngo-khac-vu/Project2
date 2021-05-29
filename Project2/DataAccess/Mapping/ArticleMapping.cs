using DataAccess.Entities;
using FluentNHibernate.Mapping;

namespace DataAccess.Mapping
{
    public class ArticleMapping : ClassMap<Article>
    {
        public ArticleMapping()
        {
            Table("Article");
            LazyLoad();
            Id(x => x.ArticleId).GeneratedBy.Native();
            Map(x => x.Name, "Name");
            Map(x => x.Slogan, "Slogan").Nullable();
            Map(x => x.NetPrice, "NetPrice");
            Map(x => x.SalePrice, "SalePrice");
            Map(x => x.VAT_ratio, "VAT_ratio");
            HasManyToMany(x => x.Discounts).Cascade.All()
                .Table("ArticleDiscount")
                .ParentKeyColumn("ArticleId")
                .ChildKeyColumn("DiscountId");
        }
    }
}
