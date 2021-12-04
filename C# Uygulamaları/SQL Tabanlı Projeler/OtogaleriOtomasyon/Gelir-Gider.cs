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
    public partial class Gelir_Gider : Form
    {
        public Gelir_Gider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NAEL1HH;Initial Catalog=OtoKiralama;Integrated Security=True");
        SqlCommand komut;
        public void Gelir_Cekme()
        {
            komut = new SqlCommand("Select *from Musteriler", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["musteri_tc"]+"  "+dr["arac_Odenecek_Fiyat"]+" "+"TL"+" "+ dr["musteri_adi"]);
            }
            baglanti.Close();
        }
        public void Gider_Cekme()
        {
            komut = new SqlCommand("Select calisan_Adi,calisan_Soyadi,calisan_Maas from Calisanlar", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                listBox2.Items.Add(dr["calisan_Maas"]+" TL  "+dr["calisan_Adi"]+dr["calisan_Soyadi"]);
            }
            baglanti.Close();
        }
        int sonuc = 0;
        int gidersonuc = 0;
        int toplam = 0;
        private void Gelir_Gider_Load(object sender, EventArgs e)
        {
           
            Gelir_Cekme();
            Gider_Cekme();
            string[] s;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                s = listBox1.Items[i].ToString().Split(' ');
                sonuc += int.Parse(s[2]);
            }
            labelSonuc.Text = sonuc.ToString() + " TL";
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                s = listBox2.Items[i].ToString().Split(' ');
                gidersonuc += int.Parse(s[0]);
            }
            labelSonucGider.Text = gidersonuc.ToString() + " TL";
            int sonuckar = sonuc-gidersonuc;
            labelKar.Text = sonuckar + " TL'DİR.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            toplam=int.Parse(textBoxSuFaturasi.Text) + int.Parse(textBoxElektrikFaturasi.Text) + int.Parse(textBoxDogalgazFaturasi.Text) + int.Parse(textBoxDigderUcretler.Text);
            labelFaturalar.Text = toplam + " TL";
            int sonuckar = sonuc - (gidersonuc+toplam);
            labelKar.Text = sonuckar + " TL'DİR.";
        }
      
    }
}
