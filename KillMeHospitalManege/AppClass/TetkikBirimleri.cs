using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class TetkikBirimleri
    {
        public string BirimAdi { get; set; }
        public string BagliOlduguServis { get; set; }
        public string YapilabilenTest { get; set; }

        //Yeni bir Tetkik birimi Xml i oluşturulmalı Tetkik birimin adı 
        //    bağlı olduğu servis ve bu birimde yapılabilen testler olmalı içinde

        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TetkikBirimleri>));

            List<TetkikBirimleri> liste = Oku();
            if (liste == null)
                liste = new List<TetkikBirimleri>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/TetkikBirimleri.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<TetkikBirimleri> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TetkikBirimleri>));
            List<TetkikBirimleri> liste = new List<TetkikBirimleri>();

            StreamReader DosyaOku = new StreamReader("../../Data/TetkikBirimleri.xml");
            try
            {
                var donecek = (List<TetkikBirimleri>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch (Exception)
            {
                DosyaOku.Close();
                return null;
            }
        }

        static public List<TetkikBirimleri> TetkikleriAl()
        {
            List<TetkikBirimleri> okunanlar = Oku();
            okunanlar.GroupBy(x => x.BirimAdi).Select(sec => new TetkikBirimleri
                {
                    BirimAdi = sec.Key,
                    BagliOlduguServis = sec.First().BagliOlduguServis
                }).ToList();
                
            return okunanlar;
        }
       
    }
}
