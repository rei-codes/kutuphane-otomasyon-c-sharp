using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{   
    public class DilManager
    {
        DbSelect dbSelect;

        public DilManager()
        {
            dbSelect = new DbSelect();
        }
        
        public List<Diller> GetDiller()
        {
            return dbSelect.GetDiller();
        }

    }
}
