using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDatabaseProject.Models
{
    [Table("UsersCalendar")]
    public class UsersCalendar
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Users")]
        public int UserDBID { get; set; }

        public Users User { get; set; }

        public int User_ID { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
