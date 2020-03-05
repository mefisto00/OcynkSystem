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

namespace Ocynkownia0811
{
    /// <summary>
    /// Logika interakcji dla klasy oknoStartowe.xaml
    /// </summary>
    public partial class oknoStartowe : Window
    {
        public string login;
        public oknoStartowe()
        {
            InitializeComponent();
           // uruchomPlanowanieBTN.IsEnabled = false;
           // uruchomRaportyBTN.IsEnabled = false;
          //  uruchomWydanieBTN.IsEnabled = false;
        }

        public oknoStartowe(string l_login)
        {
            InitializeComponent();
            // uruchomPlanowanieBTN.IsEnabled = false;
            // uruchomRaportyBTN.IsEnabled = false;
            //  uruchomWydanieBTN.IsEnabled = false;
        }

        private void UruchomRozdzielniaBTN_Click(object sender, RoutedEventArgs e)
        {
            panelXRozdzielnia rozdzielnia = new panelXRozdzielnia();
           // this.Close();
            rozdzielnia.Show();


        }

        private void UruchomPlanowanieBTN_Click(object sender, RoutedEventArgs e)
        {
            panelPlanista planista = new panelPlanista();
           // this.Close();
            planista.Show();
        }

        private void UruchomBramaBTN_Click(object sender, RoutedEventArgs e)
        {
            panelBrama brama = new panelBrama();
          //  this.Close();
            brama.Show();

        }

        private void UruchomFormowanieBTN_Click(object sender, RoutedEventArgs e)
        {
            panelXFormowanie formowanie = new panelXFormowanie();
            //this.Close();
            formowanie.Show();
        }

        private void UruchomCynkowanieBTN_Click(object sender, RoutedEventArgs e)
        {
            panelXCynkowanie cynkowanie = new panelXCynkowanie();
           // this.Close();
            cynkowanie.Show();
        }

       

        private void UruchomRozformowanieBTN_Click(object sender, RoutedEventArgs e)
        {
            panelXRozformowanie rozformowanie = new panelXRozformowanie();
            // this.Close();
            rozformowanie.Show();
        }
    }
}
