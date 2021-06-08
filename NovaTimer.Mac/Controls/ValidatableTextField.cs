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

        protected ValidationState _validationState;
        
        /// <summary>
        ///     Gets/Sets the validation state.
        /// </summary>
        public ValidationState ValidationState
        {
            get => _validationState;
            set
            {
                if (_validationState == value)
                    return;

                _validationState = value;

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

                if (_validationState != ValidationState.Valid)
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
        }

        protected virtual void ShowErrorState()
        {
            WantsLayer = true;

            var layer = Layer;
            if (layer == null)
                return;

            layer.BorderColor = ColorConstants.ErrorCG;
            layer.BorderWidth = 1.0f;
            layer.CornerRadius = 0.0f;
        }

        protected virtual void ShowWarningState()
        {
            WantsLayer = true;

            var layer = Layer;
            if (layer == null)
                return;

            layer.BorderColor = ColorConstants.WarningCG;
            layer.BorderWidth = 1.0f;
            layer.CornerRadius = 0.0f;
        }

        protected virtual void ShowInfoState()
        {
            WantsLayer = true;

            var layer = Layer;
            if (layer == null)
                return;

            layer.BorderColor = ColorConstants.InfoCG;
            layer.BorderWidth = 1.0f;
            layer.CornerRadius = 0.0f;
        }

        protected virtual void ShowValidState()
        {
            if (_showValidAsDefault)
            {
                ShowDefaultState();
                return;
            }

            WantsLayer = true;

            var layer = Layer;
            if (layer == null)
                return;

            layer.BorderColor = ColorConstants.ValidCG;
            layer.BorderWidth = 1.0f;
            layer.CornerRadius = 0.0f;
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
    }
}
