namespace Ticari_Otomasyon
{
    partial class FrmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textKullanici = new DevExpress.XtraEditors.TextEdit();
            this.textSifre = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonGiris = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textKullanici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(35, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "KULLANICI ADI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(106, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "ŞİFRE:";
            // 
            // textKullanici
            // 
            this.textKullanici.Location = new System.Drawing.Point(190, 135);
            this.textKullanici.Name = "textKullanici";
            this.textKullanici.Properties.Appearance.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textKullanici.Properties.Appearance.Options.UseFont = true;
            this.textKullanici.Size = new System.Drawing.Size(158, 28);
            this.textKullanici.TabIndex = 2;
            // 
            // textSifre
            // 
            this.textSifre.Location = new System.Drawing.Point(190, 181);
            this.textSifre.Name = "textSifre";
            this.textSifre.Properties.Appearance.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textSifre.Properties.Appearance.Options.UseFont = true;
            this.textSifre.Properties.UseSystemPasswordChar = true;
            this.textSifre.Size = new System.Drawing.Size(158, 28);
            this.textSifre.TabIndex = 3;
            // 
            // simpleButtonGiris
            // 
            this.simpleButtonGiris.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButtonGiris.Appearance.Options.UseFont = true;
            this.simpleButtonGiris.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonGiris.ImageOptions.Image")));
            this.simpleButtonGiris.Location = new System.Drawing.Point(240, 215);
            this.simpleButtonGiris.Name = "simpleButtonGiris";
            this.simpleButtonGiris.Size = new System.Drawing.Size(108, 48);
            this.simpleButtonGiris.TabIndex = 4;
            this.simpleButtonGiris.Text = "GİRİŞ";
            this.simpleButtonGiris.Click += new System.EventHandler(this.simpleButtonGiris_Click);
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(499, 338);
            this.Controls.Add(this.simpleButtonGiris);
            this.Controls.Add(this.textSifre);
            this.Controls.Add(this.textKullanici);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMİN SAYFASI";
            ((System.ComponentModel.ISupportInitialize)(this.textKullanici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit textKullanici;
        private DevExpress.XtraEditors.TextEdit textSifre;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGiris;
    }
}