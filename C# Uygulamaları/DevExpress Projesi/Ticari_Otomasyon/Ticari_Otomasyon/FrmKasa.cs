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
using DevExpress.Charts;
namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void MusteriHareketleri()
        {
            SqlDataAdapter da = new SqlDataAdapter("Exec MusteriHareket", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControlMusteriHareketler.DataSource = dt;
            
        }
        void Giderler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_GIDERLER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void FirmaHareketleri()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Exec FirmaHareketler", bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }
        void ToplamTutar()
        {
            SqlCommand komut = new SqlCommand("Select SUM(FIYAT) from TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblToplamTutar.Text = dr[0].ToString()+" TL";
            }
        }
        //son ayın faturaları
        void FaturaOdemeleri()
        {
            SqlCommand komut = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA)from TBL_GIDERLER ORDER BY ID asc ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelodemeler.Text = dr[0].ToString() + " TL";
            }
        }
        //Son ayın personel maaş toplamı
        void PersonelMaasOdemeleri()
        {
            SqlCommand komut = new SqlCommand("Select MAASLAR from TBL_GIDERLER ORDER BY ID asc ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelPersonelMaaslari.Text = dr[0].ToString() + " TL";
            }
        }
        //Musteri Sayisi
        void MusteriSayisi()
        {
            SqlCommand komut = new SqlCommand("Select Count(AD) from TBL_MUSTERILER ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelMusteriSayisi.Text = dr[0].ToString();
            }
        }
        void FirmaSayisi()
        {
            SqlCommand komut = new SqlCommand("Select Count(AD) from TBL_FIRMALAR ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelFirmaSayisi.Text = dr[0].ToString();
            }
        }
        void FirmaSehirSayisi()
        {
            SqlCommand komut = new SqlCommand("Select Count(Distinct(IL)) from TBL_FIRMALAR ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelSehirSayisi.Text = dr[0].ToString();
            }
        }
        void MusteriSehirSayisi()
        {
            SqlCommand komut = new SqlCommand("Select Count(Distinct(IL)) from TBL_MUSTERILER ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelSehirSayisi2.Text = dr[0].ToString();
            }
        }
        void PersonelSayisi()
        {
            SqlCommand komut = new SqlCommand("Select Count(*) from TBL_PERSONELLER ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelPersonelSayisi.Text = dr[0].ToString();
            }
        }
        void ToplamUrunSayisi()
        {
            SqlCommand komut = new SqlCommand("Select SUM(ADET) from TBL_URUNLER ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                labelStokSayisi.Text = dr[0].ToString();
            }
        }
        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            MusteriHareketleri();
            Giderler();
            lblAktifKullanici.Text = ad;
            FirmaHareketleri();
            ToplamTutar();
            FaturaOdemeleri();
            PersonelMaasOdemeleri();
            MusteriSayisi();
            FirmaSayisi();
            PersonelSayisi();
            FirmaSehirSayisi();
            MusteriSehirSayisi();
          
           
            bgl.baglanti().Close();
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if(sayac>0&&sayac<=5)
            {
                //1.Chart Controle ELektrik Faturası son 4 ay
                groupControl10.Text = "ELEKTRİK";
                chartControl1.Series["AYLAR"].Points.Clear();
                
                SqlCommand komut = new SqlCommand("Select top 4 AY,ELEKTRIK from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }
               
               
            }
            else if(sayac>5&&sayac<=10)
            {
                groupControl10.Text = "SU";
                chartControl1.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 AY,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            else if (sayac > 10 && sayac <= 15)
            {
                groupControl10.Text = "DOĞALGAZ";
                chartControl1.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 DOGALGAZ,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            else if (sayac > 15 && sayac <= 20)
            {
                groupControl10.Text = "İNTERNET";
                chartControl1.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 INTERNET,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            else if (sayac > 20 && sayac <= 25)
            {
                groupControl10.Text = "EKSTRA";
                chartControl1.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 EKSTRA,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            if(sayac==26)
            {
                sayac = 0;
            }
          
        }
        int sayac2=0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            if (sayac2 > 0 && sayac2 <= 5)
            {
                //1.Chart Controle ELektrik Faturası son 4 ay
                groupControl11.Text = "ELEKTRİK";
                chartControl2.Series["AYLAR"].Points.Clear();

                SqlCommand komut = new SqlCommand("Select top 4 AY,ELEKTRIK from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                }


            }
            else if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl11.Text = "SU";
                chartControl2.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 AY,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            else if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl11.Text = "DOĞALGAZ";
                chartControl2.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 DOGALGAZ,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            else if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl10.Text = "İNTERNET";
                chartControl1.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 INTERNET,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            else if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl11.Text = "EKSTRA";
                chartControl2.Series["AYLAR"].Points.Clear();
                //2.Chart Controle SU Faturası son 4 ay
                SqlCommand komut1 = new SqlCommand("Select top 4 EKSTRA,SU from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
            bgl.baglanti().Close();
        }


    }
}
