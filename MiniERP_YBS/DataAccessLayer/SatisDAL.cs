using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MiniERP_YBS.EntityLayer;

namespace MiniERP_YBS.DataAccessLayer
{
    internal class SatisDAL
    {
        // SATIŞ YAPMA VE STOKTAN DÜŞME İŞLEMİ
        public static int SatisYap(Satis s)
        {
            SqlConnection baglanti = Baglanti.BaglantiAl();
            baglanti.Open();

            // 1. AŞAMA: Satış işlemini Satislar tablosuna kaydet
            SqlCommand komut1 = new SqlCommand("INSERT INTO SatisIslemleri(UrunID, MusteriID, PersonelID, Adet, Fiyat) VALUES (@p1, @p2, @p3, @p4, @p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", s.UrunID);
            komut1.Parameters.AddWithValue("@p2", s.MusteriID);
            komut1.Parameters.AddWithValue("@p3", s.PersonelID);
            komut1.Parameters.AddWithValue("@p4", s.Adet);
            komut1.Parameters.AddWithValue("@p5", s.Fiyat);

            int sonuc = komut1.ExecuteNonQuery();

            // 2. AŞAMA: Eğer satış başarıyla tabloya yazıldıysa, satılan adet kadar stok düş
            if (sonuc > 0)
            {
                SqlCommand komut2 = new SqlCommand("UPDATE Urunler SET StokMiktari = StokMiktari - @pAdet WHERE UrunID = @pUrunID", baglanti);
                komut2.Parameters.AddWithValue("@pAdet", s.Adet);
                komut2.Parameters.AddWithValue("@pUrunID", s.UrunID);
                komut2.ExecuteNonQuery();
            }

            baglanti.Close();
            return sonuc; // Başarılıysa 1 döner, arayüzde buna göre mesaj veririz
        }
    }
}
