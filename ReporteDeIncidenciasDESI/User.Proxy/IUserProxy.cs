using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Proxy
{
    public interface IUserProxy
    {
        DataTable GetAllUsers();
        DataTable GetUserById(long id);
    }
}
