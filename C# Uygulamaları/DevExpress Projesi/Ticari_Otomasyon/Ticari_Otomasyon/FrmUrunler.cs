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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_URUNLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            textId.Text = "";
            textAd.Text = "";
            textMarka.Text = "";
            textModel.Text = "";
            textYil.Text = "";
            numericUpDownAdet.Value = 0;
            textAlisFiyat.Text = "";
            textSatisFiyat.Text = "";
            richTextBoxDetay.Text = "";
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            //Verileri kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textMarka.Text);
            komut.Parameters.AddWithValue("@p3", textModel.Text);
            komut.Parameters.AddWithValue("@p4", textYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((numericUpDownAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", richTextBoxDetay.Text);
            komut.ExecuteNonQuery();//Sorguyu çalıştır
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_URUNLER Where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", textId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textId.Text = dr["ID"].ToString();
            textAd.Text = dr["URUNAD"].ToString();
            textMarka.Text = dr["MARKA"].ToString();
            textModel.Text = dr["MODEL"].ToString();
            textYil.Text = dr["YIL"].ToString();
            numericUpDownAdet.Value = int.Parse(dr["ADET"].ToString());
            textAlisFiyat.Text = dr["ALISFIYAT"].ToString();
            textSatisFiyat.Text = dr["SATISFIYAT"].ToString();
            richTextBoxDetay.Text = dr["DETAY"].ToString();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_URUNLER set URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textMarka.Text);
            komut.Parameters.AddWithValue("@p3", textModel.Text);
            komut.Parameters.AddWithValue("@p4", textYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((numericUpDownAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", richTextBoxDetay.Text);
            komut.Parameters.AddWithValue("@p9", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void simpleButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
