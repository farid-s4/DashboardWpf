using Dashboard.Moduls;
using Dashboard.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dashboard
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowMainMenu();
            DataContext = new TaskViewModels();
        }

        private void ShowMainMenu()
        {
            MainContent.Content = null;

            NavigationPanel.Visibility = Visibility.Visible;
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            var taskModule = new TaskModules();
            taskModule.ReturnRequested += new Action(HandleReturn);

            MainContent.Content = taskModule;
            NavigationPanel.Visibility = Visibility.Collapsed;
        }
        private void HandleReturn()
        {
            ShowMainMenu();
        }

        private void FinanceButton_Click(object sender, RoutedEventArgs e)
        {
            var financeModul = new FinanceRecordModul();
            financeModul.ReturnRequested += new Action(HandleReturn);
            MainContent.Content = financeModul;
            NavigationPanel.Visibility = Visibility.Collapsed;
        }
    }
}