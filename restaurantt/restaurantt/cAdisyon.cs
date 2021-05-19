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
    class cAdisyon
    {
        cGenel gnl = new cGenel();

        #region Fields
        private int _ID;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _PersonelId;
        private int _Durum;
        private int _MasaId;
        #endregion
        //Crtk + r + e ile kalıtım yapabiliriz.
        //snippet => surrond with ile de bölge oluşturabiliriz.
        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int ServisTurNo { get => _ServisTurNo; set => _ServisTurNo = value; }
        public decimal Tutar { get => _Tutar; set => _Tutar = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int Durum { get => _Durum; set => _Durum = value; }
        public int MasaId { get => _MasaId; set => _MasaId = value; } 
        #endregion

        FrmMessageBox frmMBox = new FrmMessageBox();

        //Adisyon bilgisi getirmemizi sağlayan method
        public int getByAddition(int MasaId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From adisyonlar Where MASAID=@MasaId Order by ID desc", con);
            cmd.Parameters.Add("@MasaId", System.Data.SqlDbType.Int).Value = MasaId;
            // yukarıda Adisyonlara git MasaId'i gönderilen masa idsine eşit olanı getir . Bunu tersten sırala ve sadece 1 kayıt getir.
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MasaId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                frmMBox.lblMessage.Text = "Hata: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return MasaId;//Açık masa id'sini döndürdük.
        }
        public bool setByAddition(cAdisyon Bilgiler)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyonlar(SERVISTURNO,TARIH,PERSONELID,MASAID,DURUM) values(@ServisTurNo,@Tarih,@PersonelID,@MasaId,@Durum)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = Bilgiler.ServisTurNo;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = Bilgiler.PersonelId;
                
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@Durum", SqlDbType.Bit).Value = 0;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            return sonuc;
        }

        public void adisyonKapat(int adisyonID,int durum)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update adisyonlar set durum = @durum where ID=@adisyonId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonID;
                cmd.Parameters.Add("@durum", SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();
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
        }

        public int paketAdisyonIdBulAdedi()
        {
            int miktar = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) as Sayi from adisyonlar where (Durum=0) AND (SERVISTURNO=2) ", con);
            cmd.Parameters.Add("@MasaId", System.Data.SqlDbType.Int).Value = MasaId;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                miktar =Convert.ToInt32(cmd.ExecuteScalar()); 
            }
            catch (SqlException ex )
            {
                frmMBox.lblMessage.Text = "Hata: " + ex.Message;
            }
            return miktar;
        }

        public void acikPaketAdisyonlar(ListView lv )
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparis.MUSTERIID,Musteriler.Ad + ' ' + Musteriler.Soyad as Musteri, Adisyonlar.ID as adisyonID from paketSiparis Inner Join Musteriler on musteriler.ID=paketSiparis.MUSTERIID Inner join adisyonlar on adisyonlar.ID=paketSiparis.ADISYONID where Adisyonlar.Durum=1", con);
            //cmd.Parameters.Add("@MasaId", System.Data.SqlDbType.Int).Value = MasaId;

            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["Musteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adisyonID"].ToString());
                    sayac++;
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

        public int musterinSonAdisyonId(int musteriId)
        {
            int result = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select Adisyonlar.ID from adisyonlar Inner join paketSiparis on paketSiparis.ADISYONID=Adisyonlar.ID where paketSiparis.DURUM=1 and Adisyonlar.DURUM=1 and paketSiparis.MUSTERIID=@musteriId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
                
                
                result = Convert.ToInt32(cmd.ExecuteScalar());
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



            return result;
        }


        public void musteriDetaylar(ListView lv ,int musteriId)
        {
            lv.Items.Clear();
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select paketSiparis.MUSTERIID,paketSiparis.ADISYONID,musteriler.AD,musteriler.SOYAD,CONVERT(varchar(10),adisyonlar.TARIH,104) as TARIH from adisyonlar Inner join paketSiparis on paketSiparis.ADISYONID=adisyonlar.ID Inner join musteriler on musteriler.ID=paketSiparis.MUSTERIID where adisyonlar.SERVISTURNO=2 and adisyonlar.Durum=1 and paketSiparis.MUSTERIID=@musteriId", con);
            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;

            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    sayac++;
                }
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
        }
    }
}
