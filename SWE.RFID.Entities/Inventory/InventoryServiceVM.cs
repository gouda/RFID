using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.Inventory
{
   public class InventoryServiceVM
    {
        public Inventory Value { get; set; }
        public List<string> Errors { get; set; }
    }
}
