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
    class cUrunCesitleri
    {
        cGenel gnl = new cGenel();

        private int _UrunTurNo;
        private int _KategoriAd;
        private int _Aciklama;

        #region Properties
        public int UrunTurNo { get => _UrunTurNo; set => _UrunTurNo = value; }
        public int KategoriAd { get => _KategoriAd; set => _KategoriAd = value; }
        public int Aciklama { get => _Aciklama; set => _Aciklama = value; }
        #endregion
        //Methodun ilk inputuna listview nesnesi olan cesitler, ikincisi ise olusturulan sana btn butonudur.
        public void getByProductTypes(ListView Cesitler,Button btn)
        {
            //Listview'i temizledik.
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select URUNAD,FIYAT,urunler.ID From kategoriler Inner Join urunler on kategoriler.ID = urunler.KATEGORIID where urunler.KATEGORIID=@KATEGORIID", conn);

            string aa = btn.Name;
            int uzunluk = aa.Length;
            string fiyat = "";
           
            comm.Parameters.Add("@KATEGORIID", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            //Bağlantı bilgilerini okuduk.
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                //Listview 'e eklenecek tablolar
                Cesitler.Items.Add(dr["URUNAD"].ToString());

                fiyat = dr["FIYAT"].ToString().Substring(0, 5);
                Cesitler.Items[i].SubItems.Add(fiyat);
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }

        public void getByProductSearch(ListView Cesitler, int txt)//ürünlerin arama methodu
        {
            //Listview'i temizledik.
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select * from urunler where ID=@ID", conn);

          
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = txt;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //Bağlantı bilgilerini okuduk.
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                //Listview 'e eklenecek tablolar
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString().Substring(0, 5));
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }
    } 
}
