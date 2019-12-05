using System;

namespace Magazin.Areas.Manager.Models
{
    public class OrderItemList
    {
        public Guid ItemId { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Summ { get; set; }
    }
}