using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Categories.Application;
using Categories.Messages;
using Categories.Domain;
using Categories.Proxy;


namespace Categories.Application
{
    public class CategoriesApp : ICategoriesApp
    {
        private readonly ICategoriesProxy _proxy;

        public CategoriesApp(ICategoriesProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        //realizar logica 
        public List<CategoriesObj> GetAllCategories()
        {
            
        }
    }
}
