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
                                  where match.Stad.NbPlaces > 3 && match.Jedi1.IsSith == true && match.Jedi2.IsSith == true
                             select match.Stad.Planete;
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

    }
}
