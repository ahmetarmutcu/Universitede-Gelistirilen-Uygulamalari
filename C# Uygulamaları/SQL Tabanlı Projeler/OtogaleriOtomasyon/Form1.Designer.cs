namespace OtogaleriOtomasyon
{
    partial class Form1
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
            this.buttonAraclar = new System.Windows.Forms.Button();
            this.buttonCalisanKisiler = new System.Windows.Forms.Button();
            this.buttonGelirGider = new System.Windows.Forms.Button();
            this.buttonMusteriBilgi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAraclar
            // 
            this.buttonAraclar.BackColor = System.Drawing.Color.Lime;
            this.buttonAraclar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAraclar.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonAraclar.Location = new System.Drawing.Point(5, 12);
            this.buttonAraclar.Name = "buttonAraclar";
            this.buttonAraclar.Size = new System.Drawing.Size(202, 169);
            this.buttonAraclar.TabIndex = 14;
            this.buttonAraclar.Text = "ARAÇLAR";
            this.buttonAraclar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAraclar.UseVisualStyleBackColor = false;
            this.buttonAraclar.Click += new System.EventHandler(this.buttonAraclar_Click);
            // 
            // buttonCalisanKisiler
            // 
            this.buttonCalisanKisiler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonCalisanKisiler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCalisanKisiler.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCalisanKisiler.Location = new System.Drawing.Point(213, 12);
            this.buttonCalisanKisiler.Name = "buttonCalisanKisiler";
            this.buttonCalisanKisiler.Size = new System.Drawing.Size(209, 169);
            this.buttonCalisanKisiler.TabIndex = 15;
            this.buttonCalisanKisiler.Text = "ÇALIŞANLAR";
            this.buttonCalisanKisiler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCalisanKisiler.UseVisualStyleBackColor = false;
            this.buttonCalisanKisiler.Click += new System.EventHandler(this.buttonCalisanKisiler_Click);
            // 
            // buttonGelirGider
            // 
            this.buttonGelirGider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonGelirGider.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGelirGider.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGelirGider.Location = new System.Drawing.Point(213, 187);
            this.buttonGelirGider.Name = "buttonGelirGider";
            this.buttonGelirGider.Size = new System.Drawing.Size(209, 170);
            this.buttonGelirGider.TabIndex = 16;
            this.buttonGelirGider.Text = "GELİR-GİDER";
            this.buttonGelirGider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonGelirGider.UseVisualStyleBackColor = false;
            this.buttonGelirGider.Click += new System.EventHandler(this.buttonGelirGider_Click);
            // 
            // buttonMusteriBilgi
            // 
            this.buttonMusteriBilgi.BackColor = System.Drawing.Color.Yellow;
            this.buttonMusteriBilgi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMusteriBilgi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonMusteriBilgi.Location = new System.Drawing.Point(5, 187);
            this.buttonMusteriBilgi.Name = "buttonMusteriBilgi";
            this.buttonMusteriBilgi.Size = new System.Drawing.Size(202, 170);
            this.buttonMusteriBilgi.TabIndex = 17;
            this.buttonMusteriBilgi.Text = "MÜŞTERİ BİLGİLERİ";
            this.buttonMusteriBilgi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonMusteriBilgi.UseVisualStyleBackColor = false;
            this.buttonMusteriBilgi.Click += new System.EventHandler(this.buttonMusteriBilgi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(427, 363);
            this.Controls.Add(this.buttonMusteriBilgi);
            this.Controls.Add(this.buttonGelirGider);
            this.Controls.Add(this.buttonCalisanKisiler);
            this.Controls.Add(this.buttonAraclar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Otogaleri Otomasyonu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAraclar;
        private System.Windows.Forms.Button buttonCalisanKisiler;
        private System.Windows.Forms.Button buttonGelirGider;
        private System.Windows.Forms.Button buttonMusteriBilgi;
    }
}

