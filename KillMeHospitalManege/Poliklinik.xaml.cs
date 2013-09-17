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
    /// Interaction logic for Poliklinik.xaml
    /// </summary>
    public partial class Poliklinik : Window
    {
        public Poliklinik()
        {
            InitializeComponent();
        }

        private void Kayit_Click(object sender, RoutedEventArgs e)
        {
            int count = 1;
            List<PoliklinikKayit> liste = PoliklinikKayit.Oku();
            if (liste == null)
                liste = new List<PoliklinikKayit>();
            foreach (var item in liste)
            {

                if (item.PoliklinikAdi.Split(' ')[0] == TBAdi.Text)
                {
                    count++;
                }
            }

            PoliklinikKayit pol = new PoliklinikKayit();
            pol.PoliklinikAdi = TBAdi.Text + " - " + count.ToString(); ;
            pol.DoktorAdi = TBDoktoru.Text;

            pol.Kaydet();
            MessageBox.Show("Kayıt alındı.");

        }
    }
}
