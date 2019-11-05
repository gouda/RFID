using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.Inventory
{
   public class Inventory
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public int Id { get; set; }
        public string rowversion { get; set; }
    }
}
