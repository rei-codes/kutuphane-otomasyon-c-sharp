using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{   
    public class DbDelete
    {   
        DbSelect dbSelect = new DbSelect();
        
        OleDbConnection conn;
        OleDbCommand cmd;
        
        public DbDelete()
        {  
            conn = new OleDbConnection(ConnectionString.GetConnectionString());
        }
        
        public void DeleteKitap(int Kitap_Id)
        {   
            string sql = "delete from KITAPLAR where Id=" + Kitap_Id + "";
            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        public void DeleteOgrenci(int Ogrenci_Id)
        {
            string sql = "delete from OGRENCILER where Id=" + Ogrenci_Id + "";

            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteOgrKitap(int Ogrenci_Id)
        {
            string sql = "delete from OGRKITAP where Ogrenci_Id=" + Ogrenci_Id + "";

            cmd = new OleDbCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
