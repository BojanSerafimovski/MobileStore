using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class ProceedOrderViewModel
    {
        [Display(Name = "Name and Surname")]
        [Required(ErrorMessage = "Required field (Please insert your First Name and Last Name!)")]
        public string NameSurname { get; set; }
        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required field (We need to contact you when your order will be ready!)")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Required field (We need to know where to deliver the devices!)")]
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ShoppingCartItem ShoppingCartItem { get; set; }
        [Display(Name = "Your order costs:")]
        public double Total { get; set; }
    }
}
