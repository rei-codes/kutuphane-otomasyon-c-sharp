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
    public class DbSelect
    {
        OleDbConnection conn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataTable dt;

        public DbSelect()
        {
            conn = new OleDbConnection(ConnectionString.GetConnectionString());
        }
      
        public List<Diller> GetDiller()
        {
            List<Diller> listDiller = new List<Diller>();
            
            da = new OleDbDataAdapter("select Id,DilAdi from DILLER order by DilAdi", conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {   
                Diller diller = new Diller()
                {
                    Id = (int)dt.Rows[i]["Id"],
                    DilAdi = dt.Rows[i]["DilAdi"].ToString()
                };

                listDiller.Add(diller);
            }

            return listDiller;

        }

        public List<Turler> GetTurler()
        {
            List<Turler> listTurler = new List<Turler>();

            da = new OleDbDataAdapter("select Id,TurAdi from TURLER order by TurAdi", conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Turler turler = new Turler()
                {
                    Id = (int)dt.Rows[i]["Id"],
                    TurAdi = dt.Rows[i]["TurAdi"].ToString()
                };

                listTurler.Add(turler);
            }

            return listTurler;

        }

        public bool BarkodNoVarMi(int barkodNo)
        {
            da = new OleDbDataAdapter("select * from KITAPLAR where BarkodNo='" + barkodNo + "'", conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;


        }
        public bool BarkodNoVarMi(int barkodNo, int Id)
        {
            string sql = "select * from KITAPLAR where BarkodNo = '" + barkodNo + "' and Id <>" + Id + "";
            da = new OleDbDataAdapter(sql, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
        public List<Kitaplar> GetKitapByKitapAdi(string KitapAdi)
        {
            List<Kitaplar> listKitaplar = new List<Kitaplar>();

            string sorgu = "select k.BarkodNo,k.Id,k.KitapAdi,k.KitapYazari,k.Tur_Id,k.YayinEvi," +
                "k.SayfaSayisi,k.Dil_Id,k.BasimYili,k.RaftaMi,d.DilAdi,t.TurAdi from KITAPLAR k," +
                "DILLER d,TURLER t where  d.Id=k.Dil_Id AND t.Id=k.Tur_Id and k.KitapAdi like '%" +
                 KitapAdi + "%'";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Kitaplar kitaplar = new Kitaplar()
                {   
                    BarkodNo = dt.Rows[i]["BarkodNo"].ToString(),
                    BasimYili = dt.Rows[i]["BasimYili"].ToString(),
                    DilAdi = dt.Rows[i]["DilAdi"].ToString(),
                    Dil_Id = (int)dt.Rows[i]["Dil_Id"],
                    Id = (int)dt.Rows[i]["Id"],
                    KitapAdi = dt.Rows[i]["KitapAdi"].ToString(),
                    KitapYazari = dt.Rows[i]["KitapYazari"].ToString(),
                    RaftaMi = (int)dt.Rows[i]["RaftaMi"],
                    SayfaSayisi = dt.Rows[i]["SayfaSayisi"].ToString(),
                    TurAdi = dt.Rows[i]["TurAdi"].ToString(),
                    Tur_Id = (int)dt.Rows[i]["Tur_Id"],
                    YayinEvi = dt.Rows[i]["YayinEvi"].ToString()
                };

                listKitaplar.Add(kitaplar);
            }

            return listKitaplar;
        }

        
        public List<OgrKitap> GetByIdOGRKitap(int kitap_Id)
        {
            List<OgrKitap> list = new List<OgrKitap>();

            string sql = "select * from OGRKITAP WHERE Kitap_Id=" + kitap_Id + "";

            da = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                OgrKitap ogrKitap = new OgrKitap()
                {
                    Id = (int)dt.Rows[i]["Id"],
                    Kitap_Id = (int)dt.Rows[i]["Kitap_Id"],
                    Ogrenci_Id = (int)dt.Rows[i]["Ogrenci_Id"],
                    TeslimEttiMi = (int)dt.Rows[i]["TeslimEttiMi"],
                    VerilisTarihi = (DateTime)dt.Rows[i]["VerilisTarihi"]



                };
                
                if (ogrKitap.TeslimEttiMi == 1)
                    ogrKitap.TeslimTarihi = (DateTime)dt.Rows[i]["TeslimTarihi"];


                ogrKitap.Kitap = GetKitapById(ogrKitap.Kitap_Id);

                ogrKitap.Ogrenci = GetOgrenciById(ogrKitap.Ogrenci_Id);

                list.Add(ogrKitap);
            }

            return list;

        }

      
        public List<OgrKitap> GetByOgrenciIdOGRKitap(int kitap_Id)
        {
            List<OgrKitap> list = new List<OgrKitap>();

            string sql = "select * from OGRKITAP WHERE Ogrenci_Id=" + kitap_Id + "";

            da = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                OgrKitap ogrKitap = new OgrKitap()
                {
                    Id = (int)dt.Rows[i]["Id"],
                    Kitap_Id = (int)dt.Rows[i]["Kitap_Id"],
                    Ogrenci_Id = (int)dt.Rows[i]["Ogrenci_Id"],
                    TeslimEttiMi = (int)dt.Rows[i]["TeslimEttiMi"],
                    VerilisTarihi = (DateTime)dt.Rows[i]["VerilisTarihi"]



                };

                if (ogrKitap.TeslimEttiMi == 1)
                    ogrKitap.TeslimTarihi = (DateTime)dt.Rows[i]["TeslimTarihi"];


                ogrKitap.Kitap = GetKitapById(ogrKitap.Kitap_Id);

                ogrKitap.Ogrenci = GetOgrenciById(ogrKitap.Ogrenci_Id);

                list.Add(ogrKitap);
            }

            return list;

        }


        
        public List<Kitaplar> GetKitapByBarkodNo(string BarkodNo)
        {
            List<Kitaplar> listKitaplar = new List<Kitaplar>();
            string sorgu = "select k.BarkodNo,k.Id,k.KitapAdi,k.KitapYazari,k.Tur_Id," +
                "k.YayinEvi,k.SayfaSayisi,k.Dil_Id,k.BasimYili,k.RaftaMi,d.DilAdi," +
                "t.TurAdi from KITAPLAR k,DILLER d,TURLER t where RaftaMi=1 AND d.Id=k.Dil_Id " +
                "AND t.Id=k.Tur_Id and k.BarkodNo='" + BarkodNo + "'";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Kitaplar kitaplar = new Kitaplar()
                {
                    BarkodNo = dt.Rows[i]["BarkodNo"].ToString(),
                    BasimYili = dt.Rows[i]["BasimYili"].ToString(),
                    DilAdi = dt.Rows[i]["DilAdi"].ToString(),
                    Dil_Id = (int)dt.Rows[i]["Dil_Id"],
                    Id = (int)dt.Rows[i]["Id"],
                    KitapAdi = dt.Rows[i]["KitapAdi"].ToString(),
                    KitapYazari = dt.Rows[i]["KitapYazari"].ToString(),
                    RaftaMi = (int)dt.Rows[i]["RaftaMi"],
                    SayfaSayisi = dt.Rows[i]["SayfaSayisi"].ToString(),
                    TurAdi = dt.Rows[i]["TurAdi"].ToString(),
                    Tur_Id = (int)dt.Rows[i]["Tur_Id"],
                    YayinEvi = dt.Rows[i]["YayinEvi"].ToString()
                };

                listKitaplar.Add(kitaplar);
            }

            return listKitaplar;
        }
        public List<Kitaplar> GetKitapForChart()
        {
            List<Kitaplar> listKitaplar = new List<Kitaplar>();

            string sorgu = "SELECT Count(TURLER.TurAdi) AS TUR_SAYISI, TURLER.TurAdi " +
                "FROM TURLER INNER JOIN KITAPLAR ON TURLER.Id = KITAPLAR.Tur_Id " +
                "WHERE(((KITAPLAR.Tur_Id) =[TURLER].[Id])) " +
                "GROUP BY TURLER.TurAdi; ";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Kitaplar kitaplar = new Kitaplar()
                {
                    TurAdi = dt.Rows[i]["TurAdi"].ToString(),
                    TUR_SAYISI = (int)dt.Rows[i]["TUR_SAYISI"]
                };
                listKitaplar.Add(kitaplar);
            }
            return listKitaplar;
        }

        public List<Kitaplar> GetKitapByYazarAdi(string YazarAdi)
        {
            List<Kitaplar> listKitaplar = new List<Kitaplar>();
         
            string sorgu = "select k.BarkodNo,k.Id,k.KitapAdi,k.KitapYazari,k.Tur_Id,k.YayinEvi,k.SayfaSayisi,k.Dil_Id,k.BasimYili,k.RaftaMi,d.DilAdi,t.TurAdi from KITAPLAR k,DILLER d,TURLER t where RaftaMi=1 AND d.Id=k.Dil_Id AND t.Id=k.Tur_Id and k.KitapYazari like '%" + YazarAdi + "%'";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Kitaplar kitaplar = new Kitaplar()
                {
                    BarkodNo = dt.Rows[i]["BarkodNo"].ToString(),
                    BasimYili = dt.Rows[i]["BasimYili"].ToString(),
                    DilAdi = dt.Rows[i]["DilAdi"].ToString(),
                    Dil_Id = (int)dt.Rows[i]["Dil_Id"],
                    Id = (int)dt.Rows[i]["Id"],
                    KitapAdi = dt.Rows[i]["KitapAdi"].ToString(),
                    KitapYazari = dt.Rows[i]["KitapYazari"].ToString(),
                    RaftaMi = (int)dt.Rows[i]["RaftaMi"],
                    SayfaSayisi = dt.Rows[i]["SayfaSayisi"].ToString(),
                    TurAdi = dt.Rows[i]["TurAdi"].ToString(),
                    Tur_Id = (int)dt.Rows[i]["Tur_Id"],
                    YayinEvi = dt.Rows[i]["YayinEvi"].ToString()
                };

                listKitaplar.Add(kitaplar);
            }

            return listKitaplar;
        }
       
        public List<Ogrenciler> GetOgrenciByAd(string Ad)
        {
            List<Ogrenciler> listOgrenciler = new List<Ogrenciler>();
          
            string sorgu = "select * from OGRENCILER where Ad like '%" + Ad + "%' or Soyad like '%" + Ad + "%'";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Ogrenciler ogrenciler = new Ogrenciler()
                {
                    Ad = dt.Rows[i]["Ad"].ToString(),
                    Mail = dt.Rows[i]["Mail"].ToString(),
                    Id = (int)dt.Rows[i]["Id"],
                    Soyad = dt.Rows[i]["Soyad"].ToString(),
                    TcNo = dt.Rows[i]["TcNo"].ToString(),
                    TelNo = dt.Rows[i]["TelNo"].ToString()

                };

                listOgrenciler.Add(ogrenciler);
            }

            return listOgrenciler;
        }

        public Kitaplar GetKitapById(int Id)
        {
            Kitaplar kitap;
            string sorgu = "select k.BarkodNo,k.Id,k.KitapAdi,k.KitapYazari,k.Tur_Id,k.YayinEvi," +
                "k.SayfaSayisi,k.Dil_Id,k.BasimYili,k.RaftaMi,d.DilAdi,t.TurAdi from KITAPLAR k," +
                "DILLER d,TURLER t where  d.Id=k.Dil_Id AND t.Id=k.Tur_Id and k.Id=" + Id + "";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                kitap = new Kitaplar()
                {
                    BarkodNo = dt.Rows[i]["BarkodNo"].ToString(),
                    BasimYili = dt.Rows[i]["BasimYili"].ToString(),
                    DilAdi = dt.Rows[i]["DilAdi"].ToString(),
                    Dil_Id = (int)dt.Rows[i]["Dil_Id"],
                    Id = (int)dt.Rows[i]["Id"],
                    KitapAdi = dt.Rows[i]["KitapAdi"].ToString(),
                    KitapYazari = dt.Rows[i]["KitapYazari"].ToString(),
                    RaftaMi = (int)dt.Rows[i]["RaftaMi"],
                    SayfaSayisi = dt.Rows[i]["SayfaSayisi"].ToString(),
                    TurAdi = dt.Rows[i]["TurAdi"].ToString(),
                    Tur_Id = (int)dt.Rows[i]["Tur_Id"],
                    YayinEvi = dt.Rows[i]["YayinEvi"].ToString()
                };

                return kitap;
            }

            return null;
        }

        public int GetOgrenciIdByKitapId(int Kitap_Id)
        {
            int ogrenci_Id;
            string sql = "select * from OGRKITAP where " + Kitap_Id + "";
            da = new OleDbDataAdapter(sql, conn);
            dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            int ogrenciId = (int)dt.Rows[0]["Ogrenci_Id"];

            return ogrenciId;
        }

        public Ogrenciler GetOgrenciById(int Id)
        {
            Ogrenciler ogrenciler;
            string sorgu = "select * from OGRENCILER where Id=" + Id + "";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ogrenciler = new Ogrenciler()
                {
                    Ad = dt.Rows[i]["Ad"].ToString(),
                    Mail = dt.Rows[i]["Mail"].ToString(),
                    Id = (int)dt.Rows[i]["Id"],
                    Soyad = dt.Rows[i]["Soyad"].ToString(),
                    TcNo = dt.Rows[i]["TcNo"].ToString(),
                    TelNo = dt.Rows[i]["TelNo"].ToString()

                };

                return ogrenciler;
            }

            return null;
        }

        public bool KitapRaftaMi(int Kitap_Id)
        {
            string sql = "select * from KITAPLAR where Id=" + Kitap_Id + "";

            da = new OleDbDataAdapter(sql, conn);
            dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            int raftaMi = (int)dt.Rows[0]["RaftaMi"];

            if (raftaMi == 1)
                return true;
            else
                return false;
        }

        public List<Kitaplar> GetKitapByKitapAdiBarkodNoKitapYazari(string KitapAdi, string BarkodNo, string KitapYazari)
        {
            List<Kitaplar> listKitaplar = new List<Kitaplar>();
            string sorgu = "select k.BarkodNo,k.Id,k.KitapAdi,k.KitapYazari,k.Tur_Id,k.YayinEvi,k.SayfaSayisi,k.Dil_Id," +
                "k.BasimYili,k.RaftaMi,d.DilAdi,t.TurAdi from KITAPLAR k,DILLER d,TURLER t where RaftaMi=1 AND d.Id=k.Dil_Id " +
                "AND t.Id=k.Tur_Id and (k.KitapAdi like '%" + KitapAdi + "%' or k.BarkodNo like '" + BarkodNo + "%' or " +
                "k.KitapYazari like '%" + KitapYazari + "%')";
            da = new OleDbDataAdapter(sorgu, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Kitaplar kitaplar = new Kitaplar()
                {
                    BarkodNo = dt.Rows[i]["BarkodNo"].ToString(),
                    BasimYili = dt.Rows[i]["BasimYili"].ToString(),
                    DilAdi = dt.Rows[i]["DilAdi"].ToString(),
                    Dil_Id = (int)dt.Rows[i]["Dil_Id"],
                    Id = (int)dt.Rows[i]["Id"],
                    KitapAdi = dt.Rows[i]["KitapAdi"].ToString(),
                    KitapYazari = dt.Rows[i]["KitapYazari"].ToString(),
                    RaftaMi = (int)dt.Rows[i]["RaftaMi"],
                    SayfaSayisi = dt.Rows[i]["SayfaSayisi"].ToString(),
                    TurAdi = dt.Rows[i]["TurAdi"].ToString(),
                    Tur_Id = (int)dt.Rows[i]["Tur_Id"],
                    YayinEvi = dt.Rows[i]["YayinEvi"].ToString()
                };

                listKitaplar.Add(kitaplar);
            }

            return listKitaplar;
        }

        public List<BorcOdeme> GetBorcOdemeGetir(int Ogrenci_Id)
        {
            List<BorcOdeme> list = new List<BorcOdeme>();

            string sql = "select * from BORCODEME where Ogrenci_Id=" + Ogrenci_Id + "";

            da = new OleDbDataAdapter(sql, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BorcOdeme borc = new BorcOdeme()
                {
                    Id = (int)dt.Rows[i]["Id"],
                    Miktar = (int)dt.Rows[i]["Miktar"],
                    Tarih = (DateTime)dt.Rows[i]["Tarih"],
                    Ogrenci_Id = (int)dt.Rows[i]["Ogrenci_Id"],
                    OgrKitap_Id = (int)dt.Rows[i]["OgrKitap_Id"]
                };

                list.Add(borc);
            }

            return list;
        }
    }
}
