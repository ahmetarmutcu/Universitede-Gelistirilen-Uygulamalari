namespace Ticari_Otomasyon
{
    partial class FrmUrunler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUrunler));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonSil = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.richTextBoxDetay = new System.Windows.Forms.RichTextBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textSatisFiyat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textAlisFiyat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.numericUpDownAdet = new System.Windows.Forms.NumericUpDown();
            this.textYil = new DevExpress.XtraEditors.TextEdit();
            this.textModel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textMarka = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonTemizle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSatisFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAlisFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textYil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMarka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1074, 558);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.AppearancePrint.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.AppearancePrint.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridView1.AppearancePrint.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtonTemizle);
            this.groupControl1.Controls.Add(this.simpleButtonSil);
            this.groupControl1.Controls.Add(this.simpleButtonGuncelle);
            this.groupControl1.Controls.Add(this.simpleButtonKaydet);
            this.groupControl1.Controls.Add(this.richTextBoxDetay);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.textSatisFiyat);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.textAlisFiyat);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.numericUpDownAdet);
            this.groupControl1.Controls.Add(this.textYil);
            this.groupControl1.Controls.Add(this.textModel);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.textMarka);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.textAd);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.textId);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(1080, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(287, 558);
            this.groupControl1.TabIndex = 1;
            // 
            // simpleButtonSil
            // 
            this.simpleButtonSil.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonSil.Appearance.Options.UseFont = true;
            this.simpleButtonSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSil.ImageOptions.Image")));
            this.simpleButtonSil.Location = new System.Drawing.Point(110, 450);
            this.simpleButtonSil.Name = "simpleButtonSil";
            this.simpleButtonSil.Size = new System.Drawing.Size(146, 33);
            this.simpleButtonSil.TabIndex = 21;
            this.simpleButtonSil.Text = "Sil";
            this.simpleButtonSil.Click += new System.EventHandler(this.simpleButtonSil_Click);
            // 
            // simpleButtonGuncelle
            // 
            this.simpleButtonGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonGuncelle.Appearance.Options.UseFont = true;
            this.simpleButtonGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonGuncelle.ImageOptions.Image")));
            this.simpleButtonGuncelle.Location = new System.Drawing.Point(110, 498);
            this.simpleButtonGuncelle.Name = "simpleButtonGuncelle";
            this.simpleButtonGuncelle.Size = new System.Drawing.Size(146, 33);
            this.simpleButtonGuncelle.TabIndex = 20;
            this.simpleButtonGuncelle.Text = "Güncelleme";
            this.simpleButtonGuncelle.Click += new System.EventHandler(this.simpleButtonGuncelle_Click);
            // 
            // simpleButtonKaydet
            // 
            this.simpleButtonKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonKaydet.Appearance.Options.UseFont = true;
            this.simpleButtonKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonKaydet.ImageOptions.Image")));
            this.simpleButtonKaydet.Location = new System.Drawing.Point(110, 401);
            this.simpleButtonKaydet.Name = "simpleButtonKaydet";
            this.simpleButtonKaydet.Size = new System.Drawing.Size(146, 33);
            this.simpleButtonKaydet.TabIndex = 19;
            this.simpleButtonKaydet.Text = "Kaydet";
            this.simpleButtonKaydet.Click += new System.EventHandler(this.simpleButtonKaydet_Click);
            // 
            // richTextBoxDetay
            // 
            this.richTextBoxDetay.Location = new System.Drawing.Point(110, 296);
            this.richTextBoxDetay.Name = "richTextBoxDetay";
            this.richTextBoxDetay.Size = new System.Drawing.Size(146, 99);
            this.richTextBoxDetay.TabIndex = 8;
            this.richTextBoxDetay.Text = "";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(54, 198);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(35, 18);
            this.labelControl9.TabIndex = 17;
            this.labelControl9.Text = "Adet:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(43, 296);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(44, 18);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Detay:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(70, 168);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(19, 18);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Yıl:";
            // 
            // textSatisFiyat
            // 
            this.textSatisFiyat.Location = new System.Drawing.Point(110, 266);
            this.textSatisFiyat.Name = "textSatisFiyat";
            this.textSatisFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textSatisFiyat.Properties.Appearance.Options.UseFont = true;
            this.textSatisFiyat.Size = new System.Drawing.Size(146, 24);
            this.textSatisFiyat.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(18, 272);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(71, 18);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Satış Fiyat:";
            // 
            // textAlisFiyat
            // 
            this.textAlisFiyat.Location = new System.Drawing.Point(110, 236);
            this.textAlisFiyat.Name = "textAlisFiyat";
            this.textAlisFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textAlisFiyat.Properties.Appearance.Options.UseFont = true;
            this.textAlisFiyat.Size = new System.Drawing.Size(146, 24);
            this.textAlisFiyat.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(27, 242);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 18);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Alış Fiyat:";
            // 
            // numericUpDownAdet
            // 
            this.numericUpDownAdet.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDownAdet.Location = new System.Drawing.Point(110, 195);
            this.numericUpDownAdet.Name = "numericUpDownAdet";
            this.numericUpDownAdet.Size = new System.Drawing.Size(146, 26);
            this.numericUpDownAdet.TabIndex = 5;
            // 
            // textYil
            // 
            this.textYil.Location = new System.Drawing.Point(110, 165);
            this.textYil.Name = "textYil";
            this.textYil.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textYil.Properties.Appearance.Options.UseFont = true;
            this.textYil.Size = new System.Drawing.Size(146, 24);
            this.textYil.TabIndex = 4;
            // 
            // textModel
            // 
            this.textModel.Location = new System.Drawing.Point(110, 135);
            this.textModel.Name = "textModel";
            this.textModel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textModel.Properties.Appearance.Options.UseFont = true;
            this.textModel.Size = new System.Drawing.Size(146, 24);
            this.textModel.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(45, 138);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Model:";
            // 
            // textMarka
            // 
            this.textMarka.Location = new System.Drawing.Point(110, 99);
            this.textMarka.Name = "textMarka";
            this.textMarka.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textMarka.Properties.Appearance.Options.UseFont = true;
            this.textMarka.Size = new System.Drawing.Size(146, 24);
            this.textMarka.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(43, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 18);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Marka:";
            // 
            // textAd
            // 
            this.textAd.Location = new System.Drawing.Point(110, 69);
            this.textAd.Name = "textAd";
            this.textAd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textAd.Properties.Appearance.Options.UseFont = true;
            this.textAd.Size = new System.Drawing.Size(146, 24);
            this.textAd.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(66, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ad:";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(110, 36);
            this.textId.Name = "textId";
            this.textId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textId.Properties.Appearance.Options.UseFont = true;
            this.textId.Size = new System.Drawing.Size(146, 24);
            this.textId.TabIndex = 15;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(70, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ID:";
            // 
            // simpleButtonTemizle
            // 
            this.simpleButtonTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonTemizle.Appearance.Options.UseFont = true;
            this.simpleButtonTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonTemizle.ImageOptions.Image")));
            this.simpleButtonTemizle.Location = new System.Drawing.Point(5, 432);
            this.simpleButtonTemizle.Name = "simpleButtonTemizle";
            this.simpleButtonTemizle.Size = new System.Drawing.Size(98, 69);
            this.simpleButtonTemizle.TabIndex = 31;
            this.simpleButtonTemizle.Text = "Temizle";
            this.simpleButtonTemizle.Click += new System.EventHandler(this.simpleButtonTemizle_Click);
            // 
            // FrmUrunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmUrunler";
            this.Text = "ÜRÜNLER";
            this.Load += new System.EventHandler(this.FrmUrunler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSatisFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAlisFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textYil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMarka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RichTextBox richTextBoxDetay;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textSatisFiyat;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textAlisFiyat;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.NumericUpDown numericUpDownAdet;
        private DevExpress.XtraEditors.TextEdit textYil;
        private DevExpress.XtraEditors.TextEdit textModel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textMarka;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textAd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonKaydet;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSil;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGuncelle;
        private DevExpress.XtraEditors.SimpleButton simpleButtonTemizle;
    }
}