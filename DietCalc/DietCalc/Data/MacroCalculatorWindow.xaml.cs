using System;
using System.Windows;
using System.Windows.Controls;
using DietCalc.Configuration;
using DietCalc.Connection;
using DietCalc.Logs;
using DietCalc.Print;

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
            try
            {
                LocalParameters.proteinAmount = sliderProtein.Value;
                macroCalc.Calculate();
                txtBoxPercent.Text = Convert.ToString(Math.Round(LocalParameters.MacroPercentage, 1));
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
                LogWriter.LogWrite(h.ToString());
            }
        }
        private void SliderCarbs_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                LocalParameters.carbsAmount = sliderCarbs.Value;
                macroCalc.Calculate();
                txtBoxPercent.Text = Convert.ToString(Math.Round(LocalParameters.MacroPercentage, 1));
            }
            catch (Exception j)
            {
                MessageBox.Show(j.Message);
                LogWriter.LogWrite(j.ToString());
            }
        }
        private void SliderFats_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                LocalParameters.fatsAmount = sliderFats.Value;
                macroCalc.Calculate();
                txtBoxPercent.Text = Convert.ToString(Math.Round(LocalParameters.MacroPercentage, 1));
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
                LogWriter.LogWrite(i.ToString());
            }
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
