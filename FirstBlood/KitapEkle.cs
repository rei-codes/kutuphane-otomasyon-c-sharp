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
    public partial class KitapEkle : Form
    {

        KitapManager kitapManager;
        TurManager turManager;
        DilManager dilManager;
        List<int> listTur_Id;
        List<int> listDil_Id;
        public KitapEkle()
        {
            listTur_Id = new List<int>();
            listDil_Id = new List<int>();

            kitapManager = new KitapManager();
            turManager = new TurManager();
            dilManager = new DilManager();

            InitializeComponent();

            barkodNo_Textbox.Text = kitapManager.BarkodOlustur();

            List<Turler> listTurler = turManager.GetTurler();
            turu_Combobox.Items.Clear();

            for (int i = 0; i < listTurler.Count; i++)
            {
                Turler turler = listTurler[i];
                listTur_Id.Add(turler.Id);
                turu_Combobox.Items.Add(turler.TurAdi);

            }

            if (turu_Combobox.Items.Count > 0)
                turu_Combobox.SelectedIndex = 0;

            List<Diller> listDiller = dilManager.GetDiller();
            dil_Combobox.Items.Clear();

            for(int i=0;i< listDiller.Count;i++)
            {
                Diller diller = listDiller[i];
                listDil_Id.Add(diller.Id);
                dil_Combobox.Items.Add(diller.DilAdi);
            }

            if (dil_Combobox.Items.Count > 0)
                dil_Combobox.SelectedIndex = 0;
        }

        private void ekle_Button_Click(object sender, EventArgs e)
        {

            if(turu_Combobox.SelectedIndex == -1 || dil_Combobox.SelectedIndex==-1)
            {
                MessageBox.Show("Tür yada Dil Seçilmedi!");
                return;
            }

            int turId = listTur_Id[turu_Combobox.SelectedIndex];
            int dilId = listDil_Id[dil_Combobox.SelectedIndex];

            List<string> sonuc = kitapManager.KitapEkle(barkodNo_Textbox.Text, isim_TextBox.Text, yazar_Textbox.Text, turId, yayinevi_Textbox.Text, sayfaSayisi_Textbox.Text, dilId, basimYili_Textbox.Text);

            if (sonuc.Count == 0)
            {
                barkodNo_Textbox.Text = "";
                isim_TextBox.Text = "";
                yazar_Textbox.Text = "";
                basimYili_Textbox.Text = "";
                yayinevi_Textbox.Text = "";
                sayfaSayisi_Textbox.Text = "";
                MessageBox.Show("Başarılı");

                this.Close();
            }
            else
            {
                for (int i = 0; i < sonuc.Count; i++)
                    MessageBox.Show(sonuc[i]);
            }


        }
    }
}
