using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurantt
{
    class cDiger
    {


        cSound msc = new cSound();
        public void returnMethod()
        {
            frmMenu frm = new frmMenu();
            frm.ShowDialog();
        }
        public void cikisMethod()
        {
            ExitMessageBox frm = new ExitMessageBox();
            frm.ShowDialog();
        }

        

    }
}
