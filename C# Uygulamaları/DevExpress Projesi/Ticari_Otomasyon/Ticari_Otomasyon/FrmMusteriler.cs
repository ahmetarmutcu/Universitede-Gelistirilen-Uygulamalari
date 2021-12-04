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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControlMusteriGoster.DataSource = dt;
        }
        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("SELECT SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBoxil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void Temizleme()
        {
            textId.Text = "";
            textAd.Text = "";
            textSoyad.Text = "";
            mstTelefon1.Text = "";
            msbTelefon2.Text = "";
            mstTc.Text = "";
            textMail.Text = "";
            comboBoxil.Text = "";
            comboilce.Text = "";
            textVergi.Text = "";
            richTextBoxAdres.Text = "";
        }
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();
            Temizleme();
            SehirListesi();
        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxil.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAİL,IL,ILCE,ADRES,VERGİDAIRE)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mstTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", msbTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", mstTc.Text);
            komut.Parameters.AddWithValue("@p6", textMail.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p8", comboilce.Text);
            komut.Parameters.AddWithValue("@p9", richTextBoxAdres.Text);
            komut.Parameters.AddWithValue("@p10", textVergi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizleme();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                textId.Text = dr["ID"].ToString();
                textAd.Text = dr["AD"].ToString();
                textSoyad.Text = dr["SOYAD"].ToString();
                mstTelefon1.Text = dr["TELEFON"].ToString();
                msbTelefon2.Text = dr["TELEFON2"].ToString();
                mstTc.Text = dr["TC"].ToString();
                textMail.Text = dr["MAİL"].ToString();
                comboBoxil.Text = dr["IL"].ToString();
                comboilce.Text = dr["ILCE"].ToString();
                richTextBoxAdres.Text = dr["ADRES"].ToString();
                textVergi.Text = dr["VERGİDAIRE"].ToString();
            }
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_MUSTERILER Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silinsin mi?", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizleme();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_MUSTERILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAİL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGİDAIRE=@p10 where ID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mstTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", msbTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", mstTc.Text);
            komut.Parameters.AddWithValue("@p6", textMail.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p8", comboilce.Text);
            komut.Parameters.AddWithValue("@p9", richTextBoxAdres.Text);
            komut.Parameters.AddWithValue("@p10", textVergi.Text);
            komut.Parameters.AddWithValue("@p11", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizleme();
        }

        private void simpleButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizleme();
        }
    }
}
