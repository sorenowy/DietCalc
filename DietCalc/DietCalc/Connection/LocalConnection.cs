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
            using (var connection = new SQLiteConnection(LocalParameters.DBPath))
            using (var sqladapter = new SQLiteDataAdapter(LocalParameters.localSelectQuery, connection))
            {
                connection.Open();
                sqladapter.Fill(MenuParameters.dietList);
            }
        }
        public void LocalAddRecord()
        {
            using (var connection = new SQLiteConnection(LocalParameters.DBPath))
            using (SQLiteCommand sqlcommand = new SQLiteCommand(LocalParameters.localInsertQuery, connection))
            {
                connection.Open();
                sqlcommand.Parameters.AddWithValue("@Name", LocalParameters.username);
                sqlcommand.Parameters.AddWithValue("@Bmr", LocalParameters.BMRAmount);
                sqlcommand.Parameters.AddWithValue("@Tdee", LocalParameters.TDEEAmount);
                sqlcommand.Parameters.AddWithValue("@Protein", LocalParameters.proteinAmount);
                sqlcommand.Parameters.AddWithValue("@Carbs", LocalParameters.carbsAmount);
                sqlcommand.Parameters.AddWithValue("@Fats", LocalParameters.fatsAmount);
                sqlcommand.Parameters.AddWithValue("@DateT", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                sqlcommand.ExecuteNonQuery();
            }
        }
    }
}
