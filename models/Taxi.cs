using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiProject.models
{
    public class Taxi
    {
        [Key]
        public int TaxiId { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [DefaultValue("Unknown")]
        public string Brand { get; set; }

        [MaxLength(50)]
        public string Model { get; set; }

        public int? DriverId { get; set; }

        public Driver? DriverE { get; set; }
    }
}
