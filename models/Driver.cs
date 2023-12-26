using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiProject.models
{
    public class Driver
    {
        public int LicenseNumber { get; set; }

        public string Name { get; set; }

        public ICollection<Taxi> Taxis { get; set; }
    }
}
