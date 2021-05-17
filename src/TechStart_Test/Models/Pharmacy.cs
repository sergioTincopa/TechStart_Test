using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStart_Test.Models
{
    public class Pharmacy
    {
        public int IdPharmacy { get; set; }
        public int IdHospital { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
