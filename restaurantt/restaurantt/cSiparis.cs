using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
// listview nesnesini kullandığımızdan dolayı bu kütüphaneyi çağırdık.(Windows.forms kütüphanesini )
namespace restaurantt
{
    class cSiparis
    {

        cGenel gnl = new cGenel();
        #region Fields
        private int _Id;
        private int _adisyonID;
        private int _urunId;
        private int _adet;
        private int _masaId;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int AdisyonID { get => _adisyonID; set => _adisyonID = value; }
        public int UrunId { get => _urunId; set => _urunId = value; }
        public int Adet { get => _adet; set => _adet = value; }
        public int MasaId { get => _masaId; set => _masaId = value; }
        #endregion


        FrmMessageBox frmMBox = new FrmMessageBox();
        //Siparişleri getir
        public void getByOrder(ListView lv,int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);//Sadece satışlarda urunId olduğu için satislar.URUNID dememize gerek yoktur
            SqlCommand cmd = new SqlCommand("Select URUNAD,FIYAT,satislar.ID,URUNID,satislar.ADET from satislar Inner Join urunler on satislar.URUNID=Urunler.ID Where satislar.ADISYONID=@AdisyonId", con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@AdisyonId", System.Data.SqlDbType.Int).Value = AdisyonId;
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
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])).Substring(0, 5));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());
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

        //Siparişleri veritabanına kaydedilmesi
        public bool setSaveOrder(cSiparis Bilgiler)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satislar(ADISYONID,URUNID,ADET,MASAID) values(@AdisyonNo,@UrunId,@Adet,@masaId)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler._adisyonID;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler._urunId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler._adet;
                cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = Bilgiler._masaId;
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

        //satisId silmemizi sağlayan method
        public void setDeleteOrder(int satisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From Satislar Where ID=@SatisID", con);
            cmd.Parameters.Add("@SatisID", SqlDbType.Int).Value = satisId;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
        //FrmSiparisKontrol için yazılan method
        public decimal genelToplamBul(int musteriId)
        {
            decimal geneltoplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select SUM(dbo.satislar.ADET * dbo.urunler.FIYAT) AS fiyat from dbo.musteriler inner join dbo.paketSiparis on dbo.musteriler.ID = paketSiparis.MUSTERIID inner join adisyonlar on adisyonlar.ID=paketSiparis.ADISYONID inner join dbo.satislar on dbo.adisyonlar.ID=dbo.satislar.ADISYONID INNER JOIN dbo.urunler on dbo.satislar.URUNID=dbo.urunler.ID where(dbo.paketSiparis.MUSTERIID =@musteriId) and (dbo.paketSiparis.Durum=1)", con);
           
            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                geneltoplam = Convert.ToDecimal(cmd.ExecuteNonQuery());
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
            return geneltoplam;
        }

        public void adisyonPaketSiparisDetaylari(ListView lv,int adisyonID)
        {
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select satislar.ID as satisID, urunler.URUNAD,urunler.FIYAT,satislar.ADET from satislar Inner join adisyonlar on adisyonlar.ID=satislar.ADISYONID inner join urunler on urunler.ID=satislar.URUNID where satislar.ADISYONID=@adisyonID", con);
            cmd.Parameters.Add("adisyonID", SqlDbType.Int).Value = adisyonID;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                int i = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["satisID"].ToString());
                    lv.Items[i].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[i].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[i].SubItems.Add(dr["FIYAT"].ToString().Substring(0, 5));
                    i++;
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
