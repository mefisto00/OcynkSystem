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
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections;

namespace Ocynkownia0811
{
    /// <summary>
    /// Logika interakcji dla klasy panelXRozdzielnia.xaml
    /// </summary>
    public partial class panelXRozdzielnia : Window
    {

        public class klasaElement
        {
            public int lp { get; set; }
            public string e_nrprotokolu { get; set; }
            public string e_rodzaj { get; set; }
            public string e_ilosc { get; set; }
            public string e_waga { get; set; }
            public string e_stan { get; set; }
            public string e_gabaryt { get; set; }
            

            public klasaElement() { }

            public klasaElement(int elpe, string id, string rodz, string il, string wag, string stan, string gaba)
            {
                lp = elpe;
                e_nrprotokolu = id;
                e_rodzaj = rodz;
                e_ilosc = il;
                e_waga = wag;
                e_stan = stan;
                e_gabaryt = gaba;
               
            }

        }
        List<klasaElement> listaElement = new List<klasaElement>();
        public int liczbaporzadkowa = 1;

        public string r_idZlecenia;
        public string r_nrZlecenia;

        public panelXRozdzielnia()
        {
            InitializeComponent();
            rRozdzielnia1.Visibility = Visibility.Visible;
            rRozdzielnia2.Visibility = Visibility.Hidden;
            wczytajSpisKlientow();
            poleWaga4Procent.IsReadOnly = true;
            wprowadzDoBazyRozdzielniaBTN.IsEnabled = false;
            poleCzyGabaryt.SelectedValue = "NIE";
        }

        private void WprowadzDoBazyRozdzielniaBTN_Click(object sender, RoutedEventArgs e)
        {
            string xid;

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
                cmdlog.CommandText = "INSERT INTO protokol(nrProtokolu, nrZlecenia, nrPMP, uwagi, wagaSzacunkowa, wagaZBiletu, waga4Procent, wagaPMPZaokr, wagaZOpakowaniem, wagaOpakowania, rodzajOpakowania, ktoPrzyjalMaterialy, dataPrzyjecia, formaPlatnosci, sektorMagazyn, idZlecenia) VALUES(@nrProtokolu, @nrZlecenia, @nrPMP, @uwagi, @wagaSzacunkowa, @wagaZBiletu, @waga4Procent, @wagaPMPZaokr, @wagaZOpakowaniem, @wagaOpakowania, @rodzajOpakowania, @ktoPrzyjalMaterialy, @dataPrzyjecia, @formaPlatnosci, @sektorMagazyn, @idZlecenia)";
                cmdlog.Prepare();
                cmdlog.Parameters.AddWithValue("@nrProtokolu", poleNrProtokolu.Text);
                cmdlog.Parameters.AddWithValue("@nrZlecenia", poleNrZlecenia.Text);
                cmdlog.Parameters.AddWithValue("@nrPMP", polePMP.Text);
                cmdlog.Parameters.AddWithValue("@uwagi", poleUwagi.Text);
                cmdlog.Parameters.AddWithValue("@wagaSzacunkowa", przecinekNaKropke(poleWagaSzacunkowa.Text));
                cmdlog.Parameters.AddWithValue("@wagaZBiletu", przecinekNaKropke(poleWagaZBiletu.Text));
                cmdlog.Parameters.AddWithValue("@waga4Procent", przecinekNaKropke(poleWaga4Procent.Text));
                cmdlog.Parameters.AddWithValue("@wagaPMPZaokr", przecinekNaKropke(poleWagaPMPZaokr.Text));
                cmdlog.Parameters.AddWithValue("@wagaZOpakowaniem", przecinekNaKropke(poleWagaZOpakowaniem.Text));
                cmdlog.Parameters.AddWithValue("@wagaOpakowania", przecinekNaKropke(poleWagaOpakowania.Text));
                cmdlog.Parameters.AddWithValue("@rodzajOpakowania", poleRodzajOpakowania.Text);
                cmdlog.Parameters.AddWithValue("@ktoPrzyjalMaterialy", poleKtoPrzyjal.Text);
                cmdlog.Parameters.AddWithValue("@dataPrzyjecia", poleDataPrzyjecia.Text);
                cmdlog.Parameters.AddWithValue("@formaPlatnosci", poleFormaPlatnosci.SelectedValue.ToString());
                cmdlog.Parameters.AddWithValue("@sektorMagazyn", poleSektorMagazynu.Text.ToString());
                cmdlog.Parameters.AddWithValue("@idZlecenia", Convert.ToInt16(r_idZlecenia));
                cmdlog.ExecuteNonQuery();

                MySqlCommand cmdpro = new MySqlCommand(stm, conn);
                cmdpro.Connection = conn;
                cmdpro.Prepare();
                cmdpro.CommandText = "SELECT id FROM protokol WHERE nrProtokolu=@nrProtokolu";
                cmdpro.Parameters.AddWithValue("@nrProtokolu", poleNrProtokolu.Text);
                xid = cmdpro.ExecuteScalar().ToString();



                foreach (var item in listaElement)
                {
                    try
                    {

                        MySqlCommand cmdm = new MySqlCommand(stm, conn);
                        cmdm.Connection = conn;

                        cmdm.CommandText = "INSERT INTO material(nrProtokolu, nazwa, waga, ilosc, idProtokolu, wagaLinia, iloscLinia, czyGabaryt) VALUES(@nrProtokolu, @nazwa, @waga, @ilosc, @idProtokolu, @wagaLinia, @iloscLinia, @czyGabaryt)";
                        cmdm.Prepare();
                        if (item.e_waga == "")
                        {
                            cmdm.Parameters.AddWithValue("@waga", 0);
                            cmdm.Parameters.AddWithValue("@wagaLinia", 0);
                        }
                        else
                        {
                            cmdm.Parameters.AddWithValue("@waga", Convert.ToDouble(item.e_waga));
                            cmdm.Parameters.AddWithValue("@wagaLinia", Convert.ToDouble(item.e_waga));
                        }

                        if (item.e_ilosc == "")
                        {
                            cmdm.Parameters.AddWithValue("@ilosc", 0);
                            cmdm.Parameters.AddWithValue("@iloscLinia", 0);
                        }
                        else
                        {
                            cmdm.Parameters.AddWithValue("@ilosc", Convert.ToDouble(item.e_ilosc));
                            cmdm.Parameters.AddWithValue("@iloscLinia", Convert.ToDouble(item.e_ilosc));
                        }

                        cmdm.Parameters.AddWithValue("@nazwa", item.e_rodzaj);
                        cmdm.Parameters.AddWithValue("@nrProtokolu", item.e_nrprotokolu);
                        cmdm.Parameters.AddWithValue("@idProtokolu", Convert.ToInt16(xid));
                        cmdm.Parameters.AddWithValue("@czyGabaryt", item.e_gabaryt);
                        cmdm.ExecuteNonQuery();

                    }
                    catch (MySqlException ex)
                    {
                        System.Windows.MessageBox.Show(ex.ToString());
                    }
                }
                System.Windows.MessageBox.Show("Pomyslnie wprowadzono protokół i materiały do bazy!");
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

            private void WprowadzMaterialyBTN_Click(object sender, RoutedEventArgs e)
        {
            rRozdzielnia1.Visibility = Visibility.Collapsed;
            rRozdzielnia2.Visibility = Visibility.Visible;
            if (dgBramaWyborKlienta.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)dgBramaWyborKlienta.SelectedItems[0];
                r_nrZlecenia = row[2].ToString();
                r_idZlecenia = row[1].ToString();
                               
            }
            else return;
            poleNrZlecenia.Text = r_nrZlecenia.ToString();

        }

       

        private void BlistaUsun_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            klasaElement el = button.DataContext as klasaElement;
           
            string hkontId = el.lp.ToString();
            //  System.Windows.MessageBox.Show(hkontId);

            var kon = listaElement.FirstOrDefault<klasaElement>(d => d.lp == Convert.ToInt16(hkontId));
            listaElement.RemoveAll(x => x.lp == Convert.ToInt16(hkontId));
            liczbaporzadkowa--;
            odswiezPokaz();

        }


        public void odswiezPokaz()
        {
            var source = new BindingSource();
            ObservableCollection<klasaElement> collection = new ObservableCollection<klasaElement>(listaElement);
            source.DataSource = collection;
            lsWybrane.ItemsSource = source;

        }

        private void Br_poleSzukajBrama_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void Ro_poleSzukajBrama_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
                    cmdlog.CommandText = " select * from brama where concat(nrZlecenia,' ',nazwaKlienta,' ',kierowca,' ',pojazd,' ',rejestracja) like @frazaszukana";
                    cmdlog.Prepare();
                    //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                    string temp1 = "%" + ro_poleSzukajBrama.Text + "%";
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


        public void oblicz4procentwagi()
        {
            string temp = poleWagaZBiletu.Text;
            double wartosc = Convert.ToDouble(temp) + 0.04 * (Convert.ToDouble(temp));
            poleWaga4Procent.Text = wartosc.ToString();
            poleWagaPMPZaokr.Text = Math.Ceiling(wartosc).ToString();
        }

        private void DodajKonstrukcjeDoZestawieniaBTN_Click(object sender, RoutedEventArgs e)
        {
            listaElement.Add(new klasaElement(liczbaporzadkowa, poleNrProtokolu.Text, poleNazwaKonstrukcji.SelectedValue.ToString(), poleIloscKonstrukcji.Text, poleWagaKonstrukcji.Text, "magazyn czarny", poleCzyGabaryt.SelectedValue.ToString()));
            poleNazwaKonstrukcji.Text="";
            poleIloscKonstrukcji.Clear();
            poleWagaKonstrukcji.Clear();
            liczbaporzadkowa++;
            odswiezPokaz();
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
                cmdlog.CommandText = "SELECT * FROM brama WHERE godzinaWyjazdu IS NULL AND dataWyjazdu IS NULL";
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

        private void PoleWagaZBiletu_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                oblicz4procentwagi();
            }
        }

        private void PoleIloscKonstrukcji_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                listaElement.Add(new klasaElement(liczbaporzadkowa, poleNrProtokolu.Text, poleNazwaKonstrukcji.SelectedValue.ToString(), poleIloscKonstrukcji.Text, poleWagaKonstrukcji.Text, "magazyn czarny", poleCzyGabaryt.SelectedValue.ToString()));
                poleNazwaKonstrukcji.Text = "";
                poleIloscKonstrukcji.Clear();
                poleWagaKonstrukcji.Clear();
                liczbaporzadkowa++;
                odswiezPokaz();
            }

        }

       

        private void PotwierdzenieCHK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (potwierdzenieCHK.SelectedValue.ToString() == "TAK")
            {
                wprowadzDoBazyRozdzielniaBTN.IsEnabled = true;
            }
            else wprowadzDoBazyRozdzielniaBTN.IsEnabled = false;

        }

        private void PowrotDoWyboruZlecenia_Click(object sender, RoutedEventArgs e)
        {
            rRozdzielnia1.Visibility = Visibility.Visible;
            rRozdzielnia2.Visibility = Visibility.Hidden;
            wczytajSpisKlientow();
        }

        public string przecinekNaKropke(string wejscie)
        {
            string temp = wejscie.Replace(',', '.');
            return temp;
        }

        private void Ro_szukajKlient_Click(object sender, RoutedEventArgs e)
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
                cmdlog.CommandText = " select * from brama where concat(nrZlecenia,' ',nazwaKlienta,' ',kierowca,' ',pojazd,' ',rejestracja) like @frazaszukana";
                cmdlog.Prepare();
                //cmdlog.Parameters.AddWithValue("@frazaszukana", ex_poleSzukajKontener.Text);
                string temp1 = "%" + ro_poleSzukajBrama.Text + "%";
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

        private void Ro_resetujSzukajke_Click(object sender, RoutedEventArgs e)
        {
            wczytajSpisKlientow();
            ro_poleSzukajBrama.Clear();
        }
    }
}
