using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Categories.Domain;

namespace Categories.Messages
{
    public class CategoriesMessage
    {
    }

    public class CategoriesObjListResponse()
    {
        public List<CategoriesObj> categories { get; set; }
        public OperationResult result { get; set; }
    }

    public class CategoriesObjResponse()
    {
        public CategoriesObj category { get; set; }
        public OperationResult result { get; set; }
    }
}
