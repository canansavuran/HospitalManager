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
    /// Interaction logic for DoktorGiris.xaml
    /// </summary>
    public partial class DoktorGiris : Window
    {
        public DoktorGiris()
        {
            InitializeComponent();

            int kontrol = 0;

            List<PoliklinikKayit> liste3 = PoliklinikKayit.Oku();
            CBPoliklinik.Items.Clear();
            foreach (var item2 in liste3)
            {
                foreach (var pol in CBPoliklinik.Items)
                {
                    if (pol.ToString() == item2.PoliklinikAdi.Split('-')[0])
                        kontrol = 1;

                }
                if (kontrol == 0)
                    CBPoliklinik.Items.Add(item2.PoliklinikAdi.Split('-')[0]);
                kontrol = 0;
            }
        }

        private void Kayit_Click(object sender, RoutedEventArgs e)
        {

            DoktorHasta wnd = new DoktorHasta(CBDoktor.Text.ToString(), CBPoliklinik.Text.ToString());
            wnd.Show();
        }

        private void CBPoliklinik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBDoktor.IsEnabled = true;
            CBDoktor.Items.Clear();
            List<PoliklinikKayit> liste2 = PoliklinikKayit.Oku();
            foreach (var item in liste2)
            {
                if (item.PoliklinikAdi.Split('-')[0] == CBPoliklinik.SelectedValue.ToString())
                {
                    CBDoktor.Items.Add(item.DoktorAdi + " / " + item.PoliklinikAdi);
                }
            }
        }
    }
}
