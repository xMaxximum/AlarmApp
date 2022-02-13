using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace AlarmApp
{
    public class AlarmViewModel : ObservableObject
    {
        private string name = "Alarm 1";
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); RelativeTime = Util.ConvertDateToRelative(Date); }
        }

        private uint id;
        public uint Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private string relativeTime = string.Empty;
        public string RelativeTime
        {
            get => relativeTime;
            set => SetProperty(ref relativeTime, value);
        }

        public void Update(DateTime date)
        {
            Date = date;
            RelativeTime = Util.ConvertDateToRelative(_date);
        }
    }

    /*
    public class SubAlarmModel
    {
        public int OwnerAlarmId { get; set; }
        public DateTime Date { get; set; }
    }
    
    public class SubAlarms
    {
        public List<SubAlarmModel> Alarms { get; set; } = new();
    }
    */

    public enum Times
    {
        Seconds,
        Minutes,
        Hours,
        Days
    }
}
