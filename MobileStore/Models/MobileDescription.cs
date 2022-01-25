using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class MobileDescription
    {
        [Key]
        public int MobileDescriptionId { get; set; }

        // need to target the mobile name and the manufacture date from the mobile entity
        public int? MobileId { get; set; }
        public Mobile Mobile { get; set; }
        public string Description { get; set; }
    }
}
