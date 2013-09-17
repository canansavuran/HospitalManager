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
    /// Interaction logic for HastaServisİslemleri__Ameliyat.xaml
    /// </summary>
    public partial class HastaServisİslemleri__Ameliyat : Window
    {
        public HastaServisİslemleri__Ameliyat(string adi , string doktoradi , string hastaadi)
        {
            InitializeComponent();
            CBHastalar.Items.Clear();
            if (hastaadi == null)
            {
                List<CananYeniKayit> liste = CananYeniKayit.Oku();
                foreach (var item in liste)
                {

                    CBHastalar.Items.Add(item.TC + " - " + item.AdSoyad);
                }
            }
            else
            {
                CBHastalar.Items.Add(hastaadi);
                CBHastalar.IsEnabled = false;
            }

            CBDoktorlar.Items.Clear();


            if (doktoradi == null)
            {
                List<PoliklinikKayit> liste2 = PoliklinikKayit.Oku();
                List<ServisKayit> servis = ServisKayit.Oku();

                foreach (var item in liste2)
                {
                    foreach (var item2 in servis)
                    {
                        if (item2.ServisAdi == adi && item2.Poliklinik == item.PoliklinikAdi)
                            CBDoktorlar.Items.Add(item.DoktorAdi + " / " + item.PoliklinikAdi);
                    }
                }
            }
            else
            {
                CBDoktorlar.Items.Add(doktoradi);
                CBDoktorlar.IsEnabled = false;
            }




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

               
                    CBSaat.Items.Add(asd.ToShortTimeString());
                }

        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            Randevular randevu = new Randevular();
            randevu.HastaAdi = CBHastalar.Text;
            randevu.DoktorAdi = CBDoktorlar.Text;
            randevu.RandevuTarihi = tarihimiz.Text;
            randevu.RandevuSaati = CBSaat.Text;
            randevu.Ameliyat = 1;
            randevu.Kaydet();

            MessageBox.Show("Kayıt alındı.");
        }
    }
}
