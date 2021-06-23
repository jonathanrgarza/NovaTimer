using System;
using NovaTimer.Common.Infrastructure;

namespace NovaTimer.Common.Services
{
    /// <summary>
    ///     Interface for the timer service.
    /// </summary>
    public interface ITimerService
    {
        /// <summary>
        ///     Occurs when the service's state changes.
        /// </summary>
        event EventHandler<ValueChangedEventArgs<ServiceState>> StateChanged;

        /// <summary>
        ///     Occurs when a timer ticks.
        /// </summary>
        event EventHandler<TimeSpan> Tick;

        /// <summary>
        ///     Occurs when a timer completes.
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        ///     Gets the service's state.
        /// </summary>
        ServiceState State { get; }

        /// <summary>
        ///     Gets if the service is currently running the timer.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        ///     Gets if the service has completed the operation.
        /// </summary>
        bool IsComplete { get; }

        /// <summary>
        ///     Gets the initial time span.
        /// </summary>
        TimeSpan InitialTimeSpan { get; }

        /// <summary>
        ///     Gets the remaining time.
        /// </summary>
        TimeSpan TimeRemaining { get; }

        /// <summary>
        ///     Initalizes the service with a given time.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown if the service is currently running.
        /// </exception>
        void Initialize(TimeSpan time);

        /// <summary>
        ///     Resets the service to its initial state.
        /// </summary>
        void Reset();

        /// <summary>
        ///     Plays the timer.
        /// </summary>
        /// <returns>True if the timer is now playing, false if error.</returns>
        bool Play();

        /// <summary>
        ///     Pauses the timer.
        /// </summary>
        /// <returns>True if the timer is now paused, false if error.</returns>
        bool Pause();

        /// <summary>
        ///     Stops the timer and resets the <see cref="TimeRemaining"/>.
        /// </summary>
        /// <returns>True if the timer is now stopped, false if error.</returns>
        bool Stop();
    }
}
