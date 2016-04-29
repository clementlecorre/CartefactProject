using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar3ASP.Models
{
    public class StatusModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStatus { get; set; }
        public Boolean Open { get; set; }
        public Boolean Closed { get; set; }
        public Boolean Pending { get; set; }

    }
}
