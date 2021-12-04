using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace E_eczane
{
    public partial class KayitOl : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        void Temizle()
        {
            TextKullaniciAdi.Text = "";
            TextSifre.Text = "";
           
           
        }

        protected void ButtonUyeOl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Kullanici(kullaniciYetkiKodu,kullaniciAdi,kullaniciSifre)values(@p1,@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", 0);
            komut.Parameters.AddWithValue("@p2", TextKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p3", TextSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            LabelDurum.Visible = true;
            LabelDurum.Text = "Başarıyla Kayıt OLdunuz ";
            bgl.baglanti().Close();
            Temizle();
        }
    }
}