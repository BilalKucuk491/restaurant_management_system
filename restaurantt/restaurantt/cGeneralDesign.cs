using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace restaurantt
{
    class cGeneralDesign
    {
        public void standartLoadDesign(Button btn1, Button btn2, Form frm)
        {

            btn1.BackColor = Color.FromArgb(35, 32, 39);
            btn1.ForeColor = Color.FromArgb(228, 227, 232);
            btn2.BackColor = Color.FromArgb(35, 32, 39);
            btn2.ForeColor = Color.FromArgb(228, 227, 232);
            frm.BackColor = Color.FromArgb(46, 51, 73);
            frm.WindowState = FormWindowState.Maximized;

        }

        public void standartListviewDesign(ListView lst1, ListView lst2)
        {
            lst1.BackColor = Color.FromArgb(59, 63, 74);
            lst1.ForeColor = Color.FromArgb(228, 227, 232);
            lst2.BackColor = Color.FromArgb(59, 63, 74);
            lst2.ForeColor = Color.FromArgb(228, 227, 232);

        }

        public void standartListviewDesign1(ListView lst)
        {
            lst.BackColor = Color.FromArgb(59, 63, 74);
            lst.ForeColor = Color.FromArgb(228, 227, 232);
        }

        public void standartDataGridViewDesign(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(66, 64, 90);
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void btnLeaveColor(Button btn)
        {
            btn.BackColor = Color.FromArgb(24, 30, 54);
        }

    }

    
}
