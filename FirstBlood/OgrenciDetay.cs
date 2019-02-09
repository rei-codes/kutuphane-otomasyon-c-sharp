using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstBlood
{
    public partial class OgrenciDetay : Form
    {
        List<BorcOdeme> listBorcOdeme;
        List<int> lsitIdListBorc = new List<int>();
        List<int> listIdOgrKitap = new List<int>();

        List<OgrKitap> ogrs = new List<OgrKitap>();

        int Ogrenci_Id;
        Ogrenciler ogrenci;
        OgrenciManager ogrenciManager = new OgrenciManager();
        
        public OgrenciDetay(int _Ogrenci_Id)
        {
            Ogrenci_Id = _Ogrenci_Id;
            listBorcOdeme = ogrenciManager.GetBorcOdemeGetir(Ogrenci_Id);
            ogrenci = ogrenciManager.IdeGoreOgrenciGetir(Ogrenci_Id);
            InitializeComponent();

            tc_Textbox.Text = ogrenci.TcNo;
            ad_Textbox.Text = ogrenci.Ad;
            soyad_Textbox.Text = ogrenci.Soyad;
            eposta_Textbox.Text = ogrenci.Mail;
            tel_Textbox.Text = ogrenci.TelNo;

            dokum_Listview.FullRowSelect = true;

            dokum_Listview.View = View.Details;

            dokum_Listview.Columns.Add("Durum", 100);
            dokum_Listview.Columns.Add("Kitap Adı", 100);
            dokum_Listview.Columns.Add("Aldığı Tarih", 100);
            dokum_Listview.Columns.Add("İade Tarih", 100);

            BorcGuncelle();
            ToplamBorcHesapla();

        }

        private void BorcGuncelle()
        {
            int borc = 0;
            ogrs = ogrenciManager.OgrKitapGetirOgrenciIdeGore(Ogrenci_Id);
            listIdOgrKitap = new List<int>();
            foreach (OgrKitap ogrKitap in ogrs)
            {
                listIdOgrKitap.Add(ogrKitap.Id);

                string durum = "Teslim Edilmedi";

                if (ogrKitap.TeslimEttiMi == 1)
                    durum = "Teslim Edildi";

                string kitap_ismi = ogrKitap.Kitap.KitapAdi;

                string aldigiTarih = ogrKitap.VerilisTarihi.ToShortDateString();

                string iade_Tarihi = "";
                DateTime dtİadeTarih = new DateTime();
                if (ogrKitap.TeslimEttiMi == 1)
                {
                    iade_Tarihi = ogrKitap.TeslimTarihi.ToShortDateString();
                }
                else
                {
                    iade_Tarihi = ogrKitap.VerilisTarihi.AddDays(14).ToShortDateString();
                    dtİadeTarih = ogrKitap.VerilisTarihi.AddDays(14);
                }

                var item1 = new ListViewItem(new[] { durum, kitap_ismi, aldigiTarih, iade_Tarihi });
                dokum_Listview.Items.Add(item1);
                lsitIdListBorc.Add(ogrKitap.Id);

                if (ogrKitap.TeslimEttiMi == 1)
                {
                    dokum_Listview.Items[dokum_Listview.Items.Count - 1].BackColor = Color.Green;
                }
                else if (DateTime.Now >= dtİadeTarih)
                {
                    dokum_Listview.Items[dokum_Listview.Items.Count - 1].BackColor = Color.Red;
                }
                else if (DateTime.Now.AddDays(2) >= dtİadeTarih)
                {
                    dokum_Listview.Items[dokum_Listview.Items.Count - 1].BackColor = Color.Yellow;
                }
            }
        }

        private void borc_Button_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (dokum_Listview.SelectedItems.Count > 0)
            {
                selectedIndex = dokum_Listview.Items.IndexOf(dokum_Listview.SelectedItems[0]);
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("Listeden Seçiniz");
                return;

            }

            int secilenBorc = secilenBorcHesapla();

            int sayi = -1;
            try
            {
                sayi = Int32.Parse(borcOde_TextBox.Text);
                if (sayi <= 0)
                {
                    MessageBox.Show("Ödenecek Borç 0 ' dan büyük olması gerekir.");
                    return;
                }

                if (sayi > secilenBorc)
                {
                    MessageBox.Show("Seçilen Borçdan daha fazla ödenemez");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Sayı Girilmesi Gerekir");
                return;
            }

            DialogResult dg = MessageBox.Show("Ödensin mi ?", "Uyarı", MessageBoxButtons.YesNo);

            OgrKitap ogrKitap = ogrs[selectedIndex];
    
            if (dg == DialogResult.Yes)
            {
                BorcOdeme borc = new BorcOdeme()
                {
                    Miktar = sayi,
                    Ogrenci_Id = this.Ogrenci_Id,
                    Tarih = DateTime.Now,
                    OgrKitap_Id = ogrKitap.Id
                };

                if (ogrenciManager.BorcOdemeEkle(borc))
                {
                    borcOde_TextBox.Text = "";
                    dokum_Listview_SelectedIndexChanged(null, null);
                    listBorcOdeme = ogrenciManager.GetBorcOdemeGetir(Ogrenci_Id);
                    MessageBox.Show("Borç Ödendi");
                    dokum_Listview.Items[selectedIndex].Selected = true;
                    ToplamBorcHesapla();
                }
                else
                    MessageBox.Show("Hata Oluştu");
            }
        }
        private void dokum_Listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (dokum_Listview.SelectedItems.Count > 0)
            {
                selectedIndex = dokum_Listview.Items.IndexOf(dokum_Listview.SelectedItems[0]);
            }

            if (selectedIndex == -1)
            {
                secilenBorc_Label.Text = "";
                return;
            }

            secilenBorcHesapla();

        }
        private int secilenBorcHesapla()
        {
            int selenctedIndex = -1;
            if (dokum_Listview.SelectedItems.Count > 0)
            {
                selenctedIndex = dokum_Listview.Items.IndexOf(dokum_Listview.SelectedItems[0]);
            }

            OgrKitap ogrKitap = ogrs[selenctedIndex];

            int secilenBorc = 0;
            int odenenBorc = 0;

            foreach (BorcOdeme borc in listBorcOdeme)
            {
                if (borc.OgrKitap_Id == ogrKitap.Id)
                    odenenBorc += borc.Miktar;
            }


            if (ogrKitap.TeslimEttiMi == 1)
            {
                if (ogrKitap.VerilisTarihi.AddDays(14) < ogrKitap.TeslimTarihi)
                {
                    secilenBorc = (int)(ogrKitap.TeslimTarihi - ogrKitap.VerilisTarihi.AddDays(14)).TotalDays - odenenBorc;
                }

            }
            else
            {
                if (ogrKitap.VerilisTarihi.AddDays(14) < DateTime.Now)
                {
                    secilenBorc = (int)((DateTime.Now - ogrKitap.VerilisTarihi.AddDays(14)).TotalDays) - odenenBorc;
                }
            }

            secilenBorc_Label.Text = "Seçilen Borç : " + secilenBorc + " TL";

            ToplamBorcHesapla();

            return secilenBorc;
        }
        private void ToplamBorcHesapla()
        {
            int toplamBorc = 0;

            for (int i = 0; i < dokum_Listview.Items.Count; i++)
            {
                OgrKitap ogrKitap = ogrs[i];

                int secilenBorc = 0;
                int odenenBorc = 0;

                foreach (BorcOdeme borc in listBorcOdeme)
                {
                    if (borc.OgrKitap_Id == ogrKitap.Id)
                        odenenBorc += borc.Miktar;
                }


                if (ogrKitap.TeslimEttiMi == 1)
                {
                    if (ogrKitap.VerilisTarihi.AddDays(14) < ogrKitap.TeslimTarihi)
                    {
                        secilenBorc = (int)(ogrKitap.TeslimTarihi - ogrKitap.VerilisTarihi.AddDays(14)).TotalDays - odenenBorc;
                    }

                }
                else
                {
                    if (ogrKitap.VerilisTarihi.AddDays(14) < DateTime.Now)
                    {
                        secilenBorc = (int)((DateTime.Now - ogrKitap.VerilisTarihi.AddDays(14)).TotalDays) - odenenBorc;
                    }
                }

                toplamBorc += secilenBorc;
            }

            borc_Label.Text = toplamBorc + " TL";
        }
        private void sil_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ogrenciManager.SilOgrenci(this.Ogrenci_Id);
                ogrenciManager.SilOgrKitap(this.Ogrenci_Id);
                this.Close();
            }
        }
        private void guncelle_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Güncellemek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Ogrenciler ogrenci = new Ogrenciler()
                {
                    TcNo = tc_Textbox.Text,
                    Ad = ad_Textbox.Text,
                    Soyad = soyad_Textbox.Text,
                    Mail = eposta_Textbox.Text,
                    TelNo = tel_Textbox.Text,
                    Id = this.Ogrenci_Id
                };

                List<string> result = ogrenciManager.OgrenciGuncelle(ogrenci);

                if (result.Count > 0)
                {
                    foreach (string sonuc in result)
                        MessageBox.Show(sonuc);
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarılı!");
                }
            }
        }
    }
}
