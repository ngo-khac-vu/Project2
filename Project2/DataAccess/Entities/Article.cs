using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Article
    {
        public virtual long ArticleId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Slogan { get; set; }

        public virtual decimal NetPrice { get; set; }

        public virtual decimal SalePrice { get; set; }
        
        public virtual float VAT_ratio { get; set; }

        public virtual IList<Discount> Discounts { get; set; }
    }
}
