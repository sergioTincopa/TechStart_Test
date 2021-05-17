using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStart_Test.Models
{
    
    public class ItemVendor
    {
        public int IdItemVendor { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Item> ListItem { get; set; } 

    }
}
