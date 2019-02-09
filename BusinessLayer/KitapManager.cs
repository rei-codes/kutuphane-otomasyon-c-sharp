using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KitapManager
    {
        DbInsert dbInsert;
        DbSelect dbSelect;
        DbUpdate dbupdate = new DbUpdate();
        DbDelete dbDelete = new DbDelete();
        public KitapManager()
        {
            dbInsert = new DbInsert();
            dbSelect = new DbSelect();
        }

        public List<string> KitapEkle(string txtBarkodNo, string txtKitapAdi, string txtKitapYazari, int tur_Id, string txtYayinEvi, string txtSayfaSayisi, int dil_Id, string txtBasimYili)
        {
            List<string> result = new List<string>();

            int barkodNo;
            bool k = Int32.TryParse(txtBarkodNo, out barkodNo);

            if (k == false)
            {
                result.Add("Barkod Numarası Sayı Olmak Zorunda");
                return result;
            }
            if (dbSelect.BarkodNoVarMi(barkodNo))
            {
                result.Add("Aynı Barkod Numarası Mevcut");
                return result;
            }

            if (txtKitapAdi.Length == 0)
            {
                result.Add("Kitap Adı Boş Bırakılamaz");
                return result;
            }

            if (txtKitapYazari.Length == 0)
            {
                result.Add("Kitap Yazarı Boş Bırakılamaz");
                return result;
            }


            int basimYili;
            k = Int32.TryParse(txtBasimYili, out basimYili);
            if (k == false)
            {
                result.Add("Basım Yılı  Sayı Olmak Zorunda");
                return result;
            }

            if (txtYayinEvi.Length == 0)
            {
                result.Add("Yayın Evi Boş Bırakılamaz");
                return result;
            }

            int sayfaSayisi;
            k = Int32.TryParse(txtSayfaSayisi, out sayfaSayisi); ;
            if (k == false)
            {
                result.Add("Sayfa Sayısı Sayı Olmak Zorunda");
                return result;
            }



            if (dbInsert.KitapEkle(barkodNo, txtKitapAdi, txtKitapYazari, tur_Id, txtYayinEvi, sayfaSayisi, dil_Id, basimYili) == false)
                result.Add("Eklerken Bir Hata Oluştu");

            return result;
        }

        public string BarkodOlustur()
        {
            int barkodNo = -1;
            Random random = new Random();
            while (true)
            {
                barkodNo = random.Next(10000000, 99999999);
                if (dbSelect.BarkodNoVarMi(barkodNo) == false)
                    break;

            }

            return barkodNo.ToString();
        }

        public List<Kitaplar> KitapAdinaGoreGetir(string kitapAdi)
        {
            return dbSelect.GetKitapByKitapAdi(kitapAdi);
        }

        public List<Kitaplar> GetKitapForChart()
        {
            return dbSelect.GetKitapForChart();
        }
        public List<Kitaplar> BarkodaGoreGetir(string barkodNo)
        {
            return dbSelect.GetKitapByBarkodNo(barkodNo);
        }

        public List<Kitaplar> YazaraGoreGetir(string yazarAdi)
        {
            return dbSelect.GetKitapByYazarAdi(yazarAdi);
        }

        public bool KitapRaftaMi(int Kitap_Id)
        {
            return dbSelect.KitapRaftaMi(Kitap_Id);
        }

        public Kitaplar GetKitapById(int id)
        {
            return dbSelect.GetKitapById(id);
        }

        public List<OgrKitap> GetOgrKitapByKitapId(int Kitap_Id)
        {
            return dbSelect.GetByIdOGRKitap(Kitap_Id); ;
        }

        public List<string> KitapGuncelle(Kitaplar kitap)
        {
            List<string> result = new List<string>();

            try
            {
                Int32.Parse(kitap.BarkodNo);
                Int32.Parse(kitap.BasimYili);
                Int32.Parse(kitap.SayfaSayisi);
            }
            catch
            {
                result.Add("Barkod No , Basim Yili , Sayfa Sayısı sayı olmak zorunda");
                return result;
            }

            return dbupdate.KitapGuncelle(kitap);
        }

        public void SilKitap(int kitap_Id)
        {
            dbDelete.DeleteKitap(kitap_Id);
        }

        public void SilOgrKitap(int kitap_Id)
        {
            dbDelete.DeleteOgrKitap(kitap_Id);
        }
    }
}
