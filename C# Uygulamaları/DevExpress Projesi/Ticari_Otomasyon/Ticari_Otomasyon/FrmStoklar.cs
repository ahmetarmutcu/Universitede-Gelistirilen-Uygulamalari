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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Kastamonu", 10);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 12);

            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD as 'ÜRÜN ADI',SUM(ADET) as 'MİKTAR' from TBL_URUNLER group by URUNAD", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta Stok Miktarı Listeleme
            SqlCommand komut = new SqlCommand("Select URUNAD as 'ÜRÜN ADI',SUM(ADET) as 'MİKTAR' from TBL_URUNLER group by URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));

            }

            //Charta firma şehir sayısı çekme
            SqlCommand komut2 = new SqlCommand("Select IL,Count(*) from TBL_FIRMALAR group by IL", bgl.baglanti());
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr1[0]), int.Parse(dr1[1].ToString()));

            }
            bgl.baglanti().Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay fr = new FrmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.urunad = dr["ÜRÜN ADI"].ToString();
            }
            fr.Show();
        }
    }
}
