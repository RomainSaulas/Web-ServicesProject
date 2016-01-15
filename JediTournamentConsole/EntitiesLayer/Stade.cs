using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
        private Caracteristiques[] caracteristiques;
        private int nbPlace;
        private string planete;

        public string Planete
        {
            get
            {
                return planete;
            }
        }
        public int NbPlaces
        {
            get
            {
                return nbPlace;
            }
        }
        public Stade(Caracteristiques[] caracteristiques, int nb,string plan,int identifiant):base(identifiant)
        {
            this.caracteristiques = caracteristiques;
            nbPlace = nb;
            planete = plan;
        }

    }
}
