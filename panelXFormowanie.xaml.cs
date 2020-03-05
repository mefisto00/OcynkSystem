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
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections;



namespace Ocynkownia0811
{
    /// <summary>
    /// Logika interakcji dla klasy panelXFormowanie.xaml
    /// </summary>
    public partial class panelXFormowanie : Window
    {

        public class klasaFormowanie
        {
            public int idMat { get; set; }
           public int lp { get; set; }
            public string l_nrProtokol { get; set; }
            public string l_nazwaMat { get; set; }
            public string l_ilosc { get; set;}
            public string l_waga { get; set;}
            public string l_nwaga { get; set; }
            public string l_nilosc { get; set; }

            public klasaFormowanie() { }

            public klasaFormowanie(int idMa, int llp, string nrprot, string nazwma, string ilosc, string waga, string nwaga, string nilosc)
            {
                idMat = idMa;
                lp = llp;
                l_nrProtokol = nrprot;
                l_nazwaMat = nazwma;
                l_ilosc = ilosc;
                l_waga = waga;
                l_nwaga = nwaga;
                l_nilosc = nilosc;
            }

        }
        List<klasaFormowanie> listaFormowanie = new List<klasaFormowanie>();
        public int liczbaporzadkowa = 1;

        public string idWybrany;

        public string wybranaWaga;
        public string wybranaIlosc;


        public double Nnowawaga;
        public double Nnowailosc;

        public panelXFormowanie()
        {
            InitializeComponent();
            pFormowanie1.Visibility = Visibility.Visible;
            pFormowanie2.Visibility = Visibility.Collapsed;
            wypelnijTabeleFormowanie();

            fpoleProtokol.IsEnabled = false;
            fpoleNazwaMaterialu.IsEnabled = false;
            wprowadzTrawersDoBazyBTN.IsEnabled = false;


        }

       
        public void wypelnijTabeleFormowanie()
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
                cmdlog.CommandText = "SELECT material.id, material.nrProtokolu, material.nazwa, material.wagaLinia, material.iloscLinia, material.czyGabaryt, protokol.sektorMagazyn FROM material, protokol WHERE material.idProtokolu = protokol.id";
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgfrProtoMaterial.DataContext = dt;

            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        public void odswiezListaFormowanie()
        {
            var source = new BindingSource();
            ObservableCollection<klasaFormowanie> collection = new ObservableCollection<klasaFormowanie>(listaFormowanie);
            source.DataSource = collection;
            lsWybrane.ItemsSource = source;
            lsWybrane2.ItemsSource = source;
        }




       

        private void Fr_szukajProtokol_Click(object sender, RoutedEventArgs e)
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
                cmdlog.CommandText = " select material.nrProtokolu, material.nazwa, material.wagaLinia, material.iloscLinia, protokol.sektorMagazyn FROM material, protokol where concat(material.nrProtokolu,' ',material.nazwa,' ',material.ilosc,' ',material.waga,' ',protokol.sektorMagazyn) like @frazaszukana";
                cmdlog.Prepare();
               // cmdlog.Parameters.AddWithValue("@frazaszukana", fr_szukajka.Text);
                string temp1 = "%" + fr_szukajka.Text + "%";
                cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                Console.WriteLine(cmdlog.CommandText.ToString());
                cmdlog.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                DataTable dt = new DataTable();

                da.Fill(dt);
               dgfrProtoMaterial.DataContext = dt;
            }
            catch (MySqlException se)
            {
                System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }
        }

        private void Fr_resetujSzukajkeProtokol_Click(object sender, RoutedEventArgs e)
        {
            wypelnijTabeleFormowanie();
            fr_szukajka.Clear();
        }

        private void Fr_szukajka_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
                    string temp1 = "%" + fr_szukajka.Text + "%";
                    cmdlog.Parameters.AddWithValue("@frazaszukana", temp1);
                    Console.WriteLine(cmdlog.CommandText.ToString());
                    cmdlog.ExecuteNonQuery();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdlog);
                    MySqlCommandBuilder ccc = new MySqlCommandBuilder(da);
                    //DataTable dt = new DataTable();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgfrProtoMaterial.DataContext = dt;
                }
                catch (MySqlException se)
                {
                    System.Windows.MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
                }
            }
        }

        private void LlistaUsun_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            klasaFormowanie el = button.DataContext as klasaFormowanie;

            string hkontId = el.lp.ToString();
            //  System.Windows.MessageBox.Show(hkontId);

            var kon = listaFormowanie.FirstOrDefault<klasaFormowanie>(d => d.lp == Convert.ToInt16(hkontId));
            listaFormowanie.RemoveAll(x => x.lp == Convert.ToInt16(hkontId));
            liczbaporzadkowa--;
            odswiezListaFormowanie();
        }

        private void WprowadzTrawersDoBazyBTN_Click(object sender, RoutedEventArgs e)
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

               // cmdlog.Connection.Open();
                try
                {

                    cmdlog.CommandText = "INSERT INTO trawers(nrTrawersy, idMaterialu, nrDnia, stanTrawersy, wagaFormowania, dataStartFormowanie, godzinaStartFormowanie, dataStopFormowanie, godzinaStopFormowanie, ktoZatwierdzilFormowanie) VALUES(@nrTrawersy, @idMaterialu, @nrDnia, @stanTrawersy, @wagaFormowania, @dataStartFormowanie, @godzinaStartFormowanie, @dataStopFormowanie, @godzinaStopFormowanie, @ktoZatwierdzilFormowanie)";
                    cmdlog.Prepare();
                    foreach (var item in listaFormowanie)
                    {

                        cmdlog.Parameters.AddWithValue("@nrTrawersy", poleNrTrawers.Text);
                        cmdlog.Parameters.AddWithValue("@idMaterialu", item.idMat);
                        cmdlog.Parameters.AddWithValue("@nrDnia", poleNrDnia.Text);
                        cmdlog.Parameters.AddWithValue("@stanTrawersy", "zaformowane");
                        cmdlog.Parameters.AddWithValue("@wagaFormowania", poleWagaFormowania.Text);
                        cmdlog.Parameters.AddWithValue("@dataStartFormowanie", poleDataStartFormowania.Text);
                        cmdlog.Parameters.AddWithValue("@godzinaStartFormowanie", poleGodzinaStartFormowanie.Text);
                        cmdlog.Parameters.AddWithValue("@dataStopFormowanie", poleDataStopFormowania.Text);
                        cmdlog.Parameters.AddWithValue("@godzinaStopFormowanie", poleGodzinaStopFormowanie.Text);
                        cmdlog.Parameters.AddWithValue("@ktoZatwierdzilFormowanie", poleKtoZatwierdzilFormowanie.Text);
                        cmdlog.ExecuteNonQuery();

                        cmdlog.Parameters.Clear();

                    }
                    cmdlog.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }

                cmdm.Connection.Open();
                try
                {

                    cmdm.CommandText = "UPDATE material SET wagaLinia=@nowaWaga, iloscLinia=@nowaIlosc where id=@idMaterialu";
                    cmdm.Prepare();

                    foreach (var ite in listaFormowanie)
                    {

                        cmdm.Parameters.AddWithValue("@nowaWaga", ite.l_nwaga);
                        cmdm.Parameters.AddWithValue("@nowaIlosc", ite.l_nilosc);
                        cmdm.Parameters.AddWithValue("@idMaterialu", ite.idMat);
                        cmdm.ExecuteNonQuery();

                        cmdm.Parameters.Clear();


                    }
                    cmdm.Connection.Close();

                    System.Windows.MessageBox.Show("Pomyślnie wprowadzono trawers do bazy danych!");
                }
                catch (MySqlException ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }

            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }


            private void WprowadzTrawersDoBazyBTN_Click_1(object sender, RoutedEventArgs e)
        {
            pFormowanie1.Visibility = Visibility.Collapsed;
            pFormowanie2.Visibility = Visibility.Visible;
        }

        private void CofnijDoWyboruFormowanieBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodajSzczegolyTrawersuBTN_Click(object sender, RoutedEventArgs e)
        {

            pFormowanie1.Visibility = Visibility.Collapsed;
            pFormowanie2.Visibility = Visibility.Visible;
        }

        private void PrzekazDoTrawersyBTN_Click(object sender, RoutedEventArgs e)
        {
            double nowailosc;
            double nowawaga;

            double tempW1 = Convert.ToDouble(wybranaWaga);
            double tempW2 = Convert.ToDouble(fpoleWagaWybrana.Text);
            nowawaga = tempW1 - tempW2;
            Nnowawaga = nowawaga;

            double tempI1 = Convert.ToDouble(wybranaIlosc);
            double tempI2 = Convert.ToDouble(fpoleIloscWybrana.Text);
            nowailosc = tempI1 - tempI2;
            Nnowailosc = nowailosc;

            Console.WriteLine("[A] - "+ tempW1);
            Console.WriteLine("[B] - "+ tempW2);
            Console.WriteLine("[C] - "+ nowawaga.ToString());

            Console.WriteLine("[D] - " + tempI1);
            Console.WriteLine("[E] - " + tempI2);
            Console.WriteLine("[F] - " + nowailosc.ToString());

            listaFormowanie.Add(new klasaFormowanie(Convert.ToInt16(idWybrany), liczbaporzadkowa, fpoleProtokol.Text, fpoleNazwaMaterialu.Text, fpoleIloscWybrana.Text, fpoleWagaWybrana.Text, nowawaga.ToString(), nowailosc.ToString()));
            odswiezListaFormowanie();
            liczbaporzadkowa++;
        }

        private void OkreslIloscFormaBTN_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dtG = (DataRowView)((System.Windows.Controls.Button)e.Source).DataContext;
            Console.WriteLine(dtG[0].ToString());
            Console.WriteLine(dtG[1].ToString());
            Console.WriteLine(dtG[2].ToString());
            Console.WriteLine(dtG[3].ToString());
            Console.WriteLine(dtG[4].ToString());
            Console.WriteLine(dtG[5].ToString());

            idWybrany = dtG[0].ToString();
   
            fpoleProtokol.Text = dtG[1].ToString();
            fpoleNazwaMaterialu.Text = dtG[2].ToString();
            fpoleIloscWybrana.Text = dtG[4].ToString();
            wybranaIlosc = dtG[4].ToString();
            wybranaWaga = dtG[3].ToString();
            fpoleWagaWybrana.Text = dtG[3].ToString();
        }

        private void PotwierdzenieCHK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (potwierdzenieCHK.SelectedValue.ToString() == "TAK")
            {
                wprowadzTrawersDoBazyBTN.IsEnabled = true;
            }
            else wprowadzTrawersDoBazyBTN.IsEnabled = false;
        }

       
    }
}
