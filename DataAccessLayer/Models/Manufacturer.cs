using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }
        [Display(Name = "Logo")]
        public string PictureUrl { get; set; }
        [Display(Name = "Company")]
        public string ManufacturerName { get; set; }
        [Display(Name = "Biography")]
        public string ManufacturerBiography { get; set; }

        // relations
        public List <Mobile> Mobiles { get; set; }
    }
}
