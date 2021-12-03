using GYMDatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymProjectUI.Database.Models
{
    [Table("UserNotifications")]
    public class UserNotifications
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Users")]
        public int UserDBID { get; set; }

        public Users User { get; set; }

        public int User_ID { get; set; }

        public string Body { get; set; }
    }
}
