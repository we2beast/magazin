using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DOMAIN
{
    public class ItemDomain
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string CategoryName { get; set; }
        public DateTime? DataRegistration { get; set; }

       
       // public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
