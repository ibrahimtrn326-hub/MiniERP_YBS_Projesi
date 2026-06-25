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
        public static bool UrunGuncelleBLL(Urun u)
        {
            // Ürün adı boş olmasın ve stok/fiyat eksi değerlere düşmesin diye güvenlik koyuyoruz
            if (u.UrunAdi != "" && u.UrunAdi.Length >= 2 && u.StokMiktari >= 0 && u.BirimFiyat > 0)
            {
                return UrunDAL.UrunGuncelleDAL(u); // Şartlar sağlanıyorsa DAL katmanına gönder
            }
            else
            {
                return false; // Hatalı giriş varsa işlemi reddet
            }
        }
        public static bool UrunSilBLL(int id)
        {
            // ID 0'dan büyükse (yani gerçekten geçerli bir ürün seçilmişse) DAL katmanına gönder ve sil
            if (id > 0)
            {
                return UrunDAL.UrunSilDAL(id);
            }
            else
            {
                return false; // Hatalı bir ID geldiyse işlemi reddet
            }
        }
    }
}
