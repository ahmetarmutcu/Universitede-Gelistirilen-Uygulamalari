using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_eczane.Admin
{
    public partial class AdminTema : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KullaniciAdi"] != null)
            {
                isimsoyisim.Text = Session["KullaniciAdi"].ToString();

            }
            else
            {
                Response.Redirect("../Giris.aspx");
            }
          
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("../Giris.aspx");
        }
    }
}