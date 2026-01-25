using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using User.Application;
using Common.Domain;
using User.Proxy;

namespace ReporteDeIncidenciasDESIWebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Autentication")]
    public class AutenticationController : ApiController
    {
        private readonly IUserApp _userApp;
        public AutenticationController(IUserApp userApp)
        {
            _userApp = userApp;
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAllusers()
        {
            var result = _userApp.GetAllUsers(out var operationResult);
            return Ok(result);
        }
    }
}
