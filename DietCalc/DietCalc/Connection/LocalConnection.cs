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
                sqlcommand.Parameters.AddWithValue("@Bmr", Math.Round(LocalParameters.BMRAmount,2));
                sqlcommand.Parameters.AddWithValue("@Tdee", Math.Round(LocalParameters.TDEEAmount,2));
                sqlcommand.Parameters.AddWithValue("@Protein", Math.Round(LocalParameters.proteinAmount,2));
                sqlcommand.Parameters.AddWithValue("@Carbs", Math.Round(LocalParameters.carbsAmount,2));
                sqlcommand.Parameters.AddWithValue("@Fats", Math.Round(LocalParameters.fatsAmount,2));
                sqlcommand.Parameters.AddWithValue("@DateT", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                sqlcommand.ExecuteNonQuery();
            }
        }
    }
}
