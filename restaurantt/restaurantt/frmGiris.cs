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

    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
            
        }

        cSound msc = new cSound();

        private void frmGiris_Load(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
            cPersoneller p = new cPersoneller();
            p.personelGetInformation(cbKullanici);

        }
        cGenel gnl = new cGenel();
        public static int personelID;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            cPersoneller p = new cPersoneller();
            bool result = p.personelEntryControl(txtSifre.Text, gnl._personelId);
            personelID = gnl._personelId;
            
            if (result)
            {
                cPersonelHareketleri ch = new cPersonelHareketleri();
                ch.PersonelId = gnl._personelId;
                ch.Islem = "Giriş Yaptı";
                ch.Tarih = DateTime.Now;
                ch.PersonelActionSave(ch);
                //yukarıda methodumuzu çahırdık.
                this.Close();
                frmMenu menu = new frmMenu();
                menu.Show();
                //yukarıda bu formu sakladık ve yeni "menu" adlı formu oluşturduk ve onu gösterdik.
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)cbKullanici.SelectedItem;
            gnl._personelId = p.PersonelId;
            cGenel._gorevId = p.PersonelGorevId;
            
            
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            ExitMessageBox frm = new ExitMessageBox();
            
            frm.Show();

        }
        
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text.Length > 0)
            {
                txtSifre.Text = txtSifre.Text.Remove(txtSifre.Text.Length - 1);
            }
            msc.playClickButtonSound();

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // button özelliklerini sender'a gönderdik.
            txtSifre.Text = txtSifre.Text + btn.Text;
            msc.playClickButtonSound();
        }
    }
}






