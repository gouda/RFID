
using SWE.RFID.Attributes;
using SWE.RFID.Entities.Employee;
using SWE.RFID.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWE.RFID.Controllers
{
    [CustomAuthorize]
    public class EmployeesController : Controller
    {
        private IEmployeeManager _EmployeeManager;
        public EmployeesController(IEmployeeManager EmployeeManager)
        {
            _EmployeeManager = EmployeeManager;
        }
        // GET: Employee
        public ActionResult Index(int Id=0, string MSG = "",string msgType="")
        {
            ViewBag.MSG = MSG;
            ViewBag.SCSS = MSG;
            ViewBag.MSGType = msgType;
            var Employee = new Employee();
            if (Id != 0)
            {
                Employee= _EmployeeManager.Get(Id, Session["accessToken"].ToString());
            }
         
            return View(Employee);
        }
        [HttpPost]
        public JsonResult Index(int RecordsStart = 0, int PageSize = 0, string jtSorting = null)
        {
            try
            {
                //Get data from database
                int totalCount = 0;
                var inventories = _EmployeeManager.ListEmployeesPaged((RecordsStart/ PageSize) + 1, PageSize, Session["accessToken"].ToString(), out totalCount);



                //Return result to jTable
                return Json(new { Result = "OK", Records = inventories, TotalRecordCount = totalCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult Add(Employee Employee)
        {
            var result = false;
            if (Employee.Id != 0)
            {
                result = _EmployeeManager.Update(Employee, Session["accessToken"].ToString());
            }
            else
            {
                result = _EmployeeManager.Add(Employee, Session["accessToken"].ToString());
            }
            
            if (result == true)
            {
              return  RedirectToAction("Index",new {MSG= Employee.Id == 0 ?"Added Successfully": "Update Successfully", msgType ="success"});
            }
            else
            {
                return RedirectToAction("Index", new { MSG = "Failed To Add", msgType = "fail" });

            }

        }
     
    }
}