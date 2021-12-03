using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDatabaseProject.Models
{
    [Table("Admins")]
    public class Admins
    {
        [Key]
        public int AdminDBID { get; set; }

        public int User_ID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Messages> AdminMessages { get; set; } = new List<Messages>();
    }
}
