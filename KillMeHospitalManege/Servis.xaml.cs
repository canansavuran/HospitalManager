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
    /// Interaction logic for Servis.xaml
    /// </summary>
    public partial class Servis : Window
    {
        public Servis()
        {
            InitializeComponent();
            List<ServisKayit> liste = ServisKayit.Oku();
            foreach (var item in liste)
            {

                CBServisler.Items.Add(item.ServisAdi);
            }


	            List<PoliklinikKayit> liste2 = PoliklinikKayit.Oku();
                foreach (var item2 in liste2)
                {

                    CBPoliklinik.Items.Add(item2.PoliklinikAdi);

                }

        }

        private void Yatis_Click(object sender, RoutedEventArgs e)
        {
            HastaServisİslemleri_Yatis yeni = new HastaServisİslemleri_Yatis(CBServisler.Text, null, null);
            yeni.Show();
        }

        private void Ameliyat_Click(object sender, RoutedEventArgs e)
        {
            HastaServisİslemleri__Ameliyat yeni = new HastaServisİslemleri__Ameliyat(CBServisler.Text, null, null);
            yeni.Show();
        }

        private void Cikis_Click(object sender, RoutedEventArgs e)
        {
            HastaServisİslemleri_Cikis yeni = new HastaServisİslemleri_Cikis(CBServisler.Text);
            yeni.Show();
        }

        private void Kayit_Click(object sender, RoutedEventArgs e)
        {
            ServisKayit YeniServis = new ServisKayit();
            YeniServis.ServisAdi = TBAdi.Text;
            YeniServis.Poliklinik = CBPoliklinik.Text;
            YeniServis.Kapasite = Convert.ToInt32(TBKapasite.Text);

            YeniServis.Kaydet();
            MessageBox.Show("Kayıt alındı.");
        }

        private void CBServisler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBAdi1.IsEnabled = true;
            TBKapasite1.IsEnabled = true;
            TBPoliklinik.IsEnabled = true;
            BTNDepo.IsEnabled = true;
            Yatis.IsEnabled = true;
            Ameliyat.IsEnabled = true;
            Cikis.IsEnabled = true;

            TBAdi1.Text = CBServisler.SelectedValue.ToString();
            
            List<ServisKayit> liste = ServisKayit.Oku();
            if (liste == null)
                liste = new List<ServisKayit>();
             foreach (var item in liste)
	            {
		 
                        if(item.ServisAdi == TBAdi1.Text)
                        {
                            TBKapasite1.Text = item.Kapasite.ToString();
                            TBPoliklinik.Text = item.Poliklinik;
                            break;
                        }
	            }
        }
    }
}
