using CouncilorOffice.Domain;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FiscalData.Proxy
{
    public class CouncilorOfficeMapp
    {
        public static List<CouncilorOfficeObj> MappFiscalData(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<CouncilorOfficeObj>();

            // Si no tiene filas regresamos lista vacía
            if (dto.Rows.Count == 0)
                return list;

            foreach (DataRow row in dto.Rows)
            {
                // Obtener valores de forma segura (si la columna no existe o es DBNull, usar valores por defecto)
                long id = 0;
                if (dto.Columns.Contains("Id") && row["Id"] != DBNull.Value)
                {
                    try { id = Convert.ToInt64(row["Id"]); } catch { id = 0; }
                }

                string name = dto.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value
                    ? row["Nombre"].ToString() ?? string.Empty
                    : string.Empty;

                string description = dto.Columns.Contains("Descripcion") && row["Descripcion"] != DBNull.Value
                    ? row["Descripcion"].ToString() ?? string.Empty
                    : string.Empty;

                long order = 0;
                if (dto.Columns.Contains("Orden") && row["Orden"] != DBNull.Value)
                {
                    try { order = Convert.ToInt64(row["Orden"]); } catch { order = 0; }
                }

                // Crear nuevo WorkAreaObj por cada fila
                var item = CouncilorOfficeObj.Create(id);
                if (item != null)
                {
                    //ingresar los demas campos faltantes
                    list.Add(item);
                }
            }

            return list;
        }
    }
}