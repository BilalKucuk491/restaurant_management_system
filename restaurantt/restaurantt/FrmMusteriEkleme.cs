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
    public partial class FrmMusteriEkleme : Form
    {
        public FrmMusteriEkleme()
        {
            InitializeComponent();
        }
        FrmMessageBox FrmMBox = new FrmMessageBox();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            if (txtTelefon.Text.Length >=  11)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    FrmMBox.lblMessage.Text = "Lütfen müşterinin ad veya soyad kısımlarını boş bırakmayalım.";
                    FrmMBox.ShowDialog();
                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    bool sonuc = c.musteriVarmi(txtTelefon.Text);
                    if (!sonuc) //!sonuc demek false ise yani true döndürmüyorsa. Yani kayıtlı müşteri yoksa
                    {
                        c.Musteirad = txtMusteriAd.Text;
                        c.Musterisoyad = txtMusteriSoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Email = txtMail.Text;
                        c.Adres = txtAdres.Text;
                        txtMusteriNo.Text = c.musteriEkle(c).ToString();//scope ile müşteri idsini txtmusterino kısmına yazdırmış olduk
                        if (txtMusteriNo.Text != "")
                        {
                            FrmMBox.lblMessage.Text = "Müşteri Eklendi";
                            FrmMBox.ShowDialog();
                        }
                        else
                        {
                            FrmMBox.lblMessage.Text = "Müşteri Eklenemedi";
                            FrmMBox.ShowDialog();
                        }
                    }
                    else
                    {
                        FrmMBox.lblMessage.Text = "Müşteri zaten kayıtlı";
                        FrmMBox.ShowDialog();
                    }
                }
            }
            else
            {
                FrmMBox.lblMessage.Text = "Lütfen 11 haneli cep telefon numaranızı giriniz";
                FrmMBox.ShowDialog();
            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (cGenel._musteriEkleme == 0)
            {
                frmRezervasyon frm = new frmRezervasyon();
                cGenel._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if(cGenel._musteriEkleme == 1)
            {
                frmPaketSiparis frm = new frmPaketSiparis();
                cGenel._musteriEkleme = 0;
                this.Close();
                frm.Show();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length >= 11)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    FrmMBox.lblMessage.Text = "Lütfen müşterinin ad veya soyad kısımlarını boş bırakmayalım.";
                    FrmMBox.ShowDialog();
                }
                else
                {
                    cMusteriler c = new cMusteriler();
                    c.Musteirad = txtMusteriAd.Text;
                    c.Musterisoyad = txtMusteriSoyad.Text;
                    c.Telefon = txtTelefon.Text;
                    c.Email = txtMail.Text;
                    c.Adres = txtAdres.Text;
                    c.Musteriid =Convert.ToInt32(txtMusteriNo.Text);
                    bool sonuc = c.musteriBilgileriGuncelle(c);

                    if (sonuc) //!sonuc demek false ise yani true döndürmüyorsa. Yani kayıtlı müşteri yoksa
                    {
                       
                        if (txtMusteriNo.Text != "")
                        {
                            FrmMBox.lblMessage.Text = "Müşteri Güncellendi";
                            FrmMBox.ShowDialog();
                        }
                        else
                        {
                            FrmMBox.lblMessage.Text = "Müşteri Güncellenmedi";
                            FrmMBox.ShowDialog();
                        }
                    }
                    else
                    {
                        FrmMBox.lblMessage.Text = "Müşteri zaten kayıtlı";
                        FrmMBox.ShowDialog();
                    }
                }
            }
            else
            {
                FrmMBox.lblMessage.Text = "Lütfen 11 haneli cep telefon numaranızı giriniz";
                FrmMBox.ShowDialog();
            }
        }

        private void FrmMusteriEkleme_Load(object sender, EventArgs e)
        {
            if (cGenel._musteriId > 0)
            {
                cMusteriler c = new cMusteriler();
                txtMusteriNo.Text = Convert.ToString(cGenel._musteriId);
                c.musterilerigetirID(Convert.ToInt32(txtMusteriNo.Text),txtMusteriAd,txtMusteriSoyad,txtTelefon,txtAdres,txtMail);

            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
