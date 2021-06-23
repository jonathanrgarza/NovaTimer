using System;
using NovaTimer.Common.Infrastructure;

namespace NovaTimer.Common.Services
{
    /// <summary>
    ///     The timer service.
    /// </summary>
    public class TimerService : ITimerService
    {
        private ServiceState _state;

        /// <summary>
        ///     Initializes a new instance of <see cref="TimerService"/>.
        /// </summary>
        public TimerService()
        {
        }

        /// <inheritdoc/>
        public ServiceState State
        {
            get => _state;
            set
            {
                if (_state == value)
                    return;

                var oldValue = _state;
                _state = value;

                OnStateChanged(oldValue, _state);
            }
        }

        /// <inheritdoc/>
        public bool IsRunning => _state == ServiceState.Running;

        /// <inheritdoc/>
        public bool IsComplete { get; private set; }

        /// <inheritdoc/>
        public TimeSpan InitialTimeSpan { get; private set; }

        /// <inheritdoc/>
        public TimeSpan TimeRemaining { get; private set; }

        /// <inheritdoc/>
        public event EventHandler<ValueChangedEventArgs<ServiceState>> StateChanged;

        /// <inheritdoc/>
        public event EventHandler<TimeSpan> Tick;

        /// <inheritdoc/>
        public event EventHandler Completed;

        /// <inheritdoc/>
        public void Initialize(TimeSpan time)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Pause()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Play()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Stop()
        {
            throw new NotImplementedException();
        }

        private void OnStateChanged(ServiceState oldValue, ServiceState newValue)
        {
            StateChanged?.Invoke(this,
                new ValueChangedEventArgs<ServiceState>(oldValue, newValue));
        }
    }
}
