using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Categories.Domain;
using Common.Domain;
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

        public List<CategoriesObj> GetAllCategories(out OperationResult result)
        {
            result = new OperationResult() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<CategoriesObj> list = new List<CategoriesObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllCategories();
                list = CategoriesMapp.MappCategories(responseDT) ?? new List<CategoriesObj>();
            }catch(Exception ex)
            {
                result.Successful = false;
                if(result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener las categorias" });
            }
            return list;
        }

        public CategoriesObj GetCategoriesById(long id, out OperationResult result)
        {
            result = new OperationResult() { Successful = true };
            CategoriesObj obj = null;
            try
            {
                DataTable responseDT = _proxy.GetCategoryById(id);
                obj = CategoriesMapp.MappCategories(responseDT).First();
            }catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la categoria." });
            }
            return obj;
        }
    }
}
