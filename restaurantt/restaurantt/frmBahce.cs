using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace restaurantt
{
    public partial class frmBahce : Form
    {
        public frmBahce()
        {
            InitializeComponent();
        }
        cSound msc = new cSound();
        cGenel gnl = new cGenel();
        private void frmBahce_Load(object sender, EventArgs e)
        {
            cGeneralDesign design = new cGeneralDesign();

            design.standartLoadDesign(btnGeriDon, btnCikis, this);

            string clock = DateTime.Now.ToString("dd-MM-yyyy HH:mm dddd");
            this.lblClock.Text = clock;
            btnBahceSayfasi.BackColor = Color.FromArgb(58,100,151);

            SqlConnection con = new SqlConnection(gnl.conString);
            //yukarıda veritabanını çağırdık.
            SqlCommand cmd = new SqlCommand("select DURUM,ID from Masalar", con);
            SqlDataReader dr = null;

            if (con.State == System.Data.ConnectionState.Closed)  //bağlantı durumu kapalı ise bağlantıyı açalım.
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();//datareader okutmasını açtık.

            while (dr.Read()) // bilgi varsa sürekli okuttuk.
            {
                foreach (Control item in this.Controls) //bu formdaki kontrolleri Controle atadık.
                {
                    if (item is Button) // Buton kontrollerini kontrol etmek için if ile item butan ise dedik
                    {

                        //dr["ID"] masa numaraları 1,2,3... durum 1 ise background değiştirdik.
                        if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.bos);
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                        {
                            cMasalar ms = new cMasalar();
                            DateTime dt1 = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString())); // yukarıdaki 2 yi buradaki 2 dir.
                            DateTime dt2 = DateTime.Now; // Şuanki zamanı aldık.

                            string st1 = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();
                            // st1 ve st2 kısaltılmış tarihlerini aldık.  


                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes); // dakikaya çeviriyoruz süreleri
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes); // aynı

                            var fark = t2 - t1;  // aradaki dakika farkını bulduk.
                            //trim boşlukları temzile
                            item.Text = String.Format("{0}{1}",
                            fark.Hours > 0 ? string.Format("{0} Saat ", fark.Hours) : "",
                            fark.Minutes > 0 ? string.Format("{0} Dakika ", fark.Minutes) : "").Trim() + " Masa " + dr["ID"].ToString();//Masa boyutunu genişlettim şimdi görüküyor.
                            //Yukarısı şimdilik yorum satırı
                            //Basit bir örnek yazmış olursak..
                            //(string.Format("2017 Ocak ayının hava sıcaklığı ortalaması gündüz {0} derece  ve gece ise {1} derecedir.", 18, 2,
                            // fark 0 dan büyükse ? (if anlamında) günü yazdık. : sonra değilse boş olsun dedik.

                            //çıktı: 2017 Ocak ayının hava sıcaklığı ortalaması gündüz 18 derece  ve gece ise 2 derecedir.
                            //[{değerimizin geleceği kısım}] süslü parantezler içerisinde belirtmiş olduğumuz kısım bizim string ifademizden sonra gelen değerlerin sırasıyla yazılacağı kısımdır.

                            /*
                             yukarıda format ile farkları atadık 1 günü 12 saat 30 dakika 5.masa
                             1 Gün
                             12 Saat
                             30 Dakika 
                             Masa5
                             */
                            // dolu rengi olarak kırmızı renk gösterilecek.
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolu);
                        }

                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            //Rezervasyon rengi yeşil olacaktır. Açık rezervasyondur.
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.acik);
                        }

                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "4")
                        {
                            //Rezervasyon dolu rengi coral olacaktır. Rezerve rezervasyondur.
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.rezerve);
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string clock = DateTime.Now.ToString("dd-MM-yyyy HH:mm dddd");
            lblClock.Text = clock;
        }

        private void btnMasa36_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa36.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "1";
            cGenel._ButtonName = btnMasa36.Name;
            this.Close();
            frm.ShowDialog();
        }

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

        private void btnTerasSayfasi_Click(object sender, EventArgs e)
        {
            frmTeras frmTeras = new frmTeras();
            this.Close();
            frmTeras.Show();
        }


        private void btnMasaSayfasi_Click(object sender, EventArgs e)
        {
            frmMasalar frm = new frmMasalar();
            this.Close();
            frm.Show();
        }

        private void btnMasa37_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa37.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "2";
            cGenel._ButtonName = btnMasa37.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa38_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa38.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "3";
            cGenel._ButtonName = btnMasa38.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa39_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa39.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "4";
            cGenel._ButtonName = btnMasa39.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa40_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa40.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "5";
            cGenel._ButtonName = btnMasa40.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa41_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa41.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "6";
            cGenel._ButtonName = btnMasa41.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa42_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa42.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "7";
            cGenel._ButtonName = btnMasa42.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa43_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa43.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "8";
            cGenel._ButtonName = btnMasa43.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa44_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa44.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "9";
            cGenel._ButtonName = btnMasa44.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa45_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa45.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "10";
            cGenel._ButtonName = btnMasa45.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa46_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa46.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "11";
            cGenel._ButtonName = btnMasa46.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa47_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa47.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "12";
            cGenel._ButtonName = btnMasa47.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa48_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa48.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "13";
            cGenel._ButtonName = btnMasa48.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa49_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa49.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "14";
            cGenel._ButtonName = btnMasa49.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa50_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa50.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "15";
            cGenel._ButtonName = btnMasa50.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa51_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa51.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "16";
            cGenel._ButtonName = btnMasa51.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa52_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa52.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "17";
            cGenel._ButtonName = btnMasa52.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa53_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa53.Name.Length;
            cGenel._ButtonValue = "Bahçe " + " " + "18";
            cGenel._ButtonName = btnMasa53.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnBahceSayfasi_Click(object sender, EventArgs e)
        {

        }
    }
}
