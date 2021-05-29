using DataAccess.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace DataAccess.Mapping
{
    public class DiscountMapping : ClassMap<Discount>
    {
        public DiscountMapping()
        {
            Table("Discount");
            LazyLoad();
            Id(x => x.DiscountId).GeneratedBy.Native();
            Map(x => x.DiscountPercent, "DiscountPercent");
            Map(x => x.StartDate, "StartDate");
            Map(x => x.EndDate, "EndDate").Nullable();
            HasManyToMany(x => x.Articles).Cascade.None()
                .Table("ArticleDiscount")
                .ParentKeyColumn("DiscountId")
                .ChildKeyColumn("ArticleId");
            
        }
    }
}
