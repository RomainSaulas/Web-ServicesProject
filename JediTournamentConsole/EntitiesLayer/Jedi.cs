using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Jedi : EntityObject
    {
        private Caracteristiques[] caracteristiques;
        private bool isSith;
        private string nom;

        public Caracteristiques[] Carac
        {
            get
            {
                return caracteristiques;
            }
            set
            {
                this.Carac = value;
            }
        }
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public bool IsSith
        {
            get
            {
                return isSith;
            }
            set
            {
                this.isSith = value;
            }
        }
        public Jedi(Caracteristiques[] caracteristiques,bool isSith,string nom,int id):base(id)
        {
            this.caracteristiques = caracteristiques;
            this.isSith = isSith;
            this.nom = nom;
        }

        public override string ToString()
        {
            return nom;
        }
    }
}
