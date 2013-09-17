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
    /// Interaction logic for HastaServisİslemleri_Cikis.xaml
    /// </summary>
    public partial class HastaServisİslemleri_Cikis : Window
    {
        public HastaServisİslemleri_Cikis(string adi)
        {
            InitializeComponent();
            List<HastaServisOdasina> liste = HastaServisOdasina.Oku();
            foreach (var item in liste)
            {
                if (item.ServisAdi == adi)
                CBHastalar.Items.Add(item.HastaAdi);
            }

        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            HastaCikis randevu = new HastaCikis();
            randevu.HastaAdi = CBHastalar.Text;
            randevu.HastaMasrafi = Ucret.Text;
            randevu.CikisTarihi = DateTime.Now.ToString();
            randevu.Kaydet();

            MessageBox.Show("Çıkış yapıldı.");
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (CBOdeme.IsChecked == true)
            {
                Kaydet.IsEnabled = true;
            }
        }

        private void CBOdeme_Unchecked(object sender, RoutedEventArgs e)
        {
            
            if (CBOdeme.IsChecked == false)
            {
                Kaydet.IsEnabled = false;
            }
        }

        private void CBHastalar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double ucretimiz = 0;
            TimeSpan tm = new TimeSpan();
            List<HastaServisOdasina> liste = HastaServisOdasina.Oku();
            foreach (var item in liste)
            {
                if (item.HastaAdi == CBHastalar.SelectedValue.ToString())
                {
                    HastaOda.Text = item.OdaNo;
                    TBYatis.Text = item.YatisTarihi;
                }
            }

            List<CananYeniKayit> hasta = CananYeniKayit.Oku();
            foreach (var item in hasta)
            {
                if (item.TC == CBHastalar.SelectedValue.ToString().Split(' ')[0].ToString())
                {
                    CBKurumu.Text = item.Kurumu;
                }
            }
            tm = DateTime.Now - Convert.ToDateTime(TBYatis.Text);
            ucretimiz = Convert.ToInt32(tm.TotalDays)*25;


            if(CBKurumu.Text == "Bağlı Değil")
            {
                Ucret.Text = ucretimiz.ToString();
            }
            else if(CBKurumu.Text == "SGK")
            {
                Ucret.Text = (ucretimiz * 0.1).ToString();
            }
            else if(CBKurumu.Text == "Emekli Sandığı")
            {

                Ucret.Text = (ucretimiz * 0.5).ToString();
            }
            else if(CBKurumu.Text == "Bağkur")
            {
                Ucret.Text = (ucretimiz * 0.6).ToString();
            }

            HastaServisOdasina.Sil(CBHastalar.SelectedValue.ToString());
        }
    }
}
