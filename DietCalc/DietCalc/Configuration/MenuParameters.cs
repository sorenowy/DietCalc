using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Data;
using DietCalc.Data;

namespace DietCalc.Configuration
{
    internal static class MenuParameters
    {
        internal static DataTable dietList = new DataTable();

        internal static CaloriesCalculator caloriesCalc = null;
        internal static MacroCalculator macroCalc = null;
        internal static BitmapImage imageMenu = new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Images\image.jpg"));
    }
}
