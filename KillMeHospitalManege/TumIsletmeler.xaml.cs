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
    /// Interaction logic for TumIsletmeler.xaml
    /// </summary>
    public partial class TumIsletmeler : Window
    {
        public TumIsletmeler()
        {
            InitializeComponent();
            this.Loaded += TumIsletmeler_Loaded;

        }

        void TumIsletmeler_Loaded(object sender, RoutedEventArgs e)
        {
            urunListe.Items.Clear();
            List<FatihDepo> urunler = FatihDepo.UrunlerVeMiktarlari();
            foreach (var item in urunler)
            {
                urunListe.Items.Add(item.UrunAdi);
            }


        }

        private void urunListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            List<FatihDepo> urunler = FatihDepo.UrunlerVeMiktarlari();

            foreach (var item in urunler)
            {
                if (urunListe.SelectedValue.ToString() == item.UrunAdi)
                {
                    fiyat.Content = "Fiyat " + item.Tutar;
                    miktar.Content = "Miktar " + item.Miktar;
                    toplamTutar.Content = "Toplam Tutar " + item.Miktar * item.Tutar;
                    groupName.Header = item.UrunAdi;
                }
            }

        }

        private void azgariAzami_Click(object sender, RoutedEventArgs e)
        {

        }

        private void transfer_Click(object sender, RoutedEventArgs e)
        {
            DepoTransfer transfer = new DepoTransfer();
            transfer.Show();
        }
    }
}

