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
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            
        }
        private void FormGetir(Form frm)
        {
            pnlEkran.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlEkran.Controls.Add(frm);
            frm.Show();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            cDiger rMethod = new cDiger();
            rMethod.returnMethod();
            this.Close();
        }

        cGeneralDesign design = new cGeneralDesign();
        private void btn_Button_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            design.btnLeaveColor(btn);
        }
        void buttonDesign(Button btn)
        {
            pnlNav.Visible = true;
            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.Left = btn.Left;
            btn.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void btnEvAyari_Click(object sender, EventArgs e)
        {
            frmEvAyari h = new frmEvAyari();
            FormGetir(h);
            buttonDesign(btnEvAyari);
        }

        private void btnAnalizAyari_Click(object sender, EventArgs e)
        {
            frmAnalizAyari d = new frmAnalizAyari();
            FormGetir(d);
            buttonDesign(btnAnalizAyari);
        }

        private void btnMenuAyari_Click(object sender, EventArgs e)
        {
            
            frmMenuAyarlari d = new frmMenuAyarlari();
            FormGetir(d);
            buttonDesign(btnMenuAyari);
        }

        private void btnSiparisAyari_Click(object sender, EventArgs e)
        {
            frmSiparislerAyari m = new frmSiparislerAyari();
            FormGetir(m);
            buttonDesign(btnSiparisAyari);
        }

        private void btnKullaniciAyari_Click(object sender, EventArgs e)
        {
            frmKullaniciAyari frm = new frmKullaniciAyari();
            FormGetir(frm);
            buttonDesign(btnKullaniciAyari);
        }

        private void btnTeknikDestek_Click(object sender, EventArgs e)
        {
            frmTeknikDestekAyari frm = new frmTeknikDestekAyari();
            FormGetir(frm);
            buttonDesign(btnTeknikDestek);
        }
    }
}
