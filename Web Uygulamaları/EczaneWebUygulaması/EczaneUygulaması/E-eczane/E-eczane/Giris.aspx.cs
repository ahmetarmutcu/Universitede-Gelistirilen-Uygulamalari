using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace E_eczane
{
    public partial class Giris : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("Select *from Kullanici Where kullaniciAdi=@p1 and kullaniciSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextKullanici.Text);
            komut.Parameters.AddWithValue("@p2", TextboxSifre.Text);
            
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {

                Session.Add("id", dr["kullaniciID"].ToString());
                Session.Add("yetkikodu", dr["kullaniciYetkiKodu"].ToString());
                Session.Add("KullaniciAdi", dr["kullaniciAdi"].ToString());
                Session.Add("Sifre", dr["kullaniciSifre"].ToString());
                if (Session["yetkiKodu"].ToString() == "0")
                {
                    Response.Redirect("Anasayfa.aspx");
                }
                else
                {
                   
                    Response.Redirect("Admin/AdminAnasayfa.aspx");
                }
                
            }
            else
            {
                LabelDurum.Visible = true;
                LabelDurum.Text = "Kullanıcı adı veya Şifre yanlıştır.";
            }
            bgl.baglanti().Close();

        }
    }
}