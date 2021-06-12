using System;
using AppKit;
using Foundation;
using NovaTimer.Common.Infrastructure;
using NovaTimer.Mac.Constants;

namespace NovaTimer.Mac.Controls
{
    /// <summary>
    ///     A text field which supports validation states.
    /// </summary>
    [Register(nameof(ValidatableTextField))]
    public class ValidatableTextField : NSTextField
    {
        protected bool _showValidAsDefault = true;

        protected ValidationResult _validationResult;

        /// <summary>
        ///     Gets/Sets the validation state.
        ///     Using this to set the state will set the
        ///     message/tooltip to an empty string.
        /// </summary>
        public ValidationState ValidationState
        {
            get => _validationResult?.State ?? ValidationState.None;
            set
            {
                if (_validationResult != null &&
                    _validationResult.State == value)
                    return;

                _validationResult = new(string.Empty, value);

                UpdateValidationVisual();
            }
        }

        /// <summary>
        ///     Gets/Sets the validation result.
        /// </summary>
        public ValidationResult ValidationResult
        {
            get => _validationResult;
            set
            {
                if (_validationResult == value)
                    return;

                _validationResult = value;

                UpdateValidationVisual();
            }
        }

        /// <summary>
        ///     Gets/Sets if valid should show the same as the default state (no border).
        /// </summary>
        /// <remarks>
        ///     Default value is true.
        /// </remarks>
        public bool ShowValidAsDefault
        {
            get => _showValidAsDefault;
            set
            {
                if (_showValidAsDefault == value)
                    return;

                _showValidAsDefault = value;

                if (ValidationState != ValidationState.Valid)
                    return;

                //Update the visual since value change
                ShowValidState();
            }
        }

        /// <summary>
        ///     Initalizes a new instance of
        ///     <see cref="ValidatableTextField"/>.
        /// </summary>
        public ValidatableTextField() : base()
        {

        }

        /// <summary>
        ///     Initalizes a new instance of
        ///     <see cref="ValidatableTextField"/>.
        /// </summary>
        /// <param name="handle">The native handle.</param>
        public ValidatableTextField(IntPtr handle) : base(handle)
        {

        }

        /// <summary>
        ///     Updates the visual based on the value of
        ///     <see cref="ValidationState"/>.
        /// </summary>
        public void UpdateValidationVisual()
        {
            switch (ValidationState)
            {
                case ValidationState.None:
                    ShowDefaultState();
                    break;
                case ValidationState.Valid:
                    ShowValidState();
                    break;
                case ValidationState.Info:
                    ShowInfoState();
                    break;
                case ValidationState.Warning:
                    ShowWarningState();
                    break;
                case ValidationState.Error:
                    ShowErrorState();
                    break;
                default:
                    throw new InvalidOperationException($"{nameof(ValidationState)} has an unsupported value: {ValidationState}");
            }

            ToolTip = _validationResult?.Message;
        }

        protected virtual void ShowErrorState()
        {
            SetCommonBorder(ColorConstants.ErrorCG);
        }

        protected virtual void ShowWarningState()
        {
            SetCommonBorder(ColorConstants.WarningCG);
        }

        protected virtual void ShowInfoState()
        {
            SetCommonBorder(ColorConstants.InfoCG);
        }

        protected virtual void ShowValidState()
        {
            if (_showValidAsDefault)
            {
                ShowDefaultState();
                return;
            }

            SetCommonBorder(ColorConstants.ValidCG);
        }

        protected virtual void ShowDefaultState()
        {
            WantsLayer = true;

            var layer = Layer;
            if (layer == null)
                return;

            layer.BorderColor = ColorConstants.DefaultCG;
            layer.BorderWidth = 0.0f;
            layer.CornerRadius = 0.0f;
        }

        protected virtual void SetCommonBorder(CoreGraphics.CGColor borderColor)
        {
            WantsLayer = true;

            var layer = Layer;
            if (layer == null)
                return;

            layer.BorderColor = borderColor;
            layer.BorderWidth = 1.0f;
            layer.CornerRadius = 0.0f;
        }
    }
}
