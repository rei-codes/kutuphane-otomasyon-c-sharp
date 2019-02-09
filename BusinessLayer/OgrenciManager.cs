using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{   
    public class OgrenciManager
    {
        DbInsert dbInsert;
        DbSelect dbSelect;
        DbDelete dbDelete = new DbDelete();
        DbUpdate dbupdate = new DbUpdate();
        public OgrenciManager()
        {
            dbInsert = new DbInsert();
            dbSelect = new DbSelect();
        }

        public List<string> AddOgrenci(string txtTcNo, string txtAd, string txtSoyad, string txtMail, string txtTelNo)
        {
            List<string> sonuc = new List<string>();
            
            if (txtTcNo.Length != 11)
            {
                sonuc.Add("Tc No 11 Haneli Olmak Zorunda");
                return sonuc;
            }

            double tcNo;
            bool k = Double.TryParse(txtTcNo, out tcNo);
            if (k == false)
            {
                sonuc.Add("Tc No Sayı Olmak Zorunda");
                return sonuc;
            }


            if (txtAd.Trim().Length == 0 || txtSoyad.Trim().Length == 0 || txtMail.Trim().Length == 0 || txtTelNo.Trim().Length == 0)
            {
                sonuc.Add("Ad , Soyad , Mail , Telefon Numarası Girilmek Zorunda");
                return sonuc;
            }

            Ogrenciler ogrenci = new Ogrenciler()
            {
                Ad = txtAd,
                Soyad = txtSoyad,
                Mail = txtMail,
                TcNo = txtTcNo,
                TelNo = txtTelNo
            };

            if (dbInsert.OgrenciEkle(ogrenci) == false)
            {
                sonuc.Add("Bir sorun oluştu");
                return sonuc;
            }

            return sonuc;
        }
        
        public List<Ogrenciler> AdaGoreOgrenciGetir(string ad)
        {
            return dbSelect.GetOgrenciByAd(ad);
        }

        public Ogrenciler IdeGoreOgrenciGetir(int Ogrenci_Id)
        {
            return dbSelect.GetOgrenciById(Ogrenci_Id);
        }

        public List<OgrKitap> OgrKitapGetirOgrenciIdeGore(int Ogrenci_Id)
        {
            return dbSelect.GetByOgrenciIdOGRKitap(Ogrenci_Id);
        }

        public bool BorcOdemeEkle(BorcOdeme borc)
        {
            return dbInsert.BorcOdemeEkle(borc);
        }

        public List<BorcOdeme> GetBorcOdemeGetir(int Ogrenci_Id)
        {
            return dbSelect.GetBorcOdemeGetir(Ogrenci_Id);
        }

        public List<string> OgrenciGuncelle(Ogrenciler ogrenci)
        {
            return dbupdate.OgrenciGuncelle(ogrenci);
        }
        
        public void SilOgrenci(int ogrenci_Id)
        {
            dbDelete.DeleteOgrenci(ogrenci_Id);
        }
        public void SilOgrKitap(int ogrenci_Id)
        {
            dbDelete.DeleteOgrKitap(ogrenci_Id);
        }
    }
}
