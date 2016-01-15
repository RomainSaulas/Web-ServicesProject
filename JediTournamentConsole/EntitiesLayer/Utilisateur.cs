using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur : EntityObject
    {
        private string nom;
        private string prenom;
        private string login;
        private string password;

        public string Login
        {
            get
            {
                return login;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
        }

        public Utilisateur(string nom,string prenom,string login,string password,int id):base(id)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.password = password;
        }

    }
}
