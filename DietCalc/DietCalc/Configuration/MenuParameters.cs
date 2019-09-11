using System;
using System.Windows.Media.Imaging;
using System.Data;

namespace DietCalc.Configuration
{
    internal static class MenuParameters
    {
        internal static DataTable dietList = new DataTable();
        internal static BitmapImage imageMenu = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\image.jpg"));
    }
}
