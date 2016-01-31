using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Caracteristiques : EntityObject
    {
        private EDefCaracteristique definition;
        private string nom;
        private ETypeCaracteristique type;
        private int valeur;

        public int Valeur
        {
            get
            {
                return valeur;
            }
            set
            {
                valeur = value;

            }
        }
        public string Nom
        {
            get
            {
                return nom;
            }
        }
        public Caracteristiques(EDefCaracteristique definition,string nom,ETypeCaracteristique type,int valeur ,int id):base(id)
        {
            this.definition = definition;
            this.nom = nom;
            this.type = type;
            this.valeur = valeur;
        }
    }
}
