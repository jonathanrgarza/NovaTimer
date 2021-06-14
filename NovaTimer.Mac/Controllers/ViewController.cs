using System;

using AppKit;
using Foundation;
using NovaTimer.Common.Infrastructure;
using NovaTimer.Common.Utilities;
using NovaTimer.Mac.Contants;
using NovaTimer.Mac.Controls;

namespace NovaTimer.Mac.Controllers
{
    /// <summary>
    ///     The main view controller.
    /// </summary>
    public partial class ViewController : NSViewController
    {
        /// <summary>
		///     A helper shortcut to the app delegate.
		/// </summary>
		/// <value>The app.</value>
		public static AppDelegate App =>
            (AppDelegate)NSApplication.SharedApplication.Delegate;

        /// <summary>
        ///     The time utility.
        /// </summary>
        public ITimeUtility TimeUtility { get; private set; }

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
            SetupDependencies();
        }

        /// <summary>
        ///     Sets up the DI dependencies for this class.
        /// </summary>
        private void SetupDependencies()
        {
            var app = App;

            TimeUtility = app.Container.GetInstance<ITimeUtility>();
        }

        /// <summary>
        ///     Called when text is entered into the timer field.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        partial void OnTimerFieldEnter(NSObject sender)
        {
            if (sender is not ValidatableTextField textField)
                return;

            string value = textField.StringValue;

            if (string.IsNullOrEmpty(value))
            {
                SetNormalState(textField);
                return;
            }
            
            if (TimeUtility.TryParseTimeSpan(value, out TimeSpan timeSpan,
                out Exception ex) == false)
            {
                var valResult = new ValidationResult(
                    $"{ex.Message}\n{StringConstants.TimeFormatError}",
                    ValidationState.Error);
                SetTextFieldState(textField, valResult);

                //var alert = new NSAlert
                //{
                //    AlertStyle = NSAlertStyle.Informational,
                //    MessageText = $"{ex.Message}",
                //    InformativeText = StringConstants.TimeFormatError
                //};

                //alert.BeginSheet(View.Window);
                return;
            }

            SetNormalState(textField);
            //TODO Do something with value
        }

        private static void SetTextFieldState(ValidatableTextField textField,
            ValidationResult result)
        {
            textField.ValidationResult = result;
        }

        private static void SetNormalState(ValidatableTextField textField)
        {
            textField.ValidationResult = ValidationResult.Valid;
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

            var timeSpan = TimeSpan.FromMinutes(value);
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
