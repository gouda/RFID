using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.StaticData
{
   public static class StaticNames
    {
        public static string LoginAPIUrl = "/api/user/login?email={0}&password={1}";
        public static string InventoryListAPIUrl = "/api/inventory/getpaged?currentpage={0}&pagesize={1}";
        public static string AddInventoryAPIUrl = "/api/inventory/add";
        public static string GetInventoryAPIUrl = "/api/inventory/Get?id={0}";
        public static string UpdateInventoryAPIUrl = "/api/inventory/edit";
        public static string EmployeeListAPIUrl = "/api/Employee/getpaged?currentpage={0}&pagesize={1}";
        public static string AddEmployeeAPIUrl = "/api/Employee/add";
        public static string GetEmployeeAPIUrl = "/api/Employee/Get?id={0}";
        public static string UpdateEmployeeAPIUrl = "/api/Employee/edit";



    }
}
