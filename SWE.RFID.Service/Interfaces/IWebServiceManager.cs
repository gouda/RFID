using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.RFID.Manager.Interfaces
{
   public interface IWebServiceManager
    {
        string PostService(string URL, string postData, string accessToken, string[] routeParameters, bool needAuth = true);
        string GetService(string URL, string accessToken, bool needAuth = true);
    }
}
