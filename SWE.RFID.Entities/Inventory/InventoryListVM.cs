using SWE.RFID.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.Inventory
{
    public class InventoryListVM
    {
        public Pager Pager { get; set; }
        public List<Inventory> Value { get; set; }
        public List<string> Errors { get; set; }

    }
}
