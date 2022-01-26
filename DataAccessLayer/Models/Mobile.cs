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
        public string MobileName { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Launch Date")]
        public DateTime ManufactureDate { get; set; }
        [Display(Name = "Price")]
        public double MobilePrice { get; set; }
        [Display(Name = "Picture")]
        public string MobileImage { get; set; }

        // need to target the manufacturer name from the manufacturer entity
        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public int? MobileDescriptionId { get; set; }
        public MobileDescription Description { get; set; }
    }
}
