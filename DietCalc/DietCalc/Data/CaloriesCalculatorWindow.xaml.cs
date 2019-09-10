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
using DietCalc.Data;
using DietCalc.Logs;

namespace DietCalc.Data
{
    /// <summary>
    /// Logika interakcji dla klasy CaloriesCalculatorWindow.xaml
    /// </summary>
    public partial class CaloriesCalculatorWindow : Window
    {
        private string _sexType;
        private string _activityType;
        private string _targetType;
        CaloriesCalculator caloriesCalc = new CaloriesCalculator();
        public CaloriesCalculatorWindow()
        {
            InitializeComponent();
            cbxSex.Items.Add("Female");
            cbxSex.Items.Add("Male");
            cbxDiet.Items.Add("Bulk +10%");
            cbxDiet.Items.Add("Maintain/Recompose +0%");
            cbxDiet.Items.Add("Cut -15%");
            cbxActivity.Items.Add("Sedentary");
            cbxActivity.Items.Add("Light Activity 1-2days/week");
            cbxActivity.Items.Add("Moderate Activity 3-5d/week");
            cbxActivity.Items.Add("Heavy Activity 5d+/week");
            cbxActivity.Items.Add("Athlete - 2x/day");
            txtboxBodyFat.Visibility = Visibility.Hidden;
        }

        private void CbxSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _sexType = Convert.ToString(cbxSex.SelectedItem);
            switch (_sexType)
            {
                case "Male":
                    caloriesCalc.SelectSexFactor(cbxSex.SelectedIndex);
                    txtboxBMR.Text = Convert.ToString(Math.Round(LocalParameters.BMRAmount,2));
                    break;
                case "Female":
                    goto case "Male";
            }
        }
        private void CbxActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _activityType = Convert.ToString(cbxActivity.SelectedItem);
            switch (_activityType)
            {
                case "Sedentary":
                    caloriesCalc.SelectActivityFactor(cbxActivity.SelectedIndex);
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount, 2));
                    break;
                case "Light Activity 1-2days/week":
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount, 2));
                    goto case "Sedentary";
                case "Moderate Activity 3-5d/week":
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount, 2));
                    goto case "Sedentary";
                case "Heavy Activity 5d+/week":
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount, 2));
                    goto case "Sedentary";
                case "Athlete - 2x/day":
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount, 2));
                    goto case "Sedentary";
            }
        }
        private void CbxDiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _targetType = Convert.ToString(cbxDiet.SelectedItem);
            switch (_targetType)
            {
                case "Bulk +10%":
                    caloriesCalc.SelectTargetFactor(cbxDiet.SelectedIndex);
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount + LocalParameters.targetFactor, 2));
                    break;
                case "Maintain/Recompose +0%":
                    caloriesCalc.SelectTargetFactor(cbxDiet.SelectedIndex);
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount + LocalParameters.targetFactor, 2));
                    break;
                case "Cut -15%":
                    caloriesCalc.SelectTargetFactor(cbxDiet.SelectedIndex);
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount - LocalParameters.targetFactor, 2));
                    break;
            }
        }
        private void TxtboxAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtboxAge.Text == string.Empty)
                {
                    MessageBox.Show("Wprowadź wiek w celu policzenia!");
                }
                else
                {
                    LocalParameters.ageVal = Convert.ToInt32(txtboxAge.Text);
                    if (cbxActivity.SelectedIndex >= 0)
                    {
                        caloriesCalc.CalculateBaseCal();
                        caloriesCalc.CalculateDailyCal();
                    }
                    else
                    {
                        caloriesCalc.CalculateBaseCal();
                    }
                    txtboxBMR.Text = Convert.ToString(Math.Round(LocalParameters.BMRAmount,2));
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount,2));
                }
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
        }
        private void TxtboxWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtboxWeight.Text == string.Empty)
                {
                    MessageBox.Show("Wprowadź wagę w celu policzenia!");
                }
                else
                {
                    LocalParameters.weightVal = Convert.ToDouble(txtboxWeight.Text);
                    if (cbxActivity.SelectedIndex >= 0)
                    {
                        caloriesCalc.CalculateBaseCal();
                        caloriesCalc.CalculateDailyCal();
                    }
                    else
                    {
                        caloriesCalc.CalculateBaseCal();
                    }
                    txtboxBMR.Text = Convert.ToString(Math.Round(LocalParameters.BMRAmount,2));
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount,2));
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void TxtboxHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtboxHeight.Text == string.Empty)
                {
                    MessageBox.Show("Wprowadź wzrost w celu policzenia!");
                }
                else
                {
                    LocalParameters.heightVal = Convert.ToDouble(txtboxHeight.Text);
                    if (cbxActivity.SelectedIndex >= 0)
                    {
                        caloriesCalc.CalculateBaseCal();
                        caloriesCalc.CalculateDailyCal();
                    }
                    else
                    {
                        caloriesCalc.CalculateBaseCal();
                    }
                    txtboxBMR.Text = Convert.ToString(Math.Round(LocalParameters.BMRAmount,2));
                    txtboxTDEE.Text = Convert.ToString(Math.Round(LocalParameters.TDEEAmount,2));
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (cbxDiet.SelectedIndex == 0)
            {
                LocalParameters.TDEEAmount += LocalParameters.targetFactor;
            }
            else if (cbxDiet.SelectedIndex==2)
            {
                LocalParameters.TDEEAmount -= LocalParameters.targetFactor;
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LocalParameters.RestoreParameters();
        }
    }
}
