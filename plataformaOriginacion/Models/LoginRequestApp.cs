using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class LoginRequestApp
    {
        public string username { get; set; }
        public string password { get; set; }

        public LoginRequestApp(string user, string password)
        {
            this.username = user;
            this.password = password;
        }
    }
}
