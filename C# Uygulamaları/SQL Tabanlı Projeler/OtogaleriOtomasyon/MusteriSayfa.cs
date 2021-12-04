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
    public partial class MusteriSayfa : Form
    {
        
        public MusteriSayfa() 
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NAEL1HH;Initial Catalog=OtoKiralama;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmdb;
        public void Temizle()
        {
            textboxTc.Text = null;
            textBoxAdi.Text = null;
            textBoxSoyadi.Text = null;
            textBoxTelefon.Text = null;
            textBoxMail.Text = null;
            richTextBox1.Text = null;
            comboBoxAracPlaka.Text = null;
            textBoxTcAra.Text = null;
        }
        public void Combobox_Plaka_Cekme()
        {
            komut = new SqlCommand("Select *from Araclar", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBoxAracPlaka.Items.Add(dr["aracPlaka"]);
            }
            baglanti.Close();
        }
        public void MusteriGoster()
        {
            baglanti.Open();
            komut = new SqlCommand("Select musteri_tc,musteri_adi,musteri_soyadi,musteri_telefon,musteri_mail,musteri_adres,arac_Plaka,arac_Gun,arac_Odenecek_Fiyat,musteri_id from Musteriler", baglanti);
            da = new SqlDataAdapter(komut);
            cmdb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds,"Musteriler");
            dataGridViewMusteri.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        void MusteriSil(int musteri_id)
        {
            string sil = "Delete from Musteriler Where musteri_id=@musteri_id";
            komut = new SqlCommand(sil, baglanti);
            komut.Parameters.AddWithValue("@musteri_id", musteri_id);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        bool durum;
        void Kontrol()
        {
            baglanti.Open();
            komut = new SqlCommand("Select *from Musteriler where arac_Plaka=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBoxAracPlaka.SelectedItem.ToString());
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();

        }
       
        private void MusteriSayfa_Load(object sender, EventArgs e)
        {
            Combobox_Plaka_Cekme();
            MusteriGoster();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow drow in dataGridViewMusteri.SelectedRows)
            {
                int musteri_id = Convert.ToInt32(drow.Cells[9].Value);
                MusteriSil(musteri_id);
            }
            MusteriGoster();
        }

        private void buttonM_Ekle_Click(object sender, EventArgs e)
        {
            if(textboxTc.Text==""||textboxTc.Text.Length<11)
            {
                MessageBox.Show("Tc Kimlik Numarası 11 haneden küçük girilemez veya boş geçilemez");
            }
            else if(textBoxAdi.Text=="")
            {
                MessageBox.Show("Adınızı Boş geçmeyiniz");
            }
            else if(textBoxSoyadi.Text=="")
            {
                MessageBox.Show("Soyadınızı Boş geçmeyiniz");
            }
            else if(textBoxTelefon.Text==""||textBoxTelefon.Text.Length<11)
            {
                MessageBox.Show("Telefon Numarası 11 haneden küçük olamaz");

            }
            else if(textBoxMail.Text=="")
            {
                MessageBox.Show("Mail adresini boş geçmeyiniz");
            }
            else if(comboBoxAracPlaka.Text=="")
            {
                MessageBox.Show("Lütfen araç plakasını seçiniz");
            }
            else if(richTextBox1.Text=="")
            {
                MessageBox.Show("Adres Giriniz");
            }
            else if (textBoxgunlukucret.Text=="")
            {
                MessageBox.Show("Günlük Ücreti giriniz");
            }
            else if(numericUpDown1.Value==0)
            {
                MessageBox.Show("Araç Kiralama Gün sayısını giriniz");
            }
            else
            {
                Kontrol();
                if (durum == true)
                {
                    baglanti.Open();
                    string sorgu = "insert into Musteriler(musteri_tc,musteri_adi,musteri_soyadi,musteri_telefon,musteri_mail,musteri_adres,arac_Plaka,arac_Gun,arac_GunlukFiyat,arac_Odenecek_Fiyat)values(@m1,@m2,@m3,@m4,@m5,@m6,@m7,@m8,@m9,@m10)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@m1", textboxTc.Text);
                    komut.Parameters.AddWithValue("@m2", textBoxAdi.Text);
                    komut.Parameters.AddWithValue("@m3", textBoxSoyadi.Text);
                    komut.Parameters.AddWithValue("@m4", textBoxTelefon.Text);
                    komut.Parameters.AddWithValue("@m5", textBoxMail.Text);
                    komut.Parameters.AddWithValue("@m6", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@m7", comboBoxAracPlaka.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@m8", numericUpDown1.Value);
                    komut.Parameters.AddWithValue("@m9", textBoxgunlukucret.Text);
                    string gun_sayisi = numericUpDown1.Value.ToString();
                    int odenece_fiyat = int.Parse(gun_sayisi) * int.Parse(textBoxgunlukucret.Text);
                    komut.Parameters.AddWithValue("@m10",odenece_fiyat);

                    komut.ExecuteNonQuery();

                    Temizle();
                    MessageBox.Show("Araç Başarıyla Kiralandı");
                    baglanti.Close();
                    MusteriGoster();
                }
                else
                {
                    MessageBox.Show("Araç Kiralanmış");
                }
            }
               
            
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            da.Update(ds, "Musteriler");
            MessageBox.Show("Kayit Güncellendi");
            MusteriGoster();
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            if(textBoxTcAra.Text.Length<11)
            {
                MessageBox.Show("Lütfen Tc Kimlik numarasını doğru giriniz");
            }
            else
            {
                baglanti.Open();
                komut = new SqlCommand("Select *from Musteriler Where musteri_tc='" + textBoxTcAra.Text + "'", baglanti);
                da = new SqlDataAdapter(komut);
                ds = new DataSet();
                da.Fill(ds);
                dataGridViewMusteri.DataSource = ds.Tables[0];
                baglanti.Close();
                Temizle();
            }
          
        }

        private void buttonMusteriGoster_Click(object sender, EventArgs e)
        {
            MusteriGoster();
        }
    }
}
