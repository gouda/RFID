using SWE.RFID.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Manager.Interfaces
{
   public interface IAccountManager
    {
        User Login(string userName, string password);
    }
}
