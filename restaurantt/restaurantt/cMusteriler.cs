using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace restaurantt
{
    class cMusteriler
    {
        cGenel gnl = new cGenel();
        private int _musteriid;
        private string _musteirad;
        private string _musterisoyad;
        private string _telefon;
        private string _adres;
        private string _email;

        #region Properties
        public int Musteriid { get => _musteriid; set => _musteriid = value; }
        public string Musteirad { get => _musteirad; set => _musteirad = value; }
        public string Musterisoyad { get => _musterisoyad; set => _musterisoyad = value; }
        public string Telefon { get => _telefon; set => _telefon = value; }
        public string Adres { get => _adres; set => _adres = value; }
        public string Email { get => _email; set => _email = value; }
        #endregion
        FrmMessageBox FrmMBox = new FrmMessageBox();
        public bool musteriVarmi(string tlf)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "MusteriVarmi";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();
                sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);
            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }
            finally
            {
                con.Close();
            }
            return sonuc;
        }

        public int musteriEkle(cMusteriler m)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into musteriler(AD,SOYAD,TELEFON,ADRES,EMAIL) values(@ad,@soyad,@telefon,@adres,@email); select SCOPE_IDENTITY() ", con);
            //sCOPE_IDENTITY fonksiyonu id numarasını almamızı sağlar.
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = m._musteirad;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = m._email;
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }

        public bool musteriBilgileriGuncelle(cMusteriler m)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update musteriler set AD=@ad,SOYAD=@soyad,TELEFON=@telefon,ADRES=@adres,EMAIL=@email where ID=@musteriId ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ad", SqlDbType.VarChar).Value = m._musteirad;
                cmd.Parameters.Add("@soyad", SqlDbType.VarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("@adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = m._email;
                cmd.Parameters.Add("@musteriId", SqlDbType.VarChar).Value = m._musteriid;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }

            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }

        public void musterileriGetir(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler", con);

            SqlDataReader dr = null;


            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    sayac++;
                }

            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        //Müşterileri id numaralarına göre getirme
        public void musterilerigetirID(int musteriId, TextBox ad, TextBox soyad, TextBox tlf, TextBox adres, TextBox email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where ID=@musteriID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@musteriID", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ad.Text = dr["AD"].ToString();
                    soyad.Text = dr["SOYAD"].ToString();
                    tlf.Text = dr["TELEFON"].ToString();
                    adres.Text = dr["ADRES"].ToString();
                    email.Text = dr["EMAIL"].ToString();
                }

            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

        }

        public void musteriGetirAd(ListView lv, string musteriAd)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where AD like @musteriAd + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@musteriAd", SqlDbType.VarChar).Value = musteriAd;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    sayac++;
                }

            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }

        public void musteriGetirSoyad(ListView lv, string musteriSoyad)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where SOYAD like @musteriSoyad + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@musteriSoyad", SqlDbType.VarChar).Value = musteriSoyad;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    sayac++;
                }

            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }



        }


        public void musteriGetirTlf(ListView lv, string telefon)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from musteriler where TELEFON like @telefon + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = telefon;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    sayac++;
                }

            }
            catch (SqlException ex)
            {
                FrmMBox.lblMessage.Text = "Hata ; " + ex.Message;
                FrmMBox.ShowDialog();
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }



        }
    }

}
