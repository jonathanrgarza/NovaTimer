using System;
using System.Threading;
using NovaTimer.Common.Infrastructure;

namespace NovaTimer.Common.Services
{
    /// <summary>
    ///     The timer service.
    /// </summary>
    public class TimerService : ITimerService
    {
        private const string ServiceRunningErrorMsg = "Service is currently running";

        private ServiceState _state;

        private Timer _timer;
        private bool _isComplete;

        private const int Second = 1000;
        private readonly TimeSpan SecondTS = TimeSpan.FromSeconds(1);

        /// <summary>
        ///     Initializes a new instance of <see cref="TimerService"/>.
        /// </summary>
        public TimerService()
        {
            Reset();
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
        public bool IsComplete
        {
            get => _isComplete;
            private set
            {
                if (_isComplete == value)
                    return;

                _isComplete = value;

                if (_isComplete)
                {
                    OnCompleted();
                }
            }
        }

        /// <inheritdoc/>
        public TimeSpan InitialTimeSpan { get; private set; }

        /// <inheritdoc/>
        public TimeSpan RemainingTime { get; private set; }

        /// <inheritdoc/>
        public event EventHandler<ValueChangedEventArgs<ServiceState>> StateChanged;

        /// <inheritdoc/>
        public event EventHandler<TimeSpan> Tick;

        /// <inheritdoc/>
        public event EventHandler Completed;

        /// <inheritdoc/>
        public void Initialize(TimeSpan time)
        {
            if (_state == ServiceState.Running)
                throw new InvalidOperationException(ServiceRunningErrorMsg);

            IsComplete = false;
            InitialTimeSpan = time;
            RemainingTime = time;
            State = ServiceState.Initialized;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            if (_state == ServiceState.Running)
                throw new InvalidOperationException(ServiceRunningErrorMsg);

            _timer?.Dispose();
            _timer = null;
            InitialTimeSpan = TimeSpan.Zero;
            RemainingTime = TimeSpan.Zero;
            IsComplete = false;
            State = ServiceState.Uninitialized;
        }

        /// <inheritdoc/>
        public bool Pause()
        {
            if (_state != ServiceState.Running)
                return false;

            _timer?.Dispose();
            _timer = null;
            State = ServiceState.Paused;

            return true;
        }

        /// <inheritdoc/>
        public bool Play()
        {
            if (_state == ServiceState.Running || _state == ServiceState.Uninitialized)
                return false;

            //Check if any time remaining
            if (RemainingTime <= TimeSpan.Zero)
                return false;

            _timer = new Timer(TickHandler, null, Second, Second);
            State = ServiceState.Running;

            return true;
        }

        /// <inheritdoc/>
        public bool Stop()
        {
            if (_state == ServiceState.Stopped || _state == ServiceState.Uninitialized)
                return false;

            _timer?.Dispose();
            _timer = null;

            RemainingTime = InitialTimeSpan;
            OnTick(RemainingTime); //Allow an update of the time visible
            State = ServiceState.Stopped;

            return true;
        }

        private void TickHandler(object state)
        {
            var newTime = RemainingTime.Subtract(SecondTS);
            RemainingTime = newTime;
            OnTick(newTime);

            if (newTime <= TimeSpan.Zero)
            {
                Pause();
                IsComplete = true;
            }
        }

        private void OnStateChanged(ServiceState oldValue, ServiceState newValue)
        {
            StateChanged?.Invoke(this,
                new ValueChangedEventArgs<ServiceState>(oldValue, newValue));
        }

        private void OnTick(TimeSpan timeRemaining)
        {
            Tick?.Invoke(this, timeRemaining);
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, EventArgs.Empty);
        }
    }
}
