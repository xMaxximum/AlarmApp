using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AlarmApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            DataContext = viewModel;

            DispatcherTimer timer = new();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (AlarmModel alarm in MainWindowViewModel.GetAlarms())
            {
                alarm.Date = alarm.Date.Subtract(TimeSpan.FromSeconds(1));
            }

            // Alarms_DataGrid.Items.Refresh();

            // CommandManager.InvalidateRequerySuggested();
        }



        private void AddAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            AddAlarm window = new();
            window.ShowDialog();
        }
    }

    public class MainWindowViewModel : ObservableObject
    {
        private static List<AlarmModel> _alarms = new();

        public List<AlarmModel> Alarms { get => _alarms; set => SetProperty(ref _alarms, value); }

        public void AddAlarm(AlarmModel alarm)
        {
            alarm.Id = (uint)(_alarms.Any() ? _alarms.Count + 1 : 0);
            Alarms.Add(alarm);
        }


        public static List<AlarmModel> GetAlarms()
        {
            return _alarms;
        }
    }
}
