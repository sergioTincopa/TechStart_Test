using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStart_Test.Models
{
    public class Item
    {
        public int ItemNumber { get; set; }


        [RegularExpression(@"\d*", ErrorMessage = "Only numbers.")]
        public string UPC { get; set; }
        public string ItemDescription { get; set; }
        public decimal MinimunOrderQuantity { get; set; }
        public decimal PurchaseUnitMeasure { get; set; }
        public decimal ItemCost { get; set; }
        public int IdItemVendor { get; set; }

        public virtual ItemVendor ItemVendor { get; set; }

    }
}
