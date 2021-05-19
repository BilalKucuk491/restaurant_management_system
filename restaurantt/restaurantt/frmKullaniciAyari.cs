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
    public partial class frmKullaniciAyari : Form
    {
        public frmKullaniciAyari()
        {
            InitializeComponent();
        }
        FrmMessageBox FrmMessageBox = new FrmMessageBox();
        cGenel gnl = new cGenel();
        ExitMessageBox ms = new ExitMessageBox();
        private void kayitlarilistele(string sorgu)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from personelGorevleri", con);
                SqlDataAdapter listele = new SqlDataAdapter(sorgu, con);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridViewKullanici.DataSource = dshafiza.Tables[0];

                SqlDataReader dr;
                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbxGorev.Items.Add(dr["GOREV"]);
                }
                con.Close();
            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }

        private void frmKullaniciAyari_Load(object sender, EventArgs e)
        {   
            kayitlarilistele("SELECT p.ID as 'NO',p.AD, p.SOYAD,p.PAROLA,p.KULLANICIADI as'KULLANICI ADI', d.GOREV FROM personeller p INNER JOIN personelGorevleri d ON p.GOREVID=d.ID");
            cGeneralDesign cGeneralDesign = new cGeneralDesign();
            cGeneralDesign.standartDataGridViewDesign(dataGridViewKullanici);
        }

        FrmMessageBox FMessageBox = new FrmMessageBox();
        private void btnKayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();

                int gorev = 0;
                switch (cbxGorev.Text)
                {
                    case "Komi":
                        gorev = 1;
                    break;
                    case "Bulaşıkçı":
                        gorev = 2;
                        break;
                    case "Şef":
                        gorev = 3;
                        break;
                    case "Garson":
                        gorev = 4;
                        break;

                }
                SqlCommand cmd = new SqlCommand("insert into personeller(AD,SOYAD,PAROLA,KULLANICIADI, GOREVID) values (@ad,@soyad,@parola,@kullaniciadi,@gid)", con);
                cmd.Parameters.AddWithValue("@ad", txtKAdi.Text);
                cmd.Parameters.AddWithValue("@soyad", txtKSoyadi.Text);
                if (txtParola.Text==txtParolaTekrar.Text)
                {
                    cmd.Parameters.AddWithValue("@parola", txtParola.Text);
                }
                cmd.Parameters.AddWithValue("@kullaniciadi", txtKAdi.Text+txtKSoyadi.Text);
                cmd.Parameters.AddWithValue("@gid", Convert.ToString(gorev));
                cmd.ExecuteNonQuery();
                txtKAdi.Clear();
                txtKSoyadi.Clear();
                txtParola.Clear();
                txtParolaTekrar.Clear();
                txtNo.Clear();
                cbxGorev.Items.Clear();
                FMessageBox.MessageForm("Kayıt Eklendi");
                kayitlarilistele("SELECT p.ID as 'NO',p.AD, p.SOYAD,p.PAROLA,p.KULLANICIADI as'KULLANICI ADI', d.GOREV FROM personeller p INNER JOIN personelGorevleri d ON p.GOREVID=d.ID");
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
                switch (cbxGorev.Text)
                {
                    case "Komi":
                        gorev = 1;
                        break;
                    case "Bulaşıkçı":
                        gorev = 2;
                        break;
                    case "Şef":
                        gorev = 3;
                        break;
                    case "Garson":
                        gorev = 4;
                        break;

                }
                SqlCommand cmd = new SqlCommand("update personeller set AD=@ad,SOYAD=@soyad,PAROLA=@parola,KULLANICIADI =@kullaniciadi,GOREVID=@gid where ID=@id ", con);
                cmd.Parameters.AddWithValue("@ad", txtKAdi.Text);
                cmd.Parameters.AddWithValue("@soyad", txtKSoyadi.Text);
                if (txtParola.Text==txtParolaTekrar.Text)
                {
                    cmd.Parameters.AddWithValue("@parola", txtParola.Text);
                }
                cmd.Parameters.AddWithValue("@kullaniciadi", txtKAdi.Text +' '+ txtKSoyadi.Text);
                cmd.Parameters.AddWithValue("@gid", Convert.ToString(gorev));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtNo.Text));
                cmd.ExecuteNonQuery();
                txtKAdi.Clear();
                txtKSoyadi.Clear();
                txtParola.Clear();
                txtParolaTekrar.Clear();
                txtNo.Clear();
                cbxGorev.Items.Clear();
                FMessageBox.MessageForm("Kayıt Güncellendi");
                kayitlarilistele("SELECT p.ID as 'NO',p.AD, p.SOYAD,p.PAROLA,p.KULLANICIADI as'KULLANICI ADI', d.GOREV FROM personeller p INNER JOIN personelGorevleri d ON p.GOREVID=d.ID");
            
            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }

        private void dataGridViewKullanici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text= dataGridViewKullanici.CurrentRow.Cells[0].Value.ToString();
            txtKAdi.Text= dataGridViewKullanici.CurrentRow.Cells[1].Value.ToString();
            txtKSoyadi.Text= dataGridViewKullanici.CurrentRow.Cells[2].Value.ToString();
            txtParola.Text = dataGridViewKullanici.CurrentRow.Cells[3].Value.ToString();
            cbxGorev.Text= dataGridViewKullanici.CurrentRow.Cells[5].Value.ToString();


        }

        private void btnKayitSil_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM personeller WHERE  ID=@id ", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtNo.Text));
                cmd.ExecuteNonQuery();
                txtKAdi.Clear();
                txtKSoyadi.Clear();
                txtParola.Clear();
                txtParolaTekrar.Clear();
                txtNo.Clear();
                cbxGorev.Items.Clear();
                FMessageBox.MessageForm("Kayıt Silindi");
                kayitlarilistele("SELECT p.ID as 'NO',p.AD, p.SOYAD,p.PAROLA,p.KULLANICIADI as'KULLANICI ADI', d.GOREV FROM personeller p INNER JOIN personelGorevleri d ON p.GOREVID=d.ID");
            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }
    }
}
