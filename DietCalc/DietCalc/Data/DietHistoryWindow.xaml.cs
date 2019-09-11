using System;
using System.Windows;
using DietCalc.Configuration;


namespace DietCalc.Data
{
    /// <summary>
    /// Logika interakcji dla klasy DietHistoryWindow.xaml
    /// </summary>
    public partial class DietHistoryWindow : Window
    {
        public DietHistoryWindow()
        {
            try
            {
                InitializeComponent();
                gridTable.ItemsSource = MenuParameters.dietList.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.ToString());
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MenuParameters.dietList.Clear();
            gridTable.ItemsSource = null;
        }
    }
}
