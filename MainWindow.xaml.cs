using System.Windows;

namespace AlarmApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;

        public MainWindow()
        {
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;

            InitializeComponent();

            Closing += OnClosing;
        }

        private void OnClosing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Dispose();
        }

        private void AddAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            AddAlarm window = new(viewModel);
            window.ShowDialog();
        }
    }
}
