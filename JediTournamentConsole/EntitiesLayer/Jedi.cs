using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    [Serializable]
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
        }
        public string Nom
        {
            get
            {
                return nom;
            }
        }

        public bool IsSith
        {
            get
            {
                return isSith;
            }
        }
        public Jedi(Caracteristiques[] caracteristiques,bool isSith,string nom,int id):base(id)
        {
            this.caracteristiques = caracteristiques;
            this.isSith = isSith;
            this.nom = nom;
        }
    }
}
