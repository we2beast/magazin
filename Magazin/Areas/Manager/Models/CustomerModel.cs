using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Magazin.Areas.Manager.Models
{
    //Модель вывода в таблице
    public class CustomerListModel { 
        
        public string Code { get; set; }
        public string Name { get; set; } 
        public int? Discount { get; set; }
        public string Email { get; set; }
    }

    //Модель создания
    public class CustomerCreateModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Адресс")]
        public string Address { get; set; }
        [Display(Name = "Скидка")]
        public int? Discount { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    //Модель редактирования
    public class CustomerEditModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Discount { get; set; }
        public string UserName { get; set; }
    }

    //Модель просмотра
    public class CustomerViewModel 
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Discount { get; set; }
        public string UserName { get; set; }

        public List<OrdersListForCustomer> Orders { get; set; }
    }
}