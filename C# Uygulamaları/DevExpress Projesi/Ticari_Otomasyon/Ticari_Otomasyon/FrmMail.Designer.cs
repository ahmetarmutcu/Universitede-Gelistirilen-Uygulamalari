namespace Ticari_Otomasyon
{
    partial class FrmMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMail));
            this.label1 = new System.Windows.Forms.Label();
            this.textMail = new DevExpress.XtraEditors.TextEdit();
            this.textKonu = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.rctMesaj = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButtonGonder = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKonu.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail Adresi:";
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(129, 139);
            this.textMail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textMail.Name = "textMail";
            this.textMail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textMail.Properties.Appearance.Options.UseFont = true;
            this.textMail.Size = new System.Drawing.Size(228, 26);
            this.textMail.TabIndex = 1;
            // 
            // textKonu
            // 
            this.textKonu.Location = new System.Drawing.Point(129, 182);
            this.textKonu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textKonu.Name = "textKonu";
            this.textKonu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textKonu.Properties.Appearance.Options.UseFont = true;
            this.textKonu.Size = new System.Drawing.Size(228, 26);
            this.textKonu.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Konu:";
            // 
            // rctMesaj
            // 
            this.rctMesaj.Location = new System.Drawing.Point(129, 231);
            this.rctMesaj.Name = "rctMesaj";
            this.rctMesaj.Size = new System.Drawing.Size(228, 192);
            this.rctMesaj.TabIndex = 6;
            this.rctMesaj.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mesaj:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 124);
            this.panel1.TabIndex = 8;
            // 
            // simpleButtonGonder
            // 
            this.simpleButtonGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButtonGonder.Location = new System.Drawing.Point(210, 429);
            this.simpleButtonGonder.Name = "simpleButtonGonder";
            this.simpleButtonGonder.Size = new System.Drawing.Size(147, 39);
            this.simpleButtonGonder.TabIndex = 9;
            this.simpleButtonGonder.Text = "GÖNDER";
            this.simpleButtonGonder.Click += new System.EventHandler(this.simpleButtonGonder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "MAİL GÖNDERME PANELİ";
            // 
            // FrmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 482);
            this.Controls.Add(this.simpleButtonGonder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rctMesaj);
            this.Controls.Add(this.textKonu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textMail);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FrmMail";
            this.Text = "MAİL";
            this.Load += new System.EventHandler(this.FrmMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKonu.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textMail;
        private DevExpress.XtraEditors.TextEdit textKonu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rctMesaj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonGonder;
    }
}