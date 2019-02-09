using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{   
    public class BorcOdeme
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public int Miktar { get; set; }
        public int Ogrenci_Id { get; set; }
        public int OgrKitap_Id { get; set; }
    }
}
