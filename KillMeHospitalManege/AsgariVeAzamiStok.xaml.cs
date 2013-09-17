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
using System.Windows.Shapes;

namespace KillMeHospitalManege
{
    /// <summary>
    /// Interaction logic for AsgariVeAzamiStok.xaml
    /// </summary>
    public partial class AsgariVeAzamiStok : Window
    {
        string depo;
        public AsgariVeAzamiStok(string hangiDepo)
        {
            depo=hangiDepo;
            InitializeComponent();
            this.Loaded += AsgariVeAzamiStok_Loaded;
        }

        void AsgariVeAzamiStok_Loaded(object sender, RoutedEventArgs e)
        {
            FatihDepo asgari = new FatihDepo();
            asgari = FatihDepo.MaxBul(depo);
            urunAdi.Content = "Ürün Adı : " + asgari.UrunAdi;
            fiyat.Content = "Fiyat : " + asgari.Tutar;
            miktar.Content = "Miktar : " +asgari.Miktar;

            asgari = FatihDepo.MinBul(depo);
            azamiUrunAdi.Content = "Ürün Adı : " + asgari.UrunAdi;
            azamiFiyat.Content = "Fiyat : " + asgari.Tutar;
            azamiMiktar.Content = "Miktar : " + asgari.Miktar;
        }
    }
}
