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
using System.Windows.Shapes;
using DietCalc.Configuration;

namespace DietCalc.Data
{
    /// <summary>
    /// Logika interakcji dla klasy MacroCalculatorWindow.xaml
    /// </summary>
    public partial class MacroCalculatorWindow : Window
    {
        private string _dietType;
        MacroCalculator macroCalc = new MacroCalculator();
        public MacroCalculatorWindow()
        {
            InitializeComponent();
            cbxSplitMacros.Items.Add("Recommended 30%P/40%C/30%F");
            cbxSplitMacros.Items.Add("High Carbohydrates 30%P/50%C/20%F");
            cbxSplitMacros.Items.Add("Low Carb 40%P/20%C/40%F");
            cbxSplitMacros.Items.Add("Ketogenic 20%P/5%C/75%F");
            txtBoxCal.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount,2));
        }

        private void CbxSplitMacros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _dietType = Convert.ToString(cbxSplitMacros.SelectedItem);
            switch (_dietType)
            {
                case "Recommended 30%P/40%C/30%F":
                    macroCalc.SelectDiet(cbxSplitMacros.SelectedIndex);
                    txtBoxProtein.Text = Convert.ToString(Math.Round(LocalParameters.proteinAmount,1));
                    txtBoxCarbs.Text = Convert.ToString(Math.Round(LocalParameters.carbsAmount,1));
                    txtBoxFats.Text = Convert.ToString(Math.Round(LocalParameters.fatsAmount,1));
                    break;
                case "High Carbohydrates 30%P/50%C/20%F":
                    goto case "Recommended 30%P/40%C/30%F";
                case "Low Carb 40%P/20%C/40%F":
                    goto case "Recommended 30%P/40%C/30%F";
                case "Ketogenic 20%P/5%C/75%F":
                    goto case "Recommended 30%P/40%C/30%F";
            }
        }
    }
}
