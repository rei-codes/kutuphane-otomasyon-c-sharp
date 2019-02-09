using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ConnectionString
    {
        public static string GetConnectionString()
        {
            return @"Provider=Microsoft.ACE.Oledb.12.0;Data Source=..\..\..\Database.accdb";
        }
    }
}
