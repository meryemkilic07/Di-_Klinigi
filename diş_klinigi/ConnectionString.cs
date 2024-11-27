using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace diş_klinigi
{
    internal class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection baglanti= new SqlConnection();
            baglanti.ConnectionString = @"Data Source=LAPTOP-QIDCB50J\SQLEXPRESS;Initial Catalog=dentaldb;Integrated Security=True";

            return baglanti;

        }

    }
}
