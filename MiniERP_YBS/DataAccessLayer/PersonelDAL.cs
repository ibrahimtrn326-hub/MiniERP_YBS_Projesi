using MiniERP_YBS.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_YBS.DataAccessLayer
{
    internal class PersonelDAL
    {
        public static List<Personel> PersonelleriListele()
        {
            List<Personel> personeller = new List<Personel>();
            SqlConnection baglanti = Baglanti.BaglantiAl();
            SqlCommand komut = new SqlCommand("SELECT * FROM Personeller", baglanti);

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                Personel p = new Personel();
                p.PersonelID = Convert.ToInt32(dr["PersonelID"]);
                p.AdSoyad = dr["AdSoyad"].ToString();
                p.DepartmanID = Convert.ToInt32(dr["DepartmanID"]);
                p.Maas = Convert.ToDecimal(dr["Maas"]);
                p.GirisTarihi = Convert.ToDateTime(dr["GirisTarihi"]);

                personeller.Add(p);
            }
            dr.Close();
            baglanti.Close();

            return personeller;
        }

        // 2. YENİ PERSONEL EKLEME
        public static int PersonelEkle(Personel p)
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();

            // @p1, @p2 gibi parametreler kullanarak güvenliği sağlıyoruz
            SqlCommand komut = new SqlCommand("INSERT INTO Personeller (AdSoyad, DepartmanID, Maas, GirisTarihi) VALUES (@p1, @p2, @p3, @p4)", baglanti);

            komut.Parameters.AddWithValue("@p1", p.AdSoyad);
            komut.Parameters.AddWithValue("@p2", p.DepartmanID);
            komut.Parameters.AddWithValue("@p3", p.Maas);
            komut.Parameters.AddWithValue("@p4", p.GirisTarihi);

            baglanti.Open();
            int sonuc = komut.ExecuteNonQuery(); // Ekleme, Silme, Güncelleme işlemleri için NonQuery kullanılır
            baglanti.Close();

            return sonuc; // 0'dan büyük bir değer dönerse işlem başarılı demektir
        }
    }
}

