using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class HastaCikis
    {
        public string HastaAdi { get; set; }
        public string HastaMasrafi { get; set; }
        public string CikisTarihi { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaCikis>));

            List<HastaCikis> liste = Oku();
            if (liste == null)
                liste = new List<HastaCikis>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/HastaCikis.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<HastaCikis> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaCikis>));
            List<HastaCikis> liste = new List<HastaCikis>();

            StreamReader DosyaOku = new StreamReader("../../Data/HastaCikis.xml");
            try
            {
                var donecek = (List<HastaCikis>)serializer.Deserialize(DosyaOku);
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
