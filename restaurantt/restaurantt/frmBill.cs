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
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
            
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            cDiger rMethod = new cDiger();
            rMethod.returnMethod();
            this.Close();
            
        }
        cSiparis cs = new cSiparis();
        int odemeTurId = 0;


        void listViewDesign(ListView lst)
        {
            lst.BackColor = Color.FromArgb(59, 63, 74);
            lst.ForeColor = Color.FromArgb(228, 227, 232);
            
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            cGeneralDesign design = new cGeneralDesign();
            design.standartLoadDesign(btnGeriDon, btnCikis, this);

            listViewDesign(lvUrunler);

            if (cGenel._ServisTurNo == 1)//Masa 1 ise 
            {
                lblAdisyonId.Text = cGenel._AdisyonId; //lblAdisyon etiketine Adisyon id'ini gösterdik.

                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);

                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));

                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;//paradan dolayı decimal veri tipi kullandık.

                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);//subitems 3 olan yanii fiyatı toplam nesnesinde topladık.  
                    }

                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKDV.Text = string.Format("{0:0.000}", kdv);
                }

                
                txtIndirimTutari.Clear();
            }

            else if (cGenel._ServisTurNo == 2)
            {
                lblAdisyonId.Text = cGenel._AdisyonId; //lblAdisyon etiketine Adisyon id'ini gösterdik.
                cPaketler pc = new cPaketler();
                odemeTurId = pc.OdemeTurIdGetir(Convert.ToInt32(lblAdisyonId.Text));
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));

                if (odemeTurId == 1)
                {
                    rbKrediKarti.Checked = true;
                }
                else if (odemeTurId == 2)
                {
                    rbKrediKarti.Checked = true;
                }

                else if (odemeTurId == 3)
                {
                    rbTicket.Checked = true;
                }

                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;//paradan dolayı decimal veri tipi kullandık.

                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);//subitems 3 olan yanii fiyatı toplam nesnesinde topladık.  
                    }

                    lblToplamTutar.Text = string.Format("{0:0.000}", toplam);
                    lblOdenecek.Text = string.Format("{0:0.000}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKDV.Text = string.Format("{0:0.000}", kdv);
                }

                
                txtIndirimTutari.Clear();
            }
        }

        private void txtIndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtIndirimTutari.Text) < Convert.ToDecimal(lblToplamTutar.Text)) //indirim tutarı toplam tutardan küçükse
                {
                    try
                    {
                        lblIndirim.Text = string.Format("{0:0.0}", Convert.ToDecimal(txtIndirimTutari.Text));// Girilen indirlim tutarını lblIndirim kısmına 15.00 olarak yazdırdık.
                    }
                    catch (Exception)
                    {

                        lblIndirim.Text = string.Format("{0:0.0}", 0.0);//Burada 0.000 olarak yazdırdık.
                    }
                }
                else
                {
                    MessageBox.Show("İndirim Tutarı Toplam Tutardan Fazla Olamaz !!!");
                }
            }
            catch (Exception ex)
            {
                lblIndirim.Text = string.Format("{0:0.0}", 0.0);
            }
        }

       
        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text) > 0)
            {
                Decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(lblIndirim.Text);
                lblOdenecek.Text = string.Format("{0:0.000}", odenecek);

            }

            decimal kdv = Convert.ToDecimal(lblOdenecek.Text)*18/100;
            lblKDV.Text = string.Format("{0:0.000}", kdv);
        }

        cMasalar masalar = new cMasalar();
        cRezervasyon rezerve = new cRezervasyon();
        private void btnhesapKapat_Click(object sender, EventArgs e)
        {
            if (cGenel._ServisTurNo == 1)//Paket sipariş anlamına geliyor.
            {
                int masaid = masalar.tableGetbyNumber(cGenel._ButtonName);
                int musteriId = 0;
                if (masalar.TableGetbyState(masaid, 4) == true)//Masa numarası Rezervasyonlu ise 
                {
                    musteriId = rezerve.getByClientIdFromRezervasyon(masaid);
                }
                else
                {
                    musteriId = 1;
                }

                int odemeTurId = 0;

                if (rbNakit.Checked == true)
                {
                    odemeTurId = 1;
                }
                if (rbKrediKarti.Checked == true)
                {
                    odemeTurId = 2;
                }
                if (rbTicket.Checked == true)
                {
                    odemeTurId = 3;
                }

                cOdeme odeme = new cOdeme();
                //ADISYONID,ODEMETURID,MUSTERIID,ARATOPLAM,KDVTUTARI,INDIRIM,TOPLAMTUTAR
                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTurId;
                odeme.MusteriId = musteriId;
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKDV.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);

                if (result)
                {
                    FrmMessageBox frm = new FrmMessageBox();
                    frm.lblMessage.Text = "Hesap Kapatıldı.";
                    frm.ShowDialog();

                    masalar.setChangeTableState(Convert.ToString(masaid), 1);//Masa durumunu boş haline getirdik.

                    cRezervasyon c = new cRezervasyon();
                    c.rezervationClose(Convert.ToInt32(lblAdisyonId.Text));

                    cAdisyon a = new cAdisyon();
                    a.adisyonKapat(Convert.ToInt32(lblAdisyonId.Text),1);


                    frmSiparis frmSip = new frmSiparis();
                    frmSip.lvSiparisler.Items.Clear();
                    
                    frmMasalar mslr = new frmMasalar();
                    mslr.Show();
                    this.Close();


                }

                else
                {
                    FrmMessageBox frm = new FrmMessageBox();
                    frm.lblMessage.Text = "Hesap kapatılırken bir hata oluştu.";
                    frm.ShowDialog();
                }

            }

            //Paket Siparis
            else if (cGenel._ServisTurNo == 2)
            {
                cOdeme odeme = new cOdeme();
                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTurId;
                odeme.MusteriId = 1; //Paket sipariş ID
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKDV.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = odeme.billClose(odeme);
                if (result)
                {
                    
                    cAdisyon a = new cAdisyon();
                    a.adisyonKapat(Convert.ToInt32(lblAdisyonId.Text), 0);

                    cPaketler p = new cPaketler();
                    p.OrderServiceClose(Convert.ToInt32(lblAdisyonId.Text));
                    MessageBox.Show("Hesap kapatıldı.");

                    this.Close();
                    frmMasalar frm = new frmMasalar();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap kapatılırken bir hata oluştu.");
                }

            }
            else
            {
                MessageBox.Show("Hesap kapatılırken bir hata oluştu. Lütfen Yetkililere bildiriniz.");
            }
        }

        private void btnHesapOzeti_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near; //Stringformatı hizalamasını yakın tutuyoruz.
            e.Graphics.DrawString("InfoProgramlama RESTAURANT", Baslik, sb, 350, 100, st);//350 = x , 100= y ekseni oluyor.
            e.Graphics.DrawString("----------------", altBaslik, sb, 350, 120, st);
            e.Graphics.DrawString("Ürün Adı                 Adet           Fiyat", altBaslik, sb, 150, 250, st);
            e.Graphics.DrawString("---------------------------------------------------------", altBaslik, sb, 150, 280, st);

            for (int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, icerik, sb, 150, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, icerik, sb, 350, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[3].Text, icerik, sb, 420, 300 + i * 30, st);
            }

            e.Graphics.DrawString("---------------------------------------------------------", altBaslik, sb, 150, 300 + 30 * lvUrunler.Items.Count, st); 
            e.Graphics.DrawString("İndirim Tutarı :---------------- " + lblIndirim.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 1), st);
            e.Graphics.DrawString("Kdv Tutar      :---------------- " + lblKDV.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 2), st);
            e.Graphics.DrawString("Toplam Tutar   :---------------- " + lblToplamTutar.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödenen Tutar   :---------------- " + lblOdenecek.Text + " TL", altBaslik, sb, 250, 300 + 30 * (lvUrunler.Items.Count + 4), st);

        }

        
    }
}
