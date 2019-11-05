using SWE.RFID.Entities.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Manager.Interfaces
{
    public interface IEmployeeManager
    {
        List<Employee> ListEmployeesPaged(int pageNumber, int pageCount,string Token, out int TotalCount);

        bool Add(Employee Employee, string Token);

        bool Update(Employee Employee, string Token);

        Employee Get(int Id, string Token);
       
    }
}
