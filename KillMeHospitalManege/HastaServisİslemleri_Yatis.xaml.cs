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
    /// Interaction logic for HastaServisİslemleri_Yatis.xaml
    /// </summary>
    public partial class HastaServisİslemleri_Yatis : Window
    {
        public static string servisAdi ;
        public HastaServisİslemleri_Yatis(string Servisadi, string doktoradi, string hastaadi)
        {
            InitializeComponent();
            servisAdi = Servisadi;
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
                        if (item2.ServisAdi == servisAdi && item2.Poliklinik == item.PoliklinikAdi)
                            CBDoktorlar.Items.Add(item.DoktorAdi + " / " + item.PoliklinikAdi);
                    }
                }
            }
            else
            {
                CBDoktorlar.Items.Add(doktoradi);
                CBDoktorlar.IsEnabled = false;
            }


            CBOda.Items.Clear();
            List<OdaYeniKayit> liste3 = OdaYeniKayit.Oku();
            foreach (var item in liste3)
            {
                if(item.ServisAdi == Servisadi)
                CBOda.Items.Add(item.OdaNo);
            }
            CBHastalar.SelectedItem = 0;

            CBDoktorlar.SelectedItem = 0;

        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            HastaServisOdasina randevu = new HastaServisOdasina();
            randevu.HastaAdi = CBHastalar.Text;
            randevu.DoktorAdi = CBDoktorlar.Text;
            randevu.OdaNo = CBOda.Text;
            randevu.YatisTarihi = DateTime.Now.ToString();
            randevu.ServisAdi = servisAdi;
            randevu.Kaydet();

            MessageBox.Show("Kayıt alındı.");
        }
    }
}
