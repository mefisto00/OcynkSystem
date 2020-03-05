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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;


namespace Ocynkownia0811
{
    /// <summary>
    /// Logika interakcji dla klasy oknoDodajKlienta.xaml
    /// </summary>
    public partial class oknoDodajKlienta : Window
    {
        public oknoDodajKlienta()
        {
            InitializeComponent();
        }

        private void DodajDoBazyKlient_Click(object sender, RoutedEventArgs e)
        {

            string sciezka = "baza.config";
            string konfiguracja = File.ReadAllText(sciezka);
            try
            {

                MySqlConnection conn = null;
                conn = new MySqlConnection(konfiguracja);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.CommandText = "INSERT INTO zlecenie(" +
                    "nrZlecenia, nazwa, adres, kierowca, pojazd, rejestracja, opis, uwagi) values(" +
                    "@nrZlecenia, @nazwa, @adres, @kierowca, @pojazd, @rejestracja, @opis, @uwagi)";
                cmdlog.Prepare();
                cmdlog.Parameters.AddWithValue("@nrZlecenia", xpoleNrZlecenia.Text);
                cmdlog.Parameters.AddWithValue("@nazwa", xpoleNazwa.Text);
                cmdlog.Parameters.AddWithValue("@adres", xpoleAdres.Text);
                cmdlog.Parameters.AddWithValue("@kierowca", xpoleKierowca.Text);
                cmdlog.Parameters.AddWithValue("@pojazd", xpolePojazd.Text);
                cmdlog.Parameters.AddWithValue("@rejestracja", xpoleRejestracja.Text);
                cmdlog.Parameters.AddWithValue("@opis", xpoleOpis.Text);
                cmdlog.Parameters.AddWithValue("@uwagi", xPoleUwagi.Text);
                cmdlog.ExecuteNonQuery();
                MessageBox.Show("Pomyślnie dodano klienta do bazy!");
                this.Close();

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }
    }
}
