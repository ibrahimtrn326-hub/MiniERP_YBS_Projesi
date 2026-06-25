using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MiniERP_YBS.EntityLayer;

namespace MiniERP_YBS.DataAccessLayer
{
    public class MusteriDAL
    {
        // 1. MÜŞTERİLERİ LİSTELEME
        public static List<Musteri> MusterileriListele()
        {
            List<Musteri> musteriler = new List<Musteri>();
            SqlConnection baglanti = Baglanti.BaglantiAl();
            SqlCommand komut = new SqlCommand("SELECT * FROM Musteriler", baglanti);

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                Musteri m = new Musteri();
                m.MusteriID = Convert.ToInt32(dr["MusteriID"]);

                // DÜZELTİLEN YER: Senin tablondaki isimler
                m.SirketAdi_AdSoyad = dr["SirketAdi_AdSoyad"].ToString();
                m.Telefon = dr["Telefon"].ToString();
                m.Email = dr["Email"].ToString();

                musteriler.Add(m);
            }
            dr.Close();
            baglanti.Close();

            return musteriler;
        }

        // 2. YENİ MÜŞTERİ EKLEME
        public static int MusteriEkle(Musteri m)
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();

            // DÜZELTİLEN YER: Senin tablondaki isimler
            SqlCommand komut = new SqlCommand("INSERT INTO Musteriler (SirketAdi_AdSoyad, Telefon, Email) VALUES (@p1, @p2, @p3)", baglanti);

            komut.Parameters.AddWithValue("@p1", m.SirketAdi_AdSoyad);
            komut.Parameters.AddWithValue("@p2", m.Telefon);
            komut.Parameters.AddWithValue("@p3", m.Email);

            baglanti.Open();
            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();

            return sonuc;
        }
        // 1. Müşteri Güncelleme DAL
        public static bool MusteriGuncelleDAL(Musteri m)
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("UPDATE Musteriler SET SirketAdi_AdSoyad=@p1, Telefon=@p2 WHERE MusteriID=@p3", baglanti);

            komut.Parameters.AddWithValue("@p1", m.SirketAdi_AdSoyad);
            komut.Parameters.AddWithValue("@p2", m.Telefon);
            komut.Parameters.AddWithValue("@p3", m.MusteriID);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            return sonuc > 0;
        }

        // 2. Müşteri Silme DAL
        public static bool MusteriSilDAL(int id)
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("DELETE FROM Musteriler WHERE MusteriID=@p1", baglanti);

            komut.Parameters.AddWithValue("@p1", id);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            return sonuc > 0;
        }
    }
}