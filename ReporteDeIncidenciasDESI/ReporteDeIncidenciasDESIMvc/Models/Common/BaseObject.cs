using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteDeIncidenciasDESIMvc.Models.Common
{
    public class BaseObject
    {
        public int Id { get; set; }
        public bool Estatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDt { get; set; }

        public BaseObject()
        {
            Estatus = true;
            CreatedBy = string.Empty;
            CreatedDt = DateTime.UtcNow;
            UpdatedBy = string.Empty;
        }
    }
}