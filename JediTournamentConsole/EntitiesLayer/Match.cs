using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Match : EntityObject
    {
        
        private int idJediVainqueur;
        private Jedi jedi1;
        private Jedi jedi2;
        private EPhaseTournoi phaseTournoi;
        private Stade stade;

        public Stade Stad
        {
            get
            {
                return stade;
            }
        }
        public Jedi Jedi1 
        {
            get
            {
                return jedi1;
            }
        }
        public Jedi Jedi2
        {
            get
            {
                return jedi2;
            }
        }
        public Match(int idJediVainqueur,Jedi jedi1,Jedi jedi2,EPhaseTournoi phaseTournoi,Stade stade,int id):base(id)
        {
            this.idJediVainqueur = idJediVainqueur;
            this.jedi1 = jedi1;
            this.jedi2 = jedi2;
            this.phaseTournoi = phaseTournoi;
            this.stade = stade;
        }

    }
}
