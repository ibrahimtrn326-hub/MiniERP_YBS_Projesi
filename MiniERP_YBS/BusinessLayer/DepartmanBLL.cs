using MiniERP_YBS.DataAccessLayer;
using MiniERP_YBS.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniERP_YBS.BusinessLayer
{
    public class DepartmanBLL
    {
        public static bool DepartmanEkleBLL(Departman d)
        {
            // Departman adı boş olmasın ve en az 2 karakter olsun
            if (d.DepartmanAdi != "" && d.DepartmanAdi.Length >= 2)
            {
                return deparmanDal.DepartmanEkleDAL(d);
            }
            else
            {
                return false;
            }
        }

        // 2. Departman Silme BLL
        public static bool DepartmanSilBLL(int id)
        {
            if (id > 0)
            {
                return deparmanDal.DepartmanSilDAL(id);
            }
            return false;
        }

        // 3. Departman Güncelleme BLL
        public static bool DepartmanGuncelleBLL(Departman d)
        {
            if (d.DepartmanAdi != "" && d.DepartmanAdi.Length >= 2)
            {
                return deparmanDal.DepartmanGuncelleDAL(d);
            }
            return false;
        }
    }

}

