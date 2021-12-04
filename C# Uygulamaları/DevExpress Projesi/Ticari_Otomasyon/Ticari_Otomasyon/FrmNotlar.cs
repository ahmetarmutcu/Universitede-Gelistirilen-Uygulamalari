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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_NOTLAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControlNotlarGoster.DataSource = dt;
        }
        void Temizle()
        {
            textId.Text = "";
            mstTarih.Text = "";
            mstSaat.Text = "";
            textBaslik.Text = "";
            rctDetay.Text = "";
            TextOlusturanKisi.Text = "";
            textHitap.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR(NOTTARIH,NOTSAAT,NOTBASLIK,NOTDETAY,NOTOLUSTURAN,NOTHITAP)values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mstTarih.Text);
            komut.Parameters.AddWithValue("@p2", mstSaat.Text);
            komut.Parameters.AddWithValue("@p3", textBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rctDetay.Text);
            komut.Parameters.AddWithValue("@p5", TextOlusturanKisi.Text);
            komut.Parameters.AddWithValue("@p6", textHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Notlar Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void simpleButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                textId.Text = dr["NOTID"].ToString();
                mstTarih.Text = dr["NOTTARIH"].ToString();
                mstSaat.Text = dr["NOTSAAT"].ToString();
                textBaslik.Text = dr["NOTBASLIK"].ToString();
                rctDetay.Text = dr["NOTDETAY"].ToString();
                TextOlusturanKisi.Text = dr["NOTOLUSTURAN"].ToString();
                textHitap.Text = dr["NOTHITAP"].ToString();
            }
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_NOTLAR Where NOTID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_NOTLAR Set NOTTARIH=@p1,NOTSAAT=@p2,NOTBASLIK=@p3,NOTDETAY=@p4,NOTOLUSTURAN=@p5,NOTHITAP=@p6 where NOTID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mstTarih.Text);
            komut.Parameters.AddWithValue("@p2", mstSaat.Text);
            komut.Parameters.AddWithValue("@p3", textBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rctDetay.Text);
            komut.Parameters.AddWithValue("@p5", TextOlusturanKisi.Text);
            komut.Parameters.AddWithValue("@p6", textHitap.Text);
            komut.Parameters.AddWithValue("@p7", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                fr.metin = dr["NOTDETAY"].ToString();
            }
            fr.Show();
        }
    }
}
