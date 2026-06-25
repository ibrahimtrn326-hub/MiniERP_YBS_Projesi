using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniERP_YBS.EntityLayer;
using MiniERP_YBS.DataAccessLayer;

namespace MiniERP_YBS.BusinessLayer
{
    internal class MusteriBLL
    {
        // 1. MÜŞTERİLERİ GETİR
        public static List<Musteri> MusterileriGetirBLL()
        {
            return MusteriDAL.MusterileriListele();
        }

        // 2. MÜŞTERİ EKLEME KURALLARI
        public static int MusteriEkleBLL(Musteri m)
        {
            // İŞ KURALLARI: İsim boş olamaz, Telefon en az 10 haneli olmalı
            if (m.SirketAdi_AdSoyad != "" && m.Telefon.Length >= 10)
            {
                // Kurallara uyuyorsa DAL'a yolla
                return MusteriDAL.MusteriEkle(m);
            }
            else
            {
                // Kurallara uymuyorsa hata fırlat
                return -1;
            }
        }
        // 1. Müşteri Güncelleme BLL
        public static bool MusteriGuncelleBLL(Musteri m)
        {
            if (m.SirketAdi_AdSoyad != "" && m.Telefon.Length >= 10)
            {
                return MusteriDAL.MusteriGuncelleDAL(m);
            }
            return false;
        }

        // 2. Müşteri Silme BLL
        public static bool MusteriSilBLL(int id)
        {
            if (id > 0)
            {
                return MusteriDAL.MusteriSilDAL(id);
            }
            return false;
        }

    }
    }


