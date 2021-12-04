using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtogaleriOtomasyon
{
    public partial class CalisanlarSayfasi : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NAEL1HH;Initial Catalog=OtoKiralama;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmdb;
        public CalisanlarSayfasi()
        {
            InitializeComponent();
        }
        void CalisanGoster()
        {
            baglanti.Open();
            komut = new SqlCommand("Select calisan_Adi,calisan_Soyadi,calisan_Cinsiyeti,calisan_Yasi,calisan_IseBaslama_Tarihi,calisan_Maas,calisan_Telefon,calisan_id from Calisanlar", baglanti);
            da = new SqlDataAdapter(komut);
            cmdb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Calisanlar");
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        void DepartmanCek()
        {
            komut = new SqlCommand("Select*from Departman", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBoxDepartman.Items.Add(dr["departman_Adi"]);
            }
            baglanti.Close();

        }
        void CalisanSilme(int calisan_id)
        {
            
            string sorgu = "Delete from Calisanlar Where calisan_id=@calisanid ";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@calisanid", calisan_id);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textboxAdi.Text == "")
                {
                    MessageBox.Show("Adını giriniz");
                }
                else if (textBoxSoyadi.Text == "")
                {
                    MessageBox.Show("Soyadını giriniz");
                }
                else if (radioButtonErkek.Checked == false && radioButtonKız.Checked == false)
                {
                    MessageBox.Show("Cinsiyeti seçiniz");

                }
                else if (comboBoxDepartman.Text == "")
                {
                    MessageBox.Show("Departmanı seçiniz");
                }
                else if(date_Isebaslama_Tarihi.Text=="")
                {
                    MessageBox.Show("İşe başlama tarihi giriniz");
                }
                else if (textBoxTelefon.Text.Length < 11)
                {
                    MessageBox.Show("Boş geçilemez ve 11 karakterden kısa olamaz");

                }
                else if (textBoxYas.Text.Length > 3)
                {
                    MessageBox.Show("Yaşınız 3 karakterden fazla olamaz");
                }
                else if (textBoxMaas.Text == "")
                {
                    MessageBox.Show("Lütfen çalışan maaşını giriniz");
                }
                else
                {
                    baglanti.Open();
                    string sorgu = "insert into Calisanlar(calisan_Adi,calisan_Soyadi,calisan_Cinsiyeti,calisan_Yasi,calisan_IseBaslama_Tarihi,calisan_Maas,calisan_departmanid,calisan_Telefon)values(@c1,@c2,@c3,@c4,@c5,@c6,@c7,@c8)";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@c1", textboxAdi.Text);
                    komut.Parameters.AddWithValue("@c2", textBoxSoyadi.Text);
                    if (radioButtonErkek.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@c3", 0);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@c3", 1);
                    }

                    komut.Parameters.AddWithValue("@c4", int.Parse(textBoxYas.Text));
                    komut.Parameters.AddWithValue("@c5", date_Isebaslama_Tarihi.Value);
                    komut.Parameters.AddWithValue("@c6", int.Parse(textBoxMaas.Text));
                    komut.Parameters.AddWithValue("@c7", comboBoxDepartman.SelectedIndex + 1);
                    komut.Parameters.AddWithValue("@c8", textBoxTelefon.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla kayıt Edildi");
                    
                   
                }
                baglanti.Close();
                CalisanGoster();

            }
            catch(FormatException)
            {
                MessageBox.Show("Bir hata oluştu.Uygun formatta giriniz verileri!!");
            }
          

        }

        private void CalisanlarSayfasi_Load(object sender, EventArgs e)
        {
            DepartmanCek();
            CalisanGoster();

        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int calisanid = Convert.ToInt32(drow.Cells[7].Value);
                CalisanSilme(calisanid);
            }
            CalisanGoster();
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            da.Update(ds, "Calisanlar");
            MessageBox.Show("Kayit Güncellendi");
            CalisanGoster();
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "Select * from Calisanlar Where calisan_Adi like '%"+textBoxAdSoyadAra.Text+ "%'or calisan_Soyadi like '%" + textBoxAdSoyadAra.Text + "%'";
            komut = new SqlCommand(sorgu, baglanti);
            da = new SqlDataAdapter(komut);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();

            baglanti.Close();
        }

        private void buttonTumCalisanlariGoster_Click(object sender, EventArgs e)
        {
            CalisanGoster();
        }
    }
}
