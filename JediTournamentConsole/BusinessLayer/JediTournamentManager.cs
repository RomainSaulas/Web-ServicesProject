using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StubDataAccessLayer;
using EntitiesLayer;


namespace BusinessLayer
{
    public class JediTournamentManager
    {
        
        public IEnumerable<string> AfficheStade()
        {
            IEnumerable<string> stringStade;
            List<Stade> listStade;
            DalManager dal = new DalManager();
            listStade = dal.GetStade();
            stringStade = from stade in listStade select stade.Planete;
            return stringStade;
        }
        public IEnumerable<string> AfficheSith()
        {
            IEnumerable<string> stringSith;
            List<Jedi> listJedi;
            DalManager dal = new DalManager();
            listJedi = dal.GetJedi();
            stringSith = from sith in listJedi where sith.IsSith == true select sith.Nom;
            return stringSith;
        }
        public IEnumerable<string> AfficheJediFort()
        {
            IEnumerable<string> stringJediFort;
            List<Jedi> listJedi;
            DalManager dal = new DalManager();
            listJedi = dal.GetJedi();
            stringJediFort = from jedifort in listJedi 
                             where jedifort.Carac[0].Valeur >3  && jedifort.Carac[2].Valeur >50 
                             select jedifort.Nom;
            return stringJediFort;
        }
        public IEnumerable<string> AfficheMatchDuSiecle()
        {
            IEnumerable<string> stringMatchDuSiecle;
            List<Match> listMatch;
            DalManager dal = new DalManager();
            listMatch = dal.GetMatch();
            stringMatchDuSiecle = from match in listMatch
                                  where match.Stade.NbPlaces > 3 && match.Jedi1.IsSith == true && match.Jedi2.IsSith == true
                             select match.Stade.Planete;
            return stringMatchDuSiecle;
        }

        public bool CheckConnexionUser(string login,string password)
        {
            DalManager dal = new DalManager();
            Utilisateur user;
            user = dal.GetUtilisateurByLogin(login);

            return (user.Password == password);
        }

        public IEnumerable<string> ListJedi()
        {
            List<Jedi> listJedi;
            DalManager dal = new DalManager();
            listJedi = dal.GetJedi();
            IEnumerable<string> stringJedi;
            stringJedi = from jedi in listJedi select jedi.Nom;
            return stringJedi;
        }
        public IEnumerable<string> ListMatch()
        {
            List<Match> listMatch;
            DalManager dal = new DalManager();
            listMatch = dal.GetMatch();
            IEnumerable<string> stringMatch;
            stringMatch = from match in listMatch select match.Jedi1.Nom;
            return stringMatch;
        }
        public IEnumerable<string> ListStade()
        {
            List<Stade> listStade;
            DalManager dal = new DalManager();
            listStade = dal.GetStade();
            IEnumerable<string> stringStade;
            stringStade = from stade in listStade select stade.Planete;
            return stringStade;
        }
        public IEnumerable<string> ListCaracteristiques()
        {
            List<Caracteristiques> listCaracteristique;
            DalManager dal = new DalManager();
            listCaracteristique = dal.GetCaracteristiques();
            IEnumerable<string> stringCaracteristique;
            stringCaracteristique = from carac in listCaracteristique select carac.Nom;
            return stringCaracteristique;
        }

        public List<Jedi> ListJediInfo()
        {
            DalManager dal = new DalManager();

            return dal.GetJedi();
        }
        public List<Stade> ListStadeInfo()
        {
            DalManager dal = new DalManager();

            return dal.GetStade();
        }

        public List<Match> ListMatchInfo()
        {
            DalManager dal = new DalManager();

            return dal.GetMatch();
        }

        public List<ViewModelJedi> getAllJediModel()
        {
            List<ViewModelJedi> list = new List<ViewModelJedi>();
            var manager = new DalManager();
            var jedis = manager.GetJedi();
            foreach (Jedi jeds in jedis)
            {
                list.Add(new ViewModelJedi(jeds));
            }

            return list;
        }

        public List<ViewModelStade> getAllStadeModel()
        {
            List<ViewModelStade> list = new List<ViewModelStade>();
            var manager = new DalManager();
            var stades = manager.GetStade();
            foreach (Stade stads in stades)
            {
                list.Add(new ViewModelStade(stads));
            }

            return list;
        }

        public List<ViewModelMatch> getAllMatchModel()
        {
            List<ViewModelMatch> list = new List<ViewModelMatch>();
            var manager = new DalManager();
            var matches = manager.GetMatch();
      
            foreach (Match matchs in matches)
            {
                list.Add(new ViewModelMatch(matchs));
            }

            return list;
        }

      public void JouerAuto(Match m)
      {
         Random rnd = new Random();

         int r = rnd.Next(1, 100);

         float p = 0;
         float pj1 = 0, pj2 = 0;

         pj1 = (from sante in m.Jedi1.Carac where sante.Nom == "Sante" select sante.Valeur).FirstOrDefault() / ((from chance in m.Jedi2.Carac where chance.Nom == "Chance" select chance.Valeur).FirstOrDefault() + (from force in m.Jedi2.Carac where force.Nom == "Force" select force.Valeur).FirstOrDefault() - (from defense in m.Jedi1.Carac where defense.Nom == "Defense" select defense.Valeur).FirstOrDefault());
         pj2 = (from sante in m.Jedi2.Carac where sante.Nom == "Sante" select sante.Valeur).FirstOrDefault() / ((from chance in m.Jedi1.Carac where chance.Nom == "Chance" select chance.Valeur).FirstOrDefault() + (from force in m.Jedi1.Carac where force.Nom == "Force" select force.Valeur).FirstOrDefault() - (from defense in m.Jedi2.Carac where defense.Nom == "Defense" select defense.Valeur).FirstOrDefault());

         p = pj1 / (pj1 + pj2) * 100;

         if (r > p)
         {
            m.IdJediVainqueur = m.Jedi1.Id;
         }
         else
         {
            m.IdJediVainqueur = m.Jedi2.Id;
         }
      }

      public void launchHuitieme()
      {
         DalManager dalM = new DalManager();
         var listMatches = this.getAllMatchModel();
         List<ViewModelMatch> listHuitieme = new List<ViewModelMatch>();

         listHuitieme = (from match in listMatches
                         where match.PhaseTournoi == EPhaseTournoi.HuitiemeFinale
                         orderby match.Match.Id ascending
                         select match).ToList();

         foreach (ViewModelMatch match in listHuitieme)
         {
            JouerAuto(match.Match);
         }

         int i = 0;
         // 8 matches de huitième de final
         while (i < 8)
         {
            //creer les nouveaux matches
            // TODO:  faire que les id des matches s'incrémentent automatiquement
            // mettre dans la base de données tt ça
            //new Match(null, listVainqueurs[i], listVainqueurs[i + 1], EPhaseTournoi.DemiFinale, new Stade(), 9);
            i += 2;
         }

      }

      public void launchQuart()
      {
         DalManager dalM = new DalManager();
         var listMatches = this.getAllMatchModel();
         List<ViewModelMatch> listQuart = new List<ViewModelMatch>();
         List<Jedi> listVainqueurs = new List<Jedi>();

         listQuart = (from match in listMatches
                         where match.PhaseTournoi == EPhaseTournoi.QuartFinale
                      orderby match.Match.Id ascending
                      select match).ToList();

         foreach (ViewModelMatch match in listQuart)
         {
            JouerAuto(match.Match);
            listVainqueurs.Add((from jedis in dalM.GetJedi()
                               where jedis.Id == match.Match.IdJediVainqueur
                               select jedis).First());
         }

         int i = 0;
         // 4 matches de quart de final
         while(i < 4)
         {
            //creer les nouveaux matches
            // TODO:  faire que les id des matches s'incrémentent automatiquement
            // mettre dans la base de données tt ça
            //new Match(null, listVainqueurs[i], listVainqueurs[i + 1], EPhaseTournoi.DemiFinale, new Stade(), 9);
            i += 2;
         }

      }

      public void launchDemi()
      {
         DalManager dalM = new DalManager();
         var listMatches = this.getAllMatchModel();
         List<ViewModelMatch> listDemi = new List<ViewModelMatch>();

         listDemi = (from match in listMatches
                     where match.PhaseTournoi == EPhaseTournoi.DemiFinale
                     orderby match.Match.Id ascending
                      select match).ToList();

         foreach (ViewModelMatch match in listDemi)
         {
            JouerAuto(match.Match);
         }

         int i = 0;
         // 2 matches de quart de demi-final

         while (i < 2)
         {
            //creer les nouveaux matches
            // TODO:  faire que les id des matches s'incrémentent automatiquement
            // mettre dans la base de données tt ça
            //new Match(null, listVainqueurs[i], listVainqueurs[i + 1], EPhaseTournoi.DemiFinale, new Stade(), 9);

            i += 2;
         }

      }

      public void launchFinale()
      {
         DalManager dalM = new DalManager();
         var listMatches = this.getAllMatchModel();
         List<ViewModelMatch> listFinale = new List<ViewModelMatch>();

         listFinale = (from match in listMatches
                     where match.PhaseTournoi == EPhaseTournoi.Finale
                     select match).ToList();

         foreach (ViewModelMatch match in listFinale)
         {
            JouerAuto(match.Match);
         }

      }

   }
}
