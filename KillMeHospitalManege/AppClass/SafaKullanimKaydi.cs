using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class SafaKullanimKaydi
    {
        public string TC { get; set; }
        public string Malzeme { get; set; }
        public int Adet { get; set; }
        public int Odendimi { get; set; }
        public double Fiyati { get; set; }
        
        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaKullanimKaydi>));

            List<SafaKullanimKaydi> liste = Oku();
            if (liste == null)
                liste = new List<SafaKullanimKaydi>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/KullanimKaydi.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<SafaKullanimKaydi> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaKullanimKaydi>));
            List<SafaKullanimKaydi> liste = new List<SafaKullanimKaydi>();

            StreamReader DosyaOku = new StreamReader("../../Data/KullanimKaydi.xml");
            try
            {
                var donecek = (List<SafaKullanimKaydi>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch (Exception)
            {
                DosyaOku.Close();
                return null;
            }
        }

        static public int HastaMalzemeKayit(List<SafaKullanimKaydi> gelenListe)
        {
            foreach (var item in gelenListe)
            {
                item.Kaydet();
            }

            return 1;
        }

    }
}
