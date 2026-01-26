using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReporteDeIncidenciasDESIMvc.Controllers
{
    public class HomeController : Controller
    {
        #region Views
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autenticacion()
        {
            return View();
        }
        #endregion

        #region Data Access

        #endregion
    }
}