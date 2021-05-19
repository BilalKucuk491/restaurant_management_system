using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantt
{
    public partial class frmSiparisKontrol : Form
    {
        public frmSiparisKontrol()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            cDiger rMethod = new cDiger();
            rMethod.returnMethod();
            this.Close();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            cDiger cMethod = new cDiger();
            cMethod.cikisMethod();
        }


       
        private void frmSiparisKontrol_Load(object sender, EventArgs e)
        {
            cGeneralDesign design = new cGeneralDesign();
            design.standartLoadDesign(btnReturn, btnCikis, this);
            design.standartListviewDesign(lvMusteriDetaylari, lvSatisDetaylari);

            cAdisyon c = new cAdisyon();
            int butonSayisi = c.paketAdisyonIdBulAdedi();
            c.acikPaketAdisyonlar(lvMusteriler);
            int alt = 50; 
            int sol = 1;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi))); //Ceiling yakın olana yuvarlama.

            for (int i = 1; i <= butonSayisi; i++)
            {
                Button btn = new Button();
                btn.AutoSize = false;
                btn.Size = new Size(179, 80);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;
                btn.Text = lvMusteriler.Items[i - 1].SubItems[1].Text;
                btn.Font = new Font(btn.Font.FontFamily.Name, 18);
                btn.Location = new Point(13, 597);

                this.Controls.Add(btn);
                sol += btn.Width + 5;
                if (i == 2)
                {
                    sol = 1;
                    alt += 50;
                }
                btn.Click += new EventHandler(dinamikMethod);
                btn.MouseEnter += new EventHandler(dinamikMethod2);
            }
        }


        protected void dinamikMethod(object sender, EventArgs e)
        {
            cAdisyon c = new cAdisyon();
            Button dinamikButon = (sender as Button);
            frmBill frm = new frmBill();
            cGenel._ServisTurNo = 2;
            cGenel._AdisyonId = Convert.ToString(c.musterinSonAdisyonId(Convert.ToInt32(dinamikButon.Name)));
            this.Close();
            frm.Show();
        }


        protected void dinamikMethod2(object sender, EventArgs e)
        {
            Button dinamikButon = (sender as Button);
            cAdisyon c = new cAdisyon();
            c.musteriDetaylar(lvMusteriDetaylari, Convert.ToInt32(dinamikButon.Name));
            sonSiparisTarihi();
            lvSatisDetaylari.Items.Clear();
            cGenel._ServisTurNo = 2;
            cGenel._AdisyonId = Convert.ToString(c.musterinSonAdisyonId(Convert.ToInt32(dinamikButon.Name)));
            cSiparis sie = new cSiparis();
            lblGenelToplam.Text = Convert.ToString(sie.genelToplamBul(Convert.ToInt32(dinamikButon.Name))).Substring(0,5) + "TL";
        }

        void sonSiparisTarihi()
        {
            if (lvMusteriDetaylari.Items.Count > 0)
            {
                int num = lvMusteriDetaylari.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetaylari.Items[num - 1].SubItems[3].Text;
                txtToplamTutar.Text = Convert.ToString(num)+ " Adet";
            }
        }

        void toplam()
        {
            int kayitsayisi = lvSatisDetaylari.Items.Count;
            decimal toplam = 0;
            for (int i = 0; i < kayitsayisi; i++)
            {
                toplam += Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[2].Text) * Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[3].Text);
            }

            lblToplamSiparis.Text = toplam.ToString().Substring(0, 5) + " TL";
        }

        private void lvMusteriDetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMusteriDetaylari.SelectedItems.Count > 0)
            {
                cSiparis c = new cSiparis();
                c.adisyonPaketSiparisDetaylari(lvSatisDetaylari, Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[4].Text));
                toplam();
            }
        }
    }
}
