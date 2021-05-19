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
    public partial class keyboard : Form
    {

        protected override CreateParams CreateParams {
            get
            {
                CreateParams param = base.CreateParams;
                    param.ExStyle |= 0x08000000;
                return param;
            }
        }
        public keyboard()
        {
            InitializeComponent();

            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SendKeys.Send("w");
        }

        private void keyboard_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SendKeys.Send("Q");
            }
            else
            {
                SendKeys.Send("q");
            }
        }
    }
}
