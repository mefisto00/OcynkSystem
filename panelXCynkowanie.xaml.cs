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
    /// Logika interakcji dla klasy panelXCynkowanie.xaml
    /// </summary>
    public partial class panelXCynkowanie : Window
    {
        public panelXCynkowanie()
        {
            InitializeComponent();
           
            pCynkowanie1.Visibility = Visibility.Visible;
            pCynkowanie2.Visibility = Visibility.Collapsed;
            wypelnijTabelaZaformowane();
            wprowadzOcynkDoBazyBTN.IsEnabled = false;
        }

        private void PrzejdzDoSzczegolowCynkowaniaBTN_Click(object sender, RoutedEventArgs e)
        {
            pCynkowanie1.Visibility = Visibility.Collapsed;
            pCynkowanie2.Visibility = Visibility.Visible;
            DataRowView row = (DataRowView)dgWyborTrawersy.SelectedItems[0];

            Console.WriteLine("0 -" + row[0].ToString());
            Console.WriteLine("1 -" + row[1].ToString());
            Console.WriteLine("2 -" + row[2].ToString());
            Console.WriteLine("3 -" + row[3].ToString());
            // Console.WriteLine("4 -" + row[4].ToString());
            // Console.WriteLine("5 -" + row[5].ToString());


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

        private void WprowadzOcynkDoBazyBTN_Click(object sender, RoutedEventArgs e)
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
                    cmdlog.CommandText = "UPDATE trawers SET dataStartCynkowanie=@dataStartCynkowanie, godzinaStartCynkowanie=@godzinaStartCynkowanie, dataStopCynkowanie=@dataStopCynkowanie, godzinaStopCynkowanie=@godzinaStopCynkowanie, wagaPoOcynku=@wagaPoOcynku, ktoZatwierdzilCynkowanie=@ktoZatwierdzilCynkowanie, stanTrawersy=@stanTrawersy, temperaturaOcynk=@temperaturaOcynk where nrDnia=@nrDnia and nrTrawersy=@nrTrawersy";
                    cmdlog.Prepare();
                    cmdlog.Parameters.AddWithValue("@dataStartCynkowanie", poleDataStartCynkowanie.Text);
                    cmdlog.Parameters.AddWithValue("@godzinaStartCynkowanie",poleGodzinaStartCynkowanie.Text);
                    cmdlog.Parameters.AddWithValue("@dataStopCynkowanie",poleDataStopCynkowanie.Text);
                    cmdlog.Parameters.AddWithValue("@godzinaStopCynkowanie",poleGodzinaStopCynkowanie.Text);
                    cmdlog.Parameters.AddWithValue("@wagaPoOcynku",poleWagaPoOcynku.Text);
                    cmdlog.Parameters.AddWithValue("@ktoZatwierdzilCynkowanie",poleKtoZatwierdzilCynkowanie.Text);
                    cmdlog.Parameters.AddWithValue("@stanTrawersy","ocynkowane");
                    cmdlog.Parameters.AddWithValue("@nrDnia",poleNrDnia.Text);
                    cmdlog.Parameters.AddWithValue("@nrTrawersy",poleNrTrawersy.Text);
                    cmdlog.Parameters.AddWithValue("@temperaturaOcynk", przecinekNaKropke(poleTemperatura.Text));
                    //cmdlog.Parameters.AddWithValue("@tonazWsadu", przecinekNaKropke(poleTonazWsadu.Text));
                    //cmdlog.Parameters.AddWithValue("@zuzycieCynku", przecinekNaKropke(poleZuzycieCynku.Text));
                    //cmdlog.Parameters.AddWithValue("@gruboscMikrony", przecinekNaKropke(poleGruboscMikrony.Text));



                    cmdlog.ExecuteNonQuery();
                }
                catch(MySqlException se)
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

        public void wypelnijTabelaZaformowane()
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
                cmdlog.CommandText = "SELECT distinct nrTrawersy, nrDnia, dataStopFormowanie, godzinaStopFormowanie FROM trawers WHERE dataStartCynkowanie IS NULL and dataStopCynkowanie IS NULL; ";
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
                wprowadzOcynkDoBazyBTN.IsEnabled = true;
            }
            else wprowadzOcynkDoBazyBTN.IsEnabled = false;
        }


        private void CofnijDoWyboruOcynk_Click(object sender, RoutedEventArgs e)
        {
            pCynkowanie1.Visibility = Visibility.Collapsed;
            pCynkowanie2.Visibility = Visibility.Visible;
        }

        public string przecinekNaKropke(string wejscie)
        {
            string temp = wejscie.Replace(',', '.');
            return temp;
        }

        private void Cyn_szukajProtokol_Click(object sender, RoutedEventArgs e)
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
                cmdlog.Connection = conn;
                cmdlog.CommandText = "SELECT distinct nrTrawersy, nrDnia, dataStopFormowanie, godzinaStopFormowanie FROM trawers WHERE dataStartCynkowanie IS NULL and dataStopCynkowanie IS NULL and concat(nrTrawersy,' ',nrDnia,' ',dataStopFormowanie,' ',godzinaStopFormowanie) like @frazaszukana; ";

                //cmdlog.CommandText = " select material.nrProtokolu, material.nazwa, material.wagaLinia, material.iloscLinia, protokol.sektorMagazyn FROM material, protokol where concat(material.nrProtokolu,' ',material.nazwa,' ',material.ilosc,' ',material.waga,' ',protokol.sektorMagazyn) like @frazaszukana";
                cmdlog.Prepare();
                // cmdlog.Parameters.AddWithValue("@frazaszukana", fr_szukajka.Text);
                string temp1 = "%" + cyn_szukajka.Text + "%";
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

        private void Cyn_resetujSzukajkeProtokol_Click(object sender, RoutedEventArgs e)
        {
            wypelnijTabelaZaformowane();
            cyn_szukajka.Clear();
        }

        private void Cyn_szukajka_KeyDown(object sender, KeyEventArgs e)
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
                    string temp1 = "%" + cyn_szukajka.Text + "%";
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
    }
}
