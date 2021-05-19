namespace restaurantt
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.btnReturn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnTeknikDestek = new System.Windows.Forms.Button();
            this.btnKullaniciAyari = new System.Windows.Forms.Button();
            this.btnMenuAyari = new System.Windows.Forms.Button();
            this.btnSiparisAyari = new System.Windows.Forms.Button();
            this.btnAnalizAyari = new System.Windows.Forms.Button();
            this.btnEvAyari = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlEkran = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturn.Font = new System.Drawing.Font("Nirmala UI", 12.2F);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(0, 980);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(295, 75);
            this.btnReturn.TabIndex = 27;
            this.btnReturn.Text = "Geridön";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnTeknikDestek);
            this.panel1.Controls.Add(this.btnKullaniciAyari);
            this.panel1.Controls.Add(this.btnReturn);
            this.panel1.Controls.Add(this.btnMenuAyari);
            this.panel1.Controls.Add(this.btnSiparisAyari);
            this.panel1.Controls.Add(this.btnAnalizAyari);
            this.panel1.Controls.Add(this.btnEvAyari);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 1055);
            this.panel1.TabIndex = 28;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlNav.Location = new System.Drawing.Point(12, 321);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(6, 78);
            this.pnlNav.TabIndex = 69;
            this.pnlNav.Visible = false;
            // 
            // btnTeknikDestek
            // 
            this.btnTeknikDestek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnTeknikDestek.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTeknikDestek.FlatAppearance.BorderSize = 0;
            this.btnTeknikDestek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeknikDestek.Font = new System.Drawing.Font("Nirmala UI", 12.2F);
            this.btnTeknikDestek.ForeColor = System.Drawing.Color.White;
            this.btnTeknikDestek.Location = new System.Drawing.Point(0, 601);
            this.btnTeknikDestek.Name = "btnTeknikDestek";
            this.btnTeknikDestek.Size = new System.Drawing.Size(295, 80);
            this.btnTeknikDestek.TabIndex = 6;
            this.btnTeknikDestek.Text = "TEKNIK DESTEK";
            this.btnTeknikDestek.UseVisualStyleBackColor = false;
            this.btnTeknikDestek.Click += new System.EventHandler(this.btnTeknikDestek_Click);
            this.btnTeknikDestek.Leave += new System.EventHandler(this.btn_Button_Leave);
            // 
            // btnKullaniciAyari
            // 
            this.btnKullaniciAyari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnKullaniciAyari.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKullaniciAyari.FlatAppearance.BorderSize = 0;
            this.btnKullaniciAyari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullaniciAyari.Font = new System.Drawing.Font("Nirmala UI", 12.2F);
            this.btnKullaniciAyari.ForeColor = System.Drawing.Color.White;
            this.btnKullaniciAyari.Location = new System.Drawing.Point(0, 521);
            this.btnKullaniciAyari.Name = "btnKullaniciAyari";
            this.btnKullaniciAyari.Size = new System.Drawing.Size(295, 80);
            this.btnKullaniciAyari.TabIndex = 5;
            this.btnKullaniciAyari.Text = "KULLANICI AYARLARI";
            this.btnKullaniciAyari.UseVisualStyleBackColor = false;
            this.btnKullaniciAyari.Click += new System.EventHandler(this.btnKullaniciAyari_Click);
            this.btnKullaniciAyari.Leave += new System.EventHandler(this.btn_Button_Leave);
            // 
            // btnMenuAyari
            // 
            this.btnMenuAyari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnMenuAyari.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAyari.FlatAppearance.BorderSize = 0;
            this.btnMenuAyari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAyari.Font = new System.Drawing.Font("Nirmala UI", 12.2F);
            this.btnMenuAyari.ForeColor = System.Drawing.Color.White;
            this.btnMenuAyari.Location = new System.Drawing.Point(0, 441);
            this.btnMenuAyari.Name = "btnMenuAyari";
            this.btnMenuAyari.Size = new System.Drawing.Size(295, 80);
            this.btnMenuAyari.TabIndex = 4;
            this.btnMenuAyari.Text = "MENU AYARLARI";
            this.btnMenuAyari.UseVisualStyleBackColor = false;
            this.btnMenuAyari.Click += new System.EventHandler(this.btnMenuAyari_Click);
            this.btnMenuAyari.Leave += new System.EventHandler(this.btn_Button_Leave);
            // 
            // btnSiparisAyari
            // 
            this.btnSiparisAyari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnSiparisAyari.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSiparisAyari.FlatAppearance.BorderSize = 0;
            this.btnSiparisAyari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiparisAyari.Font = new System.Drawing.Font("Nirmala UI", 12.2F);
            this.btnSiparisAyari.ForeColor = System.Drawing.Color.White;
            this.btnSiparisAyari.Location = new System.Drawing.Point(0, 361);
            this.btnSiparisAyari.Name = "btnSiparisAyari";
            this.btnSiparisAyari.Size = new System.Drawing.Size(295, 80);
            this.btnSiparisAyari.TabIndex = 3;
            this.btnSiparisAyari.Text = "SIPARIS AYARLARI";
            this.btnSiparisAyari.UseVisualStyleBackColor = false;
            this.btnSiparisAyari.Click += new System.EventHandler(this.btnSiparisAyari_Click);
            this.btnSiparisAyari.Leave += new System.EventHandler(this.btn_Button_Leave);
            // 
            // btnAnalizAyari
            // 
            this.btnAnalizAyari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnAnalizAyari.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnalizAyari.FlatAppearance.BorderSize = 0;
            this.btnAnalizAyari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalizAyari.Font = new System.Drawing.Font("Nirmala UI", 12.2F);
            this.btnAnalizAyari.ForeColor = System.Drawing.Color.White;
            this.btnAnalizAyari.Location = new System.Drawing.Point(0, 281);
            this.btnAnalizAyari.Name = "btnAnalizAyari";
            this.btnAnalizAyari.Size = new System.Drawing.Size(295, 80);
            this.btnAnalizAyari.TabIndex = 2;
            this.btnAnalizAyari.Text = "TOPLAM ANALIZ";
            this.btnAnalizAyari.UseVisualStyleBackColor = false;
            this.btnAnalizAyari.Click += new System.EventHandler(this.btnAnalizAyari_Click);
            this.btnAnalizAyari.Leave += new System.EventHandler(this.btn_Button_Leave);
            // 
            // btnEvAyari
            // 
            this.btnEvAyari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnEvAyari.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEvAyari.FlatAppearance.BorderSize = 0;
            this.btnEvAyari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvAyari.Font = new System.Drawing.Font("Nirmala UI", 12.2F);
            this.btnEvAyari.ForeColor = System.Drawing.Color.White;
            this.btnEvAyari.Location = new System.Drawing.Point(0, 201);
            this.btnEvAyari.Name = "btnEvAyari";
            this.btnEvAyari.Size = new System.Drawing.Size(295, 80);
            this.btnEvAyari.TabIndex = 1;
            this.btnEvAyari.Text = "EV AYARLARI";
            this.btnEvAyari.UseVisualStyleBackColor = false;
            this.btnEvAyari.Click += new System.EventHandler(this.btnEvAyari_Click);
            this.btnEvAyari.Leave += new System.EventHandler(this.btn_Button_Leave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 201);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::restaurantt.Properties.Resources.aa;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(92, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 104);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "@infoProgramlama";
            // 
            // pnlEkran
            // 
            this.pnlEkran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEkran.Location = new System.Drawing.Point(295, 0);
            this.pnlEkran.Name = "pnlEkran";
            this.pnlEkran.Size = new System.Drawing.Size(1629, 1055);
            this.pnlEkran.TabIndex = 29;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.pnlEkran);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmSetting";
            this.Text = "frmSetting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlEkran;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTeknikDestek;
        private System.Windows.Forms.Button btnKullaniciAyari;
        private System.Windows.Forms.Button btnMenuAyari;
        private System.Windows.Forms.Button btnSiparisAyari;
        private System.Windows.Forms.Button btnAnalizAyari;
        private System.Windows.Forms.Button btnEvAyari;
    }
}