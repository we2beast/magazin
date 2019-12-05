using System;
using System.Collections.Generic;

namespace BusinessLayer.Domain
{
    public class Item
    {
        public Item()
        {
            this.OrderItem = new HashSet<OrderItem>();
        }
        public Guid ItemId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Guid? CategoryId { get; set; }


        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
