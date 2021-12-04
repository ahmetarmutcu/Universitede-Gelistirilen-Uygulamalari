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
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void AzalanStoklar()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,SUM(ADET)as 'ADET' from TBL_URUNLER group by URUNAD having SUM(ADET)<20 order by ADET asc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControlAzalanStoklar.DataSource = dt;

        }
        void Ajanda()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select top 5 NOTTARIH,NOTSAAT,NOTBASLIK,NOTDETAY from TBL_NOTLAR order by NOTID desc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }
        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec OzetFirmaHareketleri", bgl.baglanti());
            da.Fill(dt);
            gridControlFirmaHareketleri.DataSource = dt;
        }
        void Fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 from TBL_FIRMALAR order by AD asc", bgl.baglanti());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            AzalanStoklar();
            Ajanda();
            FirmaHareketleri();
            Fihrist();
            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");
            webBrowser3.Navigate("https://www.youtube.com");
        }

        
    }
}
