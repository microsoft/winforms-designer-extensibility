using System.ComponentModel;
using System.Text;

namespace CustomControlLibrary
{
    /// <summary>
    ///  Custom Control sample implementation.
    /// </summary>
    /// <remarks>
    ///  This sample custom control implements one custom property named <see cref="CustomPropertyStoreProperty"/> 
    ///  of type <see cref="CustomPropertyStore"/>. Its sole purpose is to demonstrate how to implement
    ///  a custom TypeEditor for editing this property's content at design time with the out-of-process
    ///  WinForms Designer. 
    /// </remarks>
    [Designer("CustomControlDesigner")]
    public class CustomControl : Control
    {
        // Backing field for CustomProperty.
        private CustomPropertyStore? _customPropertyStoreProperty;

        /// <summary>
        ///  Occurs when the CustomPropertyStoreProperty changes.
        /// </summary>
        public event EventHandler? CustomPropertyStorePropertyChanged;

        public CustomControl()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        /// <summary>
        ///  Gets or sets a value of type <see cref="CustomPropertyStore"/> which is composed of different value types,
        ///  a custom enum and a string array.
        /// </summary>
        [Description("A custom property composed of different value types, a custom enum and a string array."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomPropertyStore? CustomPropertyStoreProperty
        {
            get => _customPropertyStoreProperty;

            set
            {
                if (!Equals(value, _customPropertyStoreProperty))
                {
                    _customPropertyStoreProperty = value;
                    OnCustomPropertyStoreProperty(EventArgs.Empty);

                    // We update this property only at design-time, not at runtime.
                    if (IsHandleCreated && IsAncestorSiteInDesignMode)
                    {
                        Invalidate();
                    }
                }
            }
        }

        /// <summary>
        ///  Raises the <see cref="CustomPropertyStorePropertyChanged"/> event.
        /// </summary>
        protected virtual void OnCustomPropertyStoreProperty(EventArgs e)
            => CustomPropertyStorePropertyChanged?.Invoke(this, e);

        /// <summary>
        ///  Resets the <see cref="CustomPropertyStoreProperty"/>.
        /// </summary>
        private void ResetCustomPropertyStoreProperty()
            => CustomPropertyStoreProperty = null;

        /// <summary>
        ///  Indicates whether the <see cref="CustomPropertyStoreProperty"/> property should be persisted.
        /// </summary>
        /// <returns>
        ///  <see langword="true"/> if the CodeDOM serializer should emit code for 
        ///  assigning a valid content to the property in InitializeComponent.
        /// </returns>
        private bool ShouldSerializeCustomPropertyStoreProperty()
            => CustomPropertyStoreProperty is not null;

        // The only function of this control is to draw a visual
        // representation of the CustomPropertyStoreProperty at Design and Runtime.
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
                    BuildContentString(CustomPropertyStoreProperty),
                    Font,
                    brush,
                    point: new(10, 10));

                // Builds a long string with the text representation of 
                // the CustomPropertyStoreProperty property of this control.
                string BuildContentString(CustomPropertyStore? propertyData)
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
