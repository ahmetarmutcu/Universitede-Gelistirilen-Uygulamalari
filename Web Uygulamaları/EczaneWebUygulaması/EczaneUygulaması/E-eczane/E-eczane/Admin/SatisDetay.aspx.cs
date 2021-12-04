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
    public partial class SatisDetay : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select IlacDetay.ilacIsim,Uye.uyeIsim,Uye.uyeSoyisim,Satis.satisAdet,Satis.satisTarih from Satis inner join Uye on Satis.uyeID=Uye.uyeID inner join IlacDetay on Satis.ilacID=IlacDetay.ilacID", bgl.baglanti());
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViSatisListele.DataSource = ds;
            GridViSatisListele.DataBind();
            bgl.baglanti().Close();
        }
    }
}