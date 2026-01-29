using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Councilor.Proxy
{
    public interface ICouncilorProxy
    {
        DataTable GetAllCouncilors();
        DataTable GetCouncilorById(long id);
    }
}
