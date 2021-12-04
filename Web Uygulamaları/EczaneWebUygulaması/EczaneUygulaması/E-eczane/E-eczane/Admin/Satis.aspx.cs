using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace E_eczane.Admin
{
    public partial class Satis : System.Web.UI.Page
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {

            ilacAdi();
            Musteriler();
        }
        public void ilacAdi()
        {
            SqlCommand komut = new SqlCommand("Select *from IlacDetay", bgl.baglanti());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DropIlacAdi.Items.Add(dr["ilacIsim"].ToString());
            }
            bgl.baglanti().Close();
        }
        public void Musteriler()
        {
            SqlCommand komut = new SqlCommand("Select *from Kullanici where kullaniciYetkiKodu=0", bgl.baglanti());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                DropMusteri.Items.Add(dr["kullaniciAdi"].ToString());
            }
            bgl.baglanti().Close();
        }

        protected void ButtonSatisEkle_Click(object sender, EventArgs e)
        {
            string ilacAdi = DropIlacAdi.SelectedValue.ToString();
            string kullaniciAdi = DropMusteri.SelectedValue.ToString();
            int adet = int.Parse(TextAdet.Text.ToString());
            int ilacID = 0;
            int kullaniciID = 0;

            SqlCommand komut = new SqlCommand("Select * from IlacDetay Where ilacIsim='" + ilacAdi+"'", bgl.baglanti());
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ilacID = int.Parse(dr["ilacID"].ToString());
            }
            bgl.baglanti().Close();
            SqlCommand komut1 = new SqlCommand("Select * from Kullanici Where kullaniciAdi='" +kullaniciAdi+ "'", bgl.baglanti());
            SqlDataReader dr1;
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                kullaniciID = int.Parse(dr1["kullaniciID"].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("insert into Satis(ilacID,uyeID,satisTarih,satisAdet)values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", ilacID);
            komut2.Parameters.AddWithValue("@p2", kullaniciID);
            komut2.Parameters.AddWithValue("@p3", DateTime.Now);
            komut2.Parameters.AddWithValue("@p4", adet);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            LabelDurum.Visible = true;
            LabelDurum.Text = "İlaç başarıyla satıldı";
        }
    }
}