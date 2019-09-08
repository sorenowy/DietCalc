using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DietCalc.Configuration;
using DietCalc.Data;

namespace DietCalc
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CaloriesCalculatorWindow calcWin = new CaloriesCalculatorWindow();
            calcWin.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MacroCalculatorWindow macroWin = new MacroCalculatorWindow();
            macroWin.ShowDialog();
        }
    }
}
