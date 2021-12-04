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
    public partial class SiparisDetay : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select IlacDetay.ilacIsim,Yonetici.yoneticiIsim,yoneticiSoyisim,Siparis.siparisAdet,Siparis.siparisTarihi from Siparis inner join IlacDetay on Siparis.ilacID=IlacDetay.ilacID inner join Yonetici on Siparis.yoneticiID=Yonetici.yoneticiID", bgl.baglanti());
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridSiparisListele.DataSource = ds;
            GridSiparisListele.DataBind();
            bgl.baglanti().Close();
        }
    }
}