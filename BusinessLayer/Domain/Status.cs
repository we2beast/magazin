using System;
using System.Collections.Generic;

namespace BusinessLayer.Domain
{
    public class Status
    {
        public Status()
        {
            this.Orders = new HashSet<Order>();
        }

        public Guid StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
