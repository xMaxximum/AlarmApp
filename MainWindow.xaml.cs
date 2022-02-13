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
            try
            {
                foreach (AlarmViewModel alarm in viewModel.Alarms)
                {
                    alarm.Date = alarm.Date.Subtract(TimeSpan.FromSeconds(1));

                    if (alarm.Date.CompareTo(DateTime.Now) == 0 || alarm.Date.CompareTo(DateTime.Now) < 0)
                    {
                        viewModel.Alarms.Remove(alarm);
                        var alarmWindow = new AlarmWindow();
                        alarmWindow.Show();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void AddAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            AddAlarm window = new(viewModel);
            window.ShowDialog();
        }
    }
}
