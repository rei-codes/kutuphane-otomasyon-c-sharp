using BusinessLayer;
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
    public partial class OgrenciEkle : Form
    {
        OgrenciManager ogrenciManager;
        public OgrenciEkle()
        {
            ogrenciManager = new OgrenciManager();
            InitializeComponent();
        }
        private void ekle_Button_Click(object sender, EventArgs e)
        {
            List<string> sonuc = ogrenciManager.AddOgrenci(tc_Textbox.Text, ad_Textbox.Text, 
                soyad_Textbox.Text, eposta_Textbox.Text, tel_Textbox.Text);

            if (sonuc.Count == 0)
            {
                MessageBox.Show("Başarılı");
                this.Close();
            }
            else
            {
                for (int i = 0; i < sonuc.Count; i++)
                {
                    MessageBox.Show(sonuc[i]);
                }
            }
        }
    }
}
