using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar3ASP.Models
{
    public class RentalModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRental { get; set; }

        [Required]
        [Display(Name = "Rental Start")]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "Rental End")]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "Price per day")]
        public string Priceperday { get; set; }

        [Required]
        [Display(Name = "estimated kilometers…")]
        public float Estimated_Km { get; set; }

        public virtual PersonModels Person { get; set; }
        public virtual int PersonId { get; set; } 
        
    }
}
