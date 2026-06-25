using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniERP_YBS.EntityLayer;

namespace MiniERP_YBS.DataAccessLayer
{
    internal class UrunDAL
    {
        public static List<Urun> UrunleriListele()
        {
            List<Urun> urunler = new List<Urun>();
            SqlConnection baglanti = Baglanti.BaglantiAl();
            SqlCommand komut = new SqlCommand("SELECT * FROM Urunler", baglanti);

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                Urun u = new Urun();
                u.UrunID = Convert.ToInt32(dr["UrunID"]);
                u.UrunAdi = dr["UrunAdi"].ToString();
                u.StokMiktari = Convert.ToInt32(dr["StokMiktari"]);
                u.BirimFiyat = Convert.ToDecimal(dr["BirimFiyat"]);

                urunler.Add(u);
            }
            dr.Close();
            baglanti.Close();

            return urunler;
        }

        // 2. YENİ ÜRÜN EKLEME METODU
        public static int UrunEkle(Urun u)
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();
            SqlCommand komut = new SqlCommand("INSERT INTO Urunler (UrunAdi, StokMiktari, BirimFiyat) VALUES (@p1, @p2, @p3)", baglanti);

            komut.Parameters.AddWithValue("@p1", u.UrunAdi);
            komut.Parameters.AddWithValue("@p2", u.StokMiktari);
            komut.Parameters.AddWithValue("@p3", u.BirimFiyat);

            baglanti.Open();
            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();

            return sonuc;
        }
        public static bool UrunGuncelleDAL(Urun u)
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();

            // Urunler tablosundaki isimler farklıysa (örn: UrunAd, UrunStok vs.) aşağıdaki UPDATE sorgusunda o isimleri düzeltirsin knk
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("UPDATE Urunler SET UrunAdi=@p1, StokMiktari=@p2, BirimFiyat=@p3 WHERE UrunID=@p4", baglanti);

            // u.UrunAdi, u.Stok gibi kısımlar senin Urun.cs içindeki isimlerinle tam aynı olmalı
            komut.Parameters.AddWithValue("@p1", u.UrunAdi);
            komut.Parameters.AddWithValue("@p2", u.StokMiktari);
            komut.Parameters.AddWithValue("@p3", u.BirimFiyat);
            komut.Parameters.AddWithValue("@p4", u.UrunID);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();

            return sonuc > 0; // Eğer 1 veya daha fazla satır güncellendiyse true döner
        }
        public static bool UrunSilDAL(int id)
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();

            // Urunler tablosundan, bize gelen ID'ye sahip ürünü uçuruyoruz
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("DELETE FROM Urunler WHERE UrunID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", id);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();

            return sonuc > 0; // Eğer kayıt silindiyse true döner
        }
    }

}

