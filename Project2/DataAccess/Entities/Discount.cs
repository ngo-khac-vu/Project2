using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Discount
    {
        public virtual long DiscountId { get; set; }

        public virtual float DiscountPercent { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        public virtual IList<Article> Articles { get; set; }
    }
}
