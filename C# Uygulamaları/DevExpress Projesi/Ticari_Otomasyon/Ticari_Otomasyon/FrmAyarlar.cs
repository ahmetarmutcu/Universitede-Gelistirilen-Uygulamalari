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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            textKullanici.Text = "";
            textSifre.Text = "";
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if(buttonKaydet.Text=="KAYDET")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN(KullaniciAd,Sifre)values(@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textKullanici.Text);
                komut.Parameters.AddWithValue("@p2", textSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı sisteme kaydedildi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            if(buttonKaydet.Text == "GÜNCELLE")
            {
                SqlCommand komut1 = new SqlCommand("update tbl_ADMIN set Sifre=@p2 where KullaniciAd=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", textKullanici.Text);
                komut1.Parameters.AddWithValue("@p2", textSifre.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Sifresi Güncellendi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
           
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                textKullanici.Text = dr["KullaniciAd"].ToString();
                textSifre.Text = dr["Sifre"].ToString();
            }
        }

        private void textKullanici_EditValueChanged(object sender, EventArgs e)
        {
            if(textKullanici.Text!="")
            {
                buttonKaydet.Text = "GÜNCELLE";
                buttonKaydet.BackColor = Color.GreenYellow;
            }
            else
            {
                buttonKaydet.Text = "KAYDET";
                buttonKaydet.BackColor = Color.MediumTurquoise;
            }
        }
    }
}
