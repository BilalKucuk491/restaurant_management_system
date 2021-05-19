using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace restaurantt
{
    
    public partial class FrmMessageBox : MaterialSkin.Controls.MaterialForm
    {
        MaterialSkin.MaterialSkinManager skinManager;
        public FrmMessageBox()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Grey600, Primary.Grey900, Accent.LightBlue100, TextShade.WHITE);
        }

        public void MessageForm(string txt)
        {
            lblMessage.Text = txt;
                this.Show();
        }
        private void FrmMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}
