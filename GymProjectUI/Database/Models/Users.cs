using GymProjectUI.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDatabaseProject.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserDBID { get; set; }

        [Required]
        public int User_ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string _Password { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string _Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [ForeignKey("Admins")]
        public int AdminDBID { get; set; }

        public Admins Admin { get; set; }

        public DateTime JoinedDate { get; set; }

        [ForeignKey("Plans")]
        public int Plan_ID { get; set; }

        public Plans Plan { get; set; }

        public DateTime PlanExpiration { get; set; }

        public ICollection<UserNotifications> Notifications { get; set; } = new List<UserNotifications>();

        public ICollection<UsersCalendar> Schedules { get; set; } = new List<UsersCalendar>();
    }
}
