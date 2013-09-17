using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class PoliklinikKayit
    {
        public string PoliklinikAdi { get; set; }
        public string DoktorAdi { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PoliklinikKayit>));

            List<PoliklinikKayit> liste = Oku();



            if (liste == null)
            {
                liste = new List<PoliklinikKayit>();
            }

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/PoliklinikKaydi.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<PoliklinikKayit> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PoliklinikKayit>));
            List<PoliklinikKayit> liste = new List<PoliklinikKayit>();

            StreamReader DosyaOku = new StreamReader("../../Data/PoliklinikKaydi.xml");
            try
            {
                var donecek = (List<PoliklinikKayit>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch
            {
                DosyaOku.Close();
                return null;
            }

        }

        /// <summary>
        /// Kişinin tc numarasından bütün bilgilerini bulur
        /// </summary>
        /// <param name="gelenTC">Kişinin TC si</param>
        /// <returns>Bir kişinin tüm bilgileri</returns>
        //static public CananYeniKayit PolikinikBul(string gelenTC)
        //{

        //    var gelen = Oku();

        //    return gelen.Where(x => x.TC == gelenTC).First();

        //}
    }


}
