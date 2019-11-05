using SWE.RFID.Entities.Employee;
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
    public class EmployeeManager : IEmployeeManager
    {
        private IWebServiceManager _webServiceManager;
        public JavaScriptSerializer jsSerializer { get; set; }
        public EmployeeManager(IWebServiceManager webServiceManager)
        {
            _webServiceManager = webServiceManager;
            jsSerializer = new JavaScriptSerializer();
        }


        public List<Employee> ListEmployeesPaged(int pageNumber, int pageCount, string Token, out int TotalCount)
        {
            try
            {


                EmployeeListVM inventories = jsSerializer.Deserialize<EmployeeListVM>(_webServiceManager.PostService(StaticNames.EmployeeListAPIUrl, jsSerializer.Serialize(new Employee()), Token, new string[] { pageNumber.ToString(), pageCount.ToString() }, true));

                TotalCount = inventories.Pager.TotalItems;
                return inventories.Value;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool Add(Employee Employee, string Token)
        {
            try
            {
                _webServiceManager.PostService(StaticNames.AddEmployeeAPIUrl, jsSerializer.Serialize(Employee), Token, new string[] { }, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Employee Get(int Id, string Token)
        {
            try
            {
                var serviceReturn = _webServiceManager.GetService(string.Format(StaticNames.GetEmployeeAPIUrl, Id), Token, true);
                var Employee = jsSerializer.Deserialize<EmployeeServiceVM>(serviceReturn);
                return Employee.Value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Employee Employee, string Token)
        {
            try
            {
                _webServiceManager.PostService(StaticNames.UpdateEmployeeAPIUrl, jsSerializer.Serialize(Employee), Token, new string[] { }, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

     
    }
}
