using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class SafaHastaTani
    {
        public string TC { get; set; }
        public string Adsoyad { get; set; }
        public string Sikayet { get; set; }
        public string Sonuc { get; set; }
        public string Ilac { get; set; }
        public string Tedavi { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaHastaTani>));

            List<SafaHastaTani> liste = Oku();
            if (liste == null)
                liste = new List<SafaHastaTani>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/HastaTani.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<SafaHastaTani> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaHastaTani>));
            List<SafaHastaTani> liste = new List<SafaHastaTani>();

            StreamReader DosyaOku = new StreamReader("../../Data/HastaTani.xml");
            try
            {
                var donecek = (List<SafaHastaTani>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch (Exception)
            {
                DosyaOku.Close();
                return null;
            }
            
          

        }

        ///// <summary>
        ///// Tc Numarası alınan hastanın adı soyadını döndürür
        ///// </summary>
        ///// <param name="tc">Kişinin TC numarası</param>
        ///// <returns>Adı Soyadı</returns>
        //static public string AdSoyadDondur(string tc)
        //{
        //    return "Dantelsiz Örtü";
        //}

    }
}
