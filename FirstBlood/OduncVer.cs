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
    public partial class OduncVer : Form
    {
        
        OduncKitapOgr odunc;
        Kitaplar kitap;
        Ogrenciler ogrenci;

        OduncVerManager oduncManager = new OduncVerManager();
        List<int> listOgrenci_Id;
        List<int> listKitap_Id;
        public OduncVer(OduncKitapOgr _odunc)
        {
            odunc = _odunc;
            InitializeComponent();
            if (odunc.KitapMi)
            {
                kitap = oduncManager.GetKitapById(odunc.Kitap_Id);
                label_Bilgi.Text = "Kitap Adı : " + kitap.KitapAdi;
                ara.Text = "Öğrenci Arayınız.";
                ColumnOgrenci();
            }
            
            else
            {
                ogrenci = oduncManager.GetOgrenciById(odunc.Ogrenci_Id);
                label_Bilgi.Text = "Öğrenci Adı-Soyadı : " + ogrenci.Ad + " " + ogrenci.Soyad;
                ara.Text = "Kitap Arayınız.";
                ColumnKitap();
            }
           
            listView.FullRowSelect = true;
           
        }
        private void ColumnKitap()
        {
            listView.Items.Clear();
            listView.Clear();

            listView.View = View.Details;

            listView.Columns.Add("Barkod No", 100);
            listView.Columns.Add("Kitap Adı", 100);
            listView.Columns.Add("Yazar", 100);

        }
        private void ColumnOgrenci()
        {
            listView.Items.Clear();
            listView.Clear();

            listView.View = View.Details;

            listView.Columns.Add("Adı", 100);
            listView.Columns.Add("Soyadı", 100);
            listView.Columns.Add("Telefon", 100);
        }
        private void ListOgrenci_IdDoldur(List<Ogrenciler> listOgrenciler)
        {
            listOgrenci_Id = new List<int>();
            listKitap_Id = new List<int>();

            foreach (Ogrenciler ogrenci in listOgrenciler)
            {
                listOgrenci_Id.Add(ogrenci.Id);
            }
        }

        private void ListKitap_IdDoldur(List<Kitaplar> listKitaplar)
        {
            listOgrenci_Id = new List<int>();
            listKitap_Id = new List<int>();

            foreach (Kitaplar kitap in listKitaplar)
            {
                listKitap_Id.Add(kitap.Id);
            }
        }
        
        private void btn_OduncVer_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (listView.SelectedItems.Count > 0)
            {
                selectedIndex = listView.Items.IndexOf(listView.SelectedItems[0]);
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("Ödünç Verilecek Kitap/Öğrenci Seçiniz.");
                return;
            }

            if (odunc.KitapMi)
            {
                int ogrenci_Id = listOgrenci_Id[selectedIndex];
                ogrenci = oduncManager.GetOgrenciById(ogrenci_Id);
                DialogResult result = MessageBox.Show(kitap.KitapAdi + " kitabı , " + ogrenci.Ad + "  adlı öğrenciye verilecektir.", "UYARI", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oduncManager.AddOgrKitap(odunc.Kitap_Id, ogrenci_Id))
                    {
                        if (oduncManager.UpdateKitapRaftaMi(odunc.Kitap_Id, 0))
                        {
                            MessageBox.Show("Başarılı");

                            this.Close();
                        }
                    }
                }
            }
            else
            {   
                int kitap_Id = listKitap_Id[selectedIndex];
                kitap = oduncManager.GetKitapById(kitap_Id);
                DialogResult result = MessageBox.Show(ogrenci.Ad + " öğrencisine , " + kitap.KitapAdi + " adlı kitap verilecektir.", "UYARI", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oduncManager.AddOgrKitap(odunc.Kitap_Id, ogrenci.Id))
                    {
                        if (oduncManager.UpdateKitapRaftaMi(kitap_Id, 0))
                        {
                            MessageBox.Show("Başarılı");

                            this.Close();
                        }
                    }
                }
            }

        
        }
        
        // arama textboxuna yazdıkça liste güncellenerek uygun isimler karşımıza getiriliyor
        private void ara_TextChanged(object sender, EventArgs e)
        {
            listView.Items.Clear();
            listView.View = View.Details;


                if (odunc.KitapMi)
                {
                    List<Ogrenciler> listOgrenciler = oduncManager.GetOgrenciByAd(ara.Text);
                    ListOgrenci_IdDoldur(listOgrenciler);
                    for (int i = 0; i < listOgrenciler.Count; i++)
                    {
                        Ogrenciler ogrenciler = listOgrenciler[i];
                        var item1 = new ListViewItem(new[] { ogrenciler.Ad, ogrenciler.Soyad, ogrenciler.TelNo });
                        listView.Items.Add(item1);
                    }

                }
                else
                {

                    List<Kitaplar> listKitaplar = oduncManager.GetKitapByKitapAdiBarkodNoKitapYazari(ara.Text, ara.Text, ara.Text);
                    ListKitap_IdDoldur(listKitaplar);
                    for (int i = 0; i < listKitaplar.Count; i++)
                    {
                        Kitaplar kitap = listKitaplar[i];
                        var item1 = new ListViewItem(new[] { kitap.BarkodNo, kitap.KitapAdi, kitap.KitapYazari });
                        listView.Items.Add(item1);
                    }
                }
            
        }
        // textboxun üzerine tıklandığında üzerinde yazan yazı siliniyor
        private void ara_MouseClick(object sender, MouseEventArgs e)
        {
            ara.Text = "";
        }
    
    }
}
