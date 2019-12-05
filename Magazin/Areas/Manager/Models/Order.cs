using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BusinessLayer.Domain;
namespace Magazin.Areas.Manager.Models
{
    public class OrderListModel
    {
        public int OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public Status Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
    }

    public class OrdersListForCustomer
    {
        public int OrderNumber { get; set; }
        public Status Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
    }
    public class OrderViewModel
    {
        public int OrderNumber { get; set; }
        public Customer Customer { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ShipmentDate { get; set; }
        public Status Status { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public int Total { get; set; }
    }

    public class OrderEditModel
    {
        public int OrderNumber { get; set; }
  
        public Customer Customer { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShipmentDate { get; set; }

        [Display(Name = "Status")]
        public string StatusId { get; set; }
        public List<SelectListItem> StatusList { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public int Total { get; set; }
    }
}