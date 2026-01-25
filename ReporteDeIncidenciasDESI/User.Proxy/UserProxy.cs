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

        // Implementaciones mínimas; reemplaza por llamadas reales a la BD
        public DataTable GetAllUsers()
        {
            return new DataTable();
        }

        public DataTable GetUserById(long id)
        {
            return new DataTable();
        }
    }
}
