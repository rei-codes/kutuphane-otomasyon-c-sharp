using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{   
    public class OduncVerManager
    {   
        DbSelect dbSelect = new DbSelect();
        DbInsert dbInsert = new DbInsert();
        DbUpdate dbUpdate = new DbUpdate();
        public Kitaplar GetKitapById(int id)
        {
            return dbSelect.GetKitapById(id);
        }

        public Ogrenciler GetOgrenciById(int id)
        {
            return dbSelect.GetOgrenciById(id);
        }

        public List<Kitaplar> GetKitapByKitapAdiBarkodNoKitapYazari(string KitapAdi, string BarkodNo, string KitapYazari)
        {
            return dbSelect.GetKitapByKitapAdiBarkodNoKitapYazari(KitapAdi, BarkodNo, KitapYazari);
        }

        public List<Ogrenciler> GetOgrenciByAd(string Ad)
        {
            return dbSelect.GetOgrenciByAd(Ad);
        }

        public bool AddOgrKitap(int Kitap_Id,int Ogrenci_Id)
        {
            return dbInsert.OgrKitapEkle(Kitap_Id, Ogrenci_Id);
        }

        public bool UpdateKitapRaftaMi(int Kitap_Id,int RaftaMi)
        {
            return dbUpdate.KitapRaftaMiGuncelle(Kitap_Id, RaftaMi);
        }

    }
}
