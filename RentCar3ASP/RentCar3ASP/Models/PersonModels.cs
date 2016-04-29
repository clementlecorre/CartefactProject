using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar3ASP.Models
{
    public class PersonModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Your driving habits")]
        public string Driving_habits { get; set; }

        [Required]
        [Display(Name = "Your driver experience ")]
        public string Driver_experience { get; set; }

        //ForeignKey
       // public virtual RoleModels Role { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }

      
    }
}
