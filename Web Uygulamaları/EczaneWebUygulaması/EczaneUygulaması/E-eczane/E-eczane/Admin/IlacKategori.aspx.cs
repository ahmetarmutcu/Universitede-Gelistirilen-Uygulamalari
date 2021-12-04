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
    public partial class IlacKategori : System.Web.UI.Page
    {

        SqlBaglantisi bgl = new SqlBaglantisi();
        public void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from Kategori", bgl.baglanti());
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridIlacKategori.DataSource = ds;
            GridIlacKategori.DataBind();
            bgl.baglanti().Close();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Listele();  
        }

        protected void GridIlacKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIlacKategoriID.Text = HttpUtility.HtmlDecode(GridIlacKategori.SelectedRow.Cells[1].Text);
            TextKategoriAdi.Text = HttpUtility.HtmlDecode(GridIlacKategori.SelectedRow.Cells[2].Text);
        }

        protected void ButtonEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Kategori(kategoriIsim) values(@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextKategoriAdi.Text);
            komut.ExecuteNonQuery();
            LabelDurum.Visible = true;
            LabelDurum.Text = "Kategori başarıyla eklendi";
            bgl.baglanti().Close();
            Listele();
            TextKategoriAdi.Text = "";
            lblIlacKategoriID.Text = "";
        }

        protected void ButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Kategori Where kategoriID=@kategoriID", bgl.baglanti());
            komut.Parameters.AddWithValue("@kategoriID", int.Parse(lblIlacKategoriID.Text.ToString()));
            komut.ExecuteNonQuery();
            LabelDurum.Visible = true;
            LabelDurum.Text = "Kategori başarıyla silindi";
            bgl.baglanti().Close();
            Listele();
            TextKategoriAdi.Text = "";
            lblIlacKategoriID.Text = "";

        }
    }
}