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

        public int IdJediVainqueur
        {
            get { return idJediVainqueur; }
            set { idJediVainqueur = value; }
        }
        private Jedi jedi1;
        private Jedi jedi2;
        private EPhaseTournoi phaseTournoi;

        public EPhaseTournoi PhaseTournoi
        {
            get { return phaseTournoi; }
            set { phaseTournoi = value; }
        }
        private Stade stade;

        public Stade Stade
        {
            get
            {
                return stade;
            }
            set
            {
                stade = value;
            }
        }
        public Jedi Jedi1 
        {
            get
            {
                return jedi1;
            }
            set
            {
                jedi1 = value;
            }
        }
        public Jedi Jedi2
        {
            get
            {
                return jedi2;
            }
            set
            {
                jedi2 = value;
            }
        }
        public Match(int idJediVainqueur,Jedi jedi1,Jedi jedi2,EPhaseTournoi phaseTournoi,Stade stade,int id):base(id)
        {
            this.idJediVainqueur = 0;
            this.jedi1 = jedi1;
            this.jedi2 = jedi2;
            this.phaseTournoi = phaseTournoi;
            this.stade = stade;
        }

    }
}
