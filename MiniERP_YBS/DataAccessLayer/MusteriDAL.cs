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
    }
}