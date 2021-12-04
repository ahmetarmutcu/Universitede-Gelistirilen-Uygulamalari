using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_eczane
{
    public partial class Tema : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KullaniciAdi"] != null)
            {
                isimsoyisim.Text = Session["KullaniciAdi"].ToString();

            }
           
        }

        protected void Cikis_Click(object sender, EventArgs e)
        {
            Cikis.Visible = true;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Anasayfa.aspx");
        }
    }
}