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
    public partial class ToplamIlacSatisi : System.Web.UI.Page
    {
        SqlBaglantisi sql = new SqlBaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Exec ilacToplamSatis", sql.baglanti());

            DataTable ds = new DataTable();

            da.Fill(ds);

            GridViewSatis.DataSource = ds;

            GridViewSatis.DataBind();
            sql.baglanti().Close();
        }
    }
}