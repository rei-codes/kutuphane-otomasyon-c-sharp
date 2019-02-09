using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{   
    public class IadeAlManager
    {   
        DbSelect dbSelect = new DbSelect();
        DbInsert dbInsert = new DbInsert();
        DbUpdate dbUpdate = new DbUpdate();
        // id'ye göre Kitapları al
        public Kitaplar GetKitapById(int id)
        {
            return dbSelect.GetKitapById(id);
        }
        public Ogrenciler GetOgrenciById(int id)
        {
            return dbSelect.GetOgrenciById(id);
        }
        public List<Ogrenciler> GetOgrenciByAd(string Ad)
        {
            return dbSelect.GetOgrenciByAd(Ad);
        }
        public int GetOgrenciIdByKitapId(int Kitap_Id)
        {
            return dbSelect.GetOgrenciIdByKitapId(Kitap_Id);
        }
        public bool AddOgrKitap(int Kitap_Id,int Ogrenci_Id)
        {
            return dbInsert.OgrKitapEkle(Kitap_Id, Ogrenci_Id);
        }
        public bool UpdateKitapRaftaMi(int Kitap_Id,int RaftaMi)
        {
            return dbUpdate.KitapRaftaMiGuncelle(Kitap_Id, RaftaMi);
        }
        public bool UpdateTeslimBilgisi(int Kitap_Id, int Ogrenci_Id, DateTime Teslim_Tarihi)
        {
            return dbUpdate.TeslimBilgisiGuncelle(Kitap_Id, Ogrenci_Id, Teslim_Tarihi);
        }
    }
}
