using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoparkSimulasyonProject
{
    public partial class Form1 : Form
    {
        List<string> parkAdi = new List<string>();
        List<int> bitisSuresi = new List<int>();
        List<int> parkBaslangicListesi = new List<int>();
        List<int> sistemdeGecirilenSure = new List<int>();
        List<int> park1Kullanimi = new List<int>();
        List<int> park2Kullanimi = new List<int>();
        List<int> park3Kullanimi = new List<int>();
        List<int> park4Kullanimi = new List<int>();
        List<int> park5Kullanimi = new List<int>();
        int parkToplami = 0;
        public Form1()
        {

            InitializeComponent();
        }
        int aracSayisi = 20;
        private void Form1_Load(object sender, EventArgs e)
        {
            Guncelle();
        }
        int[] gecikmeSureleri = new int[20];
        int[] beklemeSureleri = new int[20];


        void Guncelle()
        {

            ///Textbox oluşturmak için kullanıldı
            getAracSayisiLabel(aracSayisi);
            getVarislarArasiSureText(aracSayisi);
            getVarisZamaniText(aracSayisi);
            getOtoparkBeklemeSuresiText(aracSayisi);
            getParkBaslangicText(aracSayisi);
            getSecilenParkAlani(aracSayisi);
            getPark1Bitis(aracSayisi);
            getPark2Bitis(aracSayisi);
            getPark3Bitis(aracSayisi);
            getPark4Bitis(aracSayisi);
            getPark5Bitis(aracSayisi);
            getGecikme(aracSayisi);
            getSistemdeGecirilenSure(aracSayisi);
            getPark1Kullanimi(aracSayisi);
            getPark2Kullanimi(aracSayisi);
            getPark3Kullanimi(aracSayisi);
            getPark4Kullanimi(aracSayisi);
            getPark5Kullanimi(aracSayisi);

            //Geliş  zamanları elle girilmişti bunlar textboxxlara aktarıldı.
            textPrint("txtBeklemeSuresi", rastgeleBeklemeSuresiUret(1, 8, 20));
            textPrint("txtVarisZamani", getVarisZamani());
            textPrint("txtVarislarArasiSure", varislarArasiSureHesapla(getVarisZamani(), aracSayisi));
            textPrint("txtParkBaslangic", getVarisZamani());
            textPrint("txtgecikme", gecikmeHesaplama(getVarisZamani()));
            secilenParkAlani(getVarisZamani());
            textPrint("txtsistemdeGecirilenSure", sistemdeGecirilenSureHesaplama(getVarisZamani()));

        }
        private void btnSimulasyonGuncelle_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms[0] == this)//Uygulamanin main form'u
            {
                //uygulamanin ana formunu kapatirsaniz uygulama kapanir, ana formu yeniden baslatmak uygulamayi yeniden baslatmak demektir.
                Application.Restart();
            }
        }
        public void getAracSayisiLabel(int toplamAracSayisi)
        {
            Label[] aracSayisi = new Label[toplamAracSayisi + 1];

            for (int k = 1; k < aracSayisi.Length; k++)
            {
                if (k == 1)
                {
                    aracSayisi[k] = new Label();
                    aracSayisi[k].Text = k.ToString();
                    aracSayisi[k].Name = "labelArac" + k.ToString();
                    this.groupBox1.Controls.Add(aracSayisi[k]);
                    aracSayisi[k].Top = 35;
                    aracSayisi[k].Left = 35;
                    aracSayisi[k].Width = 40;
                }
                else
                {
                    aracSayisi[k] = new Label();
                    aracSayisi[k].Text = k.ToString();
                    aracSayisi[k].Name = "labelArac" + k.ToString();
                    this.groupBox1.Controls.Add(aracSayisi[k]);
                    aracSayisi[k].Top = k * 30;
                    aracSayisi[k].Left = 35;
                    aracSayisi[k].Width = 40;
                }

            }
        }
        public void getVarislarArasiSureText(int toplamAracSayisi)
        {
            TextBox[] varislarArasiSure = new TextBox[toplamAracSayisi];

            for (int k = 0; k < toplamAracSayisi; k++)
            {
                if (k == 0 || k == 1)
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = k.ToString();
                    varislarArasiSure[k].Name = "txtVarislarArasiSure" + k.ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[k]);
                    if (k == 0)
                        varislarArasiSure[k].Top = 35;
                    else
                        varislarArasiSure[k].Top = 60;
                    varislarArasiSure[k].Left = 80;
                    varislarArasiSure[k].Width = 40;
                }

                else
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = k.ToString();
                    varislarArasiSure[k].Name = "txtVarislarArasiSure" + k.ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[k]);
                    varislarArasiSure[k].Top = k * 30 + 30;
                    varislarArasiSure[k].Left = 80;
                    varislarArasiSure[k].Width = 40;
                }

            }
        }
        public void getVarisZamaniText(int toplamAracSayisi)
        {
            TextBox[] varislarArasiSure = new TextBox[toplamAracSayisi];

            for (int k = 0; k < varislarArasiSure.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = (k).ToString();
                    varislarArasiSure[k].Name = "txtVarisZamani" + (k).ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[(k)]);
                    if (k == 0)
                        varislarArasiSure[k].Top = 35;
                    else
                        varislarArasiSure[k].Top = 60;

                    varislarArasiSure[k].Left = 155;
                    varislarArasiSure[k].Width = 45;
                }
                else
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = k.ToString();
                    varislarArasiSure[k].Name = "txtVarisZamani" + k.ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[k]);
                    varislarArasiSure[k].Top = k * 30 + 30;
                    varislarArasiSure[k].Left = 155;
                    varislarArasiSure[k].Width = 45;


                }

            }
        }
        public void getOtoparkBeklemeSuresiText(int toplamAracSayisi)
        {
            TextBox[] varislarArasiSure = new TextBox[toplamAracSayisi];

            for (int k = 0; k < varislarArasiSure.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = "" + k.ToString();
                    varislarArasiSure[k].Name = "txtBeklemeSuresi" + k.ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[k]);
                    if (k == 0)
                        varislarArasiSure[k].Top = 35;
                    else
                        varislarArasiSure[k].Top = 60;
                    varislarArasiSure[k].Left = 250;
                    varislarArasiSure[k].Width = 35;
                }
                else
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = k.ToString();
                    varislarArasiSure[k].Name = "txtBeklemeSuresi" + k.ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[k]);
                    varislarArasiSure[k].Top = k * 30 + 30;
                    varislarArasiSure[k].Left = 250;
                    varislarArasiSure[k].Width = 35;
                }

            }
        }
        public void getParkBaslangicText(int toplamAracSayisi)
        {
            TextBox[] varislarArasiSure = new TextBox[toplamAracSayisi];

            for (int k = 0; k < varislarArasiSure.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = "" + k.ToString();
                    varislarArasiSure[k].Name = "txtParkBaslangic" + k.ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[k]);
                    if (k == 0)
                        varislarArasiSure[k].Top = 35;
                    else
                        varislarArasiSure[k].Top = 60;
                    varislarArasiSure[k].Left = 460;
                    varislarArasiSure[k].Width = 35;
                }
                else
                {
                    varislarArasiSure[k] = new TextBox();
                    varislarArasiSure[k].Text = k.ToString();
                    varislarArasiSure[k].Name = "txtParkBaslangic" + k.ToString();
                    this.groupBox1.Controls.Add(varislarArasiSure[k]);
                    varislarArasiSure[k].Top = k * 30 + 30;
                    varislarArasiSure[k].Left = 460;
                    varislarArasiSure[k].Width = 35;
                }

            }
        }
        public void getSecilenParkAlani(int toplamAracSayisi)
        {
            Label[] secilenParkAlani = new Label[toplamAracSayisi];

            for (int k = 0; k < secilenParkAlani.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    secilenParkAlani[k] = new Label();
                    secilenParkAlani[k].Text = "" + k.ToString();
                    secilenParkAlani[k].Name = "txtSecilenParkAlani" + k.ToString();
                    this.groupBox1.Controls.Add(secilenParkAlani[k]);
                    if (k == 0)
                        secilenParkAlani[k].Top = 35;
                    else
                        secilenParkAlani[k].Top = 60;
                    secilenParkAlani[k].Left = 360;
                    secilenParkAlani[k].Width = 35;
                    secilenParkAlani[k].Enabled = false;
                }
                else
                {
                    secilenParkAlani[k] = new Label();
                    secilenParkAlani[k].Text = k.ToString();
                    secilenParkAlani[k].Name = "txtSecilenParkAlani" + k.ToString();
                    this.groupBox1.Controls.Add(secilenParkAlani[k]);
                    secilenParkAlani[k].Top = k * 30 + 30;
                    secilenParkAlani[k].Left = 360;
                    secilenParkAlani[k].Width = 35;
                    secilenParkAlani[k].Enabled = false;
                }

            }
        }
        public void getPark1Bitis(int toplamAracSayisi)
        {
            Label[] park1Bitis = new Label[toplamAracSayisi];

            for (int k = 0; k < park1Bitis.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    park1Bitis[k] = new Label();
                    park1Bitis[k].Text = "-";
                    park1Bitis[k].Name = "txtPark1Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park1Bitis[k]);
                    if (k == 0)
                        park1Bitis[k].Top = 35;
                    else
                        park1Bitis[k].Top = 60;
                    park1Bitis[k].Left = 560;
                    park1Bitis[k].Width = 35;
                    park1Bitis[k].Enabled = false;
                }
                else
                {
                    park1Bitis[k] = new Label();
                    park1Bitis[k].Text = "-";
                    park1Bitis[k].Name = "txtPark1Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park1Bitis[k]);
                    park1Bitis[k].Top = k * 30 + 30;
                    park1Bitis[k].Left = 560;
                    park1Bitis[k].Width = 35;
                    park1Bitis[k].Enabled = false;
                }

            }
        }
        public void getPark2Bitis(int toplamAracSayisi)
        {
            Label[] park2Bitis = new Label[toplamAracSayisi];

            for (int k = 0; k < park2Bitis.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    park2Bitis[k] = new Label();
                    park2Bitis[k].Text = "-";
                    park2Bitis[k].Name = "txtPark2Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park2Bitis[k]);
                    if (k == 0)
                        park2Bitis[k].Top = 35;
                    else
                        park2Bitis[k].Top = 60;
                    park2Bitis[k].Left = 620;
                    park2Bitis[k].Width = 35;
                    park2Bitis[k].Enabled = false;
                }
                else
                {
                    park2Bitis[k] = new Label();
                    park2Bitis[k].Text = "-";
                    park2Bitis[k].Name = "txtPark2Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park2Bitis[k]);
                    park2Bitis[k].Top = k * 30 + 30;
                    park2Bitis[k].Left = 620;
                    park2Bitis[k].Width = 35;
                    park2Bitis[k].Enabled = false;
                }

            }
        }
        public void getPark3Bitis(int toplamAracSayisi)
        {
            Label[] park3Bitis = new Label[toplamAracSayisi];

            for (int k = 0; k < park3Bitis.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    park3Bitis[k] = new Label();
                    park3Bitis[k].Text = "-";
                    park3Bitis[k].Name = "txtPark3Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park3Bitis[k]);
                    if (k == 0)
                        park3Bitis[k].Top = 35;
                    else
                        park3Bitis[k].Top = 60;
                    park3Bitis[k].Left = 700;
                    park3Bitis[k].Width = 35;
                    park3Bitis[k].Enabled = false;
                }
                else
                {
                    park3Bitis[k] = new Label();
                    park3Bitis[k].Text = "-";
                    park3Bitis[k].Name = "txtPark3Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park3Bitis[k]);
                    park3Bitis[k].Top = k * 30 + 30;
                    park3Bitis[k].Left = 700;
                    park3Bitis[k].Width = 35;
                    park3Bitis[k].Enabled = false;
                }

            }
        }
        public void getPark4Bitis(int toplamAracSayisi)
        {
            Label[] park4Bitis = new Label[toplamAracSayisi];

            for (int k = 0; k < park4Bitis.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    park4Bitis[k] = new Label();
                    park4Bitis[k].Text = "-";
                    park4Bitis[k].Name = "txtPark4Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park4Bitis[k]);
                    if (k == 0)
                        park4Bitis[k].Top = 35;
                    else
                        park4Bitis[k].Top = 60;
                    park4Bitis[k].Left = 780;
                    park4Bitis[k].Width = 35;
                    park4Bitis[k].Enabled = false;
                }
                else
                {
                    park4Bitis[k] = new Label();
                    park4Bitis[k].Text = "-";
                    park4Bitis[k].Name = "txtPark4Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park4Bitis[k]);
                    park4Bitis[k].Top = k * 30 + 30;
                    park4Bitis[k].Left = 780;
                    park4Bitis[k].Width = 35;
                    park4Bitis[k].Enabled = false;
                }

            }
        }
        public void getPark5Bitis(int toplamAracSayisi)
        {
            Label[] park5Bitis = new Label[toplamAracSayisi];

            for (int k = 0; k < park5Bitis.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    park5Bitis[k] = new Label();
                    park5Bitis[k].Text = "-";
                    park5Bitis[k].Name = "txtPark5Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park5Bitis[k]);
                    if (k == 0)
                        park5Bitis[k].Top = 35;
                    else
                        park5Bitis[k].Top = 60;
                    park5Bitis[k].Left = 850;
                    park5Bitis[k].Width = 35;
                    park5Bitis[k].Enabled = false;
                }
                else
                {
                    park5Bitis[k] = new Label();
                    park5Bitis[k].Text = "-";
                    park5Bitis[k].Name = "txtPark5Bİtis" + k.ToString();
                    this.groupBox1.Controls.Add(park5Bitis[k]);
                    park5Bitis[k].Top = k * 30 + 30;
                    park5Bitis[k].Left = 840;
                    park5Bitis[k].Width = 35;
                    park5Bitis[k].Enabled = false;
                }

            }
        }


        public void getGecikme(int toplamAracSayisi)
        {
            TextBox[] gecikme = new TextBox[toplamAracSayisi];

            for (int k = 0; k < gecikme.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    gecikme[k] = new TextBox();
                    gecikme[k].Text = "-";
                    gecikme[k].Name = "txtgecikme" + k.ToString();
                    this.groupBox1.Controls.Add(gecikme[k]);
                    if (k == 0)
                        gecikme[k].Top = 35;
                    else
                        gecikme[k].Top = 60;
                    gecikme[k].Left = 900;
                    gecikme[k].Width = 35;
                    gecikme[k].Enabled = false;
                }
                else
                {
                    gecikme[k] = new TextBox();
                    gecikme[k].Text = "-";
                    gecikme[k].Name = "txtgecikme" + k.ToString();
                    this.groupBox1.Controls.Add(gecikme[k]);
                    gecikme[k].Top = k * 30 + 30;
                    gecikme[k].Left = 900;
                    gecikme[k].Width = 35;
                    gecikme[k].Enabled = false;
                }

            }
        }
        public void getSistemdeGecirilenSure(int toplamAracSayisi)
        {
            TextBox[] sistemdeGecirilenSure = new TextBox[toplamAracSayisi];

            for (int k = 0; k < sistemdeGecirilenSure.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    sistemdeGecirilenSure[k] = new TextBox();
                    sistemdeGecirilenSure[k].Text = "-";
                    sistemdeGecirilenSure[k].Name = "txtsistemdeGecirilenSure" + k.ToString();
                    this.groupBox1.Controls.Add(sistemdeGecirilenSure[k]);
                    if (k == 0)
                        sistemdeGecirilenSure[k].Top = 35;
                    else
                        sistemdeGecirilenSure[k].Top = 60;
                    sistemdeGecirilenSure[k].Left = 980;
                    sistemdeGecirilenSure[k].Width = 35;
                    sistemdeGecirilenSure[k].Enabled = false;
                }
                else
                {
                    sistemdeGecirilenSure[k] = new TextBox();
                    sistemdeGecirilenSure[k].Text = "-";
                    sistemdeGecirilenSure[k].Name = "txtsistemdeGecirilenSure" + k.ToString();
                    this.groupBox1.Controls.Add(sistemdeGecirilenSure[k]);
                    sistemdeGecirilenSure[k].Top = k * 30 + 30;
                    sistemdeGecirilenSure[k].Left = 980;
                    sistemdeGecirilenSure[k].Width = 35;
                    sistemdeGecirilenSure[k].Enabled = false;
                }

            }
        }
        public void getPark1Kullanimi(int toplamAracSayisi)
        {
            Label[] park1Kullanimi = new Label[toplamAracSayisi];

            for (int k = 0; k < park1Kullanimi.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    park1Kullanimi[k] = new Label();
                    park1Kullanimi[k].Text = "-";
                    park1Kullanimi[k].Name = "txtPark1Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(park1Kullanimi[k]);
                    if (k == 0)
                        park1Kullanimi[k].Top = 35;
                    else
                        park1Kullanimi[k].Top = 60;
                    park1Kullanimi[k].Left = 1070;
                    park1Kullanimi[k].Width = 35;
                    park1Kullanimi[k].Enabled = false;
                }
                else
                {
                    park1Kullanimi[k] = new Label();
                    park1Kullanimi[k].Text = "-";
                    park1Kullanimi[k].Name = "txtPark1Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(park1Kullanimi[k]);
                    park1Kullanimi[k].Top = k * 30 + 30;
                    park1Kullanimi[k].Left = 1070;
                    park1Kullanimi[k].Width = 35;
                    park1Kullanimi[k].Enabled = false;
                }

            }
        }
        public void getPark2Kullanimi(int toplamAracSayisi)
        {
            Label[] getPark2Kullanimi = new Label[toplamAracSayisi];

            for (int k = 0; k < getPark2Kullanimi.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    getPark2Kullanimi[k] = new Label();
                    getPark2Kullanimi[k].Text = "-";
                    getPark2Kullanimi[k].Name = "txtPark2Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark2Kullanimi[k]);
                    if (k == 0)
                        getPark2Kullanimi[k].Top = 35;
                    else
                        getPark2Kullanimi[k].Top = 60;
                    getPark2Kullanimi[k].Left = 1120;
                    getPark2Kullanimi[k].Width = 35;
                    getPark2Kullanimi[k].Enabled = false;
                }
                else
                {
                    getPark2Kullanimi[k] = new Label();
                    getPark2Kullanimi[k].Text = "-";
                    getPark2Kullanimi[k].Name = "txtPark2Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark2Kullanimi[k]);
                    getPark2Kullanimi[k].Top = k * 30 + 30;
                    getPark2Kullanimi[k].Left = 1120;
                    getPark2Kullanimi[k].Width = 35;
                    getPark2Kullanimi[k].Enabled = false;
                }

            }
        }
        public void getPark3Kullanimi(int toplamAracSayisi)
        {
            Label[] getPark3Kullanimi = new Label[toplamAracSayisi];

            for (int k = 0; k < getPark3Kullanimi.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    getPark3Kullanimi[k] = new Label();
                    getPark3Kullanimi[k].Text = "-";
                    getPark3Kullanimi[k].Name = "txtPark3Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark3Kullanimi[k]);
                    if (k == 0)
                        getPark3Kullanimi[k].Top = 35;
                    else
                        getPark3Kullanimi[k].Top = 60;
                    getPark3Kullanimi[k].Left = 1180;
                    getPark3Kullanimi[k].Width = 35;
                    getPark3Kullanimi[k].Enabled = false;
                }
                else
                {
                    getPark3Kullanimi[k] = new Label();
                    getPark3Kullanimi[k].Text = "-";
                    getPark3Kullanimi[k].Name = "txtPark3Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark3Kullanimi[k]);
                    getPark3Kullanimi[k].Top = k * 30 + 30;
                    getPark3Kullanimi[k].Left = 1180;
                    getPark3Kullanimi[k].Width = 35;
                    getPark3Kullanimi[k].Enabled = false;
                }

            }
        }

        public void getPark4Kullanimi(int toplamAracSayisi)
        {
            Label[] getPark4Kullanimi = new Label[toplamAracSayisi];

            for (int k = 0; k < getPark4Kullanimi.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    getPark4Kullanimi[k] = new Label();
                    getPark4Kullanimi[k].Text = "-";
                    getPark4Kullanimi[k].Name = "txtPark4Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark4Kullanimi[k]);
                    if (k == 0)
                        getPark4Kullanimi[k].Top = 35;
                    else
                        getPark4Kullanimi[k].Top = 60;
                    getPark4Kullanimi[k].Left = 1250;
                    getPark4Kullanimi[k].Width = 35;
                    getPark4Kullanimi[k].Enabled = false;
                }
                else
                {
                    getPark4Kullanimi[k] = new Label();
                    getPark4Kullanimi[k].Text = "-";
                    getPark4Kullanimi[k].Name = "txtPark4Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark4Kullanimi[k]);
                    getPark4Kullanimi[k].Top = k * 30 + 30;
                    getPark4Kullanimi[k].Left = 1250;
                    getPark4Kullanimi[k].Width = 35;
                    getPark4Kullanimi[k].Enabled = false;
                }

            }
        }
        public void getPark5Kullanimi(int toplamAracSayisi)
        {
            Label[] getPark5Kullanimi = new Label[toplamAracSayisi];

            for (int k = 0; k < getPark5Kullanimi.Length; k++)
            {
                if (k == 0 || k == 1)
                {
                    getPark5Kullanimi[k] = new Label();
                    getPark5Kullanimi[k].Text = "-";
                    getPark5Kullanimi[k].Name = "txtPark5Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark5Kullanimi[k]);
                    if (k == 0)
                        getPark5Kullanimi[k].Top = 35;
                    else
                        getPark5Kullanimi[k].Top = 60;
                    getPark5Kullanimi[k].Left = 1320;
                    getPark5Kullanimi[k].Width = 35;
                    getPark5Kullanimi[k].Enabled = false;
                }
                else
                {
                    getPark5Kullanimi[k] = new Label();
                    getPark5Kullanimi[k].Text = "-";
                    getPark5Kullanimi[k].Name = "txtPark5Kullanimi" + k.ToString();
                    this.groupBox1.Controls.Add(getPark5Kullanimi[k]);
                    getPark5Kullanimi[k].Top = k * 30 + 30;
                    getPark5Kullanimi[k].Left = 1320;
                    getPark5Kullanimi[k].Width = 35;
                    getPark5Kullanimi[k].Enabled = false;
                }

            }
        }
        public void textPrint(string name, int[] dizi)
        {
            foreach (Control c in Controls)
            {
                if (c is GroupBox)//Eger Panel ise bir basamak iceri girecek 
                    foreach (Control t in c.Controls)//Panel Controllerini icerisinde ariyoruz
                    {
                        if (t is TextBox)//Sonrasinda Panelin icerisinde TextBoxları ariyoruz.
                            for (int i = 0; i < dizi.Count(); i++)
                            {
                                if (t.Name == name + (i).ToString())
                                    t.Text = dizi[i].ToString();
                            }
                    }
            }
        }
        public void textPrint(string name, int i, string data)
        {
            foreach (Control c in Controls)
            {
                if (c is GroupBox)//Eger Panel ise bir basamak iceri girecek 
                    foreach (Control t in c.Controls)//Panel Controllerini icerisinde ariyoruz
                    {
                        if (t is Label)//Sonrasinda Panelin icerisinde Label ariyoruz.
                            if (t.Name == name + (i).ToString())
                                t.Text = data.ToString();

                    }
            }
        }

        public int[] rastgeleBeklemeSuresiUret(int minumum, int maximum, int aracSayisi)
        {

            Random rastgele = new Random();
            int sayi = rastgele.Next();
            for (int i = 0; i < aracSayisi; i++)
                beklemeSureleri[i] = rastgele.Next(minumum, maximum);
            return beklemeSureleri;
        }
        public int[] varislarArasiSureHesapla(int[] varisZamaniDizi, int aracSayisi)
        {
            // 20 değeride alıcağım için
            int[] varislarArasiSureDizi = new int[aracSayisi + 1];
            for (int i = 0; i < aracSayisi; i++)
            {
                varislarArasiSureDizi[i + 1] = (varisZamaniDizi[i + 1] - varisZamaniDizi[i]);
            }
            return varislarArasiSureDizi;
        }
        public int[] getVarisZamani()
        {
            int[] varisZamani = { 0, 2, 3, 4, 5, 8, 10, 11, 13, 14, 17, 19, 20, 21, 25, 26, 28, 31, 33, 34, 35 };

            return varisZamani;
        }

        public void secilenParkAlani(int[] varisZamaniDizi)
        {
            string secilenPark = "";
            int i = 0;
            var dizi = getVarisZamani();
            basaDon:
            while (i < varisZamaniDizi.Length - 1)
            {
                if (i == 0)
                {
                    secilenPark = "Park1";
                    textPrint("txtSecilenParkAlani", i, secilenPark);
                    secilenParkBitisSuresi(secilenPark, "txtPark1Bİtis", i);
                    i++;
                    goto basaDon;
                }
                else
                {
                    if (parkAdi[i - 1] == "Park1" && (bitisSuresi[i - 1] < dizi[i] || bitisSuresi[i - 1] == dizi[i]))
                    {
                        secilenPark = "Park1";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark1Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park1" && bitisSuresi[i - 1] > dizi[i])
                    {
                        secilenPark = "Park2";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark2Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park2" && (bitisSuresi[i - 1] < dizi[i] || bitisSuresi[i - 1] == dizi[i]))
                    {
                        secilenPark = "Park2";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark2Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park2" && bitisSuresi[i - 1] > dizi[i])
                    {
                        secilenPark = "Park3";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark3Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park3" && (bitisSuresi[i - 1] < dizi[i] || bitisSuresi[i - 1] == dizi[i]))
                    {
                        secilenPark = "Park3";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark3Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park3" && bitisSuresi[i - 1] > dizi[i])
                    {
                        secilenPark = "Park4";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark4Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park4" && (bitisSuresi[i - 1] < dizi[i] || bitisSuresi[i - 1] == dizi[i]))
                    {
                        secilenPark = "Park4";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark4Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park4" && bitisSuresi[i - 1] > dizi[i])
                    {
                        secilenPark = "Park5";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark5Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else if (parkAdi[i - 1] == "Park5" && (bitisSuresi[i - 1] < dizi[i] || bitisSuresi[i - 1] == dizi[i]))
                    {
                        secilenPark = "Park5";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark5Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                    else
                    {
                        secilenPark = "Park1";
                        textPrint("txtSecilenParkAlani", i, secilenPark);
                        secilenParkBitisSuresi(secilenPark, "txtPark1Bİtis", i);
                        i++;
                        goto basaDon;
                    }
                }
            }
        }
      
        public void secilenParkBitisSuresi(string ParkAlani, string lblName, int index)
        {

            int parkBaslangicSuresi = 0;
            int beklemeSuresi = 0;

            if (ParkAlani == "Park1")
            {
                foreach (Control c in Controls)
                {
                    if (c is GroupBox)//Eger Panel ise bir basamak iceri girecek 
                        foreach (Control t in c.Controls)//Panel Controllerini icerisinde ariyoruz
                        {


                            if (t is TextBox)//Sonrasinda Panelin icerisinde Label ariyoruz.
                            {
                                if (t.Name == "txtParkBaslangic" + (index).ToString())
                                {
                                    parkBaslangicSuresi = int.Parse(t.Text);
                                }
                                if (t.Name == "txtBeklemeSuresi" + (index).ToString())
                                {
                                    beklemeSuresi = int.Parse(t.Text);
                                }

                            }
                            if (t is Label)//Sonrasinda Panelin icerisinde Label ariyoruz.
                                if (t.Name == lblName + (index).ToString())
                                {
                                    int toplam = parkBaslangicSuresi + beklemeSuresi;
                                    t.Text = toplam.ToString();
                                    parkAdi.Add("Park1");
                                    bitisSuresi.Add(toplam);
                                    park1Kullanimi.Add(beklemeSureleri[index]);
                                    textPrint("txtPark1Kullanimi", index, beklemeSureleri[index].ToString());
                                    if (index == (aracSayisi - 1))
                                    {
                                        parkToplami = toplam;
                                    }
                                }
                        }
                }


            }
            else if (ParkAlani == "Park2")
            {
                foreach (Control c in Controls)
                {
                    if (c is GroupBox)//Eger Panel ise bir basamak iceri girecek 
                        foreach (Control t in c.Controls)//Panel Controllerini icerisinde ariyoruz
                        {


                            if (t is TextBox)//Sonrasinda Panelin icerisinde Label ariyoruz.
                            {
                                if (t.Name == "txtParkBaslangic" + (index).ToString())
                                {
                                    parkBaslangicSuresi = int.Parse(t.Text);
                                }
                                if (t.Name == "txtBeklemeSuresi" + (index).ToString())
                                {
                                    beklemeSuresi = int.Parse(t.Text);
                                }

                            }
                            if (t is Label)//Sonrasinda Panelin icerisinde Label ariyoruz.
                                if (t.Name == lblName + (index).ToString())
                                {
                                    int toplam = parkBaslangicSuresi + beklemeSuresi;
                                    t.Text = toplam.ToString();
                                    parkAdi.Add("Park2");
                                    bitisSuresi.Add(toplam);
                                    park2Kullanimi.Add(beklemeSureleri[index]);
                                    textPrint("txtPark2Kullanimi", index, beklemeSureleri[index].ToString());
                                    if (index == (aracSayisi - 1))
                                    {
                                        parkToplami = toplam;
                                    }
                                }

                        }
                }

            }
            else if (ParkAlani == "Park3")
            {
                foreach (Control c in Controls)
                {
                    if (c is GroupBox)//Eger Panel ise bir basamak iceri girecek 
                        foreach (Control t in c.Controls)//Panel Controllerini icerisinde ariyoruz
                        {


                            if (t is TextBox)//Sonrasinda Panelin icerisinde Label ariyoruz.
                            {
                                if (t.Name == "txtParkBaslangic" + (index).ToString())
                                {
                                    parkBaslangicSuresi = int.Parse(t.Text);
                                }
                                if (t.Name == "txtBeklemeSuresi" + (index).ToString())
                                {
                                    beklemeSuresi = int.Parse(t.Text);
                                }

                            }
                            if (t is Label)//Sonrasinda Panelin icerisinde Label ariyoruz.
                                if (t.Name == lblName + (index).ToString())
                                {
                                    int toplam = parkBaslangicSuresi + beklemeSuresi;
                                    t.Text = toplam.ToString();
                                    parkAdi.Add("Park3");
                                    bitisSuresi.Add(toplam);
                                    park3Kullanimi.Add(beklemeSureleri[index]);
                                    textPrint("txtPark3Kullanimi", index, beklemeSureleri[index].ToString());
                                    if (index == (aracSayisi - 1))
                                    {
                                        parkToplami = toplam;
                                    }
                                }

                        }
                }

            }

            else if (ParkAlani == "Park4")
            {
                foreach (Control c in Controls)
                {
                    if (c is GroupBox)//Eger Panel ise bir basamak iceri girecek 
                        foreach (Control t in c.Controls)//Panel Controllerini icerisinde ariyoruz
                        {


                            if (t is TextBox)//Sonrasinda Panelin icerisinde Label ariyoruz.
                            {
                                if (t.Name == "txtParkBaslangic" + (index).ToString())
                                {
                                    parkBaslangicSuresi = int.Parse(t.Text);
                                }
                                if (t.Name == "txtBeklemeSuresi" + (index).ToString())
                                {
                                    beklemeSuresi = int.Parse(t.Text);
                                }

                            }
                            if (t is Label)//Sonrasinda Panelin icerisinde Label ariyoruz.
                                if (t.Name == lblName + (index).ToString())
                                {
                                    int toplam = parkBaslangicSuresi + beklemeSuresi;
                                    t.Text = toplam.ToString();
                                    parkAdi.Add("Park4");
                                    bitisSuresi.Add(toplam);
                                    park4Kullanimi.Add(beklemeSureleri[index]);
                                    textPrint("txtPark4Kullanimi", index, beklemeSureleri[index].ToString());
                                    if (index == (aracSayisi - 1))
                                    {
                                        parkToplami = toplam;
                                    }
                                }
                        }
                }
            }
            else
            {
                foreach (Control c in Controls)
                {
                    if (c is GroupBox)//Eger Panel ise bir basamak iceri girecek 
                        foreach (Control t in c.Controls)//Panel Controllerini icerisinde ariyoruz
                        {


                            if (t is TextBox)//Sonrasinda Panelin icerisinde Label ariyoruz.
                            {
                                if (t.Name == "txtParkBaslangic" + (index).ToString())
                                {
                                    parkBaslangicSuresi = int.Parse(t.Text);
                                }
                                if (t.Name == "txtBeklemeSuresi" + (index).ToString())
                                {
                                    beklemeSuresi = int.Parse(t.Text);
                                }

                            }
                            if (t is Label)//Sonrasinda Panelin icerisinde Label ariyoruz.
                                if (t.Name == lblName + (index).ToString())
                                {
                                    int toplam = parkBaslangicSuresi + beklemeSuresi;
                                    t.Text = toplam.ToString();
                                    parkAdi.Add("Park5");
                                    bitisSuresi.Add(toplam);
                                    park5Kullanimi.Add(beklemeSureleri[index]);
                                    textPrint("txtPark5Kullanimi", index, beklemeSureleri[index].ToString());
                                    if (index == (aracSayisi - 1))
                                    {
                                        parkToplami = toplam;
                                    }
                                }

                        }
                }
            }
        }

        public int[] gecikmeHesaplama(int[] varisZamani)
        {
            int[] sonuc = new int[20];
            for (int i = 0; i < varisZamani.Length - 1; i++)
            {
                parkBaslangicListesi.Add(varisZamani[i]);
            }
            for (int j = 0; j < parkBaslangicListesi.Count() - 1; j++)
            {
                sonuc[j] = parkBaslangicListesi[j] - varisZamani[j];
            }
            return sonuc;
        }
        public int[] sistemdeGecirilenSureHesaplama(int[] varisZamani)
        {

            parkBaslangicListesi.Clear();
            for (int i = 0; i < varisZamani.Length - 1; i++)
            {
                parkBaslangicListesi.Add(varisZamani[i]);
            }
            for (int j = 0; j < parkBaslangicListesi.Count() - 1; j++)
            {
                beklemeSureleri[j] = parkBaslangicListesi[j] - varisZamani[j] + beklemeSureleri[j];
            }
            return beklemeSureleri;
        }

        private void buttonAnalizCikar_Click(object sender, EventArgs e)
        {
            double ortalamaGecikme = 0;
            double ortalamaSistemdeGecirilenSure;
            double toplam = 0;
            double sistemdeGecirilenSureToplami = 0;
            double parkKullanimToplami = 0;
            double park1KullanimiSonuc = 0;
            double park2KullanimiSonuc = 0;
            double park3KullanimiSonuc = 0;
            double park4KullanimiSonuc = 0;
            double park5KullanimiSonuc = 0;
            double birimZamandaYapilanİs = 0;
            for (int i = 0; i < gecikmeSureleri.Length; i++)
            {
                toplam += gecikmeSureleri[i];
                sistemdeGecirilenSureToplami += beklemeSureleri[i];
            }
            for (int j = 0; j < park1Kullanimi.Count; j++)
                parkKullanimToplami += park1Kullanimi[j];
            park1KullanimiSonuc = (parkKullanimToplami / parkToplami) * 100;
            parkKullanimToplami = 0;

            for (int k = 0; k < park2Kullanimi.Count; k++)
                parkKullanimToplami += park2Kullanimi[k];
            park2KullanimiSonuc = (parkKullanimToplami / parkToplami) * 100;
            parkKullanimToplami = 0;

            for (int m = 0; m < park3Kullanimi.Count; m++)
                parkKullanimToplami += park3Kullanimi[m];
            park3KullanimiSonuc = (parkKullanimToplami / parkToplami) * 100;
            parkKullanimToplami = 0;

            for (int n = 0; n < park4Kullanimi.Count; n++)
                parkKullanimToplami += park4Kullanimi[n];
            park4KullanimiSonuc = (parkKullanimToplami / parkToplami) * 100;
            parkKullanimToplami = 0;
            for (int l = 0; l < park5Kullanimi.Count; l++)
                parkKullanimToplami += park5Kullanimi[l];
            park5KullanimiSonuc = (parkKullanimToplami / parkToplami) * 100;

            ortalamaGecikme = toplam / aracSayisi;
            ortalamaSistemdeGecirilenSure = sistemdeGecirilenSureToplami / aracSayisi;
            double aracAdeti = aracSayisi;
            birimZamandaYapilanİs = aracAdeti / parkToplami;

            MessageBox.Show("Park1 Kullanımı: %"+park1KullanimiSonuc+ "\n Park2 Kullanımı: %" + park2KullanimiSonuc + "\n Park3 Kullanımı: %" + park3KullanimiSonuc + "\n Park4 Kullanımı: %" + park4KullanimiSonuc+ "\n Park5 Kullanımı: %" + park5KullanimiSonuc+" \n Ortalama Gecikme: " + ortalamaGecikme + "\n Ortalama sistemde gecirilen süre:"+ortalamaSistemdeGecirilenSure+" \n"+"Birim zamanda Yapılan İş:"+birimZamandaYapilanİs);
        }

    }
}
