  using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace restaurantt
{
    class cPersoneller
    {
        
        #region Fields
        private int _PersonelGorevId;
        private int _PersonelId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;
        #endregion

        // crtl + r + e ile kısa yoldan get set yapılabilir.
        //private olan nesnelerimizi değer ataya ya da değiştirebilmek için başka bir nesneye tanımladık.



        #region Properties
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int PersonelGorevId { get => _PersonelGorevId; set => _PersonelGorevId = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; }
        #endregion

        cGenel gnl = new cGenel();
        FrmMessageBox frmMBox = new FrmMessageBox();

        public bool personelEntryControl(string password,int UserId) 
        {
            bool result = false;                 //gnl.conString
            SqlConnection con = new SqlConnection(gnl.conString);
            //PAROLA tablo ismi olandır ID için de geçerlidir.
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@Id and PAROLA=@password", con);
            cmd.Parameters.Add("@Id", System.Data.SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = password;
            try
            {
                //bağlantı durumu kapalı ise bağlantıyı açalım.
                if (con.State==System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;

            }

            return result;
        }
        public void personelGetInformation(ComboBox cb)
        {
            cb.Items.Clear();

            
                bool result = false;
                SqlConnection con = new SqlConnection(gnl.conString);
                //PAROLA tablo ismi olandır ID için de geçerlidir.
                SqlCommand cmd = new SqlCommand("Select * from Personeller", con);

               //bağlantı durumu kapalı ise bağlantıyı açalım.
               if (con.State == System.Data.ConnectionState.Closed)
               {
                  con.Open();
               }

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cPersoneller p = new cPersoneller();
                    p._PersonelId = Convert.ToInt32(dr["ID"]);
                    p._PersonelGorevId = Convert.ToInt32(dr["GOREVID"]);
                    p._PersonelAd = Convert.ToString(dr["AD"]);
                    p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                    p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                    p._PersonelDurum = Convert.ToBoolean(dr["DURUM"]);
                    cb.Items.Add(p);
                    //GOREVID Tablo ismidir.
                }
                dr.Close();
                con.Close();
                //bağlantıyı kapatmamızdaki sebep sürekli while döngüsünde aynı işi yaptığından rami zorlar.
             
        }
        public override string ToString()
        {
            return PersonelAd +" "+PersonelSoyad;
        }

        public void personelBilgileriniGetirLV(ListView lv)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            
            SqlCommand cmd = new SqlCommand("Select personeller.*, personelGorevleri.GOREV from personeller innner join personelGorevleri  on personelGorevleri.ID=personeller.GOREVID where personeller.DURUM = 0", con);

            
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;

            
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }
            dr.Close();
            con.Close();
            

        }
        public void personelBilgileriniGetirFromIdLv(ListView lv , int perId)
        {

            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Select personeller.*, personelGorevleri.GOREV from personeller innner join personelGorevleri  on personelGorevleri.ID=personeller.GOREVID where personeller.DURUM = 0 and Personeller.ID=@perId", con);
            cmd.Parameters.Add("@perId", SqlDbType.Int).Value = perId;

            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;


            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }
            dr.Close();
            con.Close();


        }
        public string personelBilgiGetirIsim(int perId)
        {
            string adsoyad = "";
            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Select AD ,SOYAD from personeller where personeller.DURUM = 0 and Personeller.ID=@perId", con);
            cmd.Parameters.Add("@perId", SqlDbType.Int).Value = perId;
            

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   
                    adsoyad = dr["AD"].ToString() + ' ' + dr["SOYAD"].ToString(); 
                }
            }
            catch (SqlException ex)
            {

                frmMBox.lblMessage.Text = "Hata: " + ex.Message;
            }
            con.Close();
            con.Dispose();
            return adsoyad;
        }

        public bool personelSifreDegistir(int personelID,string password)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Update personeller set PAROLA=@password where ID=@personelID", con);
            cmd.Parameters.Add("@personelID", SqlDbType.Int).Value = personelID;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                frmMBox.lblMessage.Text = "Hata: " + ex.Message;
            }
            con.Close();

            return sonuc;
        }
        public bool personelEkle(cPersoneller cp)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Insert into Personeller(AD,SOYAD,PAROLA,GOREVID) value (@AD,@SOYAD,@PAROLA,@GOREVID) ", con);
            cmd.Parameters.Add("@AD", SqlDbType.VarChar).Value = cp._PersonelAd;
            cmd.Parameters.Add("@SOYAD", SqlDbType.VarChar).Value = cp._PersonelSoyad;  
            cmd.Parameters.Add("@PAROLA", SqlDbType.VarChar).Value = cp._PersonelParola;
            cmd.Parameters.Add("@GOREVID", SqlDbType.Int).Value = cp._PersonelGorevId;
            sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                frmMBox.lblMessage.Text = "Hata: " + ex.Message;
            }
            con.Close();

            return sonuc;
        }
        public bool personelGuncelle(cPersoneller cp, int perID)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Update Personeller set AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA,GOREVID=@GOREVID where ID=@perID", con);
            cmd.Parameters.Add("@AD", SqlDbType.VarChar).Value = cp._PersonelAd;
            cmd.Parameters.Add("@SOYAD", SqlDbType.VarChar).Value = cp._PersonelSoyad;
            cmd.Parameters.Add("@PAROLA", SqlDbType.VarChar).Value = cp._PersonelParola;
            cmd.Parameters.Add("@GOREVID", SqlDbType.Int).Value = cp._PersonelGorevId;
            cmd.Parameters.Add("@perID", SqlDbType.Int).Value = perID;
            sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                frmMBox.lblMessage.Text = "Hata: " + ex.Message;
            }
            con.Close();

            return sonuc;
        }
        public bool personelSil(int perID)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);

            SqlCommand cmd = new SqlCommand("Update Personeller set DURUM=1 where ID=@perID", con);
            cmd.Parameters.Add("@perID", SqlDbType.Int).Value = perID;
            sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {

                frmMBox.lblMessage.Text = "Hata: " + ex.Message;
            }
            con.Close();

            return sonuc;
        }




    }

}
