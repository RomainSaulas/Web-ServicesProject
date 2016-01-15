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
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        void btnConnection_Click(object sender, RoutedEventArgs e)
        {
            JediTournamentManager manag = new JediTournamentManager();
            if (manag.CheckConnexionUser(txtLogin.Text.ToLower(), txtPassword.Password))
            {
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
        }
    }
}
