using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteDeIncidenciasDESIMvc.Models.Autentication
{
    public class TokenCookie
    {
        public Token Token { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
    }
}