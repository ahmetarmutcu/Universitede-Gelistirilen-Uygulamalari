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
    public partial class AraclarSayfasi : Form
    {
        public AraclarSayfasi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NAEL1HH;Initial Catalog=OtoKiralama;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        DataSet ds;
        public void AracGoster()
        {
            baglanti.Open();
            string kayit = "Select *from Araclar";
            komut = new SqlCommand(kayit, baglanti);
            da = new SqlDataAdapter(komut);
            ds = new DataSet();
            da.Fill(ds,"Araclar");
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        public void TextTemizle()
        {
            textBoxGunlukFiyat.Text = null;
            textboxModel.Text = null;
            textBoxMotorGucu.Text = null;
            textBoxPlakaNo.Text = null;
            textBoxMarka.Text = null;
        }

        private void AraclarSayfasi_Load(object sender, EventArgs e)
        {
            AracGoster();
            buttonEkle.Visible = true;
            buttonDuzenle.Visible = false;
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if (textboxModel.Text == "")
            {
                MessageBox.Show("Araba Modeli Gİriniz");
            }
            else if (textBoxMarka.Text == "")
            {
                MessageBox.Show("Araba Markası Giriniz");
            }
            else if (textBoxPlakaNo.Text == "")
            {
                MessageBox.Show("Arabanın Plakasını Giriniz");
            }
            else if (textBoxMotorGucu.Text == "")
            {
                MessageBox.Show("Arabanın Motorgücünü giriniz");
            }
            else if (textBoxGunlukFiyat.Text == "")
            {
                MessageBox.Show("Arabanın Günlük Ücretini giriniz..");
            }
            else
            {
                baglanti.Open();
                String kayit = "insert into Araclar(aracModel,aracMarka,aracPlaka,aracMotorGucu,aracGunlukFiyat)values(@a1,@a2,@a3,@a4,@a5)";
                komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@a1", textboxModel.Text);
                komut.Parameters.AddWithValue("@a2", textBoxMarka.Text);
                komut.Parameters.AddWithValue("@a3", textBoxPlakaNo.Text);
                komut.Parameters.AddWithValue("@a4", textBoxMotorGucu.Text);
                komut.Parameters.AddWithValue("@a5", textBoxGunlukFiyat.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Araç Başarıyla Eklendi");
                AracGoster();
                TextTemizle();
            }
            

        }
        void KayitSil(int aracid)
        {
            string sil = "Delete from Araclar Where aracid=@aracid";
             komut = new SqlCommand(sil, baglanti);
            komut.Parameters.AddWithValue("@aracid", aracid);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        void KayitGuncelle(int aracid)
        {
          
            string guncelle = "Update Araclar Set aracModel=@model,aracMarka=@marka Where aracid=@aracid";
            komut = new SqlCommand(guncelle, baglanti);
            komut.Parameters.AddWithValue("@model", textboxModel.Text);
            komut.Parameters.AddWithValue("@marka", textBoxMarka.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void buttonSil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int aracid = Convert.ToInt32(drow.Cells[0].Value);
                KayitSil(aracid);

            }
            MessageBox.Show("Arac Silindi");
            AracGoster();
        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            if(textboxModel.Text=="")
            {
                MessageBox.Show("Araba Modeli Gİriniz");
            }
            else if(textBoxMarka.Text=="")
            {
                MessageBox.Show("Araba Markası Giriniz");
            }
            else if (textBoxPlakaNo.Text == "")
            {
                MessageBox.Show("Arabanın Plakasını Giriniz");
            }
            else if(textBoxMotorGucu.Text=="")
            {
                MessageBox.Show("Arabanın Motorgücünü giriniz");
            }
            else if(textBoxGunlukFiyat.Text=="")
            {
                MessageBox.Show("Arabanın Günlük Ücretini giriniz..");
            }
            else
            {
                baglanti.Open();
                komut = new SqlCommand("Update Araclar set aracModel=@model,aracMarka=@marka,aracPlaka=@plaka,aracMotorGucu=@motorgucu,aracGunlukFiyat=@gunluk where aracid=" + aracid, baglanti);
                komut.Parameters.AddWithValue("@model", textboxModel.Text);
                komut.Parameters.AddWithValue("@marka", textBoxMarka.Text);
                komut.Parameters.AddWithValue("@plaka", textBoxPlakaNo.Text);
                komut.Parameters.AddWithValue("@motorgucu", textBoxMotorGucu.Text);
                komut.Parameters.AddWithValue("@gunluk", textBoxGunlukFiyat.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Araç Düzenlendi");
                TextTemizle();
                buttonEkle.Visible = true;
                buttonDuzenle.Visible = false;
                AracGoster();
            }
           

        }
        int motorgucu, fiyat,aracid;

        private void buttonAracGoster_Click(object sender, EventArgs e)
        {
            AracGoster();
        }

        private void buttonArama_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string ara = "Select *from Araclar Where aracPlaka='" + textBoxAracPlaka.Text + "'";
            komut = new SqlCommand(ara, baglanti);
            da = new SqlDataAdapter(komut);
            ds = new DataSet();
            da.Fill(ds,"Araclar");
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textboxModel.Text = ds.Tables["Araclar"].Rows[e.RowIndex]["aracModel"].ToString();
            textBoxMarka.Text = ds.Tables["Araclar"].Rows[e.RowIndex]["aracMarka"].ToString();
            textBoxPlakaNo.Text = ds.Tables["Araclar"].Rows[e.RowIndex]["aracPlaka"].ToString();
            motorgucu = Convert.ToInt32(ds.Tables["Araclar"].Rows[e.RowIndex]["aracMotorGucu"]);
            textBoxMotorGucu.Text = motorgucu.ToString();
            fiyat= Convert.ToInt32(ds.Tables["Araclar"].Rows[e.RowIndex]["aracGunlukFiyat"]);
            textBoxGunlukFiyat.Text = fiyat.ToString();
            aracid= Convert.ToInt32(ds.Tables["Araclar"].Rows[e.RowIndex]["aracid"]);
            textBoxaracid.Text = aracid.ToString();
            buttonEkle.Visible = false;
            buttonDuzenle.Visible = true;

        }
    }
}
