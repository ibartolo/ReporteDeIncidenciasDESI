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

                int tipoUsuario = 0;
                if (dto.Columns.Contains("TipoUsuario") && row["TipoUsuario"] != DBNull.Value)
                {
                    try { tipoUsuario = Convert.ToInt32(row["TipoUsuario"]); } catch { tipoUsuario = 0; }
                }

                string oauthProvider = dto.Columns.Contains("OAuthProvider") && row["OAuthProvider"] != DBNull.Value
                    ? row["OAuthProvider"].ToString() ?? string.Empty
                    : string.Empty;
                string oauthId = dto.Columns.Contains("OAuthId") && row["OAuthId"] != DBNull.Value
                    ? row["OAuthId"].ToString() ?? string.Empty
                    : string.Empty;

                DateTime fechaRegistro = DateTime.MinValue;
                if (dto.Columns.Contains("FechaRegistro") && row["FechaRegistro"] != DBNull.Value)
                {
                    try { fechaRegistro = Convert.ToDateTime(row["FechaRegistro"]); } catch { fechaRegistro = DateTime.MinValue; }
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

                // Crear nuevo UserObj por cada fila
                var item = UserObj.Create(id);
                if (item != null)
                {
                    // Llamadas a métodos existentes en UserObj para poblar todas las propiedades
                    item.SetInformationContact(email, tipoUsuario);
                    item.SetInformationSecurity(username, pass);
                    item.SetInformationUser(name, fechaRegistro);
                    item.SetOautInformation(oauthProvider, oauthId);
                    item.SetAuditInformationCreated(createdBy, createdDt);
                    item.SetAuditInformationUpdated(updatedBy, updatedDt);
                    item.SetStatus(estatus);

                    list.Add(item);
                }
            }

            return list;
        }
    }
}
