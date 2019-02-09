using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Entities;

namespace DataAccessLayer
{   
    public class DbInsert
    {   
        OleDbConnection conn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataTable dt;

        public DbInsert()
        { 
            conn = new OleDbConnection(ConnectionString.GetConnectionString());
        }
       
        public bool KitapEkle(int barkodNo, string kitapAdi, string kitapYazari, int tur_Id, string yayinEvi, 
            int sayfaSayisi, int dil_Id, int basimYili)
        {  
            cmd = new OleDbCommand("insert into KITAPLAR(BarkodNo,KitapAdi,KitapYazari,Tur_Id,YayinEvi," +
                "SayfaSayisi,Dil_Id,BasimYili,RaftaMi) values(" + barkodNo + ",'" + kitapAdi + "','" + 
                kitapYazari + "'," + tur_Id + ",'" + yayinEvi + "'," + sayfaSayisi + "," + dil_Id + "," + 
                basimYili + ",'1')", conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();
           
            if (sonuc > 0)
                return true;
            else
                return false;

        }

      
        public bool OgrenciEkle(Ogrenciler ogrenci)
        { 
            cmd = new OleDbCommand("insert into OGRENCILER(TcNo,Ad,Soyad,Mail,TelNo) values('" + 
                ogrenci.TcNo + "' , '" + ogrenci.Ad + "' , '" + ogrenci.Soyad + "' , '" + ogrenci.Mail + 
                "', '" + ogrenci.TelNo + "') ", conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();

            if (sonuc > 0)
                return true;
            else
                return false;
        }

        public bool OgrKitapEkle(int Kitap_Id, int Ogrenci_Id)
        {
            DateTime verilistTarihi = DateTime.Now;
            string sql = "insert into OGRKITAP(Kitap_Id,Ogrenci_Id,VerilisTarihi,TeslimEttiMi) " +
                "values('" + Kitap_Id + "' , '" + Ogrenci_Id + "' , '" + verilistTarihi + "', '0')";
            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();

            if (sonuc > 0)
                return true;
            else
                return false;
        }
        public bool BorcOdemeEkle(BorcOdeme borc)
        {
            string sql = "insert into BORCODEME(Tarih,Miktar,Ogrenci_Id,OgrKitap_Id) " +
                "values('" + borc.Tarih + "' , '" + borc.Miktar + "' , '" + borc.Ogrenci_Id + 
                "' , '"+borc.OgrKitap_Id+"' )";
            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();

            if (sonuc > 0)
                return true;
            return false;
        }
    }
}
