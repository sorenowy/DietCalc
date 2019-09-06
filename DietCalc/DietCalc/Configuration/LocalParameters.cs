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
    }
}
