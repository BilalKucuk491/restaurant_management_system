namespace restaurantt
{
    partial class frmKullaniciAyari
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
            this.btnKayitSil = new System.Windows.Forms.Button();
            this.btnKayit = new System.Windows.Forms.Button();
            this.txtParolaTekrar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.dataGridViewKullanici = new System.Windows.Forms.DataGridView();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.txtKSoyadi = new System.Windows.Forms.TextBox();
            this.txtKAdi = new System.Windows.Forms.TextBox();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxGorev = new System.Windows.Forms.ComboBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanici)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKayitSil
            // 
            this.btnKayitSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnKayitSil.FlatAppearance.BorderSize = 0;
            this.btnKayitSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKayitSil.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.btnKayitSil.ForeColor = System.Drawing.Color.White;
            this.btnKayitSil.Location = new System.Drawing.Point(496, 796);
            this.btnKayitSil.Name = "btnKayitSil";
            this.btnKayitSil.Size = new System.Drawing.Size(205, 78);
            this.btnKayitSil.TabIndex = 32;
            this.btnKayitSil.Text = "Kayıt Sil";
            this.btnKayitSil.UseVisualStyleBackColor = false;
            this.btnKayitSil.Click += new System.EventHandler(this.btnKayitSil_Click);
            // 
            // btnKayit
            // 
            this.btnKayit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnKayit.FlatAppearance.BorderSize = 0;
            this.btnKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKayit.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.btnKayit.ForeColor = System.Drawing.Color.White;
            this.btnKayit.Location = new System.Drawing.Point(74, 796);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(205, 78);
            this.btnKayit.TabIndex = 33;
            this.btnKayit.Text = "Kaydet";
            this.btnKayit.UseVisualStyleBackColor = false;
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // txtParolaTekrar
            // 
            this.txtParolaTekrar.BackColor = System.Drawing.SystemColors.Window;
            this.txtParolaTekrar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtParolaTekrar.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.txtParolaTekrar.Location = new System.Drawing.Point(856, 98);
            this.txtParolaTekrar.Multiline = true;
            this.txtParolaTekrar.Name = "txtParolaTekrar";
            this.txtParolaTekrar.PasswordChar = '*';
            this.txtParolaTekrar.Size = new System.Drawing.Size(212, 54);
            this.txtParolaTekrar.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(586, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 46);
            this.label5.TabIndex = 30;
            this.label5.Text = "Parola Tekrar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(586, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 46);
            this.label2.TabIndex = 27;
            this.label2.Text = "Parola";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 46);
            this.label1.TabIndex = 28;
            this.label1.Text = "Kullanıcı Soyadı";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.lb.ForeColor = System.Drawing.Color.White;
            this.lb.Location = new System.Drawing.Point(66, 38);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(202, 46);
            this.lb.TabIndex = 29;
            this.lb.Text = "Kullanıcı Adı";
            // 
            // dataGridViewKullanici
            // 
            this.dataGridViewKullanici.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKullanici.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKullanici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKullanici.Location = new System.Drawing.Point(74, 240);
            this.dataGridViewKullanici.Name = "dataGridViewKullanici";
            this.dataGridViewKullanici.RowHeadersWidth = 51;
            this.dataGridViewKullanici.RowTemplate.Height = 24;
            this.dataGridViewKullanici.Size = new System.Drawing.Size(992, 537);
            this.dataGridViewKullanici.TabIndex = 26;
            this.dataGridViewKullanici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKullanici_CellContentClick);
            // 
            // txtParola
            // 
            this.txtParola.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.txtParola.Location = new System.Drawing.Point(856, 30);
            this.txtParola.Multiline = true;
            this.txtParola.Name = "txtParola";
            this.txtParola.PasswordChar = '*';
            this.txtParola.Size = new System.Drawing.Size(212, 54);
            this.txtParola.TabIndex = 23;
            // 
            // txtKSoyadi
            // 
            this.txtKSoyadi.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.txtKSoyadi.Location = new System.Drawing.Point(343, 98);
            this.txtKSoyadi.Multiline = true;
            this.txtKSoyadi.Name = "txtKSoyadi";
            this.txtKSoyadi.Size = new System.Drawing.Size(212, 54);
            this.txtKSoyadi.TabIndex = 24;
            // 
            // txtKAdi
            // 
            this.txtKAdi.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.txtKAdi.Location = new System.Drawing.Point(343, 30);
            this.txtKAdi.Multiline = true;
            this.txtKAdi.Name = "txtKAdi";
            this.txtKAdi.Size = new System.Drawing.Size(212, 54);
            this.txtKAdi.TabIndex = 25;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnGuncelle.FlatAppearance.BorderSize = 0;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.btnGuncelle.ForeColor = System.Drawing.Color.White;
            this.btnGuncelle.Location = new System.Drawing.Point(285, 796);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(205, 78);
            this.btnGuncelle.TabIndex = 34;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(66, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 46);
            this.label3.TabIndex = 28;
            this.label3.Text = "Kullanıcı Görevi";
            // 
            // cbxGorev
            // 
            this.cbxGorev.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.cbxGorev.FormattingEnabled = true;
            this.cbxGorev.Location = new System.Drawing.Point(343, 171);
            this.cbxGorev.Name = "cbxGorev";
            this.cbxGorev.Size = new System.Drawing.Size(212, 43);
            this.cbxGorev.TabIndex = 35;
            // 
            // txtNo
            // 
            this.txtNo.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.txtNo.Location = new System.Drawing.Point(856, 163);
            this.txtNo.Multiline = true;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(212, 54);
            this.txtNo.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(586, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 46);
            this.label4.TabIndex = 28;
            this.label4.Text = "Kullanıcı No";
            // 
            // frmKullaniciAyari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1300, 874);
            this.Controls.Add(this.cbxGorev);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnKayitSil);
            this.Controls.Add(this.btnKayit);
            this.Controls.Add(this.txtParolaTekrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.dataGridViewKullanici);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txtKSoyadi);
            this.Controls.Add(this.txtKAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKullaniciAyari";
            this.Text = "frmKullaniciAyari";
            this.Load += new System.EventHandler(this.frmKullaniciAyari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKayitSil;
        private System.Windows.Forms.Button btnKayit;
        private System.Windows.Forms.TextBox txtParolaTekrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.DataGridView dataGridViewKullanici;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.TextBox txtKSoyadi;
        private System.Windows.Forms.TextBox txtKAdi;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxGorev;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label4;
    }
}