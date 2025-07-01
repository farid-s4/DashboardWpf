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

namespace Dashboard.Moduls
{
    /// <summary>
    /// Interaction logic for TaskModules.xaml
    /// </summary>
    public partial class TaskModules : UserControl
    {

        public event Action? ReturnRequested;

        public TaskModules()
        {
            InitializeComponent();
            DataContext = new TaskViewModels();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ReturnRequested?.Invoke();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
