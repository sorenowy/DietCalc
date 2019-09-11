using System;
using System.IO;
using System.Windows;
using DietCalc.Configuration;

namespace DietCalc.Logs
{
    public static class LogWriter
    {
        public static void LogWrite(string logMessage)
        {
            if (!Directory.Exists(LocalParameters.logPath))
            {
                Directory.CreateDirectory(LocalParameters.logPath);
            }
            if(!File.Exists(LocalParameters.logPath + DateTime.Now.ToShortDateString() + "-" + Environment.MachineName + ".txt"))
            {
                File.Create(LocalParameters.logPath + DateTime.Now.ToShortDateString() + "-" + Environment.MachineName + ".txt").Close();
            }
            try
            {
                using (var writer = File.AppendText(LocalParameters.logPath + DateTime.Now.ToShortDateString() + "-" + Environment.MachineName + ".txt"))
                {
                    AppendLog(logMessage, writer);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void AppendLog(string logMessage,TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\n");
                txtWriter.WriteLine("{0},{1},{2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), logMessage);
                txtWriter.Close();
            }
            catch (Exception e)
            {
                LogWrite(e.ToString());
            }
        }
    }
}
