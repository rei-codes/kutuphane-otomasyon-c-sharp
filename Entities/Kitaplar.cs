using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{   
    public class Kitaplar
    {
        public int Id { get; set; }
        public string BarkodNo { get; set; }
        public string KitapAdi { get; set; }
        public string KitapYazari { get; set; }
        public int Tur_Id { get; set; }
        public string YayinEvi { get; set; }
        public string SayfaSayisi { get; set; }
        public int Dil_Id { get; set; }
        public string BasimYili { get; set; }
        public int RaftaMi { get; set; }
        public string DilAdi  { get; set; }
        public string TurAdi { get; set; }
        public int TUR_SAYISI { get; set; }
    }
}
