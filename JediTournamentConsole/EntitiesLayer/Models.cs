using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace EntitiesLayer
{
    public class ViewModelJedi : ViewModelBase
    {
        private Jedi jedi;

      public Jedi Jedi
      {
         get { return jedi;  }
      }


        public int Force
        {
            get { return jedi.Carac.Where(c => c.Nom == "Force").First().Valeur; }
            set {
                jedi.Carac.Where(c => c.Nom == "Force").First().Valeur = value;
            }
        }

        public int Sante
        {
            get { return jedi.Carac.Where(c => c.Nom == "Sante").First().Valeur; }
            set {
                jedi.Carac.Where(c => c.Nom == "Sante").First().Valeur = value; }
        }

        public int Chance
        {
            get { return jedi.Carac.Where(c => c.Nom == "Chance").First().Valeur; }
            set { jedi.Carac.Where(c => c.Nom == "Chance").First().Valeur = value; }
        }

        public int Defense
        {
            get { return jedi.Carac.Where(c => c.Nom == "Defense").First().Valeur; }
            set {
                jedi.Carac.Where(c => c.Nom == "Defense").First().Valeur = value; 
            }
        }

        public bool Sith
        {
            get { return jedi.IsSith; }
            set { jedi.IsSith = value; }
        }

        public string Nom
        {
            get { return jedi.Nom; }
            set { jedi.Nom = value; }
        }

        public ViewModelJedi(Jedi jedi)
        {
            this.jedi = jedi;
            /*this.force = (from force in jedi.Carac
                         where force.Nom=="Force" 
                         select force.Valeur).FirstOrDefault();
            this.chance = (from chance in jedi.Carac
                          where chance.Nom == "Chance"
                          select chance.Valeur).FirstOrDefault();

            this.sante = (from sante in jedi.Carac
                          where sante.Nom == "Sante"
                          select sante.Valeur).FirstOrDefault();
            this.defense = (from def in jedi.Carac
                          where def.Nom == "Defense"
                          select def.Valeur).FirstOrDefault();

            this.sith = jedi.IsSith;
            this.nom = jedi.Nom;*/
      
        }
     }

    public class ViewModelMatch : ViewModelBase
    {
        private Match match;
      public Match Match
      {
         get { return match; }
      }
      public string Planete
        {
            get 
            { 
                return match.Stade.Planete; }
            set { match.Stade.Planete = value; }
        }

        public int NbPlaces
        {
            get { return match.Stade.NbPlaces; }
            set { match.Stade.NbPlaces = value; }
        }

        public Jedi Jedi1
        {
            get 
            { 
                return match.Jedi1; }
            set { match.Jedi1 = value; }
        }

        public Jedi Jedi2
        {
            get { return match.Jedi2; }
            set { match.Jedi2 = value; }
        }

        public EPhaseTournoi PhaseTournoi
        {
            get { return match.PhaseTournoi; }
            set { match.PhaseTournoi= value; }
        }
        public ViewModelMatch(Match match)
        {
            this.match = match;
            /*this.force = (from force in jedi.Carac
                          where force.Nom == "Force"
                          select force.Valeur).FirstOrDefault();
            this.chance = (from chance in jedi.Carac
                           where chance.Nom == "Chance"
                           select chance.Valeur).FirstOrDefault();

            this.sante = (from sante in jedi.Carac
                          where sante.Nom == "Sante"
                          select sante.Valeur).FirstOrDefault();
            this.defense = (from def in jedi.Carac
                            where def.Nom == "Defense"
                            select def.Valeur).FirstOrDefault();

            this.sith = jedi.IsSith;
            this.nom = jedi.Nom;*/

        }
    }
    public class ViewModelStade : ViewModelBase
    {
        private Stade stade;

      public Stade Stade
      {
         get { return stade; }
      }

      public int Force
        {
            get { return stade.Caracteristiques.Where(c => c.Nom == "Force").First().Valeur; }
            set
            {
                stade.Caracteristiques.Where(c => c.Nom == "Force").First().Valeur = value;
            }
        }

        public int Sante
        {
            get { return stade.Caracteristiques.Where(c => c.Nom == "Sante").First().Valeur; }
            set
            {
                stade.Caracteristiques.Where(c => c.Nom == "Sante").First().Valeur = value;

            }
        }

        public int Chance
        {
            get { return stade.Caracteristiques.Where(c => c.Nom == "Chance").First().Valeur; }
            set
            {
                stade.Caracteristiques.Where(c => c.Nom == "Chance").First().Valeur = value;
            }
        }

        public int Defense
        {
            get { return stade.Caracteristiques.Where(c => c.Nom == "Defense").First().Valeur; }
            set
            {
                stade.Caracteristiques.Where(c => c.Nom == "Defense").First().Valeur = value;
            }
        }

        public string Planete
        {
            get { return stade.Planete; }
            set { stade.Planete = value; }
        }

        public int NbPlaces
        {
            get { return stade.NbPlaces; }
            set { stade.NbPlaces = value; }
        }

        public ViewModelStade(Stade stade)
        {
            this.stade = stade;
            /*this.force = (from force in jedi.Carac
                          where force.Nom == "Force"
                          select force.Valeur).FirstOrDefault();
            this.chance = (from chance in jedi.Carac
                           where chance.Nom == "Chance"
                           select chance.Valeur).FirstOrDefault();

            this.sante = (from sante in jedi.Carac
                          where sante.Nom == "Sante"
                          select sante.Valeur).FirstOrDefault();
            this.defense = (from def in jedi.Carac
                            where def.Nom == "Defense"
                            select def.Valeur).FirstOrDefault();

            this.sith = jedi.IsSith;
            this.nom = jedi.Nom;*/

        }
    }
}
