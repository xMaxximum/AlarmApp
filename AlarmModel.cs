using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace AlarmApp
{
    public class AlarmModel : ObservableObject
    {
        private DateTime _date;
        private string? _relativeTime;
        public string Name { get; set; } = "Alarm 1";
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                _relativeTime = Util.ConvertDateToRelative(_date);
                RelativeTime = _relativeTime;
                SetProperty(ref _relativeTime, Util.ConvertDateToRelative(_date));
            }
        }
        public uint Id { get; set; }
        public string RelativeTime { get; set; } = string.Empty;
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
