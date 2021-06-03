using AppKit;

namespace NovaTimer.Mac
{
    /// <summary>
    ///     The entry class holding the <see cref="Main(string[])"/> method.
    /// </summary>
    static class MainClass
    {
        /// <summary>
        ///     The entry point of the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }
}
