using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain
{
    public class UserObj : Entity<long>
    {
        private string _username;
        private string _password;
        private string _email;
        private string _nombre;
        private int _tipoUsuario;
        private string _oAuthProvider;
        private string _oAuthId;
        private DateTime _fechaRegistro;
        private bool _estatus;
        private string _createdBy;
        private DateTime _createdDt;
        private string _updatedBy;
        private DateTime _updatedDt;


        public string UserName => _username;
        public string Password => _password;
        public string Email => _email;
        public string Nombre => _nombre;
        public int TipoUsuario => _tipoUsuario;
        public string OAuthProvider => _oAuthProvider;
        public string OAuthId => _oAuthId;
        public DateTime FechaRegistro => _fechaRegistro;
        public bool Estatus => _estatus;
        public string CreatedBy => _createdBy;
        public DateTime CreatedDt => _createdDt;
        public string UpdatedBy => _updatedBy;
        public DateTime UpdatedDt => _updatedDt;

        private UserObj(long UserId)
        {
            Id = UserId;
            _username = string.Empty;
            _password = string.Empty;
            _email = string.Empty;
            _nombre = string.Empty;
            _tipoUsuario = 0;
            _oAuthProvider = string.Empty;
            _oAuthId = string.Empty;
            _fechaRegistro = DateTime.MinValue;
            _estatus = false;
            _createdBy = string.Empty;
            _createdDt = DateTime.MinValue;
            _updatedBy = string.Empty;
            _updatedDt = DateTime.MinValue;
        }
        public static UserObj Create(long userId)
        {
            return new UserObj(userId);
        }
        public UserObj SetInformationContact(string email, int tipoUsuario)
        {
            _email = email;
            _tipoUsuario = tipoUsuario;
            return this;
        }
        public UserObj SetInformationSecurity(string username, string password)
        {
            _username = username;
            _password = password;
            return this;
        }
        public UserObj SetInformationUser(string nombre, DateTime fechaRegistro)
        {
            _nombre = nombre;
            _fechaRegistro = fechaRegistro;

            return this;
        }
        public UserObj SetOautInformation(string oauthProvider, string oauthId)
        {
            _oAuthProvider = oauthProvider;
            _oAuthId = oauthId;

            return this;
        }
        public UserObj SetAuditInformationCreated(string createdBy, DateTime createdDt)
        {
            _createdBy = createdBy;
            _createdDt = createdDt;
            return this;
        }

        public UserObj SetAuditInformationUpdated(string updatedBy, DateTime updatedDt)
        {
            _updatedBy = updatedBy;
            _updatedDt = updatedDt;
            return this;
        }
        public UserObj SetStatus(bool estatus)
        {
            _estatus = estatus;
            return this;
        }
    }
}
