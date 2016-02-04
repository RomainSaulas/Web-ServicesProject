using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Collections.ObjectModel;

namespace EntitiesLayer
{
    public class ViewModelEdit : ViewModelBase
    {

        //Model encapsulé dans le ViewModel
        private ObservableCollection<ViewModelJedi> _jedis;
          
        public ObservableCollection<ViewModelJedi> Jedis
        {
            get { return _jedis; }
            private set
            {
                _jedis = value;
                OnPropertyChanged("Jedis");
            }
        }

        private ViewModelJedi _selectedItem;

        public ViewModelJedi SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Console.WriteLine("garné!");
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ViewModelEdit(List<EntitiesLayer.Jedi> jedisModel)
        {
            _jedis = new ObservableCollection<ViewModelJedi>();
            foreach (EntitiesLayer.Jedi jed in jedisModel)
            {
                _jedis.Add(new ViewModelJedi(jed));
            }
        }
    }


    public class ViewModelJedi : ViewModelBase
    {
        private Jedi _jedi;

        public ViewModelJedi(Jedi jediModel)
        {
            _jedi = jediModel;
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

        public Jedi Jedi
        {
            get { return _jedi; }
            set { _jedi = value; }
        }

        public string Nom
        {
            get { return _jedi.Nom; }
            set
            {
                if (value == _jedi.Nom) return;
                _jedi.Nom = value;
                base.OnPropertyChanged("Nom");
            }
        }

        public int Force
        {
            get {
                Console.WriteLine("Force");
                return _jedi.Carac.Where(c => c.Nom == "Force").First().Valeur; }
            set {
                if (value == _jedi.Carac.Where(c => c.Nom == "Force").First().Valeur) return;
                _jedi.Carac.Where(c => c.Nom == "Force").First().Valeur = value;
                base.OnPropertyChanged("Force");
            }
        }

        public int Sante
        {
            get { return _jedi.Carac.Where(c => c.Nom == "Sante").First().Valeur; }
            set
            {
                if (value == _jedi.Carac.Where(c => c.Nom == "Sante").First().Valeur) return;
                _jedi.Carac.Where(c => c.Nom == "Sante").First().Valeur = value;
                base.OnPropertyChanged("Sante");
            }
        }

        public int Chance
        {
            get { return _jedi.Carac.Where(c => c.Nom == "Chance").First().Valeur; }
            set {
                if (value == _jedi.Carac.Where(c => c.Nom == "Chance").First().Valeur) return;
                _jedi.Carac.Where(c => c.Nom == "Chance").First().Valeur = value;
                base.OnPropertyChanged("Chance");             
            }
        }

        public int Defense
        {
            get { return _jedi.Carac.Where(c => c.Nom == "Defense").First().Valeur; }
            set {
                if (value == _jedi.Carac.Where(c => c.Nom == "Defense").First().Valeur) return;
                _jedi.Carac.Where(c => c.Nom == "Defense").First().Valeur = value;
                base.OnPropertyChanged("Defense");
                
            }
        }

        public bool Sith
        {
            get { return _jedi.IsSith; }
            set {
                if (value == _jedi.IsSith) return;
                _jedi.IsSith = value;
                base.OnPropertyChanged("Sith");
            }
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

        public int Id
        {
            get { return match.Id; }
            set { match.Id = value; }
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
