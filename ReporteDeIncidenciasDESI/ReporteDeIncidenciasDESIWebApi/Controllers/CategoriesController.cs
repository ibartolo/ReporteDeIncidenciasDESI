using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Categories.Application;
using Common.Domain;


namespace ReporteDeIncidenciasDESIWebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesApp _categoriesApp;
        public CategoriesController(ICategoriesApp categoriesApp)
        {
            _categoriesApp = categoriesApp;
        }

        [HttpGet]
        [Route("List")]
        public IHttpActionResult GetAllCategories()
        {
            var result = _categoriesApp.GetAllCategories(out var OperationResult);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("{long:id}")]
        //public IHttpActionResult GetCategoryById(long id)
        //{
        //    var result = _categoriesApp.GetCategoriesById(id, out var OperationResult);
        //    return Ok(result);
        //}
    }
}