using Categories.Domain;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Categories.Proxy
{
    public class CategoriesMapp
    {
        public static List<CategoriesObj> MappCategories(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<CategoriesObj>();

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

                long councilorId = 0;
                if (dto.Columns.Contains("RegiduriaId") && row["RegiduriaId"] != DBNull.Value)
                {
                    try { councilorId = Convert.ToInt64(row["RegiduriaId"]); } catch (Exception ex) { councilorId = 0; }
                }

                string name = dto.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value
                    ? row["Nombre"].ToString() ?? string.Empty
                    : string.Empty;


                // Crear nuevo WorkAreaObj por cada fila
                var item = CategoriesObj.Create(id);
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
