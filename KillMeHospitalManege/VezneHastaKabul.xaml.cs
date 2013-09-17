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
using System.Diagnostics;

namespace KillMeHospitalManege
{
    /// <summary>
    /// Interaction logic for VezneHastaKabul.xaml
    /// </summary>
    public partial class VezneHastaKabul : Window
    {
        public VezneHastaKabul()
        {
            InitializeComponent();

            List<ServisKayit> liste = ServisKayit.Oku();
            CBServisler.Items.Clear();
            foreach (var item in liste)
            {

                CBServisler.Items.Add(item.ServisAdi);
            }

            List<CananYeniKayit> liste2 = CananYeniKayit.Oku();
            foreach (var item in liste2)
            {

                CBHastalar.Items.Add(item.TC + " - " + item.AdSoyad);
            }

            int kontrol = 0;
            List<PoliklinikKayit> liste3 = PoliklinikKayit.Oku();
            CBPoliklinikler.Items.Clear();
            foreach (var item2 in liste3)
            {
                foreach (var pol in CBPoliklinikler.Items)
                {
                    if (pol.ToString() == item2.PoliklinikAdi.Split('-')[0])
                        kontrol = 1;
                  
                }
                if(kontrol == 0)
                CBPoliklinikler.Items.Add(item2.PoliklinikAdi.Split('-')[0]);
                kontrol = 0;
               
            }



        }

        private void BTNKaydet_Click(object sender, RoutedEventArgs e)
        {
            CananYeniKayit YeniHasta = new CananYeniKayit();
            YeniHasta.AdSoyad = TBAdSoy.Text;
            YeniHasta.TC = TBTC.Text;
            YeniHasta.Kilo = Convert.ToDouble(TBKilo.Text);
            YeniHasta.Boy = Convert.ToDouble(TBBoy.Text);
            YeniHasta.Cinsiyet = CBCins.Text;
            YeniHasta.DogumTarihi = Convert.ToDateTime(DPDogum.Text);
            YeniHasta.Adres = TBAdres.Text;
            YeniHasta.Telefon = TBTel.Text;
            YeniHasta.Kurumu = CBKurum.Text;
            YeniHasta.KanGrubu = CBKanG.Text;
            
            int i = YeniHasta.Kaydet();
            if (i == 1)
            {
                MessageBox.Show("Hasta Kaydedilmiştir.");
                TBAdres.Text = "";
                TBAdSoy.Text = "";
                TBBoy.Text = "";
                TBKilo.Text = "";
                TBTC.Text = "";
                TBTel.Text = "";
                CBCins.Text = "Erkek";
                CBKanG.Text = "0 RH +";
                CBKurum.Text = "Bağlı Değil";
            }
            else
                MessageBox.Show("Hasta Kaydedilemedi.");


        }

        private void BTNHastaAra_Click(object sender, RoutedEventArgs e)
        {
            CananYeniKayit Bulunan = new CananYeniKayit();
            Bulunan = CananYeniKayit.KisiBul(TBTC1.Text);
            TBAdres1.Text = Bulunan.Adres;
            TBAdSoy1.Text = Bulunan.AdSoyad;
            TBBoy1.Text = Bulunan.Boy.ToString();
            TBKilo1.Text = Bulunan.Kilo.ToString();
            TBTel1.Text = Bulunan.Telefon;
            CBCins1.Text = Bulunan.Cinsiyet;
            CBKanG1.Text = Bulunan.KanGrubu;
            CBKurum1.Text = Bulunan.Kurumu;
            DPDogum1.SelectedDate = Bulunan.DogumTarihi;

        }

        private void BTNGuncelle_Click(object sender, RoutedEventArgs e)
        {
            CananYeniKayit Guncellenecek = new CananYeniKayit();
            Guncellenecek.Adres = TBAdres1.Text;
            Guncellenecek.AdSoyad = TBAdSoy1.Text;
            Guncellenecek.Boy = Convert.ToDouble(TBBoy1.Text);
            Guncellenecek.Cinsiyet = CBCins1.Text;
            Guncellenecek.DogumTarihi = Convert.ToDateTime(DPDogum1.Text);
            Guncellenecek.KanGrubu = CBKanG1.Text;
            Guncellenecek.Kilo = Convert.ToDouble(TBKilo1.Text);
            Guncellenecek.Kurumu = CBKurum1.Text;
            Guncellenecek.TC = TBTC1.Text;
            Guncellenecek.Telefon = TBTel1.Text;
            int i = CananYeniKayit.KisiGuncelle(Guncellenecek);
            if (i == 1)
            {
                MessageBox.Show("Hasta Kaydedilmiştir.");
                TBAdres1.Text = "";
                TBAdSoy1.Text = "";
                TBBoy1.Text = "";
                TBKilo1.Text = "";
                TBTC1.Text = "";
                TBTel1.Text = "";
                CBCins1.Text = "Erkek";
                CBKanG1.Text = "0 RH +";
                CBKurum1.Text = "Bağlı Değil";
            }
            else
                MessageBox.Show("Hasta Kaydedilemedi.");

        }

        private void BTNHastaFiyat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOdeme_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CBServisler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBPoliklinikler.IsEnabled = false;
            CBDoktorlar.IsEnabled = true;
            CBDoktorlar.Items.Clear();
            List<ServisKayit> liste2 = ServisKayit.Oku();

            List<PoliklinikKayit> liste3 = PoliklinikKayit.Oku();

            foreach (var item in liste2)
            {
                if (item.ServisAdi.Split('-')[0] == CBServisler.SelectedValue.ToString())
                {
                    if (item.Poliklinik != null)
                    {
                        foreach (var item2 in liste3)
                        {
                            if (item2.PoliklinikAdi == item.Poliklinik)
                            {
                                CBDoktorlar.Items.Add(item2.DoktorAdi + " / " + item.Poliklinik);
                            }
                        }
                    }
                }
            }


        }

        private void CBPoliklinikler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBServisler.IsEnabled = false;
            CBDoktorlar.IsEnabled = true;
            CBDoktorlar.Items.Clear();
            List<PoliklinikKayit> liste2 = PoliklinikKayit.Oku();
            foreach (var item in liste2)
            {
                if (item.PoliklinikAdi.Split('-')[0] == CBPoliklinikler.SelectedValue.ToString())
                {
                    CBDoktorlar.Items.Add(item.DoktorAdi + " / " + item.PoliklinikAdi);
                }
            }
        }

        private void CBDoktorlar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBSaat.Items.Clear();
            int kontrol = 1;
            List<Randevular> liste = Randevular.Oku();
            DateTime asd = new DateTime();
            asd = asd.AddHours(9);
            asd = asd.AddMinutes(-8);

            for (int i = 0; i < 50; i++)
            {
                asd = asd.AddMinutes(8);
                if (i == 24)
                {
                    asd = asd.AddMinutes(88);
                }
                
                foreach (var item in liste)
                {
                    if (item.DoktorAdi == CBDoktorlar.SelectedValue.ToString())
                    {
                        if (asd.ToShortTimeString() == item.RandevuSaati)
                        {
                            if (item.Ameliyat == 1)//O saatte ameliyat varsa
                            {
                                i = 50;
                                kontrol = 0;
                            }
                            else kontrol = 0;
                        }
                    }
                }

                if (kontrol == 1)
                {
                    CBSaat.Items.Add(asd.ToShortTimeString());
                }

                kontrol = 1;
            }
        }

        private void Kayit_Click(object sender, RoutedEventArgs e)
        {
            Randevular randevu = new Randevular();
            randevu.HastaAdi = CBHastalar.Text;
            randevu.DoktorAdi = CBDoktorlar.Text;
            randevu.RandevuTarihi = tarihimiz.Text;
            randevu.RandevuSaati = CBSaat.Text;
            randevu.Ameliyat = 0;
            randevu.Kaydet();

            MessageBox.Show("Kayıt alındı.");

            this.Close();


        }




    }
}
