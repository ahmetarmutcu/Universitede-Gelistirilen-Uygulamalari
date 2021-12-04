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
    public partial class Sorular : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        void SoruListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select s1.soruID,k1.kullaniciAdi,s1.soruAciklama,s1.soruTarih from Soru s1 inner join Kullanici k1 on s1.uyeID = k1.kullaniciID", bgl.baglanti());
            DataTable ds = new DataTable();

            da.Fill(ds);
            gridlistele.DataSource = ds;
            gridlistele.DataBind();
            bgl.baglanti().Close();
        }
        void Temizle()
        {
            LabelSoruID.Text = "";
            TextSoru.Text = "";
            TextKullanicAdi.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SoruListele();
        }

        protected void gridlistele_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelSoruID.Text = HttpUtility.HtmlDecode(gridlistele.SelectedRow.Cells[1].Text);
            TextKullanicAdi.Text = HttpUtility.HtmlDecode(gridlistele.SelectedRow.Cells[2].Text);
            TextSoru.Text = HttpUtility.HtmlDecode(gridlistele.SelectedRow.Cells[3].Text);
            TextBoxTarih.Text = HttpUtility.HtmlDecode(gridlistele.SelectedRow.Cells[4].Text);
        }

        protected void ButtonSil_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Delete From Soru Where soruID=@soruID";
                SqlCommand komut = new SqlCommand(sql, bgl.baglanti());
                komut.Parameters.AddWithValue("@soruID", LabelSoruID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SoruListele();
                Temizle();
            }
            catch(Exception )
            {
                LabelDurum.Visible = true;
                LabelDurum.Text = "Soru silinemedi ilk önce Cevaplar tablosundan silinmesi lazım";
            }
           
        }

        protected void ButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}