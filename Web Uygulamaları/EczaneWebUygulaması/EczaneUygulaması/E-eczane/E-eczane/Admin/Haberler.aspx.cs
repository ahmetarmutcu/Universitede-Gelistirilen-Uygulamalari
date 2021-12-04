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
    public partial class Haberler : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Temizle()
        {
            LabelHaberID.Text="";
            TextBoxTarih.Text = "";
            TextHaberAciklamasi.Text = "";
            TextBoxHaberResim.Text = "";
            TextHaberAdi.Text = "";
        }
        void HaberListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Exec HaberListele", bgl.baglanti());
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViewHaberListele.DataSource = ds;
            GridViewHaberListele.DataBind();
            bgl.baglanti().Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HaberListele();
           
        }

        protected void GridViewHaberListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelHaberID.Text = HttpUtility.HtmlDecode(GridViewHaberListele.SelectedRow.Cells[1].Text);
            TextHaberAdi.Text = HttpUtility.HtmlDecode(GridViewHaberListele.SelectedRow.Cells[2].Text);
            TextHaberAciklamasi.Text = HttpUtility.HtmlDecode(GridViewHaberListele.SelectedRow.Cells[3].Text);
            TextBoxHaberResim.Text = HttpUtility.HtmlDecode(GridViewHaberListele.SelectedRow.Cells[5].Text);
            TextBoxTarih.Text = HttpUtility.HtmlDecode(GridViewHaberListele.SelectedRow.Cells[4].Text);

        }

        protected void ButtonEKLE_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO Haber (yoneticiID,haberAciklama,haberTarih,haberResim,haberBaslik) VALUES (@p1,@p2,@p3,@p4,@p5)";
            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", int.Parse(Session["id"].ToString()));
            komut.Parameters.AddWithValue("@p2", TextHaberAciklamasi.Text);
            komut.Parameters.AddWithValue("@p3", DateTime.Now);
            komut.Parameters.AddWithValue("@p4", TextBoxHaberResim.Text);
            komut.Parameters.AddWithValue("@p5", TextHaberAdi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            HaberListele();
            Temizle();
        }
        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void ButtonSil_Click(object sender, EventArgs e)
        {
            string sql = "Delete From Haber Where haberID=@haberID";
            SqlCommand komut = new SqlCommand(sql, bgl.baglanti());
            komut.Parameters.AddWithValue("@haberID", LabelHaberID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            HaberListele();
            Temizle();
        }


        protected void ButtonDuzenle_Click(object sender, EventArgs e)
        {
            
            String sorgu = "Update Haber set haberBaslik=@h1,haberAciklama=@h2,haberResim=@h3,haberTarih=@h4 Where haberID=@hid";
            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());
            komut.Parameters.AddWithValue("hid", int.Parse(LabelHaberID.Text));
            komut.Parameters.AddWithValue("h1", TextHaberAdi.Text);
            komut.Parameters.AddWithValue("h2", TextHaberAciklamasi.Text);
            komut.Parameters.AddWithValue("h3", TextBoxHaberResim.Text);
            komut.Parameters.AddWithValue("h4", DateTime.Now);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            LabelDurum.Visible = true;
            LabelDurum.Text = "Haber başarıyla düzenlendi";
            HaberListele();
        }
    }
}