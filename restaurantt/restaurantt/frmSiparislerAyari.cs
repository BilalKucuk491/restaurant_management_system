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
    public partial class frmSiparislerAyari : Form
    {
        public frmSiparislerAyari()
        {
            InitializeComponent();
        }
        cGenel gnl = new cGenel();
        FrmMessageBox ms = new FrmMessageBox();
        private void kayitlarilistele(string sorgu)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sorgu, con);
                SqlDataAdapter listele = new SqlDataAdapter(sorgu, con);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridViewMenu.DataSource = dshafiza.Tables[0];

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboboxKategoriId.Items.Add(dr["GOREV"]);
                }
                con.Close();
            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }
        string[] urunIsimleri = { "Çorbalar", "Ara Sıcaklar", "Ana Yemekler", "Makarnalar", "Fast Food", "Salatalar" , "Tatlılar", "İçeçekler" };
        cGeneralDesign cGeneralDesign = new cGeneralDesign();
        private void frmMenuAyari_Load(object sender, EventArgs e)
        {
            kayitlarilistele("select ID AS 'NO', KATEGORIID as 'KATEGORİ NO', URUNAD as 'ÜRÜN ADI',ACIKLAMA AS 'AÇIKLAMA',FIYAT  AS 'FİYAT' from urunler");
            cGeneralDesign.standartDataGridViewDesign(dataGridViewMenu);
            comboboxKategoriId.Items.AddRange(urunIsimleri);
        }
        FrmMessageBox FMessageBox = new FrmMessageBox();
        private void btnKayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();
                int gorev = 0;
                switch (comboboxKategoriId.Text)
                {
                    case "Çorbalar":
                        gorev = 1;
                        break;
                    case "Ara Sıcaklar":
                        gorev = 2;
                        break;
                    case "Ana Yemekler":
                        gorev = 3;
                        break;
                    case "Makarnalar":
                        gorev = 4;
                        break;
                    case "Fast Food":
                        gorev = 5;
                        break;
                    case "Salatalar":
                        gorev = 6;
                        break;
                    case "Tatlılar":
                        gorev = 7;
                        break;
                    case "İçeçekler":
                        gorev = 8;
                        break;

                }
                SqlCommand cmd = new SqlCommand("insert into urunler(KATEGORIID,URUNAD,ACIKLAMA,FIYAT) values (@kId,@urunad,@aciklama,@fiyat)", con);
                cmd.Parameters.AddWithValue("@urunad", txtUAdi.Text);
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("@fiyat", Convert.ToInt32(txtFiyat.Text));
                cmd.Parameters.AddWithValue("@kId", gorev);
                cmd.ExecuteNonQuery();
                txtUAdi.Clear();
                txtNo.Clear();
                txtFiyat.Clear();
                txtAciklama.Clear();
                txtNo.Clear();
                comboboxKategoriId.Items.Clear();
                comboboxKategoriId.Text = "";
                FMessageBox.MessageForm("Kayıt Eklendi");
                kayitlarilistele("select ID AS 'NO', KATEGORIID as 'KATEGORİ NO', URUNAD as 'ÜRÜN ADI',ACIKLAMA AS 'AÇIKLAMA',FIYAT  AS 'FİYAT' from urunler");
            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }
        
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();

                int gorev = 0;
                switch (comboboxKategoriId.Text)
                {
                    case "Çorbalar":
                        gorev = 1;
                        break;
                    case "Ara Sıcaklar":
                        gorev = 2;
                        break;
                    case "Ana Yemekler":
                        gorev = 3;
                        break;
                    case "Makarnalar":
                        gorev = 4;
                        break;
                    case "Fast Food":
                        gorev = 5;
                        break;
                    case "Salatalar":
                        gorev = 6;
                        break;
                    case "Tatlılar":
                        gorev = 7;
                        break;
                    case "İçeçekler":
                        gorev = 8;
                        break;

                }
                SqlCommand cmd = new SqlCommand("update urunler set KATEGORIID=@Kid,URUNAD=@urunAd,ACIKLAMA=@aciklama,FIYAT=@fiyat where ID=@id ", con);
                cmd.Parameters.AddWithValue("@Kid", gorev);
                cmd.Parameters.AddWithValue("@urunAd", txtUAdi.Text);
                cmd.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                cmd.Parameters.AddWithValue("@fiyat", Convert.ToInt32(txtFiyat.Text));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtNo.Text));
                cmd.ExecuteNonQuery();
                txtUAdi.Clear();
                txtNo.Clear();
                txtFiyat.Clear();
                txtAciklama.Clear();
                txtNo.Clear();
                comboboxKategoriId.Items.Clear();
                comboboxKategoriId.Text = "";
                FMessageBox.MessageForm("Kayıt Güncellendi");
                kayitlarilistele("select ID AS 'NO', KATEGORIID as 'KATEGORİ NO', URUNAD as 'ÜRÜN ADI',ACIKLAMA AS 'AÇIKLAMA',FIYAT  AS 'FİYAT' from urunler");

            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }

        private void btnKayitSil_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM urunler WHERE  ID=@id ", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtNo.Text));
                cmd.ExecuteNonQuery();
                txtUAdi.Clear();
                txtNo.Clear();
                txtFiyat.Clear();
                txtAciklama.Clear();
                txtNo.Clear();
                comboboxKategoriId.Items.Clear();
                comboboxKategoriId.Text = "";
                FMessageBox.MessageForm("Kayıt Silindi");
                kayitlarilistele("select ID AS 'NO', KATEGORIID as 'KATEGORİ NO', URUNAD as 'ÜRÜN ADI',ACIKLAMA AS 'AÇIKLAMA',FIYAT  AS 'FİYAT' from urunler");
            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }

        private void dataGridViewMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dataGridViewMenu.CurrentRow.Cells[0].Value.ToString();

            int gorev = Convert.ToInt32(dataGridViewMenu.CurrentRow.Cells[1].Value);
            switch (gorev)
            {
                case 1:
                    comboboxKategoriId.Text= "Çorbalar";
                    break;
                case 2:
                    comboboxKategoriId.Text = "Ara Sıcaklar";
                    break;
                case 3:
                    comboboxKategoriId.Text = "Ana Yemekler";
                    break;
                case 4:
                    comboboxKategoriId.Text = "Makarnalar";
                    break;
                case 5:
                    comboboxKategoriId.Text = "Fast food";
                    break;
                case 6:
                    comboboxKategoriId.Text = "Salatalar";
                    break;
                case 7:
                    comboboxKategoriId.Text = "Tatlılar";
                    break;
                case 8:
                    comboboxKategoriId.Text = "İçeçekler";
                    break;

            }
            txtUAdi.Text = dataGridViewMenu.CurrentRow.Cells[2].Value.ToString();
            txtAciklama.Text = dataGridViewMenu.CurrentRow.Cells[3].Value.ToString();
            txtFiyat.Text = dataGridViewMenu.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
