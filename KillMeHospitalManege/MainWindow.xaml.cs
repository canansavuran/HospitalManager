using KillMeHospitalManege.AppClass;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KillMeHospitalManege
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTNVezne_Click(object sender, RoutedEventArgs e)
        {
            VezneHastaKabul HastaKabul = new VezneHastaKabul();
            HastaKabul.Show();
            //jghtdfıohynr
        }

        private void BTNDoktor_Click(object sender, RoutedEventArgs e)
        {

            DoktorGiris wnd = new DoktorGiris();
            wnd.Show();
            
        }

        private void BTNTolga_Click(object sender, RoutedEventArgs e)
        {
            Poliklinik wnd = new Poliklinik();
            wnd.Show();
        }

        private void BTNGulnur_Click(object sender, RoutedEventArgs e)
        {
            Servis wnd = new Servis();
            wnd.Show();
        }

        private void BTNFAtih_Click(object sender, RoutedEventArgs e)
        {
            DepoListesi depo = new DepoListesi();
            depo.Show();
        }

        private void BTNOda_Click(object sender, RoutedEventArgs e)
        {
            Oda odam = new Oda();
            odam.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FatihDepo.UrunlerVeMiktarlari();
        }

        private void BTNTetkik_Click(object sender, RoutedEventArgs e)
        {
            Tetkik Tetkik = new Tetkik();
            Tetkik.Show();
        }
    }
}
