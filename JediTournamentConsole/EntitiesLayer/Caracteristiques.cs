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

        public EDefCaracteristique Definition
        {
            get
            {
                return definition;
            }
            set
            {
                definition = value;
            }
        }

        public ETypeCaracteristique Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

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
            set
            {
                nom = value;
            }
        }


        public Caracteristiques(EDefCaracteristique definition, string nom, ETypeCaracteristique type, int valeur, int id) : base(id)
        {
            this.definition = definition;
            this.nom = nom;
            this.type = type;
            this.valeur = valeur;
        }

        public Caracteristiques() : base()
        {
        }
    }
    }
}
