using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDatabaseProject.Models
{
    [Table("AdminMessages")]
    public class Messages
    {
        [Key]
        public int Message_ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public int _From_ID { get; set; }

        public int _To_ID { get; set; }
    }
}
