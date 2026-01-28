using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CounciliorOffice.Application;
using CounciliorOffice.Domain;
using CounciliorOffice.Messages;
using Common.Domain;


namespace ReporteDeIncidenciasDESIWebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/CounciliorOffice")]
    public class CounciliorOfficeController : ApiController
    {
        private readonly ICounciliorOfficeApp _counciliorApp;

        public CounciliorOfficeController(ICounciliorOfficeApp counciliorApp)
        {
            _counciliorApp = counciliorApp;
        }

        [HttpGet]
        public CouncilorOfficeObjListResponse GetAllCounciliors()
        {
            CouncilorOfficeObjListResponse list = new CouncilorOfficeObjListResponse();
            List<CouncilorOfficeObj> list = _app.GetAllCounciliors(out OperationResult result);
            list.councilors = list;
            list.result = result;
            return list;
        }

        [HttpGet]
        public CouncilorOfficeObjResponse GetCouncilorById(long id)
        {
            CouncilorOfficeObjResponse response = new CouncilorOfficeObjResponse();
            CategoriesObj obj = _categoryApp.GetCategoriesById(id, out OperationResult result);
            response.councilor = obj;
            response.result = result;
            return response;
        }
    }
}