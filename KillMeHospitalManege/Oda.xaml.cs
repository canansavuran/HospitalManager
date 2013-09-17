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
    /// Interaction logic for Oda.xaml
    /// </summary>
    public partial class Oda : Window
    {
        public Oda()
        {
            InitializeComponent();

            List<ServisKayit> liste = ServisKayit.Oku();
            CBServisler.Items.Clear();
            foreach (var item in liste)
            {

                CBServisler.Items.Add(item.ServisAdi);
            }



        }

        private void BTNOdaKayit_Click(object sender, RoutedEventArgs e)
        {

            OdaYeniKayit oda = new OdaYeniKayit();
            oda.ServisAdi = CBServisler.Text;
            oda.OdaNo = OdaNo.Text;
            oda.KisiSayisi = Convert.ToInt32(KisiSayisi.Text);
            oda.Cinsiyet = CBCinsiyet.Text;
            oda.Kaydet();
            MessageBox.Show("Kayıt alındı.");
        }
    }
}
