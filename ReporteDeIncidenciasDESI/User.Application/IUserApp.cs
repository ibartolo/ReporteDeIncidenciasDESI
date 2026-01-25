using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;

namespace User.Application
{
    public interface IUserApp
    {
        List<UserObj> GetAllUsers(out OperationResult result);
        UserObj GetUserById(long id, out OperationResult result);
    }
}
