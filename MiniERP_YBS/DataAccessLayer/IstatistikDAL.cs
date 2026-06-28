using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MiniERP_YBS.DataAccessLayer
{
    internal class IstatistikDAL
    {
        // 1. Toplam Ürün Sayısı
        public static int UrunSayisiGetir()
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Urunler", baglanti);
            int sayi = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            return sayi;
        }

        // 2. Toplam Müşteri Sayısı
        public static int MusteriSayisiGetir()
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Musteriler", baglanti);
            int sayi = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            return sayi;
        }

        // 3. Toplam Satış Adedi 
        public static int ToplamSatisAdediGetir()
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();
            baglanti.Open();
            // Not: Dünkü krizde tablomuzun adını 'SatisIslemleri' yapmıştık, onu çağırıyoruz!
            // ISNULL kullanıyoruz ki tabloda hiç satış yoksa program 'Null' hatası verip çökmesin, 0 dönsün.
            SqlCommand komut = new SqlCommand("SELECT ISNULL(SUM(Adet), 0) FROM SatisIslemleri", baglanti);
            int sayi = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            return sayi;
        }

        // 4. Toplam Ciro (Kasadaki Toplam Para)
        public static decimal ToplamCiroGetir()
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();
            baglanti.Open();
            // Adet ile Fiyatı çarpıp kümülatif toplamını alıyoruz:
            SqlCommand komut = new SqlCommand("SELECT ISNULL(SUM(Adet * Fiyat), 0) FROM SatisIslemleri", baglanti);
            decimal ciro = Convert.ToDecimal(komut.ExecuteScalar());
            baglanti.Close();
            return ciro;
        }
        public static int ToplamPersonelDAL()
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();

            // COUNT(*) -> Tablodaki tüm satırları sayar
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Personeller", baglanti);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            // ExecuteScalar() tek bir değer döndüreceği zaman kullanılır!
            int sonuc = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            return sonuc;
        }

        // 2. Şirketin Toplam Maaş Giderini Hesaplayan Metot
        public static decimal ToplamMaasDAL()
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();

            // SUM(Maas) -> Maaş sütunundaki tüm değerleri toplar
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("SELECT SUM(Maas) FROM Personeller", baglanti);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            // Maaş ondalıklı olabileceği için decimal'a çeviriyoruz
            decimal sonuc = Convert.ToDecimal(komut.ExecuteScalar());
            baglanti.Close();
            return sonuc;
        }

        // 3. En Yüksek Maaşı Bulan Metot
        public static decimal EnYuksekMaasDAL()
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();

            // MAX(Maas) -> Maaş sütunundaki en büyük değeri bulur
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("SELECT MAX(Maas) FROM Personeller", baglanti);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            decimal sonuc = Convert.ToDecimal(komut.ExecuteScalar());
            baglanti.Close();
            return sonuc;
        }

    }
}
