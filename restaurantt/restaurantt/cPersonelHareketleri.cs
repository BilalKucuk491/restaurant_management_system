using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace restaurantt
{
    class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _ID;
        private int _PersonelId;
        private string _Islem;
        private DateTime _Tarih;
        private bool _durum;
        #endregion
        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public string Islem { get => _Islem; set => _Islem = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public bool Durum { get => _durum; set => _durum = value; } 
        #endregion

        public bool PersonelActionSave (cPersonelHareketleri ph) // ph ile kalıtım yaparak başka bir değere nesne atadık onu kullanıyoruz dolaylı olarak.
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            //@ işareti dışarıdan parametre aldığımızı belirttik.
            SqlCommand cmd = new SqlCommand("Insert into personelHareketleri(PERSONELID,ISLEM,TARIH)Values(@personeId,@islem,@tarih", con);

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    //con kapalı ise kontrol edip açtık.
                    con.Open();
                }

                cmd.Parameters.Add("@personeId", System.Data.SqlDbType.Int).Value = ph._PersonelId;
                cmd.Parameters.Add("@islem", System.Data.SqlDbType.VarChar).Value = ph._Islem;
                cmd.Parameters.Add("@tarih", System.Data.SqlDbType.DateTime).Value = ph._Tarih;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                
            }

            return result;
        }
    }
}
