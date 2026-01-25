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
        private string _name;
        private string _lastname;

        public string UserName => _username;
        public string Password => _password;
        public string Email => _email;
        public string Name => _name;
        public string LastName => _lastname;

        private UserObj(long UserId)
        {
            Id = UserId;
            _username = string.Empty;
            _password = string.Empty;
            _email = string.Empty;
            _name = string.Empty;
            _lastname = string.Empty;
        }

        public static UserObj Create(long userId)
        {
            return new UserObj(userId);
        }

        public UserObj SetInformationContact(string email)
        {
            _email = email;
            return this;
        }

        public UserObj SetInformationSecurity(string username, string password)
        {
            _username = username;
            _password = password;
            return this;
        }

        public UserObj SetInformationUser(string name, string lastname)
        {
            _name = name;
            _lastname = lastname;
            return this;
        }
    }
}
