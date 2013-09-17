using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class Randevular
    {
        public string HastaAdi { get; set; }
        public string DoktorAdi { get; set; }
        public string RandevuTarihi  { get; set; }
        public string RandevuSaati { get; set; }
        public int Ameliyat { get; set; }

        public int Kaydet()
        {
           
            XmlSerializer serializer = new XmlSerializer(typeof(List<Randevular>));

            List<Randevular> liste = Oku();
            if (liste == null)
                liste = new List<Randevular>();

            liste.Add(this);
            StreamWriter DosyaYaz = new StreamWriter("../../Data/RandevuKayitlari.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<Randevular> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Randevular>));
            List<Randevular> liste = new List<Randevular>();

            StreamReader DosyaOku = new StreamReader("../../Data/RandevuKayitlari.xml");
            try
            {
                var donecek = (List<Randevular>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch (Exception)
            {
                DosyaOku.Close();
                return null;
            }



        }

    }
}
