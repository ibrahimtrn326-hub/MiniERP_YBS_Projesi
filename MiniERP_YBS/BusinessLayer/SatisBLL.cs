using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniERP_YBS.EntityLayer;
using MiniERP_YBS.DataAccessLayer;

namespace MiniERP_YBS.BusinessLayer
{
    internal class SatisBLL
    {
        public static int SatisYapBLL(Satis s)
        {
            // İŞ KURALLARI: Satış adedi 0'dan büyük olmalı, fiyat 0'dan büyük olmalı
            // Ayrıca Urun, Musteri ve Personel seçilmemiş (0 kalmış) olmamalı.
            if (s.Adet > 0 && s.Fiyat > 0 && s.UrunID > 0 && s.MusteriID > 0 && s.PersonelID > 0)
            {
                // Kurallar tamamsa SQL'e gönder (Hem satışı yazar hem stoku düşer)
                return SatisDAL.SatisYap(s);
            }
            else
            {
                // Hatalı veya eksik veri varsa -1 döndür
                return -1;
            }
        }

    }
}
