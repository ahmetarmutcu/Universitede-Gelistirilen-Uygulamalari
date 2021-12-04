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
    public partial class Cevap : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        void CevapListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select c1.cevapID,s1.soruAciklama,k1.kullaniciAdi,c1.cevapAciklama,c1.cevapTarih from Cevap c1 inner join Soru s1 on c1.soruID=s1.soruID inner join Kullanici k1 on s1.uyeID = k1.kullaniciID", bgl.baglanti());
            DataTable ds = new DataTable();

            da.Fill(ds);

            gridCevap.DataSource = ds;

            gridCevap.DataBind();
            bgl.baglanti().Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CevapListele();
        }
        void Temizle()
        {
            LabelCevapID.Text = "";
            TextBoxCevap.Text = "";
            TextSoru.Text = "";
            TextKullaniciAdi.Text = "";
        }

        protected void gridCevap_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelCevapID.Text = HttpUtility.HtmlDecode(gridCevap.SelectedRow.Cells[1].Text);
            TextSoru.Text = HttpUtility.HtmlDecode(gridCevap.SelectedRow.Cells[2].Text);
            TextKullaniciAdi.Text = HttpUtility.HtmlDecode(gridCevap.SelectedRow.Cells[3].Text);
            TextBoxCevap.Text = HttpUtility.HtmlDecode(gridCevap.SelectedRow.Cells[4].Text);
            TextBoxTarih.Text = HttpUtility.HtmlDecode(gridCevap.SelectedRow.Cells[4].Text);
        }

        protected void ButtonSil_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Delete From Cevap Where cevapID=@cevapID";
                SqlCommand komut = new SqlCommand(sql, bgl.baglanti());
                komut.Parameters.AddWithValue("@cevapID", LabelCevapID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                CevapListele();
                Temizle();
            }
            catch (Exception)
            {
                LabelDurum.Visible = true;
                LabelDurum.Text = "Soru silinemedi bir hata oluştu";
            }
        }

        protected void ButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}