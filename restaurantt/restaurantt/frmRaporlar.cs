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
    public partial class frmRaporlar : Form
    {
        public frmRaporlar()
        {
            InitializeComponent();
        }


        cGenel gnl = new cGenel();
        ExitMessageBox ms = new ExitMessageBox();
        private void kayitlarilistele(string sorgu)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();
                SqlDataAdapter listele = new SqlDataAdapter(sorgu, con);
                
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                con.Close();
            }
            catch (Exception hata)
            {
                ms.Text = "Hata :" + hata.Message;
                con.Close();
            }
        }
        
        private void btnReturn_Click(object sender, EventArgs e)
        {
            cDiger rMethod = new cDiger();
            rMethod.returnMethod();
            this.Close();
        }

        void buttonDesign(Button btn)
        {
            pnlNav.Visible = true;
            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.Left = btn.Left;
            btn.BackColor = Color.FromArgb(46, 51, 73);

        }
        cGeneralDesign design = new cGeneralDesign();
        private void frmRaporlar_Load(object sender, EventArgs e)
        {
            kayitlarilistele("select*from satislar");
            design.standartDataGridViewDesign(dataGridView1);
        }

        private void btnSatislar_Click(object sender, EventArgs e)
        {
            buttonDesign(btnSatislar);
            lblStatus.Text = "Satış Raporu";
            kayitlarilistele("frmRaporlarSatisListele"); 
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            buttonDesign(btnMusteriler);
            kayitlarilistele("frmRaporlarMusteriListele");
            lblStatus.Text = "Müşteri Raporu";
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            buttonDesign(btnUrunler);
            lblStatus.Text = "Ürün Raporu";
            kayitlarilistele("frmRaporlarUrunListele");
            
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            buttonDesign(btnRezervasyon);
            lblStatus.Text = "Rezervasyon Raporu";
            kayitlarilistele("frmRaporlarRezervasyonListele");
        }

        
        private void btn_Button_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            design.btnLeaveColor(btn);

        }
    }
}
