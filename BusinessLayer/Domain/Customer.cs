using System;
using System.Collections.Generic;

namespace BusinessLayer.Domain
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public Guid CustomerId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //private int? discount;
        public int? Discount { get; set; }
        //{
        //    get
        //    {
        //        if (discount == null)
        //            discount = 0;
        //        return discount;
        //    }
        //    set
        //    {
        //        discount = value;
        //    }
        //}
        public string UserName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
