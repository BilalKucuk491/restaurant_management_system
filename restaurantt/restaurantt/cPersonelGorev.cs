using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace restaurantt
{
    class cPersonelGorev
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _personelGorevId;
        private string _tanim;
        #endregion

        #region Properties
        public int PersonelGorevId { get => _personelGorevId; set => _personelGorevId = value; }
        public string Tanim { get => _tanim; set => _tanim = value; }
        #endregion

        FrmMessageBox frmMBox = new FrmMessageBox();
        public void PersonelGorevGetir(ComboBox cb)
        {
            cb.Items.Clear();

           
            SqlConnection con = new SqlConnection(gnl.conString);
            
            SqlCommand cmd = new SqlCommand("Select GOREV from personelGorevleri", con);

            SqlDataReader dr = null;
            
           
            try
            {
                //bağlantı durumu kapalı ise bağlantıyı açalım.
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cPersonelGorev c = new cPersonelGorev();
                    c._personelGorevId = Convert.ToInt32(dr["ID"].ToString());
                    c._tanim = dr["GOREV"].ToString();
                    cb.Items.Add(c);
                }
            }

            catch (SqlException ex)
            {
                frmMBox.lblMessage.Text = "Hata: " + ex.Message;

            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            
        }

        public void PersonelGorevTanim(int per)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Select * from personelGorevleri where ID=@perId", con);

            cmd.Parameters.Add("@perId", SqlDbType.Int).Value = per;


            try
            {
                
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = cmd.ExecuteScalar().ToString();
              
            }

            catch (SqlException ex)
            {
                frmMBox.lblMessage.Text = "Hata: " + ex.Message;

            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return;

        }


        //_tanim değişkenini override ettirdik.
        public override string ToString()
        {
            return _tanim;
        }
    }
}
