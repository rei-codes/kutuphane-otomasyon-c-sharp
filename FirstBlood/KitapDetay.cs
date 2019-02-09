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
    public partial class KitapDetay : Form
    {
        int Kitap_Id;
        Kitaplar kitap;

        KitapManager kitapManager = new KitapManager();
        TurManager turManager = new TurManager();
        DilManager dilManager = new DilManager();

        List<Diller> listDiller = new List<Diller>();
        List<Turler> listTurler = new List<Turler>();
        List<OgrKitap> listOgrKitap = new List<OgrKitap>();

        List<int> listOgrKitapId = new List<int>();
        List<int> listDilId = new List<int>();
        List<int> listTurId = new List<int>();
        
        public KitapDetay(int _Kitap_Id)
        {  
            Kitap_Id = _Kitap_Id;
            kitap = kitapManager.GetKitapById(Kitap_Id);

            listTurler = turManager.GetTurler();
            listDiller = dilManager.GetDiller();

            InitializeComponent();
           
            foreach (Diller dil in listDiller)
            {
                dili_Combobox.Items.Add(dil.DilAdi);
                listDilId.Add(dil.Id);

                if (dil.Id == kitap.Dil_Id)
                    dili_Combobox.SelectedIndex = dili_Combobox.Items.Count - 1;
            }

            foreach (Turler tur in listTurler)
            {
                turu_ComboBox.Items.Add(tur.TurAdi);
                listTurId.Add(tur.Id);

                if (tur.Id == kitap.Tur_Id)
                    turu_ComboBox.SelectedIndex = turu_ComboBox.Items.Count - 1;
            }

            no_Textbox.Text = kitap.BarkodNo;
            isim_Textbox.Text = kitap.KitapAdi;
            yazar_Textbox.Text = kitap.KitapYazari;
            basimYili_Textbox.Text = kitap.BasimYili;
            yayinevi_Textbox.Text = kitap.YayinEvi;
            if (kitap.RaftaMi == 1)
                rRafta.Checked = true;
            else
                rDisarda.Checked = true;

            dokum_Listview.FullRowSelect = true;

            dokum_Listview.Items.Clear();
            dokum_Listview.Clear();

            dokum_Listview.View = View.Details;
            
            dokum_Listview.Columns.Add("Durumu", 100);
            dokum_Listview.Columns.Add("Alan Kişi", 100);
            dokum_Listview.Columns.Add("Verildiği Tarih", 100);
            dokum_Listview.Columns.Add("Alınacak/Alındığı Tarih", 100);
            
            listOgrKitap = kitapManager.GetOgrKitapByKitapId(Kitap_Id);
            foreach (OgrKitap ogrKitap in listOgrKitap)
            {
                listOgrKitapId.Add(ogrKitap.Id);

                string durumu = "Durum";
                string teslimTarihi = "";
                DateTime dateTeslim;
                DateTime dateVerilis = ogrKitap.VerilisTarihi;
                DateTime bugunTarih = DateTime.Now;

                if (ogrKitap.TeslimEttiMi == 1)
                {
                    durumu = "Teslim Alındı";
                    teslimTarihi = ogrKitap.TeslimTarihi.ToShortDateString();
                }
                else
                {
                    dateTeslim = dateVerilis.AddDays(14);
                    teslimTarihi = dateTeslim.ToShortDateString();
                    if (bugunTarih > dateTeslim)
                    {
                        durumu = "Teslim Alınmadı . Teslim Süresi Geçti";
                    }
                    else
                    {
                        durumu = "Teslim Alınmadı. Teslim Süresine Var";
                    }
                }

                var item1 = new ListViewItem(new[] { durumu, ogrKitap.Ogrenci.Ad + " " +
                    ogrKitap.Ogrenci.Soyad, dateVerilis.ToShortDateString(), teslimTarihi });
                dokum_Listview.Items.Add(item1);

            }
            
        }


        private void guncelle_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Güncellemek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {

                int raftaMi = 0;
                if (rRafta.Checked)
                    raftaMi = 1;
    
                Kitaplar kitap = new Kitaplar()
                {
                    BarkodNo = no_Textbox.Text,
                    KitapAdi = isim_Textbox.Text,
                    KitapYazari = yazar_Textbox.Text,
                    BasimYili = basimYili_Textbox.Text,
                    Dil_Id = listDilId[dili_Combobox.SelectedIndex],
                    Id = this.Kitap_Id,
                    RaftaMi = raftaMi,
                    SayfaSayisi = this.kitap.SayfaSayisi,
                    Tur_Id = listTurId[turu_ComboBox.SelectedIndex],
                    YayinEvi = yayinevi_Textbox.Text
                };

                List<string> result = kitapManager.KitapGuncelle(kitap);

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

        private void sil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstiyor Musunuz?", "Uyarı", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                kitapManager.SilKitap(this.Kitap_Id);
                kitapManager.SilOgrKitap(this.Kitap_Id);
                this.Close();
            }
        }
    
    }
}
