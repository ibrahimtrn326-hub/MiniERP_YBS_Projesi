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
    }

}

