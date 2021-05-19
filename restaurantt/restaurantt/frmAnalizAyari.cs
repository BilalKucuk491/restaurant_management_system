using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace restaurantt
{
    public partial class frmAnalizAyari : Form
    {
        public frmAnalizAyari()
        {
            InitializeComponent();
        }
        cGenel gnl = new cGenel();
        private void kayitlarilistele(string sorgu)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            try
            {
                con.Open();
                SqlDataAdapter listele = new SqlDataAdapter(sorgu, con);

                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridViewAnaliz.DataSource = dshafiza.Tables[0];
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show ("Hata :" + hata.Message);
                con.Close();
            }
        }
        private void frmAnalizAyari_Load(object sender, EventArgs e)
        {
            
            kayitlarilistele("frmRaporlarSatisListele");
            cGeneralDesign cGeneralDesign = new cGeneralDesign();
            cGeneralDesign.standartDataGridViewDesign(dataGridViewAnaliz);
        }
    }
}
