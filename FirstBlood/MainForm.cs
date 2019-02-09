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
using c = System.Windows.Forms.DataVisualization.Charting;

namespace FirstBlood
{
    public partial class MainForm : Form
    {
        
        IadeKitapOgr iade;
        Kitaplar kitap;
        Ogrenciler ogrenci;
        OgrKitap ogrKitap;

        KitapManager kitapManager = new KitapManager();
        OgrenciManager ogrenciManager = new OgrenciManager();
        IadeAlManager iadeManager = new IadeAlManager();

        List<int> listOgrenci_Id;
        List<int> listKitap_Id;

        bool kitapMi = false;
        bool silindiMi = false;

        public MainForm()
        {
            InitializeComponent();
            chartUpdate(); 
            aramaTur_ComboBox.SelectedIndex = 0;

            listView.FullRowSelect = true;
        }
   
        public void chartUpdate()
        {
            
            List<Kitaplar> chartKitaplar = kitapManager.GetKitapForChart();
            
            Dictionary<string, int> tags = new Dictionary<string, int>();
            for (int i = 0; i < chartKitaplar.Count; i++)
            {
                Kitaplar kitap = chartKitaplar[i];
                tags.Add(chartKitaplar[i].TurAdi, chartKitaplar[i].TUR_SAYISI);
            }
        
            chart1.Series[0].Points.Clear();
            chart1.Series[0].ChartType = c.SeriesChartType.Pie;

            
            foreach (string tagname in tags.Keys)
            {   
                chart1.Series[0].Points.AddXY(tagname, ((tags[tagname] * 100) / tags.Values.Sum()));
                chart1.Series[0].IsValueShownAsLabel = true;
            }
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
        private void ColumnKitap()
        {
            listView.Items.Clear();
            listView.Clear();

            listView.View = View.Details;
            listView.Columns.Add("Barkod No", 100);
            listView.Columns.Add("Kitap Adı", 100);
            listView.Columns.Add("Yazar", 100);
            listView.Columns.Add("Rafta Mı?", 100);

            kitapMi = true;

        }
        private void ColumnOgrenci()
        {
            listView.Items.Clear();
            listView.Clear();

            listView.View = View.Details;

            listView.Columns.Add("Adı", 100);
            listView.Columns.Add("Soyadı", 100);
            listView.Columns.Add("Telefon", 100);

            kitapMi = false;
        }


        private void ogrenciEkle_Button_Click(object sender, EventArgs e)
        {
            OgrenciEkle oe = new OgrenciEkle();
            oe.ShowDialog();
        }
        private void kitapEkle_Button_Click(object sender, EventArgs e)
        {
            KitapEkle ke = new KitapEkle();
            ke.ShowDialog();
        }
        
        private void iade_Button_Click (object sender, EventArgs e)
        {

            DateTime bugunTarih = DateTime.Now;


            int selectedIndex = -1;
            if (listView.SelectedItems.Count > 0)
            {
                selectedIndex = listView.Items.IndexOf(listView.SelectedItems[0]);
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("Listeden Bir Şey Seçilmesi Lazım!");
                return;
            }
            IadeKitapOgr iade = new IadeKitapOgr()
            {
                KitapMi = this.kitapMi
            };
            if (kitapMi)
            {
                
                iade.Kitap_Id = listKitap_Id[selectedIndex];
                
                if (kitapManager.KitapRaftaMi(iade.Kitap_Id) == true)
                {
                    MessageBox.Show("Kitap zaten Kütüphanede");
                    return;
                }
                else
                {
                    int kitap_Id = listKitap_Id[selectedIndex];
                    kitap = iadeManager.GetKitapById(kitap_Id);
                    int ogrId = iadeManager.GetOgrenciIdByKitapId(kitap_Id);
                    DialogResult result = MessageBox.Show(kitap.KitapAdi + " kitabı iade edilecektir, Onaylıyor musunuz?", "UYARI", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        if (iadeManager.AddOgrKitap(iade.Kitap_Id, kitap_Id))
                            if (!iadeManager.UpdateKitapRaftaMi(iade.Kitap_Id, 1))
                                if(iadeManager.UpdateTeslimBilgisi(kitap_Id, ogrId, bugunTarih))
                                    MessageBox.Show("Başarılı");
                }
            }
           
            ara_Button_Click(null, null);
        }
        private void ara_Button_Click(object sender, EventArgs e)
        {
            if (aramaTur_ComboBox.SelectedIndex == 0)
            {
                ColumnKitap();
                List<Kitaplar> listKitaplar = kitapManager.KitapAdinaGoreGetir(ara_TextBox.Text);
                ListKitap_IdDoldur(listKitaplar);
                for (int i = 0; i < listKitaplar.Count; i++)
                {
                    Kitaplar kitap = listKitaplar[i];
                    string rafBilgisi = "";
                    if (kitap.RaftaMi == 1)
                        rafBilgisi = "evet";
                    else
                        rafBilgisi = "hayır";
                    var item1 = new ListViewItem(new[] { kitap.BarkodNo, kitap.KitapAdi, kitap.KitapYazari, rafBilgisi });
                    listView.Items.Add(item1);
                }


            }
            else if (aramaTur_ComboBox.SelectedIndex == 1) //öğrenci ad
            {
                ColumnOgrenci();
                List<Ogrenciler> listOgrenciler = ogrenciManager.AdaGoreOgrenciGetir(ara_TextBox.Text);
                ListOgrenci_IdDoldur(listOgrenciler);

                for (int i = 0; i < listOgrenciler.Count; i++)
                {
                    Ogrenciler ogrenciler = listOgrenciler[i];
                    var item1 = new ListViewItem(new[] { ogrenciler.Ad, ogrenciler.Soyad, ogrenciler.TelNo });
                    listView.Items.Add(item1);
                }
            }
            else if (aramaTur_ComboBox.SelectedIndex == 2)//barkod no
            {
                ColumnKitap();
                List<Kitaplar> listKitaplar = kitapManager.BarkodaGoreGetir(ara_TextBox.Text);
                ListKitap_IdDoldur(listKitaplar);

                for (int i = 0; i < listKitaplar.Count; i++)
                {
                    Kitaplar kitap = listKitaplar[i];
                    string rafBilgisi = "";
                    if (kitap.RaftaMi == 1)
                        rafBilgisi = "evet";
                    else
                        rafBilgisi = "hayır";
                    var item1 = new ListViewItem(new[] { kitap.BarkodNo, kitap.KitapAdi, kitap.KitapYazari, rafBilgisi });
                    listView.Items.Add(item1);
                }

            }
            else if (aramaTur_ComboBox.SelectedIndex == 3) // yazar
            {
                ColumnKitap();
                List<Kitaplar> listKitaplar = kitapManager.YazaraGoreGetir(ara_TextBox.Text);
                ListKitap_IdDoldur(listKitaplar);

                for (int i = 0; i < listKitaplar.Count; i++)
                {
                    Kitaplar kitap = listKitaplar[i];
                    string rafBilgisi = "";
                    if (kitap.RaftaMi == 1)
                        rafBilgisi = "evet";
                    else
                        rafBilgisi = "hayır";
                    var item1 = new ListViewItem(new[] { kitap.BarkodNo, kitap.KitapAdi, kitap.KitapYazari, rafBilgisi });
                    listView.Items.Add(item1);
                }
            }
        }
        private void ara_TextBox_Click(object sender, EventArgs e)
        {
            if (silindiMi == false)
            {
                ara_TextBox.Text = "";
                silindiMi = true;
            }
        }
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (listView.SelectedItems.Count > 0)
            {
                selectedIndex = listView.Items.IndexOf(listView.SelectedItems[0]);
            }

            if (selectedIndex == -1)
                return;

            if (kitapMi)
            {
                int Kitap_Id = listKitap_Id[selectedIndex];
                KitapDetay kitapDetay = new KitapDetay(Kitap_Id);
                kitapDetay.ShowDialog();
                ara_Button_Click(null, null);
            }
            else
            {
                int Ogrenci_Id = listOgrenci_Id[selectedIndex];
                OgrenciDetay ogrenciDetay = new OgrenciDetay(Ogrenci_Id);
                ogrenciDetay.ShowDialog();
                ara_Button_Click(null, null);
            }
        }
        private void odunc_Button_Click (object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (listView.SelectedItems.Count > 0)
            {
                selectedIndex = listView.Items.IndexOf(listView.SelectedItems[0]);
            }
            if (selectedIndex == -1)
            {
                MessageBox.Show("Listeden Bir Şey Seçilmesi Lazım!");
                return;
            }

            OduncKitapOgr odunc = new OduncKitapOgr()
            {
                KitapMi = this.kitapMi
            };

            if (kitapMi)
            {
                odunc.Kitap_Id = listKitap_Id[selectedIndex];
                if (kitapManager.KitapRaftaMi(odunc.Kitap_Id) == false)
                {
                    MessageBox.Show("Kitap Rafta Değil");
                    return;
                }
            }
            else
            {
                odunc.Ogrenci_Id = listOgrenci_Id[selectedIndex];
            }
            OduncVer ov = new OduncVer(odunc);
            ov.ShowDialog();
            ara_Button_Click(null, null);
        }
    }
}
