using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Entities.Login
{
   public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<int> RolesId { get; set; }
        public int? LangId { get; set; }
    }
}
