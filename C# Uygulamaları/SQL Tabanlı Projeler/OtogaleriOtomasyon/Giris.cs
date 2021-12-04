using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtogaleriOtomasyon
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            string kullaniciadi = textBoxKullanıcıAdı.Text;
            string sifre = textBoxSifre.Text;

              if (kullaniciadi == "admin" && sifre == "123456")
                {
                    progressBar1.Visible = true;
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.MarqueeAnimationSpeed = 10;
                    labelGiriliyor.Visible = true;
                    timer1.Interval = 3000;
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Lütfen Kullanıcı adı ve şifreyi doğru giriniz");
                }
          
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if(i==1)
            {
                
                timer1.Stop();
                
                this.Hide();
              
                Form1 frm1 = new Form1();
                frm1.Show();
            }
            
        }
    }
}
