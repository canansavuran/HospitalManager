using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class ServisKayit
    {

        public string ServisAdi { get; set; }
        public string Poliklinik { get; set; }
        public int Kapasite { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ServisKayit>));

            List<ServisKayit> liste = Oku();
           
                
           
            if(liste == null)
            {
                liste = new List<ServisKayit>();
            }

                liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/ServisKaydi.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<ServisKayit> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ServisKayit>));
            List<ServisKayit> liste = new List<ServisKayit>();

            StreamReader DosyaOku = new StreamReader("../../Data/ServisKaydi.xml");
            try
            {
                var donecek = (List<ServisKayit>)serializer.Deserialize(DosyaOku);
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
