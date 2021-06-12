using System;
using System.Collections.Generic;

namespace NovaTimer.Common.Infrastructure
{
    /// <summary>
    ///     Represents a validation result.
    /// </summary>
    public class ValidationResult : IEquatable<ValidationResult>
    {
        /// <summary>
        ///     Represents a valid result.
        /// </summary>
        public static readonly ValidationResult Valid =
            new(string.Empty, ValidationState.Valid);

        /// <summary>
        ///     Gets the message for the result.
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Gets the state for the result.
        /// </summary>
        public ValidationState State { get; }

        /// <summary>
        ///     Initalizes a new instance of
        ///     <see cref="ValidationResult"/>.
        ///     State will be set to <see cref="ValidationState.Valid"/>.
        /// </summary>
        public ValidationResult()
        {
            Message = string.Empty;
            State = ValidationState.Valid;
        }

        /// <summary>
        ///     Initalizes a new instance of
        ///     <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="state">The validation state.</param>
        public ValidationResult(string message, ValidationState state)
        {
            Message = message;
            State = state;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals(obj as ValidationResult);
        }

        /// <inheritdoc/>
        public bool Equals(ValidationResult other)
        {
            return other != null &&
                   Message == other.Message &&
                   State == other.State;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Message, State);
        }

        public static bool operator ==(ValidationResult left, ValidationResult right)
        {
            return EqualityComparer<ValidationResult>.Default.Equals(left, right);
        }

        public static bool operator !=(ValidationResult left, ValidationResult right)
        {
            return !(left == right);
        }
    }
}
