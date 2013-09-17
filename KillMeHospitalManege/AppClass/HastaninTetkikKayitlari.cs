using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class HastaninTetkikKayitlari
    {
        public string TC { get; set; }
        public string TetkikAdi { get; set; }
        public string DoktorAdi { get; set; }
        public string PoliklinikAdi { get; set; }
        public int Durum { get; set; }

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaninTetkikKayitlari>));

            List<HastaninTetkikKayitlari> liste = Oku();
            if (liste == null)
                liste = new List<HastaninTetkikKayitlari>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/HastaninTetkikKayitlari.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<HastaninTetkikKayitlari> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaninTetkikKayitlari>));
            List<HastaninTetkikKayitlari> liste = new List<HastaninTetkikKayitlari>();

            StreamReader DosyaOku = new StreamReader("../../Data/HastaninTetkikKayitlari.xml");
            try
            {
                var donecek = (List<HastaninTetkikKayitlari>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch (Exception)
            {
                DosyaOku.Close();
                return null;
            }
        }

        static public List<HastaninTetkikKayitlari> SifirlariGetir()
        {
            List<HastaninTetkikKayitlari> okunan = Oku();
            
            return okunan.Where(x =>x.Durum == 0).ToList();
        }

        public HastaninTetkikKayitlari BilgiDondur()
        {
            List<HastaninTetkikKayitlari> okunan = Oku();
            return okunan.Where(x => x.TC == this.TC && x.Durum == 0 && x.TetkikAdi == this.TetkikAdi).First();
        }

       
      
        public int Guncelle()
        {
            List<HastaninTetkikKayitlari> okunan = Oku();
            okunan.Remove(okunan.Where(x => x.TC == this.TC && x.Durum == 0 && x.TetkikAdi == this.TetkikAdi).First());
            okunan.Add(this);

            XmlSerializer serializer = new XmlSerializer(typeof(List<HastaninTetkikKayitlari>));

            StreamWriter DosyaYaz = new StreamWriter("../../Data/HastaninTetkikKayitlari.xml");
            serializer.Serialize(DosyaYaz, okunan);
            DosyaYaz.Close();

            return 1;
        }

    }
}
