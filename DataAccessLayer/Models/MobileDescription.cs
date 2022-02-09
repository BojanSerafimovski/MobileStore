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
        public string Description { get; set; }
        public string MobileDetails { get; set; }
        public Mobile MobileModel { get; set; }
    }
}
