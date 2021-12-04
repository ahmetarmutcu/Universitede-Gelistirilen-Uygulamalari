using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace E_eczane
{
    public class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-92B9LE8;Initial Catalog=EczaneUygulamasi;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}