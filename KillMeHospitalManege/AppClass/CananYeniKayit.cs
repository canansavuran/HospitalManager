using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class CananYeniKayit
    {
        public string TC { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public double Boy { get; set; }
        public double Kilo { get; set; }
        public string KanGrubu { get; set; }
        public string Kurumu { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        
        public  int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CananYeniKayit>));
         
            List<CananYeniKayit> liste = Oku();
            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/YeniKayit.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<CananYeniKayit> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CananYeniKayit>));
            List<CananYeniKayit> liste = new List<CananYeniKayit>();

            StreamReader DosyaOku = new StreamReader("../../Data/YeniKayit.xml");
            var donecek = (List<CananYeniKayit>)serializer.Deserialize(DosyaOku);
            DosyaOku.Close();
            return donecek;
            
        }

       /// <summary>
        /// Kişinin tc numarasından bütün bilgilerini bulur
       /// </summary>
       /// <param name="gelenTC">Kişinin TC si</param>
       /// <returns>Bir kişinin tüm bilgileri</returns>
        static public CananYeniKayit KisiBul(string gelenTC)
        {

            var gelen = Oku();

            return gelen.Where(x => x.TC == gelenTC).First();

        }

       
        /// <summary>
        /// Kişi Güncellemek için güncellemek kullanılacak fonksiyon
        /// </summary>
        /// <param name="gelenCanan">Güncellemek istediğiniz kişi</param>
        /// <returns>Güncelleme başarılıysa 1 değilse 0 döndürür</returns>
        static public int KisiGuncelle(CananYeniKayit gelenCanan)
        {
          //  CananYeniKayit silinecek =  KisiBul(gelenCanan.TC);
            List<CananYeniKayit> liste = Oku();
            if (liste == null)
                liste = new List<CananYeniKayit>();

            liste.Remove(liste.Where(x => x.TC == gelenCanan.TC).First()).ToString();

         
            liste.Add(gelenCanan);

            XmlSerializer serializer = new XmlSerializer(typeof(List<CananYeniKayit>));

            StreamWriter DosyaYaz = new StreamWriter("../../Data/YeniKayit.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }
        
    }
}
