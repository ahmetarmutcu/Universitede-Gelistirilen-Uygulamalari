using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {

            textMail.Text = mail;
        }
        bool kontrol = true;
        private void simpleButtonGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage(); // Mail sınıfından bir değişken türetiyoruz
            mesaj.From = new MailAddress("ahmetarmutcu2017@gmail.com");
            mesaj.To.Add(textMail.Text);
            mesaj.Subject ="KONU: "+textKonu.Text;
            mesaj.Body ="MESAJ: \n"+rctMesaj.Text;
            SmtpClient rc = new SmtpClient();
            // Gönderenin eposta giriş bilgileri
            rc.Credentials = new System.Net.NetworkCredential("ahmetarmutcu2017@gmail.com","Bensenim1453.");
            rc.Port = 587;
            rc.Host = "smtp.gmail.com";
            rc.EnableSsl = true;
            object userState = mesaj;
            try
            {
                rc.SendAsync(mesaj, (object)mesaj);
                MessageBox.Show("Mesaj Gönderilmiştir");
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mesaj Gönderilmiştir");
            }


        }
    }
}
