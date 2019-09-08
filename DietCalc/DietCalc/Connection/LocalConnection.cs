using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DietCalc.Configuration;

namespace DietCalc.Connection
{
    public class LocalConnection
    {
        public void InitializeConnection()
        {
            using (var connection = new SQLiteConnection())
            using (var sqladapter = new SQLiteDataAdapter(LocalParameters.localSelectQuery, connection))
            {

            }
        }
    }
}
