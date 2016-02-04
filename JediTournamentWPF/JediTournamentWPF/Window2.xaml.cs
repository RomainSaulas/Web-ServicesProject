using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;
using EntitiesLayer;

namespace JediTournamentWPF
{
   /// <summary>
   /// Logique d'interaction pour Window2.xaml
   /// </summary>
   public partial class Window2 : Window
   {

      public int etat_tournois = 0;
      BusinessLayer.JediTournamentManager Manager = new JediTournamentManager();
      List<ViewModelMatch> listMatch = new List<ViewModelMatch>();
      public Window2()
      {
         InitializeComponent();
         listMatch = (from mat in Manager.getAllMatchModel()
                      where mat.PhaseTournoi == EPhaseTournoi.HuitiemeFinale
                      orderby mat.Match.Id
                      select mat).ToList();
         j1.Text = listMatch[0].Jedi1.Nom;
         j2.Text = listMatch[0].Jedi2.Nom;
         j3.Text = listMatch[1].Jedi1.Nom;
         j4.Text = listMatch[1].Jedi2.Nom;
         j5.Text = listMatch[2].Jedi1.Nom;
         j6.Text = listMatch[2].Jedi2.Nom;
         j7.Text = listMatch[3].Jedi1.Nom;
         j8.Text = listMatch[3].Jedi2.Nom;
         j9.Text = listMatch[4].Jedi1.Nom;
         j10.Text = listMatch[4].Jedi2.Nom;
         j11.Text = listMatch[5].Jedi1.Nom;
         j12.Text = listMatch[5].Jedi2.Nom;
         j13.Text = listMatch[6].Jedi1.Nom;
         j14.Text = listMatch[6].Jedi2.Nom;
         j15.Text = listMatch[7].Jedi1.Nom;
         j16.Text = listMatch[7].Jedi2.Nom;
      }


      void btnPlay_Click(object sender, RoutedEventArgs e)
      {
         switch (etat_tournois)
         {
            case 0:
               Manager.launchHuitieme(listMatch);
               var listQuart = (from mat in listMatch
                                where mat.PhaseTournoi == EPhaseTournoi.QuartFinale
                                orderby mat.Match.Id
                                select mat).ToList();

               k1.Text = listQuart[0].Jedi1.Nom;
               k2.Text = listQuart[0].Jedi2.Nom;
               k3.Text = listQuart[1].Jedi1.Nom;
               k4.Text = listQuart[1].Jedi2.Nom;
               k5.Text = listQuart[2].Jedi1.Nom;
               k6.Text = listQuart[2].Jedi2.Nom;
               k7.Text = listQuart[3].Jedi1.Nom;
               k8.Text = listQuart[3].Jedi2.Nom;
               this.etat_tournois++;
               break;
            case 1:
               Manager.launchQuart(listMatch);
               var listDemi = (from mat in listMatch
                               where mat.PhaseTournoi == EPhaseTournoi.DemiFinale
                               orderby mat.Match.Id
                               select mat).ToList();
               l1.Text = listDemi[0].Jedi1.Nom;
               l2.Text = listDemi[0].Jedi2.Nom;
               l3.Text = listDemi[1].Jedi1.Nom;
               l4.Text = listDemi[1].Jedi2.Nom;

               this.etat_tournois++;
               break;
            case 2:
               Manager.launchDemi(listMatch);
               var listFinale = (from mat in listMatch
                                 where mat.PhaseTournoi == EPhaseTournoi.Finale
                                 orderby mat.Match.Id
                                 select mat).ToList();
               m1.Text = listFinale[0].Jedi1.Nom;
               m2.Text = listFinale[0].Jedi2.Nom;
               this.etat_tournois++;
               break;
            case 3:
               Match matc = (from match in listMatch
                             where match.PhaseTournoi == EPhaseTournoi.Finale
                             select match.Match).First();
               Manager.launchFinale(matc);
               v1.Text = (from vainc in Manager.getAllJediModel()
                          where vainc.Jedi.Id == matc.IdJediVainqueur
                          select vainc.Nom).First();
               this.etat_tournois++;
               button.Content = "Close";
               break;
            case 4:
               this.Close();
               break;
         }
      }
   }
}
