using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class Mobile
    {
        [Key]
        public int MobileId { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "Please add a mobile model!")]
        public string MobileName { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Launch Date")]
        [Required(ErrorMessage = "Please add a manufacture date!")]
        public DateTime ManufactureDate { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please add a mobile price!")]
        public double MobilePrice { get; set; }
        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Please insert a mobile picture url!")]
        public string MobileImage { get; set; }
        [Required(ErrorMessage = "Please insert mobile quantity!")]
        public int Quantity { get; set; }
        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Please choose the manufacturer!")]
        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int? MobileDescriptionId { get; set; }
        public MobileDescription Description { get; set; }
    }
}
