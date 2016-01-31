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

        public Caracteristiques[] Caracteristiques
        {
            get { return caracteristiques; }
            set { caracteristiques = value; }
        }
        private int nbPlace;
        private string planete;

        public string Planete
        {
            get
            {
                return planete;
            }
            set {
                planete = value;
            }
        }
        public int NbPlaces
        {
            get
            {
                return nbPlace;
            }
             set
            {
                nbPlace = value;
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
