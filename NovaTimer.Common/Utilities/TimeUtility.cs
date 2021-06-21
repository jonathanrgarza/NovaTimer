using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using NovaTimer.Common.Extensions;

namespace NovaTimer.Common.Utilities
{
    /// <summary>
    ///     The utility class for time operations.
    /// </summary>
    public class TimeUtility : ITimeUtility
    {
        private readonly string[] _supportedTimeFormats =
        {
            @"hh\:mm\:ss",
            @"hh\:mm\:s",
            @"hh\:m\:ss",
            @"hh\:m\:s",
            @"h\:mm\:ss",
            @"h\:mm\:s",
            @"h\:m\:ss",
            @"h\:m\:s",
            @"mm\:ss",
            @"mm\:s",
            @"m\:ss",
            @"m\:s",
            @"ss",
            //@"s" //Does not appear to work
        };

        /// <inheritdoc/>
        public IReadOnlyList<string> SupportedFormats { get; }

        /// <summary>
        ///     Initializes a new instance of <see cref="TimeUtility"/>.
        /// </summary>
        public TimeUtility()
        {
            SupportedFormats =
                new ReadOnlyCollection<string>(_supportedTimeFormats);
        }

        /// <inheritdoc/>
        public bool TryParseTimeSpan(string text, out TimeSpan timeSpan,
            out Exception ex)
        {
            timeSpan = TimeSpan.MinValue;
            ex = null;

            if (string.IsNullOrEmpty(text))
            {
                ex = new ArgumentException(
                    $"{nameof(text)} is null or empty");
                return false;
            }

            if (text.Length == 1)
            {
                return TryParseTimeSpanSeconds(text, ref timeSpan, ref ex);
            }

            //Format: HH:MM:SS

            //Supported time formats
            string[] formats = _supportedTimeFormats;

            var culture = CultureInfo.CurrentCulture;
            var result = TimeSpan.TryParseExact(text, formats, culture,
                out timeSpan);

            if (result == false)
            {
                if (IsAboveMaxHours(text))
                {
                    ex = new FormatException("Time above max value. Max time is 23:59:59.");
                    return false;
                }

                ex = new FormatException("Invalid text format");
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Tries to parse a given string as an interger and then converted
        ///     into a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <param name="timeSpan">The parsed <see cref="TimeSpan"/>.</param>
        /// <param name="ex">
        ///     The exception when parsing failed.
        ///     Can be an <see cref="ArgumentException"/> or
        ///     a <see cref="FormatException"/>.
        /// </param>
        /// <returns>
        ///     True if the parsing was successful, false otherwise.
        /// </returns>
        private static bool TryParseTimeSpanSeconds(string text, ref TimeSpan timeSpan, ref Exception ex)
        {
            if (int.TryParse(text, out int seconds) == false)
            {
                ex = new FormatException("Invalid text format");
                return false;
            }

            timeSpan = TimeSpan.FromSeconds(seconds);
            return true;
        }

        private static bool IsAboveMaxHours(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            if (text.Contains(":") == false)
            {
                return false;
            }

            if (text.Count(':') != 2)
            {
                return false;
            }

            int colonIndex = text.IndexOf(':');

            string hourText = text.Substring(0, colonIndex);

            if (int.TryParse(hourText, out int hours) == false)
            {
                return false;
            }

            if (hours < 24)
            {
                return false;
            }

            return true;
        }
    }
}
