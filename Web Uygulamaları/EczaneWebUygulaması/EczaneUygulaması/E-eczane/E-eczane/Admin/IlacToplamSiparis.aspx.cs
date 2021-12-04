using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace E_eczane.Admin
{
    public partial class IlacToplamSiparis : System.Web.UI.Page
    {
        SqlBaglantisi sql = new SqlBaglantisi();

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Exec ilacToplamSiparis", sql.baglanti());

            DataTable ds = new DataTable();

            da.Fill(ds);

            GridViewSiparis.DataSource = ds;
            GridViewSiparis.DataBind();
            sql.baglanti().Close();

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}