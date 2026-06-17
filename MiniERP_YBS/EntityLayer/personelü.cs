using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_YBS.EntityLayer
{
public class Personel
    {
        public int PersonelID { get; set; }
        public string AdSoyad { get; set; }
        public int DepartmanID { get; set; }
        public decimal Maas { get; set; }
        public DateTime GirisTarihi { get; set; }
    }
}
