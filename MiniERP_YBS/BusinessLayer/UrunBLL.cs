using MiniERP_YBS.DataAccessLayer;
using MiniERP_YBS.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_YBS.BusinessLayer
{
    internal class UrunBLL
    {
        public static List<Urun> UrunleriGetirBLL()
        {
            return UrunDAL.UrunleriListele();
        }

        // 2. YENİ ÜRÜN EKLEME KURALLARI
        public static int UrunEkleBLL(Urun u)
        {
            // İŞ KURALLARI: Ürün adı boş olamaz, stok 0'dan küçük olamaz, fiyat 0'dan büyük olmalı.
            if (u.UrunAdi != "" && u.StokMiktari >= 0 && u.BirimFiyat > 0)
            {
                // Kurallara uyuyorsa DAL'a (SQL'e) gönder
                return UrunDAL.UrunEkle(u);
            }
            else
            {
                // Kurallara uymuyorsa kaydetme
                return -1;
            }
        }
    }
}
