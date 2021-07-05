using System;
namespace NovaTimer.Common.Services
{
    /// <summary>
    ///     Interface for the sound service.
    /// </summary>
    public interface ISoundService
    {
        /// <summary>
        ///     Plays a simple notification sound.
        ///     Either the system beep sound or a short sound file.
        /// </summary>
        /// <returns>True if the sound played, false otherwise.</returns>
        bool PlayBeep();
    }
}
