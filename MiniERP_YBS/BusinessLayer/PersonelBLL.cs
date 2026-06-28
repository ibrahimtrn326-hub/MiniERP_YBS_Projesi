using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniERP_YBS.EntityLayer;
using MiniERP_YBS.DataAccessLayer;

namespace MiniERP_YBS.BusinessLayer
{
    public class PersonelBLL
    {
        public static List<Personel> PersonelleriGetirBLL()
        {
            // Listeleme işlemi için ekstra bir kurala gerek yok, DAL'daki listeleme metodunu çağırıyoruz.
            return PersonelDAL.PersonelleriListele();
        }

        // 2. YENİ PERSONEL EKLEME KURALLARI
        public static int PersonelEkleBLL(Personel p)
        {
            // İŞ KURALLARI (BUSINESS RULES) BURADA DEVREYE GİRİYOR
            // İsim boş olamaz, en az 3 harfli olmalı ve maaş 17002 TL'den (asgari ücret) az olamaz

            if (p.AdSoyad != "" && p.AdSoyad.Length >= 3 && p.Maas >= 17002)
            {
                // Kurallara uyuyorsa, Data Access Layer'a (SQL'e) gönder
                return PersonelDAL.PersonelEkle(p);
            }
            else
            {
                // Kurallara uymuyorsa kaydetme ve hata kodu olarak -1 döndür
                return -1;
            }
        }
        // 1. Personel Güncelleme BLL
        public static bool PersonelGuncelleBLL(Personel p)
        {
            // İsim boş olmasın ve maaş 0'dan büyük olsun
            if (p.AdSoyad != "" && p.Maas > 0 && p.DepartmanID > 0)
            {
                return PersonelDAL.PersonelGuncelleDAL(p);
            }
            return false;
        }

        // 2. Personel Silme BLL
        public static bool PersonelSilBLL(int id)
        {
            if (id > 0)
            {
                return PersonelDAL.PersonelSilDAL(id);
            }
            return false;
        }
    }
}

