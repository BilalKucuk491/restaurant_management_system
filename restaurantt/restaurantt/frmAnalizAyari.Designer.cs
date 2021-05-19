namespace restaurantt
{
    partial class frmAnalizAyari
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
            this.dataGridViewAnaliz = new System.Windows.Forms.DataGridView();
            this.lblMusteriSayisi = new System.Windows.Forms.Label();
            this.lblSatisSayisi = new System.Windows.Forms.Label();
            this.txtMusteriSayisi = new System.Windows.Forms.TextBox();
            this.txtSatisSayisi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnaliz)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAnaliz
            // 
            this.dataGridViewAnaliz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAnaliz.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAnaliz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnaliz.Location = new System.Drawing.Point(115, 246);
            this.dataGridViewAnaliz.Name = "dataGridViewAnaliz";
            this.dataGridViewAnaliz.RowHeadersWidth = 51;
            this.dataGridViewAnaliz.RowTemplate.Height = 24;
            this.dataGridViewAnaliz.Size = new System.Drawing.Size(1346, 635);
            this.dataGridViewAnaliz.TabIndex = 27;
            // 
            // lblMusteriSayisi
            // 
            this.lblMusteriSayisi.AutoSize = true;
            this.lblMusteriSayisi.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.lblMusteriSayisi.ForeColor = System.Drawing.Color.White;
            this.lblMusteriSayisi.Location = new System.Drawing.Point(107, 39);
            this.lblMusteriSayisi.Name = "lblMusteriSayisi";
            this.lblMusteriSayisi.Size = new System.Drawing.Size(346, 46);
            this.lblMusteriSayisi.TabIndex = 31;
            this.lblMusteriSayisi.Text = "Toplam Müşteri Sayısı";
            // 
            // lblSatisSayisi
            // 
            this.lblSatisSayisi.AutoSize = true;
            this.lblSatisSayisi.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.lblSatisSayisi.ForeColor = System.Drawing.Color.White;
            this.lblSatisSayisi.Location = new System.Drawing.Point(107, 105);
            this.lblSatisSayisi.Name = "lblSatisSayisi";
            this.lblSatisSayisi.Size = new System.Drawing.Size(241, 46);
            this.lblSatisSayisi.TabIndex = 32;
            this.lblSatisSayisi.Text = "Toplam Kazanç";
            // 
            // txtMusteriSayisi
            // 
            this.txtMusteriSayisi.Location = new System.Drawing.Point(508, 26);
            this.txtMusteriSayisi.Multiline = true;
            this.txtMusteriSayisi.Name = "txtMusteriSayisi";
            this.txtMusteriSayisi.ReadOnly = true;
            this.txtMusteriSayisi.Size = new System.Drawing.Size(239, 59);
            this.txtMusteriSayisi.TabIndex = 33;
            // 
            // txtSatisSayisi
            // 
            this.txtSatisSayisi.Location = new System.Drawing.Point(508, 92);
            this.txtSatisSayisi.Multiline = true;
            this.txtSatisSayisi.Name = "txtSatisSayisi";
            this.txtSatisSayisi.ReadOnly = true;
            this.txtSatisSayisi.Size = new System.Drawing.Size(239, 59);
            this.txtSatisSayisi.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 46);
            this.label1.TabIndex = 32;
            this.label1.Text = "Aylık Kazanç";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(508, 157);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(239, 59);
            this.textBox1.TabIndex = 33;
            // 
            // frmAnalizAyari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1629, 1055);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtSatisSayisi);
            this.Controls.Add(this.txtMusteriSayisi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSatisSayisi);
            this.Controls.Add(this.lblMusteriSayisi);
            this.Controls.Add(this.dataGridViewAnaliz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnalizAyari";
            this.Text = "frmAnalizAyari";
            this.Load += new System.EventHandler(this.frmAnalizAyari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnaliz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAnaliz;
        private System.Windows.Forms.Label lblMusteriSayisi;
        private System.Windows.Forms.Label lblSatisSayisi;
        private System.Windows.Forms.TextBox txtMusteriSayisi;
        private System.Windows.Forms.TextBox txtSatisSayisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}