using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    internal class Connection
    {
        public static string getConnectionString() {
           return "server=montero.database.windows.net;database=PersonaDB;uid=prueba;pwd=.1234abcde;trustServerCertificate = true;";
        }
    }
}
