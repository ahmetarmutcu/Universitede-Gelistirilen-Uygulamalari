using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string urunid;
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            textUrunId.Text = urunid;
            SqlCommand komut = new SqlCommand("Select *from TBL_FATURADETAY Where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textUrunId.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                textUrunAd.Text = dr["URUNAD"].ToString();
                textMiktar.Text = dr["MIKTAR"].ToString();
                TextFiyat.Text = dr["FIYAT"].ToString();
                textTutar.Text = dr["TUTAR"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURADETAY set URUNAD=@p1,MIKTAR=@p2,FIYAT=@p3,TUTAR=@p4 Where FATURAURUNID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", textMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TextFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TextFiyat.Text)*decimal.Parse(textMiktar.Text));
            komut.Parameters.AddWithValue("@p5",textUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklik kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
