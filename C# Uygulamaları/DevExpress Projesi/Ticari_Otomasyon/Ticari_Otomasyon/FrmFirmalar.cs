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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControlFirmaGoster.DataSource = dt;
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
        void CariKodAciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                rchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListesi();
            CariKodAciklamalar();
            Temizle();
        }

        void Temizle()
        {
            textId.Text = "";
            textAd.Text = "";
            textSektor.Text = "";
            textYetkili.Text = "";
            textYetkiliGorev.Text = "";
            mskYetkiTc.Text = "";
            mskTelefon1.Text = "";
            mskTelefon2.Text = "";
            textMail.Text = "";
            mskFax.Text = "";
            comboBoxil.Text = "";
            comboilce.Text = "";
            textVergi.Text = "";
            richTextBoxAdres.Text = "";
            textKod1.Text = "";
            textKod2.Text = "";
            textKod3.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                textId.Text = dr["ID"].ToString();
                textAd.Text = dr["AD"].ToString();
                textYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                textYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                mskYetkiTc.Text = dr["YETKILITC"].ToString();
                textSektor.Text = dr["SEKTOR"].ToString();
                mskTelefon1.Text = dr["TELEFON1"].ToString();
                mskTelefon2.Text = dr["TELEFON2"].ToString();
                textMail.Text = dr["MAIL"].ToString();
                mskFax.Text = dr["FAX"].ToString();
                comboBoxil.Text = dr["IL"].ToString();
                comboilce.Text = dr["ILCE"].ToString();
                textVergi.Text = dr["VERGIDAIRE"].ToString();
                richTextBoxAdres.Text = dr["ADRES"].ToString();
                textKod1.Text = dr["OZELKOD1"].ToString();
                textKod2.Text = dr["OZELKOD2"].ToString();
                textKod3.Text = dr["OZELKOD3"].ToString();

            }
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR(AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", textYetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskYetkiTc.Text);
            komut.Parameters.AddWithValue("@p5", textSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", mskTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", textMail.Text);
            komut.Parameters.AddWithValue("@p9", mskFax.Text);
            komut.Parameters.AddWithValue("@p10", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p11", comboilce.Text);
            komut.Parameters.AddWithValue("@p12", textVergi.Text);
            komut.Parameters.AddWithValue("@p13", richTextBoxAdres.Text);
            komut.Parameters.AddWithValue("@p14", textKod1.Text);
            komut.Parameters.AddWithValue("@p15", textKod2.Text);
            komut.Parameters.AddWithValue("@p16", textKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void comboBoxil_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboilce.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("SELECT ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from  TBL_FIRMALAR Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            SqlCommand komut1 = new SqlCommand("Delete from TBL_BANKALAR Where FIRMAID=@p2", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p2", textId.Text);
            komut1.ExecuteNonQuery();
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
            Temizle();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5,TELEFON1=@p6,TELEFON2=@p7,MAIL=@p8,FAX=@p9,IL=@p10,ILCE=@p11,VERGIDAIRE=@p12,ADRES=@p13,OZELKOD1=@p14,OZELKOD2=@p15,OZELKOD3=@p16 where ID=@p17", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", textYetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskYetkiTc.Text);
            komut.Parameters.AddWithValue("@p5", textSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTelefon1.Text);
            komut.Parameters.AddWithValue("@p7", mskTelefon2.Text);
            komut.Parameters.AddWithValue("@p8", textMail.Text);
            komut.Parameters.AddWithValue("@p9", mskFax.Text);
            komut.Parameters.AddWithValue("@p10", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p11", comboilce.Text);
            komut.Parameters.AddWithValue("@p12", textVergi.Text);
            komut.Parameters.AddWithValue("@p13", richTextBoxAdres.Text);
            komut.Parameters.AddWithValue("@p14", textKod1.Text);
            komut.Parameters.AddWithValue("@p15", textKod2.Text);
            komut.Parameters.AddWithValue("@p16", textKod3.Text);
            komut.Parameters.AddWithValue("@p17", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
