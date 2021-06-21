using System;
namespace NovaTimer.Common.Extensions
{
    /// <summary>
    ///     Extensions for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Gets the occurance count of a given value within the string.
        /// </summary>
        /// <param name="text">The string.</param>
        /// <param name="value">The value to count.</param>
        /// <returns>
        ///     The number of occurance of the value within the string.
        /// </returns>
        public static int Count(this string text, char value)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            int count = 0;
            
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == value)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        ///     Gets the occurance count of a given value within the string.
        /// </summary>
        /// <param name="text">The string.</param>
        /// <param name="value">The value to count.</param>
        /// <returns>
        ///     The number of occurance of the value within the string.
        /// </returns>
        public static int Count(this string text, string value)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            if (string.IsNullOrEmpty(value))
                return 0;

            int textLength = text.Length;
            int valueLength = value.Length;

            if (textLength < valueLength)
                return 0;

            if (textLength == valueLength)
            {
                return text == value ? 1 : 0;
            }

            int length = textLength - valueLength;

            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (IsSubstringEqual(text, i, value))
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        ///     Gets whether the given value is equal to a substring of the
        ///     given string.
        /// </summary>
        /// <param name="text">The string.</param>
        /// <param name="startIndex">
        ///     The starting index of the substring.
        /// </param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     True if the substring is equal to the given value,
        ///     false otherwise.
        /// </returns>
        public static bool IsSubstringEqual(this string text, int startIndex,
            string value)
        {
            if (string.IsNullOrEmpty(text))
            {
                if (string.IsNullOrEmpty(value))
                {
                    return true;
                }

                return false;
            }

            if (string.IsNullOrEmpty(value))
                return false;

            if (startIndex < 0 || startIndex >= text.Length)
            {
                throw new ArgumentException("Start index is out of range", nameof(startIndex));
            }

            int remainLength = text.Length - startIndex;
            int length = value.Length;

            if (remainLength < length)
                return false;

            int j = 0;
            for (int i = startIndex; i < length; i++)
            {
                char textChar = text[i];
                char valueChar = value[j];

                if (textChar != valueChar)
                    return false;

                j++;
            }

            return true;
        }
    }
}
