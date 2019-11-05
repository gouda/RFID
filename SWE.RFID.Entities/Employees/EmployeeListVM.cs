using SWE.RFID.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.Employee
{
    public class EmployeeListVM
    {
        public Pager Pager { get; set; }
        public List<Employee> Value { get; set; }
        public List<string> Errors { get; set; }

    }
}
