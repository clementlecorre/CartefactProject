using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar3ASP.Models
{
    public class CarModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCar { get; set; }

        [Required]
        [Display(Name = "The brand")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "The model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Description of car")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Date of purchase of car")]
        public DateTime Buying_Date { get; set; }


        [Required]
        [Display(Name = "Mileage")]
        public int Km { get; set; }

        //ForeignKey
        public virtual LocationModels Location { get; set; }
        //ForeignKey
        public virtual StatusModels Status { get; set; }
    }
}
