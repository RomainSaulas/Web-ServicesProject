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

namespace JediTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            
            
            InitializeComponent();

            ComboItems.Items.Add("Gestion des Stades");
            ComboItems.Items.Add("Gestion des Jedis");
            ComboItems.Items.Add("Gestion des Matchs");
            

            
        }
        private void ComboItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //List<Object> list;
            //ListItems.Items.Clear();

            String selection = ComboItems.SelectedItem.ToString();
            //ListItems.Items.Clear();
            BusinessLayer.JediTournamentManager manager = new BusinessLayer.JediTournamentManager();
            String[] choice = selection.Split(' ');
            ListItemsJedi.Visibility = System.Windows.Visibility.Collapsed;
            ListItemsStade.Visibility = System.Windows.Visibility.Collapsed;
            ListItemsMatch.Visibility = System.Windows.Visibility.Collapsed;
            // récupération des Jedis
            switch (choice[2]){
                case "Stades": ListItemsStade.ItemsSource = manager.getAllStadeModel(); 
                    ListItemsStade.Visibility = System.Windows.Visibility.Visible; break;
               
                case "Jedis": /*ListItemsJedi.ItemsSource = manager.ListJediInfo();*/
                    ListItemsJedi.Visibility = System.Windows.Visibility.Visible;
                    EntitiesLayer.ViewModelEdit vmEdit = new EntitiesLayer.ViewModelEdit(manager.ListJediInfo());
                    this.DataContext = vmEdit;
                    break;
                case "Matchs": ListItemsMatch.ItemsSource = manager.getAllMatchModel(); 
                    ListItemsMatch.Visibility = System.Windows.Visibility.Visible; break;
            }
        }

    }
}
