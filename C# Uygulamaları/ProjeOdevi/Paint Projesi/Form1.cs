using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ProjeOdevi
{
    public partial class Form1 : Form
    {
        List<Sekil> sekiller = new List<Sekil>();
        List<Panel> renkPaneli = new List<Panel>();
        List<Panel> sekilPaneli = new List<Panel>();
        private Sekil aktifsekil;
        private bool cizimaktifmi = false;

        private int _baslangic_X = 0;
        private int _baslangic_Y = 0;

        private Color sekilrengi;
        private Color sekilcizgi_Rengi;

        String secilensekil = "Kare";
        private Bitmap bm;
        private String sekil_islemleri = "";
        private String sekiladi = "";
        private bool sekil_secildi = false;


        public void RenkPaneli()
        {
            renkPaneli.Add(panelkirmizi);
            renkPaneli.Add(panellacivert);
            renkPaneli.Add(panelyesil);
            renkPaneli.Add(panelturuncu);
            renkPaneli.Add(panelsihay);
            renkPaneli.Add(panelsari);
            renkPaneli.Add(panelmor);
            renkPaneli.Add(panelkahverengi);
            renkPaneli.Add(panelbeyaz);
        }
        public void SekilPaneli()
        {
            sekilPaneli.Add(panelkare);
            sekilPaneli.Add(panelDaire);
            sekilPaneli.Add(panelUcgen);
            sekilPaneli.Add(panelaltigen);
        }
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            bm = new Bitmap(CizimAlani.Width, CizimAlani.Height);

            RenkPaneli();
            SekilPaneli();
            secilensekil = "Kare";
            sekiladi = "Kare";
            sekilrengi = Color.Red;
            sekilcizgi_Rengi = Color.Black;
            panelkare.BackColor = Color.Violet;
            panelkirmizi.BackColor = Color.Violet;
           
        }
        private void RenkPanel_Sec(Panel panel)
        {
            foreach (Panel p in renkPaneli)
            {
                if(p == panel)
                {
                    p.BackColor = Color.Violet;
                }
                else
                {
                    p.BackColor = Color.LightSkyBlue;
                }

            }
        }
        private void SekilPanel_Sec(Panel panel)
        {
            foreach (Panel p in sekilPaneli)
            {
                if (p == panel)
                {
                    p.BackColor = Color.Violet;
                }
                else
                {
                    p.BackColor = Color.LemonChiffon;
                }
            }
        }
        private void CizimAlani_Paint(object sender, PaintEventArgs e)
        {
           Graphics cizimaraci = e.Graphics;
           foreach(var s in sekiller)
               s.Ciz(cizimaraci);
            if(cizimaktifmi)
              aktifsekil.Ciz(cizimaraci);
        }

        private void CizimAlani_MouseUp(object sender, MouseEventArgs e)//Mouse işlemi bittiğinde
        {
            if (cizimaktifmi)
            {
                sekiller.Add(aktifsekil);
                _baslangic_X = 0;
                _baslangic_Y = 0;
                cizimaktifmi = false;
                CizimAlani.Invalidate();
            }
        }
        private void CizimAlani_MouseDown(object sender, MouseEventArgs e)
        {
            _baslangic_X = e.X;
            _baslangic_Y = e.Y;
            if (sekil_islemleri == "sec")
            {
                foreach (var s in sekiller)
                {
                    if(s.Mouse_Seklin_Icindemi(_baslangic_X,_baslangic_Y,s.X,s.Y))
                    {
                        s.Sekil_Cizgi_Rengi = Color.Violet ;
                        sekil_secildi = true;
                        CizimAlani.Refresh();
                        
                    }
                    if(sekil_secildi == true)
                    {
                        sekil_secildi = false; 
                        s.Sekilrengi = sekilrengi;
                        CizimAlani.Refresh();
                        s.Sekil_Cizgi_Rengi = Color.Transparent;
                        break;
                    }

                }
               
            }
            if(sekil_islemleri=="silme")
            {
                foreach (var s in sekiller)
                {
                   if (s.Mouse_Seklin_Icindemi(_baslangic_X, _baslangic_Y, s.X, s.Y))
                    {
                            sekiller.Remove(s);
                            Refresh();
                            sekil_islemleri = "yok";
                            panelSilme.BackColor = Color.White;
                            break;
                    }
                }
            }
            if (!cizimaktifmi)
            {
                    Rectangle rectangle = new Rectangle(e.X, e.Y, 0, 0);
                    switch (secilensekil)
                    {
                        case "Kare":

                            aktifsekil = new Kare(rectangle, sekilrengi,sekiladi);
                            cizimaktifmi = true;
                            break;

                        case "Daire":
                            aktifsekil = new Daire(rectangle, sekilrengi,sekiladi);
                            cizimaktifmi = true;
                            break;
                        case "Ucgen":
                            aktifsekil = new Ucgen(rectangle, sekilrengi);
                            cizimaktifmi = true;
                            break;

                        case "Altigen":
                            aktifsekil = new Altigen(rectangle, sekilrengi);
                            cizimaktifmi = true;
                            break;
                    }
              
            }
           
        }
        private void CizimAlani_MouseMove(object sender, MouseEventArgs e)
        {
            if (cizimaktifmi)
            {
                aktifsekil.BitisKordinatlari(e.X, e.Y);
                aktifsekil.sekiladi = sekiladi;
                CizimAlani.Invalidate();
            }
            textBox1.Text = "X: " + e.X;
            textBox2.Text = "Y: " + e.Y;

        }
      
        private void Kare_Click(object sender, EventArgs e)
        {
            secilensekil ="Kare";
            sekil_islemleri = "yok";
            sekiladi = "Kare";
            panelSecme.BackColor = Color.White;
            SekilPanel_Sec(panelkare);

        }
        private void Daire_Click(object sender, EventArgs e)
        {
            secilensekil = "Daire";
            sekil_islemleri = "yok";
            sekiladi = "Daire";
            panelSecme.BackColor = Color.White;
            SekilPanel_Sec(panelDaire);
        }
        private void Ucgen_Click(object sender, EventArgs e)
        {
            sekil_islemleri = "yok";
            panelSecme.BackColor = Color.White;
            secilensekil = "Ucgen";
            SekilPanel_Sec(panelUcgen);
        }
        private void altigen_Click(object sender, EventArgs e)
        {
            secilensekil = "Altigen";
            sekil_islemleri = "yok";
            panelSecme.BackColor = Color.White;
            SekilPanel_Sec(panelaltigen);
        }
        private void kirmizi_Click(object sender, EventArgs e)
        {

            sekilrengi = Color.Red;
            RenkPanel_Sec(panelkirmizi);
        }
        private void lacivert_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.Blue;
            RenkPanel_Sec(panellacivert);
        }
        private void yesil_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.Green;
            RenkPanel_Sec(panelyesil);
        }
        private void turuncu_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.Orange;
            RenkPanel_Sec(panelturuncu);
        }

        private void siyah_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.Black;
            RenkPanel_Sec(panelsihay);
        }

        private void sari_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.Yellow;
            RenkPanel_Sec(panelsari);
        }

        private void mor_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.Purple;
            RenkPanel_Sec(panelmor);
        }

        private void kahverengi_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.FromArgb(192, 64, 0);
            RenkPanel_Sec(panelkahverengi);
        }

        private void beyaz_Click(object sender, EventArgs e)
        {
            sekilrengi = Color.White;
            RenkPanel_Sec(panelbeyaz);

        }

        private void buttonsilme_Click(object sender, EventArgs e)
        {
            Graphics g = CizimAlani.CreateGraphics();
            g.Clear(CizimAlani.BackColor);
        }

        private void Silme_Click(object sender, EventArgs e)
        {
            sekil_islemleri = "silme";
            secilensekil = "Yok";
            panelSilme.BackColor = Color.Violet;
            panelSecme.BackColor = Color.White;
        }

        private void Secme_Click(object sender, EventArgs e)
        {
            sekil_islemleri = "sec";
            secilensekil = "Yok";
            panelSilme.BackColor = Color.White;
            panelSecme.BackColor = Color.Violet;
        }
        private void kaydet_Click(object sender, EventArgs e)
        {
            panelkaydet.BackColor = Color.Violet;
            panelAc.BackColor = Color.Aqua;
            //Bitmap bm = new Bitmap(CizimAlani.Width, CizimAlani.Height);
            //Graphics cizimalani = Graphics.FromImage(bm);
            //Rectangle rect = CizimAlani.RectangleToScreen(CizimAlani.ClientRectangle);
            //cizimalani.CopyFromScreen(rect.Location, Point.Empty, CizimAlani.Size);

            //SaveFileDialog kaydet = new SaveFileDialog();
            //kaydet.Filter = "Txt files| *.txt";

            //if (kaydet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    try
            //    {

            //        if (File.Exists(kaydet.FileName))
            //        {
            //            File.Delete(kaydet.FileName);
            //        }
            //        if (kaydet.FileName.Contains(".txt"))
            //        {
            //            bm.Save(kaydet.FileName, ImageFormat.MemoryBmp);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Dosya kaydetme hatası : " + ex.Message);
            //    }
            //}
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Filter = "Metin Dosyası|*.txt";
            kaydet.OverwritePrompt = true;
            kaydet.CreatePrompt = true;
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                StreamWriter kayit = new StreamWriter(kaydet.FileName);
                foreach (var sekil in sekiller)
                {
                    kayit.WriteLine(sekil.sekiladi + "," + sekil.X + "," + sekil.Y+","+150+","+150+","+sekil.Sekilrengi);
                }
                kayit.Close();
            }
        }
        private void Ac_Click(object sender, EventArgs e)
        {
            //panelAc.BackColor = Color.Violet;
            //panelkaydet.BackColor = Color.Aqua;
            //cizimaktifmi = false;
            //OpenFileDialog dosya_ac = new OpenFileDialog();
            //dosya_ac.Filter = "Txt files| *.txt";
            //if (dosya_ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    try
            //    {

            //        CizimAlani.Image = (Image)Image.FromFile(dosya_ac.FileName).Clone();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Hatali resim " + ex.Message);
            //    }
            //}
            OpenFileDialog dosya_ac = new OpenFileDialog();
            dosya_ac.Filter = "Metin dosyası| *.txt";
            sekiller.Clear();
            if (dosya_ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = new FileStream(dosya_ac.FileName, FileMode.Open, FileAccess.Read);
                StreamReader oku = new StreamReader(fs);
                string satir = "";
                while ((satir = oku.ReadLine()) != null)
                {
                   String[] parcalar = satir.Split(',');
                    if(parcalar[0]=="Kare")
                    {
                        if (parcalar[5] == "Color [Red]")
                            sekilrengi = Color.Red;
                        else if (parcalar[5] == "Color [Blue]")
                            sekilrengi = Color.Blue;
                        else if (parcalar[5] == "Color [Green]")
                            sekilrengi = Color.Green;
                        else if (parcalar[5] == "Color [Orange]")
                            sekilrengi = Color.Orange;
                        else if (parcalar[5] == "Color [Black]")
                            sekilrengi = Color.Black;
                        else if (parcalar[5] == "Color [Yellow]")
                            sekilrengi = Color.Yellow;
                        else if (parcalar[5] == "Color [Purple]")
                            sekilrengi = Color.Purple;
                        else if (parcalar[5] == "Color [A=255, R=192, G=64, B=0]")
                            sekilrengi = Color.FromArgb(192, 64, 0);
                        else 
                            sekilrengi = Color.White;
                            cizimaktifmi = true;
                            Rectangle rectangle = new Rectangle(int.Parse(parcalar[1]), int.Parse(parcalar[2]), int.Parse(parcalar[3]), int.Parse(parcalar[4]));
                            aktifsekil = new Kare(rectangle, sekilrengi, sekiladi);
                            break;
                    }
                    else if (parcalar[0] == "Daire")
                    {
                        if (parcalar[3] == "Color [Red]")
                            sekilrengi = Color.Red;
                        else if (parcalar[5] == "Color [Blue]")
                            sekilrengi = Color.Blue;
                        else if (parcalar[5] == "Color [Green]")
                            sekilrengi = Color.Green;
                        else if (parcalar[5] == "Color [Orange]")
                            sekilrengi = Color.Orange;
                        else if (parcalar[5] == "Color [Black]")
                            sekilrengi = Color.Black;
                        else if (parcalar[5] == "Color [Yellow]")
                            sekilrengi = Color.Yellow;
                        else if (parcalar[5] == "Color [Purple]")
                            sekilrengi = Color.Purple;
                        else if (parcalar[5] == "Color [A=255, R=192, G=64, B=0]")
                            sekilrengi = Color.FromArgb(192, 64, 0);
                        else
                            sekilrengi = Color.White;
                        cizimaktifmi = true;
                        Rectangle rectangle = new Rectangle(int.Parse(parcalar[1]), int.Parse(parcalar[2]), int.Parse(parcalar[3]), int.Parse(parcalar[4]));
                        aktifsekil = new Daire(rectangle, sekilrengi, sekiladi);
                        break;
                    }

                    sekiller.Add(aktifsekil);
                    cizimaktifmi = false;
                    CizimAlani.Invalidate();

                }
                oku.Close();

            }

        }
    }

}

