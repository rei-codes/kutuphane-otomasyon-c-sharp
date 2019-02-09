using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{   
    public class OgrKitap
    {
        public int Id { get; set; }
        public int Kitap_Id { get; set; }
        public int Ogrenci_Id { get; set; }

        public DateTime TeslimTarihi { get; set; }
        public DateTime VerilisTarihi { get; set; }

        public int TeslimEttiMi { get; set; }

        public Kitaplar Kitap { get; set; }
        public Ogrenciler Ogrenci { get; set; }
    }
}

