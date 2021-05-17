using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TechStart_Test.Models
{
    public class PharmacyInventory
    {
        public int IdPharmacy { get; set; }
        public int ItemNumber { get; set; }

        
        public int QuantityOnHand { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderQuantity { get; set; }
        public decimal SellingUnitMeasure { get; set; }
    }
}
