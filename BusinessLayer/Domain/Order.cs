using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Domain
{
    public class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public int? OrderNumber { get; set; }
        public Guid StatusId { get; set; }        
        [NotMapped]
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Status Status { get; set; }
    }
}
