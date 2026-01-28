using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProxy;
using Microsoft.Data.SqlClient;
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
            var parameter = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var r = GetObject("GetCategoriaById", CommandType.StoredProcedure, parameter);
            return r;
        }
    }
}
