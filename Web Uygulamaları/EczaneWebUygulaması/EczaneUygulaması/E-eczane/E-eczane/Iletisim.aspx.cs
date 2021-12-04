using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace E_eczane
{
    public partial class Iletisim : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGonder_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into Soru(uyeID,soruAciklama,soruTarih)values(@p1,@p2,@p3)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", int.Parse(Session["id"].ToString()));
                komut.Parameters.AddWithValue("@p2", TextSoru.Text);
                komut.Parameters.AddWithValue("@p3", DateTime.Now);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                LabelDurum.Enabled = false;
                LabelDurum.Text = "Soru başarıyla gönderildi";
            }
            catch(Exception)
            {
                LabelDurum.Text = "Soru göndermek sisteme giriş yapınız";
            }
  

        }
    }
}