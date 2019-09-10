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
using DietCalc.Connection;
using DietCalc.Logs;

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
            mainMenuImage.Source = MenuParameters.imageMenu;
            LogWriter.LogWrite("Program initialized successfully");
        }
        private void buttonCaloriesCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CaloriesCalculatorWindow calcWin = new CaloriesCalculatorWindow();
                calcWin.ShowDialog();
                LogWriter.LogWrite("Opened the calorie calculator window.");
            }
            catch (Exception calerr)
            {
                LogWriter.LogWrite(calerr.ToString());
            }
        }
        private void buttonMacro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MacroCalculatorWindow macroWin = new MacroCalculatorWindow();
                macroWin.ShowDialog();
                LogWriter.LogWrite("Opened the macros calculator window.");
            }
            catch (Exception f)
            {
                LogWriter.LogWrite(f.ToString());
            }
        }
        private void buttonHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LocalConnection localCon = new LocalConnection();
                DietHistoryWindow dietWin = new DietHistoryWindow();
                localCon.InitializeConnection();
                dietWin.ShowDialog();
                LogWriter.LogWrite("Opened the macros calculator window.");
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
                LogWriter.LogWrite(g.ToString());
            }
        }
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("Thanks for using DietCalc 2019.", "ByeBye");
            LogWriter.LogWrite("Program Closed.");
        }
    }
}
