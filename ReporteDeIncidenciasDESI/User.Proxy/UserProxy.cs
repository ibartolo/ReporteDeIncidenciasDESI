using SqlProxy;
using System.Data;

namespace User.Proxy
{
    // Ahora implementa IUserProxy
    public class UserProxy : DbWrapper, IUserProxy
    {
        public UserProxy()
        {
            // Inicialización de DbWrapper si es necesaria
        }
        public DataTable GetAllUsers()
        {
            DataTable dt = GetObject("GetAllUsuario", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable GetUserById(long id)
        {
            return new DataTable();
        }
    }
}
