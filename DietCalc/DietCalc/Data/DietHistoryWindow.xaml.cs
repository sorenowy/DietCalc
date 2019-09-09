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

namespace DietCalc.Data
{
    /// <summary>
    /// Logika interakcji dla klasy DietHistoryWindow.xaml
    /// </summary>
    public partial class DietHistoryWindow : Window
    {
        public DietHistoryWindow()
        {
            InitializeComponent();
            gridTable.ItemsSource = MenuParameters.dietList.DefaultView;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MenuParameters.dietList.Clear();
            gridTable.ItemsSource = null;
        }
    }
}
