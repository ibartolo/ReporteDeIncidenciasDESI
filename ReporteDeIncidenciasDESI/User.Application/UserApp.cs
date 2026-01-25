using Common.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;
using User.Proxy;

namespace User.Application
{
    public class UserApp : IUserApp
    {
        private readonly IUserProxy _proxy;

        public UserApp(IUserProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public List<UserObj> GetAllUsers(out OperationResult result)
        {
            result = new OperationResult { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<UserObj> response = new List<UserObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllUsers();
                response = UserMapp.MappUser(responseDT) ?? new List<UserObj>();
            }
            catch (Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener los usuarios." });
            }
            return response;
        }

        public UserObj GetUserById(long id, out OperationResult result)
        {
            result = new OperationResult { Successful = true };
            UserObj obj = null;
            try
            {
                DataTable responseDT = _proxy.GetUserById(id);
                obj = UserMapp.MappUser(responseDT).First();
            }
            catch (Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener el usuario." });
            }
            return obj;
        }
    }
}
