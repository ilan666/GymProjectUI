using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDatabaseProject.Models
{
    [Table("Plans")]
    public class Plans
    {
        [Key]
        public int Plan_ID { get; set; }

        [Required]
        public string _Plan { get; set; }

        [Required]
        public int Cost { get; set; }
    }
}
