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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using EntitiesLayer;

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JediTournamentManager manag = new JediTournamentManager();
        private IEnumerable<string> stringInfo;
        public MainWindow()
        {
            InitializeComponent();
            tBox.Text = "";
        }

        void btnJedis_Click(object sender, RoutedEventArgs e)
        {
            stringInfo = manag.ListJedi();
            tBox.Text = "";
            foreach (String s in stringInfo)
            {
                tBox.Text += s+'\n';
            }

        }
        void btnStades_Click(object sender, RoutedEventArgs e)
        {
            stringInfo = manag.ListStade();
            tBox.Text = "";
            foreach (String s in stringInfo)
            {
                tBox.Text += s + '\n';
            }
        }
        void btnMatchs_Click(object sender, RoutedEventArgs e)
        {
            stringInfo = manag.ListMatch();
            tBox.Text = "";
            foreach (String s in stringInfo)
            {
                tBox.Text += s + '\n';
            }
        }
        void btnCaracteristiques_Click(object sender, RoutedEventArgs e)
        {
            stringInfo = manag.ListCaracteristiques();
            tBox.Text = "";
            foreach (String s in stringInfo)
            {
                tBox.Text += s + '\n';
            }
        }
        void btnBonus_Click(object sender, RoutedEventArgs e)
        {
            stringInfo = manag.ListCaracteristiques();
            tBox.Text = "";
            foreach (String s in stringInfo)
            {
                tBox.Text += s + '\n';
            }
        }
    }
}
