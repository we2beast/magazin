using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Domain
{
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemPrice { get; set; }
        [NotMapped]
        public decimal Summ { get { return ItemCount * ItemPrice; } }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}
