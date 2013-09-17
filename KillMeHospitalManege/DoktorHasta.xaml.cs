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
    /// Interaction logic for DoktorHasta.xaml
    /// </summary>
    public partial class DoktorHasta : Window
    {
        public static string doktoradi,poliAdi;
        public DoktorHasta(string doktorAdi,string poladi)
        {
            InitializeComponent();
            doktoradi = doktorAdi;
            poliAdi = poladi;
            List<ServisKayit> liste = ServisKayit.Oku();
            ComboServis.Items.Clear();
            foreach (var item in liste)
            {

                ComboServis.Items.Add(item.ServisAdi);
            }


            List<FatihDepo> listem = FatihDepo.depoStok("poliknilik");
            ComboMalzeme.Items.Clear();
            
            foreach (var item2 in listem)
            {
                ComboMalzeme.Items.Add(item2.UrunAdi +" "+item2.Tutar);
            }
            List<TetkikBirimleri> listemTetkik = TetkikBirimleri.Oku();
            tetkikCombo.Items.Clear();
            
            foreach (var item3 in listemTetkik)
            {
                if (poliAdi.IndexOf(item3.BagliOlduguServis)>=0)
                {
                    tetkikCombo.Items.Add(item3.YapilabilenTest);
                }
            }

        }

        private void BtnKayit3_Click(object sender, RoutedEventArgs e)
        {
            SafaHastaTani taniKayit = new SafaHastaTani();
            taniKayit.TC = TbTCNo.Text;
            taniKayit.Adsoyad = TbAd.Text;
            taniKayit.Sikayet = TbSikayet.Text;
            taniKayit.Sonuc = TbSonuc.Text;
            taniKayit.Ilac = TbIlac.Text;
            taniKayit.Tedavi = TbTedavi.Text;
            taniKayit.Kaydet();
            MenuServis.IsEnabled = true;
            MenuTetkik.IsEnabled = true;
            MnuMalzeme.IsEnabled = true;
            MessageBox.Show("İşleminiz başarıyla gerçekleşti");
           
           
        }

        private void BtnAra_Click(object sender, RoutedEventArgs e)
        {
            TbAd.Text = CananYeniKayit.KisiBul(TbTCNo.Text).AdSoyad;
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            ListMalzemeListesi.Items.Add(ComboMalzeme.Text);
        }

        private void BtnSil_Click(object sender, RoutedEventArgs e)
        {
            ListMalzemeListesi.Items.Remove(ListMalzemeListesi.SelectedItem);
        }

        private void BtnKayit_Click(object sender, RoutedEventArgs e)
        {
            HastaninTetkikKayitlari Tetkim = new HastaninTetkikKayitlari();
            Tetkim.TC = TbTCNo.Text;
            Tetkim.TetkikAdi = tetkikCombo.Text;
            Tetkim.Durum = 0;
            Tetkim.PoliklinikAdi = poliAdi;
            Tetkim.DoktorAdi = doktoradi;
            Tetkim.Kaydet();
        }

        private void BtnKayit2_Click(object sender, RoutedEventArgs e)
        {
            
            CananYeniKayit yenim=new CananYeniKayit();
            string ad=TbTCNo.Text + " - " + CananYeniKayit.KisiBul(TbTCNo.Text).AdSoyad;
            if (CbTur.Text == "Ameliyat")
            {
                HastaServisİslemleri__Ameliyat yeni = new HastaServisİslemleri__Ameliyat(ComboServis.Text, doktoradi, ad);
                yeni.Show();
            }
            else if (CbTur.Text == "Yatış")
            {
                HastaServisİslemleri_Yatis yeni = new HastaServisİslemleri_Yatis(ComboServis.Text, doktoradi, ad);
                yeni.Show();
            }
            
        }

        private void BtnnKaydet_Click(object sender, RoutedEventArgs e)
        {
           //////
            foreach (string item in ListMalzemeListesi.Items)
            {
                FatihDepo depomAzalt = new FatihDepo();
                depomAzalt.UrunAdi = item.Split(' ')[0];
                depomAzalt.HangiDepo = "poliknilik";
                depomAzalt.Miktar = 1;
                depomAzalt.UrunMiktarAzalt();
                
            }
            foreach (string itemm in ListMalzemeListesi.Items)
            {
                SafaKullanimKaydi kullandigim = new SafaKullanimKaydi();
                kullandigim.Adet = 1;
                kullandigim.Malzeme = itemm.Split(' ')[0];
                kullandigim.Fiyati = Convert.ToInt32(itemm.Split(' ')[1]);
                kullandigim.Odendimi = 0;
                kullandigim.TC = TbTCNo.Text;
                kullandigim.Kaydet();
            }

        }
    }
}
