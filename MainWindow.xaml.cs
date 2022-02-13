using System;
using System.Windows;
using System.Windows.Threading;

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

            InitializeComponent();
            DataContext = viewModel;

            DispatcherTimer timer = new();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (AlarmModel alarm in viewModel.Alarms)
            {
                alarm.Date = alarm.Date.Subtract(TimeSpan.FromSeconds(1));
            }
        }

        private void AddAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            AddAlarm window = new(viewModel);
            window.ShowDialog();
        }
    }
}
