using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessLayer.Domain;

namespace Magazin.Models
{
    public class MyOrdersModel
    {
        public int OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public Status Status { get; set; }
    }
    public class MyOrderViewModel
    {
        public int OrderNumber { get; set; }
        public Customer Customer { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ShipmentDate { get; set; }
        public Status Status { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public int Total { get; set; }
    }
}