using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;

namespace User.Proxy
{
    public class UserMapp
    {
        public static List<UserObj> MappUser(DataTable dto)
        {
            // Si dto es null lanzamos excepción indicando que no fue posible obtener valores
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "No fue posible obtener valores desde el DataTable.");

            var list = new List<UserObj>();

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

                string username = dto.Columns.Contains("UserName") && row["UserName"] != DBNull.Value
                    ? row["UserName"].ToString() ?? string.Empty
                    : string.Empty;
                string pass = dto.Columns.Contains("Pass") && row["Pass"] != DBNull.Value
                    ? row["Pass"].ToString() ?? string.Empty
                    : string.Empty;
                string email = dto.Columns.Contains("Email") && row["Email"] != DBNull.Value
                    ? row["Email"].ToString() ?? string.Empty
                    : string.Empty;
                string name = dto.Columns.Contains("Nombre") && row["Nombre"] != DBNull.Value
                    ? row["Nombre"].ToString() ?? string.Empty
                    : string.Empty;
                string lastname = dto.Columns.Contains("Apellido") && row["Apellido"] != DBNull.Value
                    ? row["Apellido"].ToString() ?? string.Empty
                    : string.Empty;



                // Crear nuevo WorkAreaObj por cada fila
                var item = UserObj.Create(id);
                if (item != null)
                {
                    item.SetInformationContact(email);
                    item.SetInformationSecurity(username, pass);
                    item.SetInformationUser(name, lastname);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
