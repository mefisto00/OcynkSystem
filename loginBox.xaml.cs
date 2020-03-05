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
using System.Security.Cryptography;

namespace Ocynkownia0811
{
    /// <summary>
    /// Logika interakcji dla klasy loginBox.xaml
    /// </summary>
    public partial class loginBox : Window
    {
        public loginBox()
        {
            InitializeComponent();
        }

        private void L_pass_KeyDown(object sender, KeyEventArgs e)
        {
            walidacja(l_login.Text, l_pass.Password.ToString());
        }

        private void L_zaloguj_Click(object sender, RoutedEventArgs e)
        {
            walidacja(l_login.Text, l_pass.Password.ToString());
        }

        public string kodowanieDoMD5(string wartosc)
        {

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(wartosc);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();
            return encoded;
        }



        public void walidacja(string logi, string hasl)
        {
            string sciezka = "baza.config";
            string konfiguracja = File.ReadAllText(sciezka);
            string haslmd5 = kodowanieDoMD5(hasl);
            bool czyPrawidlowe = false;

            try
            {

                MySqlConnection conn = null;
                conn = new MySqlConnection(konfiguracja);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmdlog = new MySqlCommand(stm, conn);
                cmdlog.Connection = conn;
                cmdlog.CommandText = "SELECT * FROM logowanie WHERE login=@login";
                cmdlog.Prepare();
                cmdlog.Parameters.AddWithValue("@login", l_login.Text);
                cmdlog.ExecuteNonQuery();
                Console.WriteLine("larum parum");
                MySqlDataReader rdr = cmdlog.ExecuteReader();


                //   Console.WriteLine("{0} {1} {2}", rdr.GetName(0), rdr.GetName(1).PadLeft(18), rdr.GetName(2).PadLeft(18));
                while (rdr.Read())
                {
                    //  Console.WriteLine(rdr.GetString(0).PadRight(18) + rdr.GetString(1).PadRight(18)+rdr.GetString(2));
                    if (rdr.GetString(2) == haslmd5)
                    {
                        czyPrawidlowe = true;

                    }
                    else czyPrawidlowe = false;
                }

                if (czyPrawidlowe == true)
                {
                    Console.WriteLine("OK");

                    //3-6
                    MainWindow mw = new MainWindow(l_login.Text);

                    //  MainWindow mw = new MainWindow(logx, przelozonyx);
                    this.Close();
                    mw.Show();
                    System.Uri uri = new System.Uri("pack://application:,,,,/CaroSYSTEM2809;component/MainWindow.xaml");
                    Application.Current.MainWindow = mw;

                }
                else
                {
                    Console.WriteLine("CHUJ");
                    MessageBox.Show("Twoje dane logowania są nieprawidłowe!", "Błąd logowania!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                /*  Console.WriteLine("XD");
                          MessageBox.Show("Walidacja poprawna, witaj: " + reader.GetString("log_imie") + " " + reader.GetString("log_nazwisko"));
                          MainWindow mw = new MainWindow(Convert.ToInt32(reader.GetString("log_id")), reader.GetString("log_login"), reader.GetString("log_imie"), reader.GetString("log_nazwisko"), reader.GetString("log_mail"), reader.GetString("log_telefon"));



                          this.Hide();
                          mw.Show();
                          // Console.WriteLine("{0}", Application.Current.StartupUri.ToString());
                          //Application.Current.StartupUri = (Uri)"MainWindow.xaml";
                          System.Uri uri = new System.Uri("pack://application:,,,,/Caro2_2904x;component/MainWindow.xaml");
                          Application.Current.MainWindow = mw;


                      */
            }
            catch (MySqlException se)
            {
                MessageBox.Show("Wystąpił błąd połączenia: " + se.ToString());
            }



        }
    }
}
