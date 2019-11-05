using SWE.RFID.Entities.Login;
using SWE.RFID.Entities.StaticData;
using SWE.RFID.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SWE.RFID.Manager
{
    public class AccountManager : IAccountManager
    {
        private IWebServiceManager _webServiceManager;
        public JavaScriptSerializer jsSerializer { get; set; }
        public AccountManager(IWebServiceManager webServiceManager)
        {
            _webServiceManager = webServiceManager;
            jsSerializer = new JavaScriptSerializer();
        }

        public User Login(string userName, string password)
        {
            var user = new User { UserName = userName, Password = password };

            try
            {
                var result= _webServiceManager.PostService(StaticNames.LoginAPIUrl, jsSerializer.Serialize( user), "", new string[] { userName, password }, false);
                user = jsSerializer.Deserialize<User>(result);
                user.UserName = userName;
                user.Password = password;
            }
            catch (Exception ex)
            {

            }
            return user;

        }
    }
}
