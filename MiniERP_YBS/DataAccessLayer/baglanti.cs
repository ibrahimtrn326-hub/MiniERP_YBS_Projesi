using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniERP_YBS.DataAccessLayer
{
    internal class Baglanti
    {
        private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=CRM,;Integrated Security=True;TrustServerCertificate=True";
        public static SqlConnection BaglantiAl()
        {
            SqlConnection baglanti = new SqlConnection(connectionString);
            return baglanti;
        }

    }
}
