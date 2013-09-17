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
    /// Interaction logic for DepoListesi.xaml
    /// </summary>
    public partial class DepoListesi : Window
    {
       
        public DepoListesi()
        {
            InitializeComponent();
            this.Loaded += DepoListesi_Loaded;
        }

        void DepoListesi_Loaded(object sender, RoutedEventArgs e)
        {
            urunListe.Items.Clear();
            
            List<FatihDepo> urunler = FatihDepo.depoStok("servis");
            foreach (var item in urunler)
            {
                urunListe.Items.Add(item.UrunAdi);
            }
        }

        private void urunListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
                List<FatihDepo> urunler = FatihDepo.depoStok("servis");
                foreach (var item in urunler)
                {
                    if (urunListe.SelectedValue.ToString() == item.UrunAdi)
                    {
                        fiyat.Content = "Fiyat " + item.Tutar;
                        miktar.Content = "Miktar " + item.Miktar;
                        toplamTutar.Content = "Toplam Tutar " + item.Miktar * item.Tutar;
                    }
                }
           
        }

        private void azgariAzami_Click(object sender, RoutedEventArgs e)
        {
            AsgariVeAzamiStok stok = new AsgariVeAzamiStok("servis");
            stok.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TumIsletmeler tumu = new TumIsletmeler();
            tumu.ShowDialog();
        }

        private void transfer_Click(object sender, RoutedEventArgs e)
        {
            DepoTransfer transfer = new DepoTransfer();
            transfer.ShowDialog();
        }

    }
}
