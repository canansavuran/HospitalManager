using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class OdaYeniKayit
    {
        public string ServisAdi { get; set; }
        public string OdaNo { get; set; }
        public int KisiSayisi { get; set; }
        public string Cinsiyet { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<OdaYeniKayit>));

            List<OdaYeniKayit> liste = Oku();



            if (liste == null)
            {
                liste = new List<OdaYeniKayit>();
            }

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/OdaKaydi.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<OdaYeniKayit> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<OdaYeniKayit>));
            List<OdaYeniKayit> liste = new List<OdaYeniKayit>();

            StreamReader DosyaOku = new StreamReader("../../Data/OdaKaydi.xml");
            try
            {
                var donecek = (List<OdaYeniKayit>)serializer.Deserialize(DosyaOku);
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
