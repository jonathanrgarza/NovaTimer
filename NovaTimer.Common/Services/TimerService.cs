using System;
using NovaTimer.Common.Infrastructure;

namespace NovaTimer.Common.Services
{
    /// <summary>
    ///     The timer service.
    /// </summary>
    public class TimerService : ITimerService
    {
        public TimerService()
        {
        }

        public ServiceState State => throw new NotImplementedException();

        public bool IsRunning => throw new NotImplementedException();

        public bool IsComplete => throw new NotImplementedException();

        public TimeSpan InitialTimeSpan => throw new NotImplementedException();

        public TimeSpan TimeRemaining => throw new NotImplementedException();

        public event EventHandler<ValueChangedEventArgs<ServiceState>> StateChanged;
        public event EventHandler<TimeSpan> Tick;
        public event EventHandler Completed;

        public void Initialize(TimeSpan time)
        {
            throw new NotImplementedException();
        }

        public bool Pause()
        {
            throw new NotImplementedException();
        }

        public bool Play()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }
    }
}
