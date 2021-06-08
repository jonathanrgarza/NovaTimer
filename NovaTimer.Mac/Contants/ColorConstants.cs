using AppKit;
using CoreGraphics;

namespace NovaTimer.Mac.Constants
{
    /// <summary>
    ///     Colors constants.
    /// </summary>
    public static class ColorConstants
    {
        /// <summary>
        ///     The <see cref="NSColor"/> representing an error state.
        /// </summary>
        public static readonly NSColor Error =
            NSColor.FromRgb(232, 12, 12);

        /// <summary>
        ///     The <see cref="CGColor"/> representing an error state.
        /// </summary>
        public static readonly CGColor ErrorCG =
            Error.CGColor;

        /// <summary>
        ///     The <see cref="NSColor"/> representing a warning state.
        /// </summary>
        public static readonly NSColor Warning =
            NSColor.FromRgb(250, 242, 7);

        /// <summary>
        ///     The <see cref="CGColor"/> representing a warning state.
        /// </summary>
        public static readonly CGColor WarningCG =
            Warning.CGColor;

        /// <summary>
        ///     The <see cref="NSColor"/> representing a information state.
        /// </summary>
        public static readonly NSColor Info =
            NSColor.FromRgb(7, 129, 250);

        /// <summary>
        ///     The <see cref="CGColor"/> representing a information state.
        /// </summary>
        public static readonly CGColor InfoCG =
            Info.CGColor;

        /// <summary>
        ///     The <see cref="NSColor"/> representing a valid state.
        /// </summary>
        public static readonly NSColor Valid =
            NSColor.FromRgb(16, 130, 16);

        /// <summary>
        ///     The <see cref="CGColor"/> representing a valid state.
        /// </summary>
        public static readonly CGColor ValidCG =
            Valid.CGColor;

        /// <summary>
        ///     The <see cref="NSColor"/> representing a default/none state.
        /// </summary>
        public static readonly NSColor Default =
            NSColor.Black;

        /// <summary>
        ///     The <see cref="CGColor"/> representing a default/none state.
        /// </summary>
        public static readonly CGColor DefaultCG =
            Default.CGColor;
    }
}
