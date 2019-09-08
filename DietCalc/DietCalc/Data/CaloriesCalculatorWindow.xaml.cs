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
        }

        private void CbxSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CaloriesCalculator caloriesCalc = new CaloriesCalculator();
            _sexType = Convert.ToString(cbxSex.SelectedItem);
            switch (_sexType)
            {
                case "Male":
                    caloriesCalc.SelectSexFactor(cbxSex.SelectedIndex);
                    txtboxBMR.Text = Convert.ToString(LocalParameters.BMRAmount);
                    break;
                case "Female":
                    caloriesCalc.SelectSexFactor(cbxSex.SelectedIndex);
                    txtboxBMR.Text = Convert.ToString(LocalParameters.BMRAmount);
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
                    txtboxBMR.Text = Convert.ToString(LocalParameters.BMRAmount);
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
                    LocalParameters.weightVal = Convert.ToInt32(txtboxWeight.Text);
                    txtboxBMR.Text = Convert.ToString(LocalParameters.BMRAmount);
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
                    LocalParameters.heightVal = Convert.ToInt32(txtboxHeight.Text);
                    txtboxBMR.Text = Convert.ToString(LocalParameters.BMRAmount);
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }
    }
}
