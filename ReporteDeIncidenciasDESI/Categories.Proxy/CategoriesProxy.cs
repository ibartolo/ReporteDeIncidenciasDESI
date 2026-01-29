using SqlProxy;
using System.Data;
using System.Data.SqlClient;

namespace Categories.Proxy
{
    public class CategoriesProxy : DbWrapper, ICategoriesProxy
    {
        public DataTable GetAllCategories()
        {
            var r = GetObject("GetAllCategoria", CommandType.StoredProcedure);
            return r;
        }

        public DataTable GetCategoryById(long id)
        {
            var parameter = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            var r = GetObject("GetCategoriaById", CommandType.StoredProcedure, parameter);
            return r;
        }

        public DataTable GetCategoriesByCouncilor(long councilorId) 
        {
            var parameter = new SqlParameter[]
            {
                new SqlParameter("@RegiduriaId", councilorId)
            };

            var r = GetObject("GetCategoriasByRegiduria", CommandType.StoredProcedure, parameter);
            return r;
        }

        public DataTable GetCategoriesByCouncilorId(long councilorId)
        {
            var parameter = new SqlParameter[]
            {
                new SqlParameter("@RegiduriaId", councilorId)
            };

            var r = GetObject("GetCategoriasByRegiduriaId", CommandType.StoredProcedure, parameter);
            return r;
        }
    }
}