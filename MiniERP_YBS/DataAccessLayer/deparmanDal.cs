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
    }
}
