using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantt
{
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
            string clock = DateTime.Now.ToString("dd-MM-yyyy HH:mm dddd");
            this.lblClock.Text = clock;
        }



        private void btnCikis_Click(object sender, EventArgs e)
        {
            cDiger cMethod = new cDiger();
            cMethod.cikisMethod();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            cDiger rMethod = new cDiger();
            rMethod.returnMethod();
            this.Close();
        }
        cSound msc = new cSound();
        private void btnMasa1_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis(); 
            //frm sipariş formundan frm türettik.
            int uzunluk = btnMasa1.Name.Length;
            cGenel._ButtonValue = "Masa"+" "+"1";
            cGenel._ButtonName = btnMasa1.Name; // nesne idsini aldık btnMasa1 olanı aldık.btnmasa1 id olarak 7. başladı o da 1 dir.
            //yukarıda veritanındaki bilgileri bu nesnelere atamış olduk.
            this.Close();
            frm.ShowDialog();
            //Siparis kısmını açtık.

            /*
             
             Önce string tipindeki name değişkenine "Emre Yıldırım" değerini atadım. 
             Daha sonra substring() methodu ile bu stringden parçalar alalım. "name.Substring(0, 4)" kod cümlesi, 0. indexten başlayıp, 4 harf boyunca ilerle demektir.
             Yani bu kod cümlesi "Emre" değerini döndürür. "name.Substring(5)" kod cümlesi, 5. indexten başlayıp string sonuna kadar devam et demektir.
             Yani bu kod cümlesi "Yıldırım" değerini döndürür.

             */
            
        }
        /*
        clock
        */
        
        cGenel gnl = new cGenel();
        private void frmMasalar_Load(object sender, EventArgs e)
        {
            cGeneralDesign design = new cGeneralDesign();
            design.standartLoadDesign(btnCikis, btnCikis, this);

            btnMasaSayfasi.BackColor = Color.FromArgb(58, 100, 151);

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
                            fark.Hours > 0 ? string.Format("{0} Saat ", fark.Hours) :"",
                            fark.Minutes > 0 ? string.Format("{0} Dakika ", fark.Minutes) :"").Trim() + " Masa " + dr["ID"].ToString();//Masa boyutunu genişlettim şimdi görüküyor.
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

        
        private void btnMasa2_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa2.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "2";
            cGenel._ButtonName = btnMasa2.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa3.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "3";
            cGenel._ButtonName = btnMasa3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa4.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "4";
            cGenel._ButtonName = btnMasa4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa5.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "5";
            cGenel._ButtonName = btnMasa5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa6.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "6";
            cGenel._ButtonName = btnMasa6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa7.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "7";
            cGenel._ButtonName = btnMasa7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa8.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "8";
            cGenel._ButtonName = btnMasa8.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa9.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "9";
            cGenel._ButtonName = btnMasa9.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa10.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "10";
            cGenel._ButtonName = btnMasa10.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa11_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa11.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "11";
            cGenel._ButtonName = btnMasa11.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa12_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa12.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "12";
            cGenel._ButtonName = btnMasa12.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa13_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa13.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "13";
            cGenel._ButtonName = btnMasa13.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa14_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa14.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "14";
            cGenel._ButtonName = btnMasa14.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa15_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa15.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "15";
            cGenel._ButtonName = btnMasa15.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa16_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa16.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "16";
            cGenel._ButtonName = btnMasa16.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa17_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa17.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "17";
            cGenel._ButtonName = btnMasa17.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa18_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa18.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "18";
            cGenel._ButtonName = btnMasa18.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa19_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa19.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "19";
            cGenel._ButtonName = btnMasa19.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa20_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa20.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "20";
            cGenel._ButtonName = btnMasa20.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa21_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa21.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "21";
            cGenel._ButtonName = btnMasa21.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa22_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa22.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "22";
            cGenel._ButtonName = btnMasa22.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa23_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa23.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "23";
            cGenel._ButtonName = btnMasa23.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa24_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa24.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "24";
            cGenel._ButtonName = btnMasa24.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa25_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa25.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "25";
            cGenel._ButtonName = btnMasa25.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa26_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa26.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "26";
            cGenel._ButtonName = btnMasa26.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa27_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa27.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "27";
            cGenel._ButtonName = btnMasa27.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa28_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa28.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "28";
            cGenel._ButtonName = btnMasa28.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa29_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa29.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "29";
            cGenel._ButtonName = btnMasa29.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa30_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa30.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "30";
            cGenel._ButtonName = btnMasa30.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa31_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa31.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "31";
            cGenel._ButtonName = btnMasa31.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa32_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa32.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "32";
            cGenel._ButtonName = btnMasa32.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa33_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa33.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "33";
            cGenel._ButtonName = btnMasa33.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa34_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa34.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "34";
            cGenel._ButtonName = btnMasa34.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa35_Click(object sender, EventArgs e)
        {
            msc.playClickButtonSound();
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa35.Name.Length;
            cGenel._ButtonValue = "Masa" + " " + "35";
            cGenel._ButtonName = btnMasa35.Name;
            this.Close();
            frm.ShowDialog();
        }
              

        private void btnTerasSayfasi_Click(object sender, EventArgs e)
        {
            frmTeras frmTeras = new frmTeras();
            this.Close();
            frmTeras.Show();
            
        }

        private void btnBahceSayfasi_Click(object sender, EventArgs e)
        {
            frmBahce frm = new frmBahce();
            this.Close();
            frm.ShowDialog();
        }
        
    }
}
