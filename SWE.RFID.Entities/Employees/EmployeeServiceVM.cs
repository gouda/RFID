using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.Employee
{
   public class EmployeeServiceVM
    {
        public Employee Value { get; set; }
        public List<string> Errors { get; set; }
    }
}
