using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_YBS.EntityLayer
{
    internal class Satis
    {
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public int MusteriID { get; set; }
        public int PersonelID { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime Tarih { get; set; }
    }
}
