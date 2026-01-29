using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categories.Domain;
using Common.Domain;

namespace Categories.Application
{
    public interface ICategoriesApp
    {
        List<CategoriesObj> GetAllCategories(out OperationResult result);
        CategoriesObj GetCategoriesById(long id, out OperationResult result);
    }
}
