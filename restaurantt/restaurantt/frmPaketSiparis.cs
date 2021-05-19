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
    public partial class frmPaketSiparis : Form
    {
        public frmPaketSiparis()
        {
            InitializeComponent();
        }

        private void frmPaketSiparis_Load(object sender, EventArgs e)
        {
            cGeneralDesign design = new cGeneralDesign();
            design.standartLoadDesign(btnCikis, btnCikis, this);
        }
    }
}
