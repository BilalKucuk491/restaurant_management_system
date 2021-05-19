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
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
            this.lblClock.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm dddd");
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

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteriEkleme m = new FrmMusteriEkleme();
            cGenel._musteriEkleme = 1;
            m.btnEkle.Visible = true;
            m.btnGuncelle.Visible = false;
            m.ShowDialog();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {

            cGeneralDesign design = new cGeneralDesign();
            design.standartLoadDesign(btnReturn, btnCikis, this);

            cMusteriler c = new cMusteriler();
            c.musterileriGetir(lvMusteriler);
            listViewDesign(lvMusteriler);

        }

        void listViewDesign(ListView lst)
        {
            lst.BackColor = Color.FromArgb(59, 63, 74);
            lst.ForeColor = Color.White;
        }
        private void btnMusteriSec_Click(object sender, EventArgs e)
        {

        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                cGenel._musteriEkleme = 1;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
               
                FrmMusteriEkleme frm = new FrmMusteriEkleme();
                frm.btnEkle.Visible = false;
                frm.btnGuncelle.Visible = true;
                frm.ShowDialog();
                    
            }
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musteriGetirAd(lvMusteriler, txtAd.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musteriGetirSoyad(lvMusteriler, txtSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler c = new cMusteriler();
            c.musteriGetirTlf(lvMusteriler, txtTelefon.Text);
        }


        private void txtBoxControls()
        {

        }

        FrmMessageBox frmMBox = new FrmMessageBox();
        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if (txtAdisyonID.Text != "")
            {
                cGenel._AdisyonId = txtAdisyonID.Text;
                cPaketler c = new cPaketler();
                bool sonuc = c.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonID.Text));

                if (sonuc)
                {
                    frmBill frm = new frmBill();

                    cGenel._ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    frmMBox.lblMessage.Text = txtAdisyonID.Text + " Böyle bir adisyon bulunamadı.";
                    frmMBox.ShowDialog();
                }
            }
            else
            {
                frmMBox.lblMessage.Text = "Aramak istediğiniz adisyonu yazınız";
                frmMBox.ShowDialog();
            }
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol s = new frmSiparisKontrol();
            this.Close();
            s.Show();
        }

       
    }
}
