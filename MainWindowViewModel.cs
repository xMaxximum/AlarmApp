using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace AlarmApp
{
    public class MainWindowViewModel : ObservableObject, IDisposable
    {
        private readonly Timer _backgroundTimer;

        private bool disposedValue;

        public ObservableCollection<AlarmViewModel> Alarms { get; } = new();

        public MainWindowViewModel()
        {
            _backgroundTimer = new Timer(OnTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        public void AddAlarm(AlarmViewModel alarm)
        {
            alarm.Id = (uint)(Alarms.Count + 1);
            Alarms.Add(alarm);
        }

        private void OnTimerTick(object? state)
        {
            foreach (var alarm in Alarms.ToArray())
            {
                alarm.RelativeTime = Util.ConvertDateToRelative(alarm.Date);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _backgroundTimer.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MainWindowViewModel()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
