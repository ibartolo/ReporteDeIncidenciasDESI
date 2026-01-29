using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Councilor.Application;
using Councilor.Domain;
using Common.Domain;


namespace ReporteDeIncidenciasDESIWebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Councilor")]
    public class CounciliorOfficeController : ApiController
    {
        private readonly ICouncilorApp _councilorApp;

        public CounciliorOfficeController(ICouncilorApp councilorApp)
        {
            _councilorApp = councilorApp;
        }

        [HttpGet]
        [Route("List")]
        public IHttpActionResult GetAllCouncilors()
        {
            var r = _councilorApp.GetAllCouncilors(out var OperationResult);
            return Ok(r);
        }

        //[HttpGet]
        //[Route("{long:id}")]
        //public IHttpActionResult GetCouncilorById(long id)
        //{
        //    var r = _councilorApp.GetCouncilorById(id, out var OperationResult);
        //    return Ok(r);
        //}
    }
}