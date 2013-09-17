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
using KillMeHospitalManege.AppClass;

namespace KillMeHospitalManege
{
    /// <summary>
    /// Interaction logic for Tetkik.xaml
    /// </summary>
    public partial class Tetkik : Window
    {
        public Tetkik()
        {
            InitializeComponent();

            List<ServisKayit> liste = ServisKayit.Oku();
            CBServisler.Items.Clear();
            foreach (var item in liste)
            {
                CBServisler.Items.Add(item.ServisAdi);
            }

            List<FatihDepo> listem = FatihDepo.depoStok("tetkik");
            CBilaclar.Items.Clear();

            foreach (var item2 in listem)
            {
                CBilaclar.Items.Add(item2.UrunAdi + "/" + item2.Tutar);
            }
        }

        private void BTNEkle_Click(object sender, RoutedEventArgs e)
        {
            TetkikBirimleri EklenecekBirim = new TetkikBirimleri();
            List<string> BirimTestleri = new List<string>();
            EklenecekBirim.BirimAdi = TBTetkikAd.Text;
            EklenecekBirim.BagliOlduguServis = CBServisler.Text;
            foreach (string item in LBTestler.Items)
            {
                EklenecekBirim.YapilabilenTest = item;
                EklenecekBirim.Kaydet();
            }
        }

        private void BTNTestEkle_Click(object sender, RoutedEventArgs e)
        {
            LBTestler.Items.Add(TBTestAd.Text);
        }

        private void BTNTestSil_Click(object sender, RoutedEventArgs e)
        {
            LBTestler.Items.Remove(LBTestler.SelectedItem);
        }

        private void BTNIstekler_Click(object sender, RoutedEventArgs e)
        {
            List<HastaninTetkikKayitlari> Isteklist = new List<HastaninTetkikKayitlari>();
            Isteklist = HastaninTetkikKayitlari.SifirlariGetir();
            LBYapilanIstek.Items.Clear();
            foreach (var item in Isteklist)
            {
                LBYapilanIstek.Items.Add(item.TC +"/"+ item.TetkikAdi);
            }

        }


        private void BTNSonucEkle_Click(object sender, RoutedEventArgs e)
        {
            double malzemeUcreti = 0;
            foreach (string item in LBIlaclistem.Items)
            {
                if (item != "")
                {
                    FatihDepo depomAzalt = new FatihDepo();
                    depomAzalt.UrunAdi = item.Split('/')[0];
                    malzemeUcreti = malzemeUcreti + Convert.ToDouble(item.Split('/')[1]);
                    depomAzalt.HangiDepo = "tetkik";
                    depomAzalt.Miktar = 1;
                    depomAzalt.UrunMiktarAzalt();
                }
            }
            SafaTetkik HastaSonuclar = new SafaTetkik();
            HastaSonuclar.TC = LHastaTc.Content.ToString();
            HastaSonuclar.TetkikAdi = LTahlilAd.Content.ToString();
            HastaSonuclar.TetkikBagliOlduguServis = LServis.Content.ToString();
            HastaSonuclar.TetkikIsteyenDoktor = LDoktor.Content.ToString();
            HastaSonuclar.TetkikIsteyenServis = LServis.Content.ToString();
            HastaSonuclar.TetkikSonucu = CBSonuc.Text;
            HastaSonuclar.TetkikUcreti = Convert.ToDouble(TBUcret.Text);
            HastaSonuclar.TetkikDegeri = TBDeger.Text;
            HastaSonuclar.Kaydet();

            HastaninTetkikKayitlari GecenHasta = new HastaninTetkikKayitlari();
            HastaninTetkikKayitlari Gecir = new HastaninTetkikKayitlari();
            string asd = LBYapilanIstek.SelectedItem.ToString();
            GecenHasta.TC = LBYapilanIstek.SelectedItem.ToString().Split('/')[0];
            GecenHasta.TetkikAdi = LBYapilanIstek.SelectedItem.ToString().Split('/')[1];
            GecenHasta.Durum = 0;
            Gecir = GecenHasta.BilgiDondur();
            Gecir.Durum = 1;
            Gecir.Guncelle();

        }

        private void BTNKullan_Click(object sender, RoutedEventArgs e)
        {
            LBIlaclistem.Items.Add(CBilaclar.Text);
        }

        private void BTNCikar_Click(object sender, RoutedEventArgs e)
        {
            LBIlaclistem.Items.Remove(LBIlaclistem.SelectedItem);
        }

        private void LBYapilanIstek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBYapilanIstek.SelectedIndex != -1)
            {
                HastaninTetkikKayitlari GecenHasta = new HastaninTetkikKayitlari();
                HastaninTetkikKayitlari Gecir = new HastaninTetkikKayitlari();
                string asd = LBYapilanIstek.SelectedItem.ToString();
                GecenHasta.TC = LBYapilanIstek.SelectedItem.ToString().Split('/')[0];
                GecenHasta.TetkikAdi = LBYapilanIstek.SelectedItem.ToString().Split('/')[1];
                GecenHasta.Durum = 0;
                Gecir = GecenHasta.BilgiDondur();
                TISonucTabi.IsSelected = true;
                LDoktor.Content = Gecir.DoktorAdi.Split('/')[0];
                LHastaTc.Content = Gecir.TC;
                LTahlilAd.Content = Gecir.TetkikAdi;
                LServis.Content = Gecir.PoliklinikAdi;
            }
        }
    }
}
