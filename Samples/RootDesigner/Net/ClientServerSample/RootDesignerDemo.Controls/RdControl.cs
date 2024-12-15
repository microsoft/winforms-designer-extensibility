using System.ComponentModel;
using System.Text;

namespace RootDesignerDemo.Controls
{
    /// <summary>
    ///  Custom Control sample implementation.
    /// </summary>
    /// <remarks>
    ///  This sample custom control implements one custom property named <see cref="RdPropertyStoreProperty"/> 
    ///  of type <see cref="RdPropertyStore"/>. Its sole purpose is to demonstrate how to implement
    ///  a custom TypeEditor for editing this property's content at design time with the out-of-process
    ///  WinForms Designer. 
    /// </remarks>
    [Designer("RdControlDesigner")]
    public class RdControl : Control
    {
        // Backing field for CustomProperty.
        private RdPropertyStore? _customPropertyStoreProperty;

        /// <summary>
        ///  Occurs when the RdPropertyStoreProperty changes.
        /// </summary>
        public event EventHandler? RdPropertyStorePropertyChanged;

        public RdControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        /// <summary>
        ///  Gets or sets a value of type <see cref="RdPropertyStore"/> which is composed of different value types,
        ///  a custom enum and a string array.
        /// </summary>
        [Description("A custom property composed of different value types, a custom enum and a string array."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RdPropertyStore? RdPropertyStoreProperty
        {
            get => _customPropertyStoreProperty;

            set
            {
                if (!Equals(value, _customPropertyStoreProperty))
                {
                    _customPropertyStoreProperty = value;
                    OnRdPropertyStoreProperty(EventArgs.Empty);

                    // We update this property only at design-time, not at runtime.
                    if (IsHandleCreated && IsAncestorSiteInDesignMode)
                    {
                        Invalidate();
                    }
                }
            }
        }

        /// <summary>
        ///  Raises the <see cref="RdPropertyStorePropertyChanged"/> event.
        /// </summary>
        protected virtual void OnRdPropertyStoreProperty(EventArgs e)
            => RdPropertyStorePropertyChanged?.Invoke(this, e);

        /// <summary>
        ///  Resets the <see cref="RdPropertyStoreProperty"/>.
        /// </summary>
        private void ResetRdPropertyStoreProperty()
            => RdPropertyStoreProperty = null;

        /// <summary>
        ///  Indicates whether the <see cref="RdPropertyStoreProperty"/> property should be persisted.
        /// </summary>
        /// <returns>
        ///  <see langword="true"/> if the CodeDOM serializer should emit code for 
        ///  assigning a valid content to the property in InitializeComponent.
        /// </returns>
        private bool ShouldSerializeRdPropertyStoreProperty()
            => RdPropertyStoreProperty is not null;

        // The only function of this control is to draw a visual
        // representation of the RdPropertyStoreProperty at Design and Runtime.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // We show this only at Design time, not at runtime.
            if (IsAncestorSiteInDesignMode)
            {

                // Drawing a frame around the control's borders:
                var pen = new Pen(ForeColor);
                var brush = new SolidBrush(ForeColor);

                // Drawing the contents of the CustomProperty.
                e.Graphics.DrawString(
                    BuildContentString(RdPropertyStoreProperty),
                    Font,
                    brush,
                    point: new(10, 10));

                // Builds a long string with the text representation of 
                // the RdPropertyStoreProperty property of this control.
                string BuildContentString(RdPropertyStore? propertyData)
                {
                    StringBuilder stringBuilder = new();

                    if (propertyData is null)
                    {
                        stringBuilder.Append("No CustomProperty Data defined.");
                        return stringBuilder.ToString();
                    }

                    stringBuilder.AppendLine($"{nameof(propertyData.SomeMustHaveId)}: {propertyData.SomeMustHaveId}");
                    stringBuilder.AppendLine($"{nameof(propertyData.DateCreated)}: {propertyData.DateCreated:yyyy-mm-dd (ddd)}");
                    stringBuilder.AppendLine($"{nameof(propertyData.CustomEnumValue)}: '{propertyData.CustomEnumValue}'");
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine("List of Strings:");
                    stringBuilder.AppendLine("=============================");

                    propertyData.ListOfStrings?.ForEach(
                        stringValue => stringBuilder.AppendLine($"* {stringValue}"));

                    return stringBuilder.ToString();
                }
            }
        }
    }
}
