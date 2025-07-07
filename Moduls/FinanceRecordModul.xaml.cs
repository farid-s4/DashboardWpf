using Dashboard.ViewModels;
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
using Dashboard.Services;
namespace Dashboard.Moduls
{
    /// <summary>
    /// Interaction logic for FinanceRecordModul.xaml
    /// </summary>
    public partial class FinanceRecordModul : UserControl
    {
        public event Action? ReturnRequested;

        public FinanceRecordModul()
        {
            InitializeComponent();
            DataContext = new FinanceRecordViewModel();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnRequested?.Invoke();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
