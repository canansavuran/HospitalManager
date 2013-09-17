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
    /// Interaction logic for DepoTransfer.xaml
    /// </summary>
    public partial class DepoTransfer : Window
    {
        public DepoTransfer()
        {
            InitializeComponent();
        }

        private void liste1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            urunler1.Items.Clear();
            ListBoxItem depoitem = liste1.SelectedItem as ListBoxItem;
            string depo = depoitem.Content.ToString();


            List<FatihDepo> urunler = FatihDepo.depoStok(depo);
            foreach (var item in urunler)
            {
                urunler1.Items.Add(item.UrunAdi);
            }
        }

        private void liste2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            urunler2.Items.Clear();
            FatihDepo depolar = new FatihDepo();
            ListBoxItem depoitem = liste2.SelectedItem as ListBoxItem;
            string depo = depoitem.Content.ToString();


            List<FatihDepo> urunler = FatihDepo.depoStok(depo);
            foreach (var item in urunler)
            {
                urunler2.Items.Add(item.UrunAdi);
            }
        }

        private void urunler2Yolla_Click(object sender, RoutedEventArgs e)
        {

            ListBoxItem gidicekVeri = liste2.SelectedItem as ListBoxItem;
            string gidicekDepo = gidicekVeri.Content.ToString();
            
            
            FatihDepo islenecekVeri = new FatihDepo();
            FatihDepo aktarilacakVeri = new FatihDepo();



            ListBoxItem depoitem = liste1.SelectedItem as ListBoxItem;
            string depo = depoitem.Content.ToString();
            List<FatihDepo> urunler = FatihDepo.depoStok(depo);


            //ListBoxItem eksilecekVeri = urunler1.SelectedItem as ListBoxItem;
            string veri = urunler1.SelectedValue.ToString();

            foreach (var item in urunler)
            {
                if (veri == item.UrunAdi)
                {
                    islenecekVeri.Miktar = Convert.ToInt32(adet.Text);
                    islenecekVeri.Tutar = item.Tutar;
                    islenecekVeri.UrunAdi = item.UrunAdi;
                    islenecekVeri.SonKullanmaTarihi = item.SonKullanmaTarihi;
                    islenecekVeri.HangiDepo = item.HangiDepo;

                    aktarilacakVeri.HangiDepo = gidicekDepo;
                    aktarilacakVeri.UrunAdi= item.UrunAdi;


                    islenecekVeri.UrunSevkiyati(aktarilacakVeri);
                    MessageBox.Show("Aktarım Gerçekleşti.");
                }
            }

        }

        private void urunler1Yolla_Click(object sender, RoutedEventArgs e)
        {


            ListBoxItem gidicekVeri = liste1.SelectedItem as ListBoxItem;
            string gidicekDepo = gidicekVeri.Content.ToString();


            FatihDepo islenecekVeri = new FatihDepo();
            FatihDepo aktarilacakVeri = new FatihDepo();



            ListBoxItem depoitem = liste2.SelectedItem as ListBoxItem;
            string depo = depoitem.Content.ToString();
            List<FatihDepo> urunler = FatihDepo.depoStok(depo);


            //ListBoxItem eksilecekVeri = urunler1.SelectedItem as ListBoxItem;
            string veri = urunler2.SelectedValue.ToString();

            foreach (var item in urunler)
            {
                if (veri == item.UrunAdi)
                {
                    islenecekVeri.Miktar = Convert.ToInt32(adet.Text);
                    islenecekVeri.Tutar = item.Tutar;
                    islenecekVeri.UrunAdi = item.UrunAdi;
                    islenecekVeri.SonKullanmaTarihi = item.SonKullanmaTarihi;
                    islenecekVeri.HangiDepo = item.HangiDepo;

                    aktarilacakVeri.HangiDepo = gidicekDepo;
                    aktarilacakVeri.UrunAdi = item.UrunAdi;


                    islenecekVeri.UrunSevkiyati(aktarilacakVeri);
                    MessageBox.Show("Aktarım Gerçekleşti.");
                }
            }


        }
    }
}
