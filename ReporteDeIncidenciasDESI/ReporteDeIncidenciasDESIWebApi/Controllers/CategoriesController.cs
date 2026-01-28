using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Categories.Application;
using Categories.Domain;
using Common.Domain;


namespace ReporteDeIncidenciasDESIWebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesApp _categoryApp;
        public CategoriesController(ICategoriesApp categoriesApp)
        {
            _categoryApp = categoriesApp;
        }

        [HttpGet]
        public CategoriesObjListResponse GetAllCategories()
        {
            CategoriesObjListResponse list = new CategoriesObjListResponse();
            List<CategoriesObj> list = _app.GetAllCategories(out OperationResult result);
            list.categories = list;
            list.result = result;
            return list;
        }

        [HttpGet]
        public CategoriesObjResponse GetCategoriesById(long id)
        {
            CategoriesObjResponse response = new CategoriesObjResponse();
            CategoriesObj obj = _categoryApp.GetCategoriesById(id, out OperationResult result);
            response.category = obj;
            response.result = result;
            return response;
        }
    }
}