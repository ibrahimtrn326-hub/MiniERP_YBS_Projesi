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

    }
}
