using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SqlProxy;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Councilor.Proxy
{
    public class CouncilorProxy : DbWrapper, ICouncilorProxy
    {
        public DataTable GetAllCouncilors()
        {
            var r = GetObject("GetAllRegiduria", CommandType.StoredProcedure);
            return r;
        }

        public DataTable GetCouncilorById(long id)
        {
            var parameter = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            var r = GetObject("GetRegiduriaById", CommandType.StoredProcedure, parameter);
            return r;
        }
    }
}
