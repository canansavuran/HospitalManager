using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KillMeHospitalManege.AppClass
{
    public class SafaTetkik
    {
        public string TC { get; set; }
        public string TetkikIsteyenDoktor { get; set; }
        public string TetkikIsteyenServis { get; set; }
        public string TetkikAdi { get; set; }
        public string TetkikBagliOlduguServis { get; set; }
        public string TetkikDegeri { get; set; }
        public string TetkikSonucu { get; set; }
        public double TetkikUcreti { get; set; }

        //Hastanın tetkik sonuçlarının kaydedilmesi Hastanın Tc si 
        //Tetkiği isteyen doktor ve servis , tetkiğin adı tetkik 
        //biriminn adı tetkik biriminin bağlı olduğu servis tetkik değeri , 
        //tetkik sonucu, tetkik ücreti olan bir xml oluşturulacak.
        
        public int Kaydet()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaTetkik>));

            List<SafaTetkik> liste = Oku();
            if (liste == null)
                liste = new List<SafaTetkik>();

            liste.Add(this);

            StreamWriter DosyaYaz = new StreamWriter("../../Data/Tetkikler.xml");
            serializer.Serialize(DosyaYaz, liste);
            DosyaYaz.Close();

            return 1;
        }

        static public List<SafaTetkik> Oku()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SafaTetkik>));
            List<SafaTetkik> liste = new List<SafaTetkik>();

            StreamReader DosyaOku = new StreamReader("../../Data/Tetkikler.xml");
            try
            {
                var donecek = (List<SafaTetkik>)serializer.Deserialize(DosyaOku);
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
