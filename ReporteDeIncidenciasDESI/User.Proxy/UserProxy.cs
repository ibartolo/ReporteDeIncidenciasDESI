using SqlProxy;
using System.Data;
using System.Data.SqlClient;

namespace User.Proxy
{
    // Ahora implementa IUserProxy
    public class UserProxy : DbWrapper, IUserProxy
    {
        public DataTable GetAllUsers()
        {
            DataTable dt = GetObject("GetAllUsuario", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable GetUserById(long id)
        {
            var sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            DataTable dt = GetObject("GetUsuarioById", CommandType.StoredProcedure, sqlParameters);
            return dt;
        }
    }
}
