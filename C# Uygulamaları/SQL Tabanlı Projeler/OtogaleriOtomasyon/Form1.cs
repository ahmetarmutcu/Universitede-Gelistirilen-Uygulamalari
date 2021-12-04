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

namespace OtogaleriOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NAEL1HH;Initial Catalog=OtoKiralama;Integrated Security=True");
        private void pictureboxArac_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "Select *from Araclar";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dataGridViewBilgiler.DataSource = dt;
            baglanti.Close();


        }
        private void buttonAraclar_Click(object sender, EventArgs e)
        {
            AraclarSayfasi Araclar = new AraclarSayfasi();
            Araclar.Show();
        }

        private void buttonMusteriBilgi_Click(object sender, EventArgs e)
        {
            MusteriSayfa Musteriler = new MusteriSayfa();
            Musteriler.Show();
        }

        private void buttonCalisanKisiler_Click(object sender, EventArgs e)
        {
            CalisanlarSayfasi calisanlar = new CalisanlarSayfasi();
            calisanlar.Show();
        }

        private void buttonGelirGider_Click(object sender, EventArgs e)
        {
            Gelir_Gider gelirgider = new Gelir_Gider();
            gelirgider.Show();
        }
    }
}
