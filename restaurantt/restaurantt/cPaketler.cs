using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace restaurantt
{
    class cPaketler
    {
        #region MyRegion
        private int _ID;
        private int _AdditionID;
        private int _ClientId;
        private string _Description;
        private int _State;
        private int __Paytypeid;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int AdditionID { get => _AdditionID; set => _AdditionID = value; }
        public int ClientId { get => _ClientId; set => _ClientId = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int State { get => _State; set => _State = value; }
        public int Paytypeid { get => __Paytypeid; set => __Paytypeid = value; }
        #endregion
        cGenel gnl = new cGenel();

        
        public bool OrderServiceOpen(cPaketler order)//Paket servisİ ekleme methodu
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into paketSiparis(ADISYONID,MUSTERIID,ODEMETURUID,ACIKLAMA) values(@ADISYONID,@MUSTERIID,@ODEMETURUID,@ACIKLAMA)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = order._AdditionID;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = order._ClientId;
                cmd.Parameters.Add("@ODEMETURUID", SqlDbType.Int).Value = order.__Paytypeid;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = order._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }

        public void OrderServiceClose(int AddtionID)//Kasaya para geldiğinde kapatma methodu.
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            //SqlCommand cmd = new SqlCommand("Update paketSiparis set paketSiparis.durum=1 from paketSiparis Inner Join adisyonlar on paketSiparis.ADISYONID=adisyonlar.ID where paketSiparis.ADISYONID=@AddtionID", con);
            SqlCommand cmd = new SqlCommand("Update paketSiparis set paketSiparis.durum=1 where paketSiparis.ADISYONID=@AddtionID", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AddtionID", SqlDbType.Int).Value = AddtionID;
                Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }

        public int OdemeTurIdGetir(int AdisyonId)//Açılan Adisyon ve paket sipariş ait ön girilen ödeme tur id
        {
            int odemeTurID = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparis.ODEMETURID from paketSiparis Inner Join Adisyonlar on paketSiparis.ADISYONID=Adisyonlar.ID where adisyonlar.ID=@AdisyonID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@AdisyonID", SqlDbType.Int).Value = AdisyonId;
                odemeTurID = Convert.ToInt32(cmd.ExecuteScalar());//tek işlemlerde ExecuteNonQuery yerine kullanılabilir.
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return odemeTurID;
        }

        //Sipariş kontrol için müşteriye ait açık olan en son adisyon nosunu getirme.
        //Bir müşteriye ait 2 tane siparişin açık olamayacağını belirtiyoruz.
        public int musteriSonAdisyonIDGetir(int MusteriID)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select adisyonlar.ID from adisyonlar Inner Join paketSiparis on paketSiparis.ADISYONID=Adisyonlar.ID where (adisyonlar.DURUM=0) and (paketSiparis.DURUM=0) and paketSiparis.MUSTERIID=@MusteriID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@MusteriID", SqlDbType.Int).Value = MusteriID;
                no = Convert.ToInt32(cmd.ExecuteScalar());//tek işlemlerde ExecuteNonQuery yerine kullanılabilir.
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }



            return no;
        }


        //Müşteri arama ekranında adisyonbul butonu için yapılmıştır. Yani adisyon açık mı değil mi kontrol eden methodttur.
        public bool getCheckOpenAdditionID(int additionID)//Paket servisİ ekleme methodu
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from adisyonlar where (DURUM=0) and (ID=@additionID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@additionID", SqlDbType.Int).Value = additionID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }
    }
}
