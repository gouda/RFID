using SWE.RFID.Entities.Inventory;
using SWE.RFID.Entities.StaticData;
using SWE.RFID.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SWE.RFID.Manager.Services
{
    public class InventoryManager : IInventoryManager
    {
        private IWebServiceManager _webServiceManager;
        public JavaScriptSerializer jsSerializer { get; set; }
        public InventoryManager(IWebServiceManager webServiceManager)
        {
            _webServiceManager = webServiceManager;
            jsSerializer = new JavaScriptSerializer();
        }


        public List<Inventory> ListInventoriesPaged(int pageNumber, int pageCount, string Token, out int TotalCount)
        {
            try
            {


                InventoryListVM inventories = jsSerializer.Deserialize<InventoryListVM>(_webServiceManager.PostService(StaticNames.InventoryListAPIUrl, jsSerializer.Serialize(new Inventory()), Token, new string[] { pageNumber.ToString(), pageCount.ToString() }, true));

                TotalCount = inventories.Pager.TotalItems;
                return inventories.Value;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool Add(Inventory inventory, string Token)
        {
            try
            {
                _webServiceManager.PostService(StaticNames.AddInventoryAPIUrl, jsSerializer.Serialize(inventory), Token, new string[] { }, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Inventory Get(int Id, string Token)
        {
            try
            {
                var serviceReturn = _webServiceManager.GetService(string.Format(StaticNames.GetInventoryAPIUrl, Id), Token, true);
                var inventory = jsSerializer.Deserialize<InventoryServiceVM>(serviceReturn);
                return inventory.Value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Inventory inventory, string Token)
        {
            try
            {
                _webServiceManager.PostService(StaticNames.UpdateInventoryAPIUrl, jsSerializer.Serialize(inventory), Token, new string[] { }, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
