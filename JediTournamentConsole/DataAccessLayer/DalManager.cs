using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.IO;
using DataAccessLayer;

namespace DataAccessLayer
{
    public class DalManager
    {
        private static DalManager _instance;
        private static readonly object padlock = new object();
        IBridge bado;

        public static DalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DalManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private DalManager()
        {
            string server = "bktsql.database.windows.net";

            string dataBaseName = "SQL";

            string UserName = "Groupe10";

            string pwd = "Tour1234";


            String ConnectionString = "Data Source=" + server + ";Initial Catalog=" + dataBaseName + ";User ID=" + UserName + ";Password=" + pwd;
            // Requête SQL

            bado = new MySql(ConnectionString);
        }

        public List<Jedi> GetJedi()
        {
            return bado.getJedis();
        }
        public List<Stade> GetStade()
        {
            return bado.getStades();
        }
        public List<Match> GetMatch()
        {
            return bado.getMatches();
        }
        public List<Tournoi> GetTournoi()
        {
            return bado.getTournois();
        }
        public List<Caracteristiques> GetCaracteristiques()
        {
            return bado.getCaracteristiques();
        }
        public void ModifierJedis(Jedi jedi)
        {
            bado.updateJedis(jedi);
        }
        public void ModifierStades(Stade stade)
        {
            bado.updateStades(stade);
        }
        public void ModifierMatches(Match match)
        {
            bado.updateMatches(match);
        }
        public void ModifierTournois(Tournoi tournoi)
        {
            bado.updateTournois(tournoi);
        }
        public void ModifierCaracteristiques(Caracteristiques caracteristique)
        {
            bado.updateCaracteristiques(caracteristique);
        }

        // INSERT sont pas encore implementer

        public void InsertJedis(Jedi jedi)
        {
            bado.updateJedis(jedi);
        }
        public void InsertStades(Stade stade)
        {
            bado.updateStades(stade);
        }
        public void InsertMatches(Match match)
        {
            bado.updateMatches(match);
        }
        public void InsertTournois(Tournoi tournoi)
        {
            bado.updateTournois(tournoi);
        }
        public void InsertCaracteristiques(Caracteristiques caracteristique)
        {
            bado.updateCaracteristiques(caracteristique);
        }

    }
}