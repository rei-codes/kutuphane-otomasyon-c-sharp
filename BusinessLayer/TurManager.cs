using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{   
    public class TurManager
    {
        DbSelect dbSelect;

        public TurManager()
        {
            dbSelect = new DbSelect();
        }

        public List<Turler> GetTurler()
        {
            return dbSelect.GetTurler();
        }

    }
}
