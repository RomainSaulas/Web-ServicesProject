using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IBridge
    {
        
        List<Jedi> getJedis();
        List<Stade> getStades();
        List<Match> getMatches();
        List<Caracteristiques> getCaracteristiques();
        List<Tournoi> getTournois();
        void updateJedis(Jedi Jedi);
        void updateStades(Stade stade );
        void updateMatches(Match match);
        void updateCaracteristiques(Caracteristiques caracteristiques);
        void updateTournois(Tournoi tournoi);
        
    }
}
