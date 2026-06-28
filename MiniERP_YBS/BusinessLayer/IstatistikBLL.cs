using MiniERP_YBS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_YBS.BusinessLayer
{
    internal class IstatistikBLL
    {

        public static int UrunSayisiBLL()
        {
            return IstatistikDAL.UrunSayisiGetir();
        }

        public static int MusteriSayisiBLL()
        {
            return IstatistikDAL.MusteriSayisiGetir();
        }

        public static int ToplamSatisAdediBLL()
        {
            return IstatistikDAL.ToplamSatisAdediGetir();
        }

        public static string ToplamCiroBLL()
        {
            decimal ciro = IstatistikDAL.ToplamCiroGetir();
            // Gelen sayıyı ekranda "1.250,00 TL" şeklinde çok şık, kurumsal bir para formatında gösterir:
            return ciro.ToString("N2") + " TL";
        }
        public static int ToplamPersonelBLL()
        {
            return IstatistikDAL.ToplamPersonelDAL();
        }

        public static decimal ToplamMaasBLL()
        {
            return IstatistikDAL.ToplamMaasDAL();
        }

        public static decimal EnYuksekMaasBLL()
        {
            return IstatistikDAL.EnYuksekMaasDAL();
        }
    }
}
