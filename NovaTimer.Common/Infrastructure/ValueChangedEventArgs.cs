using System;
namespace NovaTimer.Common.Infrastructure
{
    /// <summary>
    ///     Event arguments for a value changed event.
    /// </summary>
    /// <typeparam name="T">The type for the value.</typeparam>
    public class ValueChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        ///     Gets the old value.
        /// </summary>
        public T OldValue { get; }

        /// <summary>
        ///     Gets the new value.
        /// </summary>
        public T NewValue { get; }

        /// <summary>
        ///     Initializes a new instance of <see cref="ValueChangedEventArgs{T}"/>.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public ValueChangedEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
