
using SWE.RFID.Attributes;
using SWE.RFID.Entities.Inventory;
using SWE.RFID.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWE.RFID.Controllers
{
    [CustomAuthorize]
    public class InventoryController : Controller
    {
        private IInventoryManager _inventoryManager;
        public InventoryController(IInventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }
        // GET: Inventory
        public ActionResult Index(int Id=0, string MSG = "",string msgType="")
        {
            ViewBag.MSG = MSG;
            ViewBag.SCSS = MSG;
            ViewBag.MSGType = msgType;
            var inventory = new Inventory();
            if (Id != 0)
            {
                inventory= _inventoryManager.Get(Id, Session["accessToken"].ToString());
            }
         
            return View(inventory);
        }
        [HttpPost]
        public JsonResult Index(int RecordsStart = 0, int PageSize = 0, string jtSorting = null)
        {
            try
            {
                //Get data from database
                int totalCount = 0;
                var inventories = _inventoryManager.ListInventoriesPaged((RecordsStart/ PageSize) + 1, PageSize, Session["accessToken"].ToString(), out totalCount);



                //Return result to jTable
                return Json(new { Result = "OK", Records = inventories, TotalRecordCount = totalCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Add(Inventory inventory)
        {
            var result = false;
            if (inventory.Id != 0)
            {
                result = _inventoryManager.Update(inventory, Session["accessToken"].ToString());
            }
            else
            {
                result = _inventoryManager.Add(inventory, Session["accessToken"].ToString());
            }
            
            if (result == true)
            {
              return  RedirectToAction("Index",new {MSG= inventory.Id == 0 ?"Added Successfully": "Update Successfully", msgType ="success"});
            }
            else
            {
                return RedirectToAction("Index", new { MSG = "Failed To Add", msgType = "fail" });

            }

        }
     
    }
}