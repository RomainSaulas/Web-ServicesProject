using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{

    
    public class DalManager
    {
        private List<Jedi> listJedi = new List<Jedi>();
        private List<Match> listMatch = new List<Match>();
        private List<Stade> listStade = new List<Stade>();
        private List<Caracteristiques> listCaracteristiques = new List<Caracteristiques>();
        private List<Utilisateur> listUtilisateur = new List<Utilisateur>(); 
       
        public DalManager()
        {
           
            Caracteristiques Force1 = new Caracteristiques(EDefCaracteristique.Force,"Force",ETypeCaracteristique.Jedi,666,10);
            Caracteristiques Force2= new Caracteristiques(EDefCaracteristique.Force,"Force",ETypeCaracteristique.Jedi,42,11);
            Caracteristiques Defense1= new Caracteristiques(EDefCaracteristique.Defense,"Defense",ETypeCaracteristique.Jedi,666,12);
            Caracteristiques Defense2= new Caracteristiques(EDefCaracteristique.Defense,"Defense",ETypeCaracteristique.Jedi,42,13);
            Caracteristiques Vie1= new Caracteristiques(EDefCaracteristique.Sante,"Sante",ETypeCaracteristique.Jedi,666,14);
            Caracteristiques Vie2= new Caracteristiques(EDefCaracteristique.Sante,"Sante",ETypeCaracteristique.Jedi,42,15);
            Caracteristiques Chance1= new Caracteristiques(EDefCaracteristique.Chance,"Chance",ETypeCaracteristique.Jedi,666,16);
            Caracteristiques Chance2= new Caracteristiques(EDefCaracteristique.Chance,"Chance",ETypeCaracteristique.Jedi,42,17);
            Caracteristiques ForceStade= new Caracteristiques(EDefCaracteristique.Force,"Force",ETypeCaracteristique.Stade,666,18);
            Caracteristiques DefenseStade= new Caracteristiques(EDefCaracteristique.Defense,"Defense",ETypeCaracteristique.Stade,6666,19);
            Caracteristiques VieStade= new Caracteristiques(EDefCaracteristique.Sante,"Sante",ETypeCaracteristique.Stade,666,20);
            Caracteristiques ChanceStade= new Caracteristiques(EDefCaracteristique.Chance,"Chance",ETypeCaracteristique.Stade,666,21);
            Caracteristiques[] Un = {Force1,Defense1,Vie1,Chance1};
            Caracteristiques[] Deux = {Force2,Defense2,Vie2,Chance2};
            Caracteristiques[] Stade = {ForceStade,DefenseStade,VieStade,ChanceStade};

            Utilisateur Romain = new Utilisateur("Saulas", "Romain", "rosaulas", "saluasor",12314);
            Utilisateur Simon = new Utilisateur("Dujardin", "Simon", "admin", "admin", 12314);

            Jedi Yoda = new Jedi(Un,false,"Yoda",1);
            Jedi Palpatine = new Jedi(Deux,true,"Palpatine",2);
            Jedi JeanPierre = new Jedi(Un, true, "Jean-Pierre", 5);

            Stade Tatouine = new Stade(Stade,50000,"Tatouine",3);

            Match Versus1 = new Match(1,Yoda,Palpatine,EPhaseTournoi.Finale,Tatouine,4);
            Match Versus2 = new Match(5, JeanPierre, Palpatine, EPhaseTournoi.Finale, Tatouine, 4);

            listUtilisateur.Add(Romain);
            listUtilisateur.Add(Simon);
            
            listJedi.Add(Yoda);
            listJedi.Add(JeanPierre);
            listJedi.Add(Palpatine);
           
            listMatch.Add(Versus1);
            listMatch.Add(Versus2);
           
            listStade.Add(Tatouine);
            
            listCaracteristiques.Add(Force1);
            listCaracteristiques.Add(Force2);
            listCaracteristiques.Add(ForceStade);
            listCaracteristiques.Add(Defense1);
            listCaracteristiques.Add(Defense2);
            listCaracteristiques.Add(DefenseStade);
            listCaracteristiques.Add(Vie1);
            listCaracteristiques.Add(Vie2);
            listCaracteristiques.Add(VieStade);
            listCaracteristiques.Add(Chance1 );
            listCaracteristiques.Add(Chance2);
            listCaracteristiques.Add(ChanceStade);

        }
        
        public List<Jedi> GetJedi()
        {
            return listJedi;
        }
        public List<Match> GetMatch()
        {
            return listMatch;
        }
        public List<Stade> GetStade() 
        {
            return listStade;
        }
        public List<Caracteristiques>   GetCaracteristiques()
        {
            return listCaracteristiques;
        }

        public Utilisateur GetUtilisateurByLogin(string log)
        {
            return listUtilisateur.Find(x => x.Login==log);
        }
    }
}
