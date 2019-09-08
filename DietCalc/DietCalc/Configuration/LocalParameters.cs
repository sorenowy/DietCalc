using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalc.Configuration
{
    internal static class LocalParameters
    {
        internal static string logPath = Environment.CurrentDirectory + @"\Logs\ProgramLog";
        internal static string DBPath = "Data Source=" + Environment.CurrentDirectory + @"\Connection\DietDatabase.db";
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
    }
}
