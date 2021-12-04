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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControlFaturaGoster.DataSource = dt;
        }
        void Temizle()
        {
            textId.Text = "";
            textSeri.Text = "";
            textSıra.Text = "";
            dateTarih.Text = "";
            mstSaat.Text = "";
            textVergi.Text = "";
            textAlici.Text = "";
            textTeslimEden.Text = "";
            textTeslimAlan.Text = "";
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        private void simpleButtonKaydet_Click(object sender, EventArgs e)
        {
            //Firma Carisi
            if (textFaturaId.Text!="" && comboBox1.Text == "Firma")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TextFiyat.Text);
                miktar = Convert.ToDouble(textMiktar.Text);
                tutar = miktar * fiyat;
                textTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID)values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", textUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", textMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(TextFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(textTutar.Text));
                komut2.Parameters.AddWithValue("@p5", textFaturaId.Text);
                komut2.ExecuteNonQuery();
                
                //Hareket Tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER(URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH)values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", textUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", textMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", textEditPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", textEditFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(TextFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(textTutar.Text));
                komut3.Parameters.AddWithValue("@h7", textFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", dateTarih.Text);
                komut3.ExecuteNonQuery();
                //Stok sayısını azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER Set ADET=ADET-@s1 Where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", textMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", textUrunId.Text);
                bgl.baglanti().Close();
                MessageBox.Show("Fatura ait Ürün Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
            
            if (textFaturaId.Text == "" )
            {

                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textSeri.Text);
                komut.Parameters.AddWithValue("@p2", textSıra.Text);
                komut.Parameters.AddWithValue("@p3", dateTarih.Text);
                komut.Parameters.AddWithValue("@p4", mstSaat.Text);
                komut.Parameters.AddWithValue("@p5", textVergi.Text);
                komut.Parameters.AddWithValue("@p6", textAlici.Text);
                komut.Parameters.AddWithValue("@p7", textTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", textTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            //Müşteri Carisi
            if (textFaturaId.Text != "" && comboBox1.Text == "Müşteri")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TextFiyat.Text);
                miktar = Convert.ToDouble(textMiktar.Text);
                tutar = miktar * fiyat;
                textTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID)values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", textUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", textMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(TextFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(textTutar.Text));
                komut2.Parameters.AddWithValue("@p5", textFaturaId.Text);
                komut2.ExecuteNonQuery();

                //Hareket Tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKET(URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH)values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", textUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", textMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", textEditPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", textEditFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(TextFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(textTutar.Text));
                komut3.Parameters.AddWithValue("@h7", textFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", dateTarih.Text);
                komut3.ExecuteNonQuery();
                //Stok sayısını azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER Set ADET=ADET-@s1 Where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", textMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", textUrunId.Text);
                bgl.baglanti().Close();
                MessageBox.Show("Fatura ait Ürün Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                textId.Text = dr["FATURABILGIID"].ToString();
                textSeri.Text = dr["SERI"].ToString();
                textSıra.Text = dr["SIRANO"].ToString();
                dateTarih.Text = dr["TARIH"].ToString();
                mstSaat.Text = dr["SAAT"].ToString();
                textVergi.Text = dr["VERGIDAIRE"].ToString();
                textAlici.Text = dr["ALICI"].ToString();
                textTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                textTeslimAlan.Text = dr["TESLIMALAN"].ToString();
            }
            
        }
        private void simpleButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void simpleButtonSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURABILGI Where FATURABILGIID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Listele();
            Temizle();
        }

        private void simpleButtonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI Set SERI=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRE=@p5,ALICI=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 Where FATURABILGIID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textSeri.Text);
            komut.Parameters.AddWithValue("@p2", textSıra.Text);
            komut.Parameters.AddWithValue("@p3", dateTarih.Text);
            komut.Parameters.AddWithValue("@p4", mstSaat.Text);
            komut.Parameters.AddWithValue("@p5", textVergi.Text);
            komut.Parameters.AddWithValue("@p6", textAlici.Text);
            komut.Parameters.AddWithValue("@p7", textTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", textTeslimAlan.Text);
            komut.Parameters.AddWithValue("@p9", textId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgi Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void simpleButtonBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT from TBL_URUNLER Where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textUrunId.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                textUrunAd.Text = dr["URUNAD"].ToString();
                TextFiyat.Text = dr["SATISFIYAT"].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
