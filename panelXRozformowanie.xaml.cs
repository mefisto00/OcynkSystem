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
    /// Logika interakcji dla klasy panelXRozformowanie.xaml
    /// </summary>
    public partial class panelXRozformowanie : Window
    {
        public panelXRozformowanie()
        {
            InitializeComponent();
            rRozformowanie1.Visibility = Visibility.Visible;
            rRozformowanie2.Visibility = Visibility.Collapsed;
            wypelnijTabeleOcynkowane();
            wprowadzRozformDoBazyBTN.IsEnabled = false;
        }
           

        private void Rfr_szukajTrawers_Click(object sender, RoutedEventArgs e)
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
                    cmdlog.CommandText = " select material.nrProtokolu, material.nazwa, material.waga, material.ilosc, protokol.sektorMagazyn FROM material, protokol where concat(material.nrProtokolu,' ',material.nazwa,' ',material.ilosc,' ',material.waga,' ',protokol.sektorMagazyn) like @frazaszukana";
                    cmdlog.Prepare();
                    // cmdlog.Parameters.AddWithValue("@frazaszukana", fr_szukajka.Text);
                    string temp1 = "%" + rfr_szukajka.Text + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgWyborTrawersy.DataContext = dt;
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            
        }

        private void Rfr_resetujSzukajke_Click(object sender, RoutedEventArgs e)
        {
            rfr_szukajka.Clear();
            wypelnijTabeleOcynkowane();

        }

        private void Rfr_szukajka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
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
                    cmdlog.CommandText = " select material.nrProtokolu, material.nazwa, material.waga, material.ilosc, protokol.sektorMagazyn FROM material, protokol where concat(material.nrProtokolu,' ',material.nazwa,' ',material.ilosc,' ',material.waga,' ',protokol.sektorMagazyn) like @frazaszukana";
                    cmdlog.Prepare();
                    // cmdlog.Parameters.AddWithValue("@frazaszukana", fr_szukajka.Text);
                    string temp1 = "%" + rfr_szukajka.Text + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgWyborTrawersy.DataContext = dt;
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            }

        }

        private void WprowadzRozformDoBazyBTN_Click(object sender, RoutedEventArgs e)
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
                MySqlCommand cmdm = new MySqlCommand(stm, conn);
                try
                {
                    cmdlog.CommandText = "UPDATE trawers SET dataStartRozformowanie=@dataStartRozformowanie, godzinaStartRozformowanie=@godzinaStartRozformowanie, dataStopRozformowanie=@dataStopRozformowanie, godzinaStopRozformowanie=@godzinaStopRozformowanie, ktoZatwierdzilRozformowanie=@ktoZatwierdzilRozformowanie, stanTrawersy=@stanTrawersy, tonazWsadu=@tonazWsadu, zuzycieCynku=@zuzycieCynku, gruboscMikrony=@gruboscMikrony where nrDnia=@nrDnia and nrTrawersy=@nrTrawersy";
                    cmdlog.Prepare();
                    cmdlog.Parameters.AddWithValue("@dataStartRozformowanie", poleDataStartRozformowanie.Text);
                    cmdlog.Parameters.AddWithValue("@godzinaStartRozformowanie", poleGodzinaStartRozformowanie.Text);
                    cmdlog.Parameters.AddWithValue("@dataStopRozformowanie", poleDataStopRozformowanie.Text);
                    cmdlog.Parameters.AddWithValue("@godzinaStopRozformowanie", poleGodzinaStopRozformowanie.Text);
                   
                    cmdlog.Parameters.AddWithValue("@ktoZatwierdzilRozformowanie", poleKtoZatwierdzilRozformowanie.Text);
                    cmdlog.Parameters.AddWithValue("@stanTrawersy", "rozformowane");
                    cmdlog.Parameters.AddWithValue("@nrDnia", poleNrDnia.Text);
                    cmdlog.Parameters.AddWithValue("@nrTrawersy", poleNrTrawersy.Text);

                    cmdlog.Parameters.AddWithValue("@tonazWsadu", przecinekNaKropke(poleTonazWsadu.Text));
                    cmdlog.Parameters.AddWithValue("@zuzycieCynku", przecinekNaKropke(poleZuzycieCynku.Text));
                    cmdlog.Parameters.AddWithValue("@gruboscMikrony", przecinekNaKropke(poleGruboscMikrony.Text));



                    cmdlog.ExecuteNonQuery();
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }

                System.Windows.MessageBox.Show("Pomyślnie wprowadzono dane do bazy!");

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        private void PrzejdzDoSzczegolowRozformyBTN_Click(object sender, RoutedEventArgs e)
        {
            rRozformowanie1.Visibility = Visibility.Collapsed;
            rRozformowanie2.Visibility = Visibility.Visible;
            DataRowView row = (DataRowView)dgWyborTrawersy.SelectedItems[0];
            poleNrTrawersy.Text = row[0].ToString();
            poleNrDnia.Text = row[1].ToString();

            string sciezka = "baza.config";
            string konfiguracja = File.ReadAllText(sciezka);
            try
            {

                MySqlConnection conn = null;
                conn = new MySqlConnection(konfiguracja);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.CommandText = "SELECT material.nazwa, material.waga, material.ilosc, material.nrProtokolu FROM trawers, material WHERE trawers.idMaterialu=material.id and trawers.nrDnia = @nrDnia; ";
                cmdlog.Prepare();
                cmdlog.Parameters.AddWithValue("@nrDnia", row[1].ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgNaTrawersie.DataContext = dt;


            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }


        }

        public string przecinekNaKropke(string wejscie)
        {
            string temp = wejscie.Replace(',', '.');
            return temp;
        }


        public void wypelnijTabeleOcynkowane()
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
                cmdlog.CommandText = "SELECT distinct nrTrawersy, nrDnia, dataStopFormowanie, godzinaStopFormowanie, dataStopCynkowanie, godzinaStopCynkowanie FROM trawers WHERE dataStartRozformowanie IS NULL and dataStopRozformowanie IS NULL and dataStopCynkowanie IS NOT NULL and godzinaStopCynkowanie IS NOT NULL; ";
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgWyborTrawersy.DataContext = dt;

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        private void PotwierdzenieCHK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (potwierdzenieCHK.SelectedValue.ToString() == "TAK")
            {
                wprowadzRozformDoBazyBTN.IsEnabled = true;
            }
            else wprowadzRozformDoBazyBTN.IsEnabled = false;

        }

        private void CofnijDoWyboruTrawersBTN_Click(object sender, RoutedEventArgs e)
        {
            rRozformowanie1.Visibility = Visibility.Visible;
            rRozformowanie2.Visibility = Visibility.Collapsed;
            wypelnijTabeleOcynkowane();
        }
    }
}
