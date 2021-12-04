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
    
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControlPersonelGoster.DataSource = dt;
        }
        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("SELECT SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void Temizle()
        {
            textAd.Text = "";
            textSoyad.Text = "";
            mstTelefon.Text = "";
            mstTc.Text = "";
            textMail.Text = "";
            comboBoxil.Text = "";
            comboilce.Text = "";
            textGorev.Text = "";
            richTextBoxAdres.Text = "";
            textId.Text = "";
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();
            Listele();
            SehirListesi();
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mstTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mstTc.Text);
            komut.Parameters.AddWithValue("@p5", textMail.Text);
            komut.Parameters.AddWithValue("@p6", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p7", comboilce.Text);
            komut.Parameters.AddWithValue("@p8", richTextBoxAdres.Text);
            komut.Parameters.AddWithValue("@p9", textGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void simpleButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                textId.Text = dr["ID"].ToString();
                textAd.Text = dr["AD"].ToString();
                textSoyad.Text = dr["SOYAD"].ToString();
                mstTelefon.Text = dr["TELEFON"].ToString();
                mstTc.Text = dr["TC"].ToString();
                textMail.Text = dr["MAIL"].ToString();
                comboBoxil.Text = dr["IL"].ToString();
                comboilce.Text = dr["ILCE"].ToString();
                richTextBoxAdres.Text = dr["ADRES"].ToString();
                textGorev.Text = dr["GOREV"].ToString();
            }
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_PERSONELLER Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
            Temizle();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER Set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 Where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mstTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mstTc.Text);
            komut.Parameters.AddWithValue("@p5", textMail.Text);
            komut.Parameters.AddWithValue("@p6", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p7", comboilce.Text);
            komut.Parameters.AddWithValue("@p8", richTextBoxAdres.Text);
            komut.Parameters.AddWithValue("@p9", textGorev.Text);
            komut.Parameters.AddWithValue("@p10", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personeller Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
