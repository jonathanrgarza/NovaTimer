using AppKit;
using Foundation;
using NovaTimer.Common.Services;
using NovaTimer.Common.Utilities;
using SimpleInjector;

namespace NovaTimer.Mac
{
    /// <summary>
    ///     The app delegate for the application.
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        private Container _container;

        /// <summary>
        ///     Gets the DI Container.
        /// </summary>
        public Container Container => _container ??= BuildContainer();

        /// <summary>
        ///     Initalizes a new instance of <see cref="AppDelegate"/>.
        /// </summary>
        public AppDelegate()
        {
        }

        /// <summary>
        ///     Sent by the default notification center immediately before
        ///     the application object is initialized.
        /// </summary>
        /// <param name="notification">
        ///     A notification named willFinishLaunchingNotification.
        ///     Calling the object method of this notification returns
        ///     the NSApplication object itself.
        /// </param>
        public override void WillFinishLaunching(NSNotification notification)
        {
            //Note: Not called before ViewController.ViewDidLoad
        }

        /// <summary>
        ///     Sent by the default notification center after the application
        ///     has been launched and initialized but before it has
        ///     received its first event.
        /// </summary>
        /// <param name="notification">
        ///     A notification named didFinishLaunchingNotification.
        ///     Calling the object method of this notification
        ///     returns the NSApplication object itself.
        /// </param>
        /// <remarks>
        ///     Delegates can implement this method to perform further
        ///     initialization. This method is called after the application’s
        ///     main run loop has been started but before it has processed
        ///     any events. If the application was launched by the user
        ///     opening a file, the delegate’s application(_:openFile:) method
        ///     is called before this method. If you want to perform
        ///     initialization before any files are opened, implement the
        ///     applicationWillFinishLaunching(_:) method in your delegate,
        ///     which is called before application(_:openFile:).)
        /// </remarks>
        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        /// <summary>
        ///     Sent by the default notification center immediately before
        ///     the application terminates.
        /// </summary>
        /// <param name="notification">
        ///     A notification named willTerminateNotification. Calling the
        ///     object method of this notification returns the
        ///     NSApplication object itself.
        /// </param>
        /// <remarks>
        ///     Your delegate can use this method to perform any final
        ///     cleanup before the application terminates.
        /// </remarks>
        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        /// <summary>
        ///     Sets up the DI container for the application.
        /// </summary>
        private Container BuildContainer()
        {
            var container = new Container();

            container.Register<ITimeUtility, TimeUtility>(Lifestyle.Singleton);
            container.Register<ITimerService, TimerService>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }
    }
}
