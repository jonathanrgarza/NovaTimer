using System;

using AppKit;
using Foundation;

namespace NovaTimer.Mac.Controllers
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            
        }

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

        partial void OnTimerFieldEnter(NSObject sender)
        {
            if (sender is not NSTextField textField)
                return;

            string value = textField.StringValue;
            //TODO Do something with value
        }

        partial void OnToolbarMinutesFieldEnter(NSObject sender)
        {
            if (sender is not NSTextField textField)
                return;

            int value = textField.IntValue;
            //TODO Do something with value
        }

        partial void OnToolbarPlayToggleButtonPressed(NSObject sender)
        {
            throw new NotImplementedException();
        }

        partial void OnToolbarStopButtonPressed(NSObject sender)
        {
            throw new NotImplementedException();
        }
    }
}
