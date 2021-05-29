using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace NovaTimer.Mac
{
    [Register("VerticallyCenteredTextFieldCell")]
    public class VerticallyCenteredTextFieldCell : NSTextFieldCell
    {
        private bool _isEditingOrSelecting;

        public VerticallyCenteredTextFieldCell() : base()
        {

        }

        public VerticallyCenteredTextFieldCell(IntPtr handle) : base(handle)
        {

        }

        public override CGRect DrawingRectForBounds(CGRect theRect)
        {
            var newRect = base.DrawingRectForBounds(theRect);

            //Check if we are editing or selecting
            if (_isEditingOrSelecting != false)
                return newRect; //If so, return the original calculated rect

            //If not, center the drawing rect
            var idealSize = CellSizeForBounds(theRect);

            //Center text in the proposed rect
            nfloat heightDelta = newRect.Size.Height - idealSize.Height;

            if (heightDelta > 0)
            {
                var newSize = newRect.Size;
                newSize.Height -= heightDelta;
                newRect.Size = newSize;

                newRect.Y += heightDelta / 2;
            }

            return newRect;
        }

        public override void SelectWithFrame(CGRect aRect, NSView inView, NSText editor, NSObject delegateObject, nint selStart, nint selLength)
        {
            aRect = DrawingRectForBounds(aRect);

            _isEditingOrSelecting = true;
            base.SelectWithFrame(aRect, inView, editor, delegateObject, selStart, selLength);
            _isEditingOrSelecting = false;
        }

        public override void EditWithFrame(CGRect aRect, NSView inView, NSText editor, NSObject delegateObject, NSEvent theEvent)
        {
            aRect = DrawingRectForBounds(aRect);

            _isEditingOrSelecting = true;
            base.EditWithFrame(aRect, inView, editor, delegateObject, theEvent);
            _isEditingOrSelecting = false;
        }
    }
}
