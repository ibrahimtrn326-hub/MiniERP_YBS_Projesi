using MiniERP_YBS.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_YBS.DataAccessLayer
{
   public class deparmanDal
    {
        public static List<Departman> DepartmanlariListele()
        {
            List<Departman> departmanlar = new List<Departman>();
            SqlConnection baglanti = Baglanti.BaglantiAl();

            // SQL sorgumuzu yazıyoruz
            SqlCommand komut = new SqlCommand("SELECT * FROM Departmanlar", baglanti);

            baglanti.Open();
            SqlDataReader dr = komut.ExecuteReader(); // Verileri okumak için

            while (dr.Read())
            {
                Departman dep = new Departman();
                dep.DepartmanID = Convert.ToInt32(dr["DepartmanID"]);
                dep.DepartmanAdi = dr["DepartmanAdi"].ToString();

                departmanlar.Add(dep); // Listeye ekle
            }
            dr.Close();
            baglanti.Close();

            return departmanlar;
        }
        // 1. Departman Silme DAL
        public static bool DepartmanSilDAL(int id)
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("DELETE FROM Departmanlar WHERE DepartmanID=@p1", baglanti);

            komut.Parameters.AddWithValue("@p1", id);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            return sonuc > 0;
        }

        // 2. Departman Güncelleme DAL
        public static bool DepartmanGuncelleDAL(Departman d)
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();
            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("UPDATE Departmanlar SET DepartmanAdi=@p1 WHERE DepartmanID=@p2", baglanti);

            komut.Parameters.AddWithValue("@p1", d.DepartmanAdi);
            komut.Parameters.AddWithValue("@p2", d.DepartmanID);

            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            int sonuc = komut.ExecuteNonQuery();
            baglanti.Close();
            return sonuc > 0;
        }
        public static bool DepartmanEkleDAL(Departman d)
        {
            System.Data.SqlClient.SqlConnection baglanti = MiniERP_YBS.DataAccessLayer.Baglanti.BaglantiAl();

            System.Data.SqlClient.SqlCommand komut = new System.Data.SqlClient.SqlCommand("INSERT INTO Departmanlar (DepartmanAdi) VALUES (@p1)", baglanti);

            // Senin BLL'de kullandığın isme (DepartmanAdi) göre uyarladım
            komut.Parameters.AddWithValue("@p1", d.DepartmanAdi);

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
