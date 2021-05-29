// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace NovaTimer.Mac
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField TimerField { get; set; }

		[Action ("OnTimerFieldEnter:")]
		partial void OnTimerFieldEnter (Foundation.NSObject sender);

		[Action ("OnToolbarMinutesFieldEnter:")]
		partial void OnToolbarMinutesFieldEnter (Foundation.NSObject sender);

		[Action ("OnToolbarPlayToggleButtonPressed:")]
		partial void OnToolbarPlayToggleButtonPressed (Foundation.NSObject sender);

		[Action ("OnToolbarStopButtonPressed:")]
		partial void OnToolbarStopButtonPressed (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TimerField != null) {
				TimerField.Dispose ();
				TimerField = null;
			}
		}
	}
}
