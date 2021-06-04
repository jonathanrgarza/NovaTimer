using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace NovaTimer.Common.Utilities
{
    /// <summary>
    ///     The utility class for time operations.
    /// </summary>
    public class TimeUtility : ITimeUtility
    {
        private readonly string[] _supportedTimeFormats =
        {
            @"mm\:ss",
            @"hh\:mm\:ss"
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

            //Format: HH:MM:SS

            if (text.Contains(':') == false)
            {
                //Try to parse as a single number then (seconds)
                return TryParseSeconds(text, out timeSpan, out ex);
            }

            //Supported time formats
            var formats = _supportedTimeFormats;

            var culture = CultureInfo.CurrentCulture;
            var result = TimeSpan.TryParseExact(text, formats, culture,
                out timeSpan);

            if (result == false)
            {
                ex = new FormatException("Invalid text format");
                return false;
            }

            return true;
        }

        private bool TryParseSeconds(string text, out TimeSpan timeSpan,
            out Exception ex)
        {
            ex = null;

            var culture = CultureInfo.CurrentCulture;
            var result = TimeSpan.TryParseExact(text, "ss", culture,
                out timeSpan);

            if (result == false)
            {
                ex = new FormatException("Invalid text format");
                return false;
            }

            return true;
        }
    }
}
