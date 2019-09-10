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
using DietCalc.Connection;
using DietCalc.Logs;

namespace DietCalc.Data
{
    /// <summary>
    /// Logika interakcji dla klasy MacroCalculatorWindow.xaml
    /// </summary>
    public partial class MacroCalculatorWindow : Window
    {
        private string _dietType;
        MacroCalculator macroCalc = new MacroCalculator();
        LocalConnection localCon = new LocalConnection();
        public MacroCalculatorWindow()
        {
            try
            {
                InitializeComponent();
                cbxSplitMacros.Items.Add("Recommended 30%P/40%C/30%F");
                cbxSplitMacros.Items.Add("High Carbohydrates 30%P/50%C/20%F");
                cbxSplitMacros.Items.Add("Low Carb 40%P/20%C/40%F");
                cbxSplitMacros.Items.Add("Ketogenic 20%P/5%C/75%F");
                cbxSplitMacros.Items.Add("Custom");
                txtBoxCal.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount, 2));
                sliderProtein.Visibility = Visibility.Hidden;
                sliderCarbs.Visibility = Visibility.Hidden;
                sliderFats.Visibility = Visibility.Hidden;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during loading!", "Error");
                LogWriter.LogWrite(e.ToString());
            }
        }

        private void CbxSplitMacros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _dietType = Convert.ToString(cbxSplitMacros.SelectedItem);
            try
            {
                switch (_dietType)
                {
                    case "Recommended 30%P/40%C/30%F":
                        macroCalc.SelectDiet(cbxSplitMacros.SelectedIndex);
                        txtBoxProtein.Text = Convert.ToString(Math.Round(LocalParameters.proteinAmount, 1));
                        txtBoxCarbs.Text = Convert.ToString(Math.Round(LocalParameters.carbsAmount, 1));
                        txtBoxFats.Text = Convert.ToString(Math.Round(LocalParameters.fatsAmount, 1));
                        break;
                    case "High Carbohydrates 30%P/50%C/20%F":
                        goto case "Recommended 30%P/40%C/30%F";
                    case "Low Carb 40%P/20%C/40%F":
                        goto case "Recommended 30%P/40%C/30%F";
                    case "Ketogenic 20%P/5%C/75%F":
                        goto case "Recommended 30%P/40%C/30%F";
                    case "Custom":
                        macroCalc.SelectDiet(cbxSplitMacros.SelectedIndex);
                        sliderProtein.Visibility = Visibility.Visible;
                        sliderCarbs.Visibility = sliderProtein.Visibility;
                        sliderFats.Visibility = sliderProtein.Visibility;
                        txtBoxPercent.Text = Convert.ToString(Math.Round(LocalParameters.MacroPercentage, 1));
                        txtBoxProtein.Text = Convert.ToString(Math.Round(LocalParameters.proteinAmount, 1));
                        txtBoxCarbs.Text = Convert.ToString(Math.Round(LocalParameters.carbsAmount, 1));
                        txtBoxFats.Text = Convert.ToString(Math.Round(LocalParameters.fatsAmount, 1));
                        break;
                }
                LogWriter.LogWrite($"Loaded {_dietType}, to calculation");
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message);
                LogWriter.LogWrite(fe.ToString());
            }
        }
        private void SliderProtein_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LocalParameters.proteinAmount = sliderProtein.Value;
            macroCalc.Calculate();
            txtBoxPercent.Text = Convert.ToString(Math.Round(LocalParameters.MacroPercentage, 1));
        }
        private void SliderCarbs_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LocalParameters.carbsAmount = sliderCarbs.Value;
            macroCalc.Calculate();
            txtBoxPercent.Text = Convert.ToString(Math.Round(LocalParameters.MacroPercentage, 1));
        }
        private void SliderFats_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LocalParameters.fatsAmount = sliderFats.Value;
            macroCalc.Calculate();
            txtBoxPercent.Text = Convert.ToString(Math.Round(LocalParameters.MacroPercentage, 1));
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                LocalParameters.username = txtBoxName.Text;
                localCon.LocalAddRecord();
                LocalParameters.RestoreParameters();
                LogWriter.LogWrite("Added to SQLite DB.");
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
                LogWriter.LogWrite(g.ToString());
            }
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LocalParameters.RestoreParameters();
        }
    }
}
