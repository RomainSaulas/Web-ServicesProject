using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Joueur : EntityObject
    {
        private string nom;
        private int score;

        public Joueur(string nom,int score,int id):base(id)
        {
            this.nom = nom;
            this.score = score;
        }
    }
}
