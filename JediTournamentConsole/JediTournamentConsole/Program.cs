using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace JediTournamentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            JediTournamentManager business = new JediTournamentManager();
            IEnumerable<string> listStade = business.AfficheStade();
            Console.WriteLine("Affiche Stade :");
            foreach (string element in listStade)
            {
                Console.WriteLine("Stade : {0}",element);
            }
            IEnumerable<string> listSith = business.AfficheSith();
            Console.WriteLine("Affiche Sith :");
            foreach (string element in listSith)
            {
                Console.WriteLine("Sith : {0}", element);
            }
            IEnumerable<string> listJediFort = business.AfficheJediFort();
            Console.WriteLine("Affiche Jedi Fort :");
            foreach (string element in listJediFort)
            {
                Console.WriteLine("Jedi Fort : {0}", element);
            }
            IEnumerable<string> listMatchDuSiecle = business.AfficheMatchDuSiecle();
            Console.WriteLine("Affiche Match Du Siecle :");
            foreach (string element in listMatchDuSiecle)
            {
                Console.WriteLine("Match Du Siecle : {0}", element);
            }
            Console.ReadKey();
        }
    }
}
