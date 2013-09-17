using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class SafaKisiServis
    {
        public string TC { get; set; }
        public string ServisAdi { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaKisiServis>));

            List<SafaKisiServis> liste = Oku();
            if (liste == null)
                liste = new List<SafaKisiServis>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/ServisKisiKaydi.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<SafaKisiServis> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaKisiServis>));
            List<SafaKisiServis> liste = new List<SafaKisiServis>();

            StreamReader DosyaOku = new StreamReader("../../Data/ServisKisiKaydi.xml");
            try
            {
                var donecek = (List<SafaKisiServis>)serializer.Deserialize(DosyaOku);
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
