using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurantt
{

    class cMasalar
    {
        #region Fields
        private int _ID;
        private int _KAPASITE;
        private int _SERVISTURU;
        private int _DURUM;
        private int _ONAY;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int KAPASITE { get => _KAPASITE; set => _KAPASITE = value; }
        public int SERVISTURU { get => _SERVISTURU; set => _SERVISTURU = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int ONAY { get => _ONAY; set => _ONAY = value; }
        #endregion

        cGenel gnl = new cGenel();

        public string SessionSum(int state,string masaId)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            //Adisyon tablosundan masaId ve Tarihi çektik. Masalar ve Adisyon tablosunu ilişki kurduk join ile. MasaId ile MasalarId birbirine bağladık.
            SqlCommand cmd = new SqlCommand("Select TARIH,MasaId From adisyonlar Right Join Masalar on adisyonlar.MasaId=Masalar.ID Where Masalar.DURUM=@durum and adisyonlar.Durum=0 and masalar.ID=@masaId", con);
            SqlDataReader dr = null;
            //SessionSum methoduna state değeri giriyoruz. state değerini @duruma atıyoruz onuda Duruma atıyoruz.
            cmd.Parameters.Add("@durum",SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = Convert.ToInt32(masaId);// Masanın idsını gönderme sebebimiz durumunu birlikte belirtmiş oluyoruz.

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //Tarihi string değere çevirip dtye atadık.
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                //Bütün bağlantıları kapattık ram şişmesin diye.
                dr.Close();
                con.Dispose();
                con.Close();
            }

            return dt; // methodu döndürdük.
        }


        // Masalardaki masa isimlerini almamızı sağlayan ve onları int türünden almış oluruz.
        public int tableGetbyNumber(string TableValue)
        {
            string aa = TableValue;
            int lenght = aa.Length;
            // int türünde veri tipi olduğu için döndürdük. Substring ile son karekterten 1 eksiğini ve 1. karekteri al Masa 1 sonarsı 1 al dedik
            if (lenght > 8)
            {
                return Convert.ToInt32(aa.Substring(lenght-2,2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(lenght - 1, 1));
            }
            
        }


        //Masa durumunu öğrenmek için yazılan method. True ya da False değer dönecektir.
        public bool TableGetbyState(int ButtonName,int state)
        {
            //ButtonName masa numarası , state ise durumudur.
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select durum From Masalar Where Id=@TableId and DURUM=@state", con);

            cmd.Parameters.Add("@tableId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // türünü True False çevirdik.
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return result;
        }

        //Tablo durumunu değiştirmemizi sağlayan durum.
        public void setChangeTableState(string ButtonName,int state)
        {
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update masalar Set DURUM=@Durum where ID=@MasaNo ", con);
            string masaNo = "";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            if (true)
            {

            }
            string aa = ButtonName;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;//masa durmunu 1 ise 2 haline getirmemizi sağlar.
            if (uzunluk > 8)
            {
                masaNo = aa.Substring(uzunluk - 2, 2);
            }
            else
            {
                masaNo = aa.Substring(uzunluk - 1, 1);
            }
            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = Convert.ToInt32(masaNo);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();

        }
    }
}
