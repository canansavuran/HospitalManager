using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class HastaServisOdasina
    {
        public string HastaAdi { get; set; }
        public string OdaNo { get; set; }
        public string DoktorAdi { get; set; }
        public string YatisTarihi { get; set; }
        public string ServisAdi { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaServisOdasina>));

            List<HastaServisOdasina> liste = Oku();
            if (liste == null)
                liste = new List<HastaServisOdasina>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/HastaOda.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<HastaServisOdasina> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaServisOdasina>));
            List<HastaServisOdasina> liste = new List<HastaServisOdasina>();

            StreamReader DosyaOku = new StreamReader("../../Data/HastaOda.xml");
            try
            {
                var donecek = (List<HastaServisOdasina>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch (Exception)
            {
                DosyaOku.Close();
                return null;
            }



        }

        static public int Sil(string gelenIsim)
        {
            List<HastaServisOdasina> okunan = Oku();
            okunan.Remove(okunan.Where(x => x.HastaAdi == gelenIsim).First());

            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaServisOdasina>));

            StreamWriter DosyaYaz = new StreamWriter("../../Data/HastaOda.xml");
            serializer.Serialize(DosyaYaz, okunan);
            DosyaYaz.Close();

            return 1;
        }
    }
}
