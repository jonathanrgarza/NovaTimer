// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace NovaTimer.Mac.Controllers
{
    /// <summary>
    ///		The main window controller.
    /// </summary>
    public partial class WindowController : NSWindowController
    {
        /// <summary>
        ///     A helper shortcut to the app delegate.
        /// </summary>
        /// <value>The app.</value>
        public static AppDelegate App =>
            (AppDelegate)NSApplication.SharedApplication.Delegate;

        /// <summary>
        ///     Initalizes a new instance of <see cref="WindowController"/>.
        /// </summary>
        /// <param name="handle">The native handle.</param>
        public WindowController(IntPtr handle) : base(handle)
        {
            
        }

        /// <summary>
        ///     Sent after the window owned by the receiver has been loaded.
        /// </summary>
        public override void WindowDidLoad()
        {
            base.WindowDidLoad();

            // Do any additional setup after loading the window.
        }
    }
}
