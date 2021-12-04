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

    public partial class Ilaclar : System.Web.UI.Page
    {
        SqlBaglantisi sql = new SqlBaglantisi();

        void İlacDetay()
        {
            SqlDataAdapter da = new SqlDataAdapter("Exec ilacListele", sql.baglanti());
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViewIlacListele.DataSource = ds;
            GridViewIlacListele.DataBind();
            sql.baglanti().Close();
        }
        void IlacListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Exec SadeceIlacListele", sql.baglanti());
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridIlacListele.DataSource = ds;
            GridIlacListele.DataBind();
            sql.baglanti().Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IDCekme();
            İlacKategorisi();
            FirmaKategorisi();
            İlacDetay();
            IlacListele();
        }
        public void FirmaKategorisi()
        {
            SqlCommand komut = new SqlCommand("Select *from Firma", sql.baglanti());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DropDownIlacFirma.Items.Add(dr["firmaIsim"].ToString());
            }
            sql.baglanti().Close();
        }
        public void İlacKategorisi()
        {
            SqlCommand komut = new SqlCommand("Select *from Kategori", sql.baglanti());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DropDownIlacKategori.Items.Add(dr["kategoriIsim"].ToString());
            }
            sql.baglanti().Close();
        }
        public void IDCekme()
        {
            SqlCommand komut = new SqlCommand("Select TOP 1 ilacID from Ilac ORDER BY ilacID desc", sql.baglanti());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TextIlacID.Text = (dr["ilacID"].ToString());
            }
            sql.baglanti().Close();
        }
        public int IDGetir()
        {
            sql.baglanti().Close();
            SqlCommand komut = new SqlCommand("Select TOP 1 ilacID from Ilac ORDER BY ilacID desc", sql.baglanti());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
                id = int.Parse(dr["ilacID"].ToString());
            }
            sql.baglanti().Close();
            return id;
        }

        protected void GridViewIlacListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextIlacID.Text = HttpUtility.HtmlDecode(GridViewIlacListele.SelectedRow.Cells[1].Text);
        }

        protected void ButtonEKLE_Click(object sender, EventArgs e)
        {
            if (FileResim.HasFile)
            {
                FileResim.SaveAs(Server.MapPath("../image/ilaclar" + FileResim.FileName));
                string resim = FileResim.FileName;
                string adi = TextBoxilacAdi.Text.ToString();
                string aciklama = TextBoxilacAciklama.Text.ToString();
                int ilacAdet = int.Parse(TextBoxIlacAdet.Text.ToString());
                string kategoriIsim = DropDownIlacKategori.SelectedValue.ToString();
                string firmaIsim = DropDownIlacFirma.SelectedValue.ToString();
                SqlCommand komut = new SqlCommand("Exec ilacEkle @ilacisim='"+adi+"',@ilacAciklama='"+aciklama+"',@ilacAdet="+ilacAdet+"," +
                    "@firmaIsim='"+firmaIsim+"',@kategoriIsim='"+kategoriIsim+"',@resim='"+resim+"'", sql.baglanti());
                komut.ExecuteNonQuery();
                sql.baglanti().Close();

                LabelDurum.Visible = true;
                LabelDurum.Text = "İLAÇ veritabanına başarıyla kaydedildi";
                Response.Redirect("Ilaclar.aspx");
            }
            else
            {
                LabelDurum.Visible = true;
                LabelDurum.Text = "Kaydetme işlemi için resim ekleyiniz.";
            }
        }

        protected void ButtonDetaySil_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "Exec ilacSil @ilacID='"+int.Parse(TextIlacID.Text).ToString()+"'";
                SqlCommand komut = new SqlCommand(sorgu, sql.baglanti());                
                komut.ExecuteNonQuery();
                sql.baglanti().Close();
                İlacDetay();
                IlacListele();
            }
            catch (Exception)
            {
                LabelDurum.Visible = true;
                LabelDurum.Text = "Soru silinemedi hata oluştu";
            }
        }

        
    }
}