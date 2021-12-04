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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void BankaListeleme()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec BankaBilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControlBankalarGoster.DataSource = dt;
            
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
        void FirmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD from TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpFirma.Properties.NullText = "Lütfen bir Ad seçiniz";
            lookUpFirma.Properties.ValueMember = "ID";
            lookUpFirma.Properties.DisplayMember = "AD";
            lookUpFirma.Properties.DataSource = dt;
        }
        void Temizleme()
        {
            textId.Text = "";
            textBankaAdi.Text = "";
            comboBoxil.Text = "";
            comboilce.Text = "";
            textSube.Text = "";
            textIban.Text = "";
            textHesapNo.Text = "";
            textYetkili.Text = "";
            mskTelefon.Text = "";
            dateTarih.Text = "";
            textHesapturu.Text = "";
            lookUpFirma.Text = "";
        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            BankaListeleme();
            SehirListesi();
            FirmaListesi();
            Temizleme();
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR(BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTUR,FIRMAID)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p3", comboilce.Text);
            komut.Parameters.AddWithValue("@p4", textSube.Text);
            komut.Parameters.AddWithValue("@p5", textIban.Text);
            komut.Parameters.AddWithValue("@p6", textHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", textYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p9", dateTarih.Text);
            komut.Parameters.AddWithValue("@p10", textHesapturu.Text);
            komut.Parameters.AddWithValue("@p11", lookUpFirma.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BankaListeleme();
            Temizleme();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                textId.Text = dr["ID"].ToString();
                textBankaAdi.Text = dr["BANKAADI"].ToString();
                comboBoxil.Text = dr["IL"].ToString();
                comboilce.Text= dr["ILCE"].ToString();
                textSube.Text = dr["SUBE"].ToString();
                textIban.Text = dr["IBAN"].ToString();
                textHesapNo.Text = dr["HESAPNO"].ToString();
                textYetkili.Text = dr["YETKILI"].ToString();
                mskTelefon.Text = dr["TELEFON"].ToString();
                dateTarih.Text = dr["TARIH"].ToString();
                textHesapturu.Text = dr["HESAPTUR"].ToString();

            }
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_BANKALAR Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka sistemden silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            BankaListeleme();
            Temizleme();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_BANKALAR set BANKAADI=@p1,IL=@p2,ILCE=@p3,SUBE=@p4,IBAN=@p5,HESAPNO=@p6,YETKILI=@p7,TELEFON=@p8,TARIH=@p9,HESAPTUR=@p10,FIRMAID=@p11 Where ID=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxil.Text);
            komut.Parameters.AddWithValue("@p3", comboilce.Text);
            komut.Parameters.AddWithValue("@p4", textSube.Text);
            komut.Parameters.AddWithValue("@p5", textIban.Text);
            komut.Parameters.AddWithValue("@p6", textHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", textYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p9", dateTarih.Text);
            komut.Parameters.AddWithValue("@p10", textHesapturu.Text);
            komut.Parameters.AddWithValue("@p11", lookUpFirma.EditValue);
            komut.Parameters.AddWithValue("@p12", textId.Text);
            komut.ExecuteNonQuery();
            BankaListeleme();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Temizleme();
        }
    }
}
