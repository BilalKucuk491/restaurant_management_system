using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;//ArrayList çağırmamıza sağlayan kütüphane
using System.Data.SqlClient;

namespace restaurantt
{
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
            this.lblClock.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm dddd");
        }


       void lblToplamTurarDurumu()
        {
            decimal toplam = 0;//paradan dolayı decimal veri tipi kullandık.
            for (int i = 0; i < lvSiparisler.Items.Count; i++)
            {
                toplam = toplam + Convert.ToDecimal(lvSiparisler.Items[i].SubItems[3].Text);

            }

            lblTutar.Text = Convert.ToString(toplam);
        }

        //FullRowSelect program çalışırken bir sütünu tamamen seçmemizi izin verir.
        int tableId; int AdditionId;

        frmGiris frmGiris = new frmGiris();
        cPersoneller cPersoneller = new cPersoneller();
        private void frmSiparis_Load(object sender, EventArgs e)
        {
            lblKullaniciIsmi.Text = cPersoneller.personelBilgiGetirIsim(frmGiris.personelID);
            lblToplamTurarDurumu();

            // buton Name'ini lblmasano'ya ismi oldu.
            lbMasaNo.Text = cGenel._ButtonValue;

            //Burada masa numarasını almış olduk
            cMasalar ms = new cMasalar();//cGenel._ButtonName
            tableId = ms.tableGetbyNumber(cGenel._ButtonName);

            //Table id'si 2 veya 4 
            if (ms.TableGetbyState(tableId, 2) == true || ms.TableGetbyState(10, 4) == true)
            {
                cAdisyon Ad = new cAdisyon();
                AdditionId = Ad.getByAddition(tableId);
                cSiparis orders = new cSiparis();
                orders.getByOrder(lvSiparisler, AdditionId);
                //Burada lvSiaprisler'de diğer veriler gösterilecek adisyonId ile idlerini karşılaştırmamızı sağlar
            }

         
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            cDiger rMethod = new cDiger();
            rMethod.returnMethod();
            this.Close();
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // button özelliklerini sender'a gönderdik.
            txtAdet.Text = txtAdet.Text + btn.Text;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            if (txtAdet.Text.Length > 0)
            {
                txtAdet.Text = txtAdet.Text.Remove(txtAdet.Text.Length - 1);
            }
        }

       

        cUrunCesitleri Uc = new cUrunCesitleri();
        cSound msc = new cSound();
        private void btnCorba1_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnCorba1);
        }

        private void btnAraSicak2_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnAraSicak2);
        }

        private void btnAnaYemek3_Click_1(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnAnaYemek3);
        }

        private void btnMakarna4_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnMakarna4);
        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnFastFood5);
        }

        private void btnSalata6_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnSalata6);
        }

        private void btnTatlilar7_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnTatlilar7);
        }

        private void btnIcecekler8_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            Uc.getByProductTypes(lvMenu, btnIcecekler8);
        }

       
        int sayac = 0; int sayac2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            
            //txtAdet boş ise default değer olarak 1 atadık hata almayalım.
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }

            //Çift tıklama yaptığımız sütunun içinde değer var mı yok mu kontrol edilir.
            if (lvMenu.Items.Count>0)
            {
                sayac = lvSiparisler.Items.Count;
                //Seçilen sütünlardaki metini lvsiparişler menüsüne ekledik.
                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                //1.sütün 2.kolonu şeçtik
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                //Ürün fiyatını adedi ile çarptık
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());
                


                //Yenieklenenler listesine değerleri ekledik.
                lvYeniEklenenler.Items.Add(AdditionId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(tableId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;

                txtAdet.Text = "";


                //lbltutar fiyatlandırma
                if (lvSiparisler.Items.Count > 0)
                {

                    decimal toplam = 0;//paradan dolayı decimal veri tipi kullandık.
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvSiparisler.Items[i].SubItems[3].Text);//subitems 3 olan yanii fiyatı toplam nesnesinde topladık.  
                    }

                    lblTutar.Text = string.Format("{0:0.000}", toplam);
                }


            }
        }


        ArrayList silinler = new ArrayList();
        private void btnSiparis_Click_1(object sender, EventArgs e)
        {
            msc.playClickButtonSound();

            /** 
              
            1- Masa Boş
            2- Masa Dolu
            3- Masa Rezerve
            4- Dolu Rezerve
                Yukaridaki masa durumlarıdır.
            */

            cMasalar masa = new cMasalar();
            frmMasalar ms = new frmMasalar();
            cAdisyon newAddition = new cAdisyon();
            cSiparis saveOrder = new cSiparis();
            
            bool sonuc = false;

            //Masa durumu 1 ise yani boş ise
            if (masa.TableGetbyState(tableId, 1) == true)
            {
                newAddition.ServisTurNo = 1;//Şimdilik servisTurNo 1 yaptık.

                

                newAddition.PersonelId = 1;
                newAddition.MasaId = tableId;
                newAddition.Tarih = DateTime.Now;
                sonuc = newAddition.setByAddition(newAddition);
                masa.setChangeTableState(cGenel._ButtonName, 2);//tableId yerine bilgilerin toplandığı direk buton ismini alıyoruz.

                if (lvSiparisler.Items.Count > 0)//elde 0 dan büyük yani en az bir veri veya daha fazlasını olduğunu anladık.
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)//Kayıt sayısı kadar for döngüsü devam eder. Dinamik bir döngü
                    {
                        saveOrder.MasaId = tableId;
                        saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text); //0.kolon değil 1.kolon olduğundan
                        saveOrder.setSaveOrder(saveOrder); //SaveOrder daki bilgileri setSaveOrder ile veritabanına kaydettik.

                    }

                    this.Close();//Bu sipariş kısmını kapattık.
                    ms.Show();//Masalar formunu gösterdik.
                }
            }

            else if (masa.TableGetbyState(tableId, 2) == true || masa.TableGetbyState(tableId, 4) == true)   //Masa durumu 2 ise yani dolu ise
            {
                cGenel._ServisTurNo = 1;
                if (lvYeniEklenenler.Items.Count > 0)//içinde her hangi girilen değer varsa
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++) //Kaç tane girilen değer yani item olduğuna bakarız.
                    {
                        saveOrder.MasaId = tableId;
                        saveOrder.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }

                   
                }

                if (silinler.Count > 0)
                {
                    foreach (string item in silinler)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }
                }

                this.Close();
                ms.Show();
            }

            else if (masa.TableGetbyState(tableId, 3) == true)//Masa durumu 3 olduğunda. açık rezerve durumu
            {
                
                newAddition.ServisTurNo = 1;//Şimdilik servisTurNo 1 yaptık.
                newAddition.PersonelId = 1;
                newAddition.MasaId = tableId;
                newAddition.Tarih = DateTime.Now;
                sonuc = newAddition.setByAddition(newAddition);
                masa.setChangeTableState(cGenel._ButtonName, 3);//tableId yerine bilgilerin toplandığı direk buton ismini alıyoruz.

                if (lvSiparisler.Items.Count > 0)//elde 0 dan büyük yani en az bir veri veya daha fazlasını olduğunu anladık.
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)//Kayıt sayısı kadar for döngüsü devam eder. Dinamik bir döngü
                    {
                        saveOrder.MasaId = tableId;
                        saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text); //0.kolon değil 1.kolon olduğundan
                        saveOrder.setSaveOrder(saveOrder); //SaveOrder daki bilgileri setSaveOrder ile veritabanına kaydettik.

                    }

                    this.Close();//Bu sipariş kısmını kapattık.
                    ms.Show();//Masalar formunu gösterdik.
                }
            }

        }

        private void lvSiparisler_DoubleClick(object sender, EventArgs e)//lvSiparişlere çiftt tıklandığında iki koşul oluşacak.
        {
            if (lvSiparisler.Items.Count > 0)//lvSiaprişlerde ürün olup olmadığına baktık.
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    cSiparis saveOrder = new cSiparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparisler.Items[0].SubItems[4].Text)); //satisId sini sildi

                }

                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++) // Eğer 
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }

                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index); //Hangi şeye çift tıkladıysak en son gitmesini sağlayan ksım 

            }
 
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (txtAra.Text != "")
            {
                cUrunCesitleri cu = new cUrunCesitleri();
                cu.getByProductSearch(lvMenu, Convert.ToInt32(txtAra.Text)); //arama methodu kullandık. Bu methodta idlere bakarak arama yapılıyor.
            }
            
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            cGenel._ServisTurNo = 1; //ServisTurNo 1 değerini atadık.
            cGenel._AdisyonId = AdditionId.ToString();//AdisyonId 'ye AdditionId atadık.
            frmBill frm = new frmBill();

            frm.ShowDialog();
        }

        
        private void btnKlavye_Click(object sender, EventArgs e)
        {
            keyboard k = new keyboard();
            k.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void lvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlSiparisArttirma.Visible == true)
            {
                pnlSiparisArttirma.Visible = false;
            }
            
        }

        private void btnUrnGeri_Click(object sender, EventArgs e)
        {
            pnlSiparisArttirma.Visible = true;
        }

        private void btnNokta_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // button özelliklerini sender'a gönderdik.
            txtAdet.Text = txtAdet.Text + btn.Text;
        }

        cGenel gnl = new cGenel();
        public void ArtisAzalisMethod(int id, ListView lv)
        {
            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Select * from urunler where (ID=@urunID)", con);
            cmd.Parameters.Add("urunID", SqlDbType.Int).Value = id;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["FIYAT"].ToString().Substring(0,5));
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }


        }
        void btnUrnArtisAzalis(int sonuc)
        {
            if (lvSiparisler.Items.Count > 0 && Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[1].Text) >= 0)
            {
                int adet = 0;
                ArtisAzalisMethod(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[2].Text), lvDeneme);
                if (sonuc == 1)
                {
                    adet = Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[1].Text) + 1;
                }
                else if (sonuc == 0)
                {
                    adet = Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[1].Text) - 1;
                }
                else
                {
                    FrmMessageBox mb = new FrmMessageBox();
                    mb.lblMessage.Text = "Hata btnUrnArtisAzalis metodu hata veriyor.";
                }

                lvSiparisler.SelectedItems[0].SubItems[1].Text = adet.ToString();
                decimal fiyat = Convert.ToDecimal(lvDeneme.Items[0].SubItems[0].Text);

                fiyat = fiyat * adet;

                lvSiparisler.SelectedItems[0].SubItems[3].Text = fiyat.ToString();

                lblToplamTurarDurumu();
            }
            
        }
        private void btnUrnBrmArt_Click(object sender, EventArgs e)
        {
            btnUrnArtisAzalis(1);
            buttonDesign(btnUrnBrmArt);
        }

        private void btnUrnBrmAzlt_Click(object sender, EventArgs e)
        {
            btnUrnArtisAzalis(0);
            buttonDesign(btnUrnBrmAzlt);
        }
        cGeneralDesign design = new cGeneralDesign();
        private void btn_button_leave(object sender, EventArgs e)
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

        private void btnAdisyonEkle_Click(object sender, EventArgs e)
        {
            buttonDesign(btnAdisyonEkle);
        }

        private void btnHesapYaz_Click(object sender, EventArgs e)
        {
            buttonDesign(btnHesapYaz);
        }

        private void btnAdisyonNotu_Click(object sender, EventArgs e)
        {
            buttonDesign(btnAdisyonNotu);
        }

        private void btnFaturaYaz_Click(object sender, EventArgs e)
        {
            buttonDesign(btnFaturaYaz);
        }

        private void btnMasaDegistir_Click(object sender, EventArgs e)
        {
            buttonDesign(btnMasaDegistir);
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            buttonDesign(btnMusteriSec);
        }

        private void btnUrnIkram_Click(object sender, EventArgs e)
        {
            buttonDesign(btnUrnIkram);
        }

        private void btnUrnIade_Click(object sender, EventArgs e)
        {
            buttonDesign(btnUrnIade);
        }

        private void btnUrnIptal_Click(object sender, EventArgs e)
        {
            buttonDesign(btnUrnIptal);
        }

        private void btnUrnFytDegistir_Click(object sender, EventArgs e)
        {
            buttonDesign(btnUrnFytDegistir);
        }
    }
}
