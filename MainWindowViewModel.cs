using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlarmApp
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<AlarmViewModel> _alarms = new();
        public ObservableCollection<AlarmViewModel> Alarms
        {
            get => _alarms;
            set => SetProperty(ref _alarms, value);
        }

        public void AddAlarm(AlarmViewModel alarm)
        {
            alarm.Id = (uint)(_alarms.Any() ? _alarms.Count + 1 : 0);
            Alarms.Add(alarm);
        }
    }
}
