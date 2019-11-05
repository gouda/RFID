using SWE.RFID.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Manager.Interfaces
{
    public interface IInventoryManager
    {
        List<Inventory> ListInventoriesPaged(int pageNumber, int pageCount,string Token, out int TotalCount);

        bool Add(Inventory inventory, string Token);

        bool Update(Inventory inventory, string Token);

        Inventory Get(int Id, string Token);
       
    }
}
