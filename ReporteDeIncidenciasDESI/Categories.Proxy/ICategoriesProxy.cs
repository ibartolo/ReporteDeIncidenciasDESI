using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Proxy
{
    public interface ICategoriesProxy
    {
        DataTable GetAllCategories();
        DataTable GetCategoryById(long id);
        DataTable GetCategoriesByCouncilor(long councilorId);
        DataTable GetCategoriesByCouncilorId(long councilorId);
    }
}
