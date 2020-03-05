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
    /// Logika interakcji dla klasy anulujWjazdWyjazd.xaml
    /// </summary>
    public partial class anulujWjazdWyjazd : Window
    {
        public string id;
        public anulujWjazdWyjazd()
        {
            InitializeComponent();
        }

        public anulujWjazdWyjazd(string xid)
        {
            InitializeComponent();
            id = xid;
        }
    }
}
