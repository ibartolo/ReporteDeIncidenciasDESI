using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Councilor.Domain;

namespace Councilor.Proxy
{
    public class CouncilorMapp
    {
        public static List<CouncilorObj> MappCouncilor(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<CouncilorObj>();

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

                int order = 0;
                if (dto.Columns.Contains("Orden") && row["Orden"] != DBNull.Value)
                {
                    try { order = Convert.ToInt32(row["Orden"]); } catch (Exception ex) { order = 0; }
                }

                bool estatus = false;
                if (dto.Columns.Contains("Estatus") && row["Estatus"] != DBNull.Value)
                {
                    try { estatus = Convert.ToBoolean(row["Estatus"]); } catch { estatus = false; }
                }

                string createdBy = dto.Columns.Contains("CreatedBy") && row["CreatedBy"] != DBNull.Value
                    ? row["CreatedBy"].ToString() ?? string.Empty
                    : string.Empty;

                DateTime createdDt = DateTime.MinValue;
                if (dto.Columns.Contains("CreatedDt") && row["CreatedDt"] != DBNull.Value)
                {
                    try { createdDt = Convert.ToDateTime(row["CreatedDt"]); } catch { createdDt = DateTime.MinValue; }
                }

                string updatedBy = dto.Columns.Contains("UpdatedBy") && row["UpdatedBy"] != DBNull.Value
                    ? row["UpdatedBy"].ToString() ?? string.Empty
                    : string.Empty;

                DateTime updatedDt = DateTime.MinValue;
                if (dto.Columns.Contains("UpdatedDt") && row["UpdatedDt"] != DBNull.Value)
                {
                    try { updatedDt = Convert.ToDateTime(row["UpdatedDt"]); } catch { updatedDt = DateTime.MinValue; }
                }

                // Crear nuevo WorkAreaObj por cada fila
                var item = CouncilorObj.Create(id);
                if (item != null)
                {
                    //ingresar los demas campos faltantes
                    item.SetInformationAditional(name, description, order);
                    item.SetInformationCreated(createdBy, createdDt);
                    item.SetInformationUpdated(updatedBy, updatedDt);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
