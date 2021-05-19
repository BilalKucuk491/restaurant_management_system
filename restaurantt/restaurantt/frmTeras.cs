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
    public partial class frmTeras : Form
    {
        public frmTeras()
        {
            InitializeComponent();
            string clock = DateTime.Now.ToString("dd-MM-yyyy HH:mm dddd");
            this.lblClock.Text = clock.ToString();
        }
        cSound msc = new cSound();
        private void btnGeriDon_Click(object sender, EventArgs e)
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

        private void frmTeras_Load(object sender, EventArgs e)
        {
            cGeneralDesign design = new cGeneralDesign();
            design.standartLoadDesign(btnGeriDon, btnCikis, this);

            btnTerasSayfasi.BackColor = Color.FromArgb(58, 100, 151);
        }

        private void btnMasaSayfasi_Click(object sender, EventArgs e)
        {
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.ShowDialog();
        }

        private void btnBahceSayfasi_Click(object sender, EventArgs e)
        {
            frmBahce frm = new frmBahce();
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa54_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa54.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "1";
            cGenel._ButtonName = btnMasa54.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa55_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa55.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "2";
            cGenel._ButtonName = btnMasa55.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa56_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa56.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "3";
            cGenel._ButtonName = btnMasa56.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa57_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa57.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "4";
            cGenel._ButtonName = btnMasa57.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa58_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa58.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "5";
            cGenel._ButtonName = btnMasa58.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa59_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa59.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "6";
            cGenel._ButtonName = btnMasa59.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa60_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa60.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "7";
            cGenel._ButtonName = btnMasa60.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa61_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa61.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "8";
            cGenel._ButtonName = btnMasa61.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa62_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa62.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "9";
            cGenel._ButtonName = btnMasa62.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa63_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa63.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "10";
            cGenel._ButtonName = btnMasa63.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa64_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa64.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "11";
            cGenel._ButtonName = btnMasa64.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa65_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa65.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "12";
            cGenel._ButtonName = btnMasa65.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa66_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa66.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "13";
            cGenel._ButtonName = btnMasa66.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa67_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa67.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "14";
            cGenel._ButtonName = btnMasa67.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa68_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa68.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "15";
            cGenel._ButtonName = btnMasa68.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa69_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa69.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "16";
            cGenel._ButtonName = btnMasa69.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa70_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa70.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "17";
            cGenel._ButtonName = btnMasa70.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa71_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa71.Name.Length;
            cGenel._ButtonValue = "Teras " + " " + "18";
            cGenel._ButtonName = btnMasa71.Name;
            this.Close();
            frm.ShowDialog();
        }

    }
}
