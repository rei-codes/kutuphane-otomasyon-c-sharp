using Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{ 
    public class DbUpdate
    {   
        DbSelect dbSelect = new DbSelect();

        OleDbConnection conn;
        OleDbCommand cmd;

        public DbUpdate()
        {
            conn = new OleDbConnection(ConnectionString.GetConnectionString());
        }
       
        public bool KitapRaftaMiGuncelle(int Kitap_Id, int RaftaMi)
        {
            string sql = "update KITAPLAR set RaftaMi='" + RaftaMi + "' where Id=" + Kitap_Id + "";
            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();

            if (sonuc > 0)
                return true;
            else
                return false;
        }
        
        public bool TeslimBilgisiGuncelle(int Kitap_Id, int Ogrenci_Id, DateTime Teslim_Tarihi)
        {
            string sql = "update OGRKITAP set TeslimEttiMi = 1, Teslim_Tarihi= '" + Teslim_Tarihi +
                "' where Kitap_Id=" + Kitap_Id + ", Ogrenci_Id=" + Ogrenci_Id + "";

            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();

            if (sonuc > 0)
                return true;
            else
                return false;
        }
        public List<string> KitapGuncelle(Kitaplar kitap)
        {
            List<string> result = new List<string>();
            try
            {
                if (dbSelect.BarkodNoVarMi(Int32.Parse(kitap.BarkodNo), kitap.Id))
                {
                    result.Add("Aynı Barkod Numarası Mevcut");
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Add("Barkod Numarası Sayı olmak zorunda MI " + ex);
                return result;
            }

            string sql = "update KITAPLAR set BarkodNo='" + kitap.BarkodNo + "' , KitapAdi='" + 
                kitap.KitapAdi + "' , KitapYazari='" + kitap.KitapYazari + "' , Tur_Id='" + kitap.Tur_Id +
                "' , YayinEvi='" + kitap.YayinEvi + "' , SayfaSayisi='" + kitap.SayfaSayisi + "' , Dil_Id='" 
                + kitap.Dil_Id + "' , BasimYili='" + kitap.BasimYili + "' , RaftaMi='" + kitap.RaftaMi +
                "' where Id=" + kitap.Id + "";

            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();

            if (sonuc > 0)
                return result;
            else
            {
                result.Add("Bir hata oldu");
                return result;
            }
        }
        public List<string> OgrenciGuncelle(Ogrenciler ogrenci)
        {
            List<string> result = new List<string>();

            string sql = "update OGRENCILER set TcNo='" + ogrenci.TcNo +
                "' , Ad='" + ogrenci.Ad + "' , Soyad='" + ogrenci.Soyad + "' , Mail='" +
                ogrenci.Mail + "' , TelNo='" + ogrenci.TelNo + "' where Id=" + ogrenci.Id + "";

            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            int sonuc = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
       
    }
}
