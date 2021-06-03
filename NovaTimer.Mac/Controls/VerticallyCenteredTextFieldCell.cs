using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace NovaTimer.Mac.Controls
{
    /// <summary>
    ///     A textfield cell which vertically centers it text.
    /// </summary>
    [Register("VerticallyCenteredTextFieldCell")]
    public class VerticallyCenteredTextFieldCell : NSTextFieldCell
    {
        private bool _isEditingOrSelecting;

        /// <summary>
        ///     Initalizes a new instance of
        ///     <see cref="VerticallyCenteredTextFieldCell"/>.
        /// </summary>
        public VerticallyCenteredTextFieldCell() : base()
        {

        }

        /// <summary>
        ///     Initalizes a new instance of
        ///     <see cref="VerticallyCenteredTextFieldCell"/>.
        /// </summary>
        /// <param name="handle">The native handle.</param>
        public VerticallyCenteredTextFieldCell(IntPtr handle) : base(handle)
        {

        }

        /// <summary>
        ///     Returns the rectangle within which the receiver draws itself.
        /// </summary>
        /// <param name="theRect"></param>
        /// <returns>
        ///     The rectangle in which the receiver draws itself.
        ///     If not editing or selecting the field, will return a
        ///     centered rectangle.
        ///     Otherwise will return a rectangle is slightly inset
        ///     from the one in theRect.
        /// </returns>
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

        /// <summary>
        ///     Selects the specified text range in the cell's field editor.
        /// </summary>
        /// <param name="aRect">The bounding rectangle of the cell.</param>
        /// <param name="inView">The control that manages the cell.</param>
        /// <param name="editor">
        ///     The field editor to use for editing the cell.
        /// </param>
        /// <param name="delegateObject">
        ///     The object to use as a delegate for the field
        ///     editor (textObj parameter). This delegate object receives
        ///     various NSText delegation and notification methods during
        ///     the course of editing the cell's contents.
        /// </param>
        /// <param name="selStart">The start of the text selection.</param>
        /// <param name="selLength">The length of the text range.</param>
        /// <remarks>
        ///     This method is similar to
        ///     edit(withFrame:in:editor:delegate:event:), except that it
        ///     can be invoked in any situation, not only on a
        ///     mouse-down event.
        ///     This method returns without doing anything if
        ///     controlView, textObj, or the receiver is nil, or if the
        ///     receiver has no font set for it.
        /// </remarks>
        public override void SelectWithFrame(CGRect aRect, NSView inView,
            NSText editor, NSObject delegateObject,
            nint selStart, nint selLength)
        {
            aRect = DrawingRectForBounds(aRect);

            _isEditingOrSelecting = true;
            base.SelectWithFrame(aRect, inView, editor, delegateObject,
                selStart, selLength);
            _isEditingOrSelecting = false;
        }

        /// <summary>
        ///     Begins editing of the receiver’s text using
        ///     the specified field editor.
        /// </summary>
        /// <param name="aRect">The bounding rectangle of the cell.</param>
        /// <param name="inView">The control that manages the cell.</param>
        /// <param name="editor">
        ///     The field editor to use for editing the cell.
        /// </param>
        /// <param name="delegateObject">
        ///     The object to use as a delegate for the field editor
        ///     (textObj parameter).
        ///     This delegate object receives various NSText delegation and
        ///     notification methods during the course of
        ///     editing the cell's contents.
        /// </param>
        /// <param name="theEvent">
        ///     The NSLeftMouseDown event that
        ///     initiated the editing behavior.
        /// </param>
        /// <remarks>
        ///     If the receiver isn’t a text-type NSCell object, no editing
        ///     is performed. Otherwise, the field editor (textObj) is sized
        ///     to aRect and its superview is set to controlView, so it
        ///     exactly covers the receiver. The field editor is then
        ///     activated and editing begins. It’s the responsibility of the
        ///     delegate to end editing when responding to
        ///     textShouldEndEditing(_:). Upon ending the editing session,
        ///     the delegate should remove any data from the field editor.
        /// </remarks>
        public override void EditWithFrame(CGRect aRect, NSView inView,
            NSText editor, NSObject delegateObject, NSEvent theEvent)
        {
            aRect = DrawingRectForBounds(aRect);

            _isEditingOrSelecting = true;
            base.EditWithFrame(aRect, inView, editor,
                delegateObject, theEvent);
            _isEditingOrSelecting = false;
        }
    }
}
