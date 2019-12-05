using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BusinessLayer.Domain;
namespace Magazin.Areas.Manager.Models
{
    //Модель вывода в таблице
    public class ItemListModelManager
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Category Category { get; set; }
    }

    //Модель создания
    public class ItemCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }
        public string CategoryId { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
    }

    //Модель редактирования
    public class ItemEditModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string CategoryId { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
    }

    //Модель просмотра
    public class ItemViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Category Category { get; set; }
    }
}