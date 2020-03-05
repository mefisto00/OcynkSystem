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
using System.Windows.Threading;



namespace Ocynkownia0811
{
    /// <summary>
    /// Logika interakcji dla klasy panelBrama.xaml
    /// </summary>
    public partial class panelBrama : Window
    {


        public string tempnrZlecenia;
        public string tempNazwa;
        public string tempRejestracja;
        public string tempID;
        public string tempKierowca;
        public string tempPojazd;


        public panelBrama()
        {
           

            InitializeComponent();
            wczytajSpisKlientow();           
            vBrama1.Visibility = Visibility.Visible;
            vBrama2.Visibility = Visibility.Collapsed;
            vBrama3.Visibility = Visibility.Collapsed;
            vBramaWjazdSzczegoly.Visibility = Visibility.Collapsed;

        }

        public void wczytajSpisKlientow()
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
                cmdlog.CommandText = "SELECT * FROM zlecenie";
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgBramaWyborKlienta.DataContext = dt;

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }


        public void wczytajSpisDoWyjazdu()
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
                cmdlog.CommandText = "SELECT * FROM brama WHERE godzinaWyjazdu IS NULL AND dataWyjazdu IS NULL; ";
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgBramaWyborKlientaWyjazd.DataContext = dt;

            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }

        }



        private void Br_poleSzukajBrama_KeyDown(object sender, KeyEventArgs e)
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
                    cmdlog.Connection = conn;
                    cmdlog.CommandText = " select * from zlecenie where concat(nrZlecenia,' ',adres,' ',nazwa,' ',kierowca,' ',pojazd,' ',rejestracja) like @frazaszukana";
                    cmdlog.Prepare();
                    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                    string temp1 = "%" + br_poleSzukajBrama.Text + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgBramaWyborKlienta.DataContext = dt;
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            oknoDodajKlienta odk = new oknoDodajKlienta();
            odk.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ZarejestrujBramaWjazd_Click(object sender, RoutedEventArgs e)
        {
            wczytajSpisKlientow();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();


          
        vBrama1.Visibility = Visibility.Collapsed;
            vBrama2.Visibility = Visibility.Visible;
            vBrama3.Visibility = Visibility.Collapsed;
           
        }

        private void ZarejestrujBramaWyjazd_Click(object sender, RoutedEventArgs e)
        {
            wczytajSpisDoWyjazdu();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();



            vBrama1.Visibility = Visibility.Collapsed;
            vBrama2.Visibility = Visibility.Collapsed;
            vBrama3.Visibility = Visibility.Visible;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.poleDataWjazduPojazdu.Text = dateTime.ToShortDateString();
            this.poleGodzinaWjazduPojazdu.Text = dateTime.ToShortTimeString();

            this.poleDataWyjazduPojazdu.Text = dateTime.ToShortDateString();
            this.poleGodzinaWyjazduPojazdu.Text = dateTime.ToShortTimeString();
        }


        private void Br_szukajKlient_Click(object sender, RoutedEventArgs e)
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
                    cmdlog.CommandText = " select * from zlecenie where concat(nrZlecenia,' ',adres,' ',nazwa,' ',kierowca,' ',pojazd,' ',rejestracja) like @frazaszukana";
                    cmdlog.Prepare();
                    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                    string temp1 = "%" + br_poleSzukajBrama.Text + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgBramaWyborKlienta.DataContext = dt;
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            
        }

        private void Br_resetujSzukajke_Click(object sender, RoutedEventArgs e)
        {
            wczytajSpisKlientow();
            br_poleSzukajBrama.Clear();

        }

        private void ZatwierdzWjazdBTN_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)dgBramaWyborKlienta.SelectedItems[0];



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
               cmdlog.CommandText = "INSERT INTO `brama`(idKlienta, nrZlecenia, nazwaKlienta, kierowca, pojazd, rejestracja, dataWjazdu, godzinaWjazdu) VALUES(@idKlienta, @idZlecenia, @nazwaKlienta, @kierowca, @pojazd, @rejestracja, @dataWjazdu, @godzinaWjazdu)";

                cmdlog.Prepare();
                cmdlog.Parameters.AddWithValue("@idKlienta", Convert.ToInt16(row[0].ToString()));
                cmdlog.Parameters.AddWithValue("@idZlecenia", row[1].ToString());
                cmdlog.Parameters.AddWithValue("@nazwaKlienta", row[2].ToString());
                cmdlog.Parameters.AddWithValue("@kierowca", row[4].ToString());
                cmdlog.Parameters.AddWithValue("@pojazd", row[5].ToString());
                cmdlog.Parameters.AddWithValue("@rejestracja", row[6].ToString());
                cmdlog.Parameters.AddWithValue("@dataWjazdu", poleDataWjazduPojazdu.Text.ToString());
                cmdlog.Parameters.AddWithValue("@godzinaWjazdu", poleGodzinaWjazduPojazdu.Text.ToString());

              
                  cmdlog.ExecuteNonQuery();


                 MessageBox.Show("Pomyślnie wprowadzono wpis wjazdowy!");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PowrocBramaHomeBTN_Click(object sender, RoutedEventArgs e)
        {
            vBrama1.Visibility = Visibility.Visible;
            vBrama2.Visibility = Visibility.Collapsed;
            vBrama3.Visibility = Visibility.Collapsed;
        }

        private void ZatwierdzWyjazdBTN_Click(object sender, RoutedEventArgs e)
        {

            DataRowView row = (DataRowView)dgBramaWyborKlientaWyjazd.SelectedItems[0];//wybor id wyjazdowego


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
                cmdlog.CommandText = "UPDATE `brama` SET dataWyjazdu=@dataWyjazdu, godzinaWyjazdu=@godzinaWyjazdu WHERE id=@id";
                cmdlog.Prepare();
                cmdlog.Parameters.AddWithValue("@id", Convert.ToInt16(row[0].ToString()));          
                cmdlog.Parameters.AddWithValue("@dataWyjazdu", poleDataWyjazduPojazdu.Text.ToString());
                cmdlog.Parameters.AddWithValue("@godzinaWyjazdu", poleGodzinaWyjazduPojazdu.Text.ToString());
                cmdlog.ExecuteNonQuery();

                MessageBox.Show("Pomyślnie wprowadzono wpis wyjazdowy!");

            }
            
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            wczytajSpisDoWyjazdu();
        }

        private void WprowadzSzczegolyWjazdu_Click(object sender, RoutedEventArgs e)
        {


            DataRowView row = (DataRowView)dgBramaWyborKlienta.SelectedItems[0];
            Console.WriteLine(">1 " + row[1].ToString()); //idZlecenie
            Console.WriteLine(">2 " + row[2].ToString()); //nazwa
            Console.WriteLine(">3 " + row[3].ToString()); //adres
            Console.WriteLine(">4 " + row[4].ToString()); //kierowca
            Console.WriteLine(">5 " + row[5].ToString()); //auto pojazd
            Console.WriteLine(">6 " + row[6].ToString()); //rejestracja
            Console.WriteLine(">7 " + row[7].ToString()); //uwagi
            Console.WriteLine(">0 " + row[0].ToString()); //id systemowe


            tempnrZlecenia = row[1].ToString();
            tempRejestracja = row[6].ToString();
            tempNazwa = row[2].ToString();
            tempID = row[0].ToString();
            tempKierowca = row[4].ToString();
            tempPojazd = row[5].ToString();



            vBramaWjazdSzczegoly.Visibility = Visibility.Visible;
            vBrama1.Visibility = Visibility.Collapsed;
            vBrama2.Visibility = Visibility.Collapsed;
            vBrama3.Visibility = Visibility.Collapsed;



            poleNrZlecenia.Text = tempnrZlecenia;
            poleNazwa.Text = tempNazwa;
            poleRejestracja.Text = tempRejestracja;

        }

        private void CofnijDOBramaGlownaBTN_Click(object sender, RoutedEventArgs e)
        {
            vBrama1.Visibility = Visibility.Visible;
            vBrama2.Visibility = Visibility.Collapsed;
            vBrama3.Visibility = Visibility.Collapsed;
            vBramaWjazdSzczegoly.Visibility = Visibility.Collapsed;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void AnulujWjazdBTN_Click(object sender, RoutedEventArgs e)
        {
            anulujWjazdWyjazd anu = new anulujWjazdWyjazd(tempID);
            anu.Show();
        }

        private void ZatwierdzWjazd_Click(object sender, RoutedEventArgs e)
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
                //  cmdlog.CommandText = "UPDATE `brama` SET dataWyjazdu=@dataWyjazdu, godzinaWyjazdu=@godzinaWyjazdu WHERE id=@id";
                cmdlog.CommandText = "INSERT INTO brama(idKlienta, czyPrzywoz, czyOpakowanie, sztukiOpakowanie, wagaAutoNetto, wagaAutoTara, wagaAutoBrutto, PMPWMP, UWMPWZ, kierowca, pojazd, rejestracja, dataWjazdu, godzinaWjazdu)" +
                    " VALUES(@idKlienta, @czyPrzywoz, @czyOpakowanie, @sztukiOpakowanie, @wagaAutoNetto, @wagaAutoTara, @wagaAutoBrutto, @PMPWMP, @UWMPWZ, @kierowca, @pojazd, @rejestracja, @dataWjazdu, @godzinaWjazdu)";


                cmdlog.Prepare();
                cmdlog.Parameters.AddWithValue("@idKlienta",Convert.ToInt16(tempID));
                cmdlog.Parameters.AddWithValue("@czyPrzywoz","1");
                if (czyOpakowanieCHK.IsChecked ?? true)
                {
                    cmdlog.Parameters.AddWithValue("@czyOpakowanie", "1");
                    cmdlog.Parameters.AddWithValue("@sztukiOpakowanie", Convert.ToInt16(poleIleOpakowan.Text));

                }
                else
                { cmdlog.Parameters.AddWithValue("@czyOpakowanie", "0");
                    cmdlog.Parameters.AddWithValue("@sztukiOpakowanie", 0);
                }

               
                cmdlog.Parameters.AddWithValue("@wagaAutoNetto",Convert.ToDouble(poleWagaNetto.Text));
                cmdlog.Parameters.AddWithValue("@wagaAutoTara", Convert.ToDouble(poleWagaTara.Text));
                cmdlog.Parameters.AddWithValue("@wagaAutoBrutto", Convert.ToDouble(poleWagaBrutto.Text));
                cmdlog.Parameters.AddWithValue("@PMPWMP", polePMP.Text);
                cmdlog.Parameters.AddWithValue("@UWMPWZ", poleUWMPWZ.Text);
                cmdlog.Parameters.AddWithValue("@kierowca", tempKierowca);
                cmdlog.Parameters.AddWithValue("@pojazd", tempPojazd);
                cmdlog.Parameters.AddWithValue("@rejestracja",tempRejestracja);
                cmdlog.Parameters.AddWithValue("@dataWjazdu", poleDataWjazduPojazdu.Text.ToString());
                cmdlog.Parameters.AddWithValue("@godzinaWjazdu",poleGodzinaWjazduPojazdu.Text.ToString());


                Console.WriteLine(cmdlog.CommandText.ToString());


                //cmdlog.Parameters.AddWithValue("@id", Convert.ToInt16(row[0].ToString()));
                //cmdlog.Parameters.AddWithValue("@dataWyjazdu", poleDataWyjazduPojazdu.Text.ToString());
                //cmdlog.Parameters.AddWithValue("@godzinaWyjazdu", poleGodzinaWyjazduPojazdu.Text.ToString());
                cmdlog.ExecuteNonQuery();

                MessageBox.Show("Pomyślnie wprowadzono wpis wjazdowy!");

            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
