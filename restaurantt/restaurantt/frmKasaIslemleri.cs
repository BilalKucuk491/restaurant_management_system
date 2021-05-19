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
    public partial class frmKasaIslemleri : Form
    {
        public frmKasaIslemleri()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
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

        private void frmKasaIslemleri_Load(object sender, EventArgs e)
        {
            cGeneralDesign design = new cGeneralDesign();
            design.standartLoadDesign(btnGeriDon, btnCikis, this);
        }
    }
}
