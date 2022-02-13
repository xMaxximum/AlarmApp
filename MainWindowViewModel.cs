using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlarmApp
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<AlarmModel> _alarms = new();
        public ObservableCollection<AlarmModel> Alarms
        {
            get => _alarms;
            set => SetProperty(ref _alarms, value);
        }

        public void AddAlarm(AlarmModel alarm)
        {
            alarm.Id = (uint)(_alarms.Any() ? _alarms.Count + 1 : 0);
            Alarms.Add(alarm);
        }
    }
}
