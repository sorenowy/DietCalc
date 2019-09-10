using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using DietCalc.Configuration;
using DietCalc.Logs;

namespace DietCalc.Connection
{
    public class LocalConnection
    {
        public void InitializeConnection()
        {
            try
            {
                using (var connection = new SQLiteConnection(LocalParameters.DBPath))
                using (var sqladapter = new SQLiteDataAdapter(LocalParameters.localSelectQuery, connection))
                {
                    connection.Open();
                    sqladapter.Fill(MenuParameters.dietList);
                }
                LogWriter.LogWrite($"Loaded DataTable from SQL, to Grid");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                LogWriter.LogWrite(e.ToString());
            }
        }
        public void LocalAddRecord()
        {
            try
            {
                using (var connection = new SQLiteConnection(LocalParameters.DBPath))
                using (SQLiteCommand sqlcommand = new SQLiteCommand(LocalParameters.localInsertQuery, connection))
                {
                    connection.Open();
                    sqlcommand.Parameters.AddWithValue("@Name", LocalParameters.username);
                    sqlcommand.Parameters.AddWithValue("@Bmr", Math.Round(LocalParameters.BMRAmount, 2));
                    sqlcommand.Parameters.AddWithValue("@Tdee", Math.Round(LocalParameters.TDEEAmount, 2));
                    sqlcommand.Parameters.AddWithValue("@Protein", Math.Round(LocalParameters.proteinAmount, 2));
                    sqlcommand.Parameters.AddWithValue("@Carbs", Math.Round(LocalParameters.carbsAmount, 2));
                    sqlcommand.Parameters.AddWithValue("@Fats", Math.Round(LocalParameters.fatsAmount, 2));
                    sqlcommand.Parameters.AddWithValue("@DateT", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    sqlcommand.ExecuteNonQuery();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
                LogWriter.LogWrite(f.ToString());
            }
        }
    }
}
