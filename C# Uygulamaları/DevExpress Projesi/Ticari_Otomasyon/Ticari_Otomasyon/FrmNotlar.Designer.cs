namespace Ticari_Otomasyon
{
    partial class FrmNotlar
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotlar));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlNotlarGoster = new DevExpress.XtraGrid.GridControl();
            this.simpleButtonGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.TextOlusturanKisi = new System.Windows.Forms.MaskedTextBox();
            this.mstSaat = new System.Windows.Forms.MaskedTextBox();
            this.mstTarih = new System.Windows.Forms.MaskedTextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSil = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.rctDetay = new System.Windows.Forms.RichTextBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textHitap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textBaslik = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNotlarGoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textHitap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBaslik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControlNotlarGoster;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridControlNotlarGoster
            // 
            gridLevelNode2.RelationName = "Level1";
            this.gridControlNotlarGoster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlNotlarGoster.Location = new System.Drawing.Point(1, 1);
            this.gridControlNotlarGoster.MainView = this.gridView1;
            this.gridControlNotlarGoster.Name = "gridControlNotlarGoster";
            this.gridControlNotlarGoster.Size = new System.Drawing.Size(1075, 569);
            this.gridControlNotlarGoster.TabIndex = 4;
            this.gridControlNotlarGoster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // simpleButtonGuncelle
            // 
            this.simpleButtonGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonGuncelle.Appearance.Options.UseFont = true;
            this.simpleButtonGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonGuncelle.ImageOptions.Image")));
            this.simpleButtonGuncelle.Location = new System.Drawing.Point(110, 499);
            this.simpleButtonGuncelle.Name = "simpleButtonGuncelle";
            this.simpleButtonGuncelle.Size = new System.Drawing.Size(146, 33);
            this.simpleButtonGuncelle.TabIndex = 20;
            this.simpleButtonGuncelle.Text = "Güncelleme";
            this.simpleButtonGuncelle.Click += new System.EventHandler(this.simpleButtonGuncelle_Click);
            // 
            // TextOlusturanKisi
            // 
            this.TextOlusturanKisi.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TextOlusturanKisi.Location = new System.Drawing.Point(110, 204);
            this.TextOlusturanKisi.Name = "TextOlusturanKisi";
            this.TextOlusturanKisi.Size = new System.Drawing.Size(146, 26);
            this.TextOlusturanKisi.TabIndex = 26;
            this.TextOlusturanKisi.ValidatingType = typeof(int);
            // 
            // mstSaat
            // 
            this.mstSaat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mstSaat.Location = new System.Drawing.Point(110, 114);
            this.mstSaat.Mask = "00:00";
            this.mstSaat.Name = "mstSaat";
            this.mstSaat.Size = new System.Drawing.Size(146, 26);
            this.mstSaat.TabIndex = 25;
            this.mstSaat.ValidatingType = typeof(System.DateTime);
            // 
            // mstTarih
            // 
            this.mstTarih.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mstTarih.Location = new System.Drawing.Point(110, 72);
            this.mstTarih.Mask = "00/00/0000";
            this.mstTarih.Name = "mstTarih";
            this.mstTarih.Size = new System.Drawing.Size(146, 26);
            this.mstTarih.TabIndex = 24;
            this.mstTarih.ValidatingType = typeof(System.DateTime);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtonTemizle);
            this.groupControl1.Controls.Add(this.simpleButtonGuncelle);
            this.groupControl1.Controls.Add(this.TextOlusturanKisi);
            this.groupControl1.Controls.Add(this.mstSaat);
            this.groupControl1.Controls.Add(this.mstTarih);
            this.groupControl1.Controls.Add(this.simpleButtonSil);
            this.groupControl1.Controls.Add(this.simpleButtonKaydet);
            this.groupControl1.Controls.Add(this.rctDetay);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.textHitap);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.textBaslik);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.textId);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(1082, -10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(287, 580);
            this.groupControl1.TabIndex = 5;
            // 
            // simpleButtonTemizle
            // 
            this.simpleButtonTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonTemizle.Appearance.Options.UseFont = true;
            this.simpleButtonTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonTemizle.ImageOptions.Image")));
            this.simpleButtonTemizle.Location = new System.Drawing.Point(5, 416);
            this.simpleButtonTemizle.Name = "simpleButtonTemizle";
            this.simpleButtonTemizle.Size = new System.Drawing.Size(99, 95);
            this.simpleButtonTemizle.TabIndex = 27;
            this.simpleButtonTemizle.Text = "Temizle";
            this.simpleButtonTemizle.Click += new System.EventHandler(this.simpleButtonTemizle_Click);
            // 
            // simpleButtonSil
            // 
            this.simpleButtonSil.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonSil.Appearance.Options.UseFont = true;
            this.simpleButtonSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSil.ImageOptions.Image")));
            this.simpleButtonSil.Location = new System.Drawing.Point(110, 446);
            this.simpleButtonSil.Name = "simpleButtonSil";
            this.simpleButtonSil.Size = new System.Drawing.Size(146, 33);
            this.simpleButtonSil.TabIndex = 21;
            this.simpleButtonSil.Text = "Sil";
            this.simpleButtonSil.Click += new System.EventHandler(this.simpleButtonSil_Click);
            // 
            // simpleButtonKaydet
            // 
            this.simpleButtonKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonKaydet.Appearance.Options.UseFont = true;
            this.simpleButtonKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonKaydet.ImageOptions.Image")));
            this.simpleButtonKaydet.Location = new System.Drawing.Point(110, 397);
            this.simpleButtonKaydet.Name = "simpleButtonKaydet";
            this.simpleButtonKaydet.Size = new System.Drawing.Size(146, 33);
            this.simpleButtonKaydet.TabIndex = 19;
            this.simpleButtonKaydet.Text = "Kaydet";
            this.simpleButtonKaydet.Click += new System.EventHandler(this.simpleButtonKaydet_Click);
            // 
            // rctDetay
            // 
            this.rctDetay.Location = new System.Drawing.Point(110, 291);
            this.rctDetay.Name = "rctDetay";
            this.rctDetay.Size = new System.Drawing.Size(146, 88);
            this.rctDetay.TabIndex = 18;
            this.rctDetay.Text = "";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(49, 251);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(38, 18);
            this.labelControl9.TabIndex = 17;
            this.labelControl9.Text = "Hitap:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(43, 291);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(44, 18);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Detay:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(20, 212);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(67, 18);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Oluşturan:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(43, 168);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Başlık:";
            // 
            // textHitap
            // 
            this.textHitap.Location = new System.Drawing.Point(110, 248);
            this.textHitap.Name = "textHitap";
            this.textHitap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textHitap.Properties.Appearance.Options.UseFont = true;
            this.textHitap.Size = new System.Drawing.Size(146, 24);
            this.textHitap.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(49, 122);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 18);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Saat:";
            // 
            // textBaslik
            // 
            this.textBaslik.Location = new System.Drawing.Point(110, 162);
            this.textBaslik.Name = "textBaslik";
            this.textBaslik.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBaslik.Properties.Appearance.Options.UseFont = true;
            this.textBaslik.Size = new System.Drawing.Size(146, 24);
            this.textBaslik.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(49, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tarih:";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(110, 33);
            this.textId.Name = "textId";
            this.textId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textId.Properties.Appearance.Options.UseFont = true;
            this.textId.Size = new System.Drawing.Size(146, 24);
            this.textId.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(66, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ID:";
            // 
            // FrmNotlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 561);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControlNotlarGoster);
            this.Name = "FrmNotlar";
            this.Text = "NOTLAR";
            this.Load += new System.EventHandler(this.FrmNotlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNotlarGoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textHitap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBaslik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControlNotlarGoster;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGuncelle;
        private System.Windows.Forms.MaskedTextBox TextOlusturanKisi;
        private System.Windows.Forms.MaskedTextBox mstSaat;
        private System.Windows.Forms.MaskedTextBox mstTarih;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSil;
        private DevExpress.XtraEditors.SimpleButton simpleButtonKaydet;
        private System.Windows.Forms.RichTextBox rctDetay;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textHitap;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textBaslik;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textId;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonTemizle;
    }
}