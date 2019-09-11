using System;
using DietCalc.Logs;

namespace DietCalc.Configuration
{
    internal static class LocalParameters
    {
        internal static string username { get; set; }
        internal static string logPath = Environment.CurrentDirectory + @"\Logs\ProgramLog\";
        internal static string DBPath = "Data Source=" + Environment.CurrentDirectory + @"\Connection\DietDatabase.db";
        internal static string pdfPath = Environment.CurrentDirectory + @"\Logs\PDFPrint\";
        internal static string pdfFile = Environment.CurrentDirectory + "\\Logs\\PDFPrint\\" + DateTime.Now.ToShortDateString() + ".pdf";
        internal static string logoPath = Environment.CurrentDirectory + @"\Images\Logo.png";
        internal static string localSelectQuery = "SELECT Name AS [Person Name],Bmr AS [BMR Calories], Tdee AS [TDEE Calories], Protein AS [Protein (g)], Carbs AS [Carbs (g)],Fats AS [Fats (g)], DateT as [Date of creation] FROM DietTable";
        internal static string localInsertQuery = "INSERT INTO DietTable (Name,Bmr,Tdee,Protein,Carbs,Fats,DateT) VALUES (@Name,@Bmr,@Tdee,@Protein,@Carbs,@Fats,@DateT)";
        internal static double maleFactor = 5;
        internal static double femaleFactor = -161;
        internal static double proteinAmount { get; set; }
        internal static double carbsAmount { get; set; }
        internal static double fatsAmount { get; set; }
        internal static int ageVal { get; set; }
        internal static double weightVal { get; set; }
        internal static double heightVal { get; set; }
        internal static double exerciseFactor { get; set; }
        internal static double targetFactor { get; set; }
        internal static double BMRAmount { get; set; }
        internal static double TDEEAmount { get; set; }
        internal static double MacroPercentage { get; set; }
        internal static void RestoreParameters()
        {
            proteinAmount = 0;
            carbsAmount = 0;
            fatsAmount = 0;
            ageVal = 0;
            weightVal = 0;
            heightVal = 0;
            BMRAmount = 0;
            TDEEAmount=0;
            username=string.Empty;
            LogWriter.LogWrite("Restored parameters");
        }
    }
}
