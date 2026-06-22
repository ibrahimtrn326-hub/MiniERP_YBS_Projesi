using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MiniERP_YBS.DataAccessLayer
{
    internal class AdminDAL
    {
        public static bool LoginKontrol(string kAdi, string sifre)
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();
            baglanti.Open();

            SqlCommand komut = new SqlCommand("SELECT * FROM Adminler WHERE KullaniciAdi=@p1 AND Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", kAdi);
            komut.Parameters.AddWithValue("@p2", sifre);

            SqlDataReader dr = komut.ExecuteReader();
            bool durum = dr.Read(); // Eğer veritabanında böyle biri varsa 'true', yoksa 'false' döner

            baglanti.Close();
            return durum;
        }
    }
}

