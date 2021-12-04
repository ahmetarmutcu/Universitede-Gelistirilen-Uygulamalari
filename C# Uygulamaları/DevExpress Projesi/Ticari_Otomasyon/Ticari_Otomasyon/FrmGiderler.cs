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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void GiderListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControlGiderlerGoster.DataSource = dt;
        }
        void Temizle()
        {
            textId.Text = "";
            comboBoxAy.Text = "";
            comboYil.Text = "";
            textElektrik.Text = "";
            textSu.Text = "";
            textDogalgaz.Text = "";
            textEkstra.Text = "";
            textInternet.Text = "";
            rctNotlar.Text = "";
            textMaas.Text = "";
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            GiderListele();
            Temizle();
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxAy.Text);
            komut.Parameters.AddWithValue("@p2", comboYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(textElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(textSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(textDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textMaas.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(textEkstra.Text));
            komut.Parameters.AddWithValue("@p9", rctNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Sisteme kayıtedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GiderListele();
            Temizle();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                textId.Text = dr["ID"].ToString();
                comboBoxAy.Text = dr["AY"].ToString();
                comboYil.Text = dr["YIL"].ToString();
                textElektrik.Text = dr["ELEKTRIK"].ToString();
                textSu.Text = dr["SU"].ToString();
                textDogalgaz.Text = dr["DOGALGAZ"].ToString();
                textInternet.Text = dr["INTERNET"].ToString();
                textMaas.Text = dr["MAASLAR"].ToString();
                textEkstra.Text = dr["EKSTRA"].ToString();
                rctNotlar.Text = dr["NOTLAR"].ToString();

            }
        }

        private void simpleButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void simpleButtonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_GIDERLER Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            GiderListele();
            Temizle();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_GIDERLER set AY=@p1,YIL=@p2,ELEKTRIK=@p3,SU=@p4,DOGALGAZ=@p5,INTERNET=@p6,MAASLAR=@p7,EKSTRA=@p8,NOTLAR=@p9 where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxAy.Text);
            komut.Parameters.AddWithValue("@p2", comboYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(textElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(textSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(textDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(textInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(textMaas.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(textEkstra.Text));
            komut.Parameters.AddWithValue("@p9", rctNotlar.Text);
            komut.Parameters.AddWithValue("@p10", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GiderListele();
            Temizle();
        }
    }
}
