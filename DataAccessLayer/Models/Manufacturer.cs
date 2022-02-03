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
        [Required(ErrorMessage = "Please add a picture!")]
        public string PictureUrl { get; set; }
        [Display(Name = "Company")]
        [Required(ErrorMessage = "Please add a Company name!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The company name can't be less than three characters!")]
        public string ManufacturerName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Please add a short bio!")]
        public string ManufacturerBiography { get; set; }

        // relations
        public List <Mobile> Mobiles { get; set; }
    }
}
