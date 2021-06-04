using System;
using System.Collections.Generic;

namespace NovaTimer.Common.Utilities
{
    /// <summary>
    ///     Interface for a time utility.
    /// </summary>
    public interface ITimeUtility
    {
        /// <summary>
        ///     The supported TimeSpan formats for parsing.
        /// </summary>
        IReadOnlyList<string> SupportedFormats { get; }

        /// <summary>
        ///     Tries to parse a given string into an appropriate
        ///     <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="timeSpan">The parsed <see cref="TimeSpan"/>.</param>
        /// <param name="ex">The exception when parsing failed.</param>
        /// <returns>
        ///     True if the parsing was successful, false otherwise.
        /// </returns>
        bool TryParseTimeSpan(string text, out TimeSpan timeSpan,
            out Exception ex);
    }
}
