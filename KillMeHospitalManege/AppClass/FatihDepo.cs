using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class FatihDepo
    {
        public string HangiDepo { get; set; }
        public string UrunAdi { get; set; }
        public int Miktar { get; set; }
        public double Tutar { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }


        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FatihDepo>));

            List<FatihDepo> liste = Oku();
            if (liste == null)
                liste = new List<FatihDepo>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/DepoUrunler.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<FatihDepo> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FatihDepo>));
            List<FatihDepo> liste = new List<FatihDepo>();

            StreamReader DosyaOku = new StreamReader("../../Data/DepoUrunler.xml");
            try
            {
                var donecek = (List<FatihDepo>)serializer.Deserialize(DosyaOku);
                DosyaOku.Close();
                return donecek;
            }
            catch (Exception)
            {
                DosyaOku.Close();
                return null;
            }
        }

        static public List<FatihDepo> depoStok()
        {
            List<FatihDepo> okunan = Oku();
            return okunan.Where(x => x.SonKullanmaTarihi.CompareTo(DateTime.Now) >= 0 && x.Miktar >= 0).ToList();
        }

        static public List<FatihDepo> depoStok(string gelenHangiDepo)
        {
            List<FatihDepo> okunan = Oku();
            return okunan.Where(x => x.HangiDepo == gelenHangiDepo).ToList().Where(x => x.SonKullanmaTarihi.CompareTo(DateTime.Now) >= 0 && x.Miktar >= 0).ToList();
        }

        static public FatihDepo MaxBul(string GelenDepo)
        {
            List<FatihDepo> okunan = Oku();
            return okunan.Where(x => x.HangiDepo == GelenDepo).OrderByDescending(a => a.Miktar).First();
        }

        static public FatihDepo MaxBul()
        {
            List<FatihDepo> okunan = Oku();
            return okunan.OrderByDescending(a => a.Miktar).First();
        }

        static public FatihDepo MinBul(string GelenDepo)
        {
            List<FatihDepo> okunan = Oku();
            return okunan.Where(x => x.HangiDepo == GelenDepo).OrderBy(a => a.Miktar).First();
        }

        static public FatihDepo MinBul()
        {
            List<FatihDepo> okunan = Oku();
            return okunan.OrderBy(a => a.Miktar).First();
        }

        static public List<FatihDepo> UrunlerVeMiktarlari()
        {
            List<FatihDepo> okunan = Oku();
            List<FatihDepo> donecek = new List<FatihDepo>();
            List<FatihDepo> gruplanan = okunan.GroupBy(x => x.UrunAdi).Select(grouping => new FatihDepo //This is your custom class, for binding only
                    {
                        UrunAdi = grouping.Key,
                        Tutar = grouping.First().Tutar,
                        Miktar = grouping.Sum(order => order.Miktar)
                    }).ToList();

            return gruplanan.Where(x => x.SonKullanmaTarihi.CompareTo(DateTime.Now) >= 0 && x.Miktar >= 0).ToList() ;



        }

        public int UruneMiktarEkle()
        {

            List<FatihDepo> liste = Oku();
            if (liste == null)
                liste = new List<FatihDepo>();

            FatihDepo degisecek = liste.Where(x => x.UrunAdi == this.UrunAdi && x.HangiDepo == this.HangiDepo).First();


            liste.Remove(liste.Where(x => x.UrunAdi == this.UrunAdi && x.HangiDepo == this.HangiDepo).First());

            degisecek.Miktar += this.Miktar;
            degisecek.SonKullanmaTarihi = this.SonKullanmaTarihi;

            liste.Add(degisecek);

            XmlSerializer serializer = new XmlSerializer(typeof(List<FatihDepo>));

            StreamWriter DosyaYaz = new StreamWriter("../../Data/DepoUrunler.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }
        
        public int UrunMiktarAzalt()
        {

            List<FatihDepo> liste = Oku();
            if (liste == null)
                liste = new List<FatihDepo>();

            FatihDepo degisecek = liste.Where(x => x.UrunAdi == this.UrunAdi && x.HangiDepo == this.HangiDepo).First();


            liste.Remove(liste.Where(x => x.UrunAdi == this.UrunAdi && x.HangiDepo == this.HangiDepo).First());

            degisecek.Miktar -= this.Miktar;

            liste.Add(degisecek);

            XmlSerializer serializer = new XmlSerializer(typeof(List<FatihDepo>));

            StreamWriter DosyaYaz = new StreamWriter("../../Data/DepoUrunler.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        public int UrunSevkiyati(FatihDepo HangiDepoya)
        {
            this.UrunMiktarAzalt();
            HangiDepoya.Miktar = this.Miktar;
            HangiDepoya.UruneMiktarEkle();
            return 1;
        }


        static public List<FatihDepo> TemizListeAl()
        {
            List<FatihDepo> okunan = Oku();

            okunan.Where(x => x.SonKullanmaTarihi.CompareTo(DateTime.Now)>=0 && x.Miktar>=0);
            return okunan;
        }
    }
}
