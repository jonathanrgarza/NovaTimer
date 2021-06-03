using System;

using AppKit;
using Foundation;

namespace NovaTimer.Mac.Controllers
{
    /// <summary>
    ///     The main view controller.
    /// </summary>
    public partial class ViewController : NSViewController
    {
        /// <summary>
        ///     Initalizes a new instance of <see cref="ViewController"/>.
        /// </summary>
        /// <param name="handle">The native handle.</param>
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        ///     Event handler called when the view is loaded into memory.
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        /// <summary>
        ///     The object whose value is presented in the receiver’s
        ///     primary view.
        /// </summary>
        /// <remarks>
        ///     This property retains the object you provide to it;
        ///     it does not copy it. In another words, a view controller
        ///     has a to-one relationship with its represented object and
        ///     does not own it as an attribute.
        /// </remarks>
        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        /// <summary>
        ///     Called when text is entered into the timer field.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        partial void OnTimerFieldEnter(NSObject sender)
        {
            if (sender is not NSTextField textField)
                return;

            string value = textField.StringValue;
            //TODO Do something with value
        }

        /// <summary>
        ///     Called when minutes are entered into the toolbar
        ///     minutes field.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        partial void OnToolbarMinutesFieldEnter(NSObject sender)
        {
            if (sender is not NSTextField textField)
                return;

            int value = textField.IntValue;
            //TODO Do something with value
        }

        /// <summary>
        ///     Called when the toolbar play/pause button is pressed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        partial void OnToolbarPlayToggleButtonPressed(NSObject sender)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Called when the toolbar stop button is pressed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        partial void OnToolbarStopButtonPressed(NSObject sender)
        {
            throw new NotImplementedException();
        }
    }
}
