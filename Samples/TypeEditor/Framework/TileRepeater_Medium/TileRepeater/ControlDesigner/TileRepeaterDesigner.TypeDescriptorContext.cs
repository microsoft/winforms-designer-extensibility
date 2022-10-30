using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinForms.Tiles.Designer
{
    internal partial class TileRepeaterDesigner
    {
        /// <summary>
        ///  Helper class, so we can show a Type Editor from an ActionList.
        /// </summary>
        /// <remarks>
        ///  The idea is, that we use this as a service provider (<see cref="ITypeDescriptorContext"/> derived
        ///  from <see cref="IServiceProvider"/>) and a <see cref="IWindowsFormsEditorService"/> at the same time.
        ///  The latter is needed inside a Type Editor to show the actual Dialog. Unfortunately, that service is
        ///  not available, neither via the Site nor the DesignerHost in the context of the ActionList.
        ///  So, we use this class to reroute the responsibility to show the dialog to this class.
        /// </remarks>
        private class TypeDescriptorContext : ITypeDescriptorContext, IWindowsFormsEditorService
        {
            private readonly IComponent _component;

            public TypeDescriptorContext(IComponent component, PropertyDescriptor propertyDescriptor)
            {
                _component = component ?? throw new ArgumentNullException(nameof(component));
                PropertyDescriptor = propertyDescriptor ?? throw new ArgumentNullException(nameof(propertyDescriptor));
            }

            public IContainer? Container
                => _component.Site?.Container;

            public object Instance
                => _component;

            public PropertyDescriptor PropertyDescriptor { get; }

            public void CloseDropDown()
            {
            }

            public void DropDownControl(Control control)
            {
            }

            public object? GetService(Type serviceType)
            {
                // When the Type Editor requests the IWindowsFormsEditorService, we
                // return this. Then, when the Type Editor wants to show the dialog,
                // that method call gets rerouted to our implementation here.
                if (serviceType == typeof(ITypeDescriptorContext) ||
                    serviceType == typeof(IWindowsFormsEditorService))
                {
                    return this;
                }

                return _component.Site?.GetService(serviceType);
            }

            // Don't need this since the content update of the control at design time
            // is done by the control itself.
            public void OnComponentChanged()
            {
            }

            public bool OnComponentChanging()
            {
                return false;
            }

            public DialogResult ShowDialog(Form dialog)
                => GetService(typeof(IUIService)) is IUIService uiService
                    ? uiService.ShowDialog(dialog)
                    : dialog.ShowDialog(_component as IWin32Window);
        }
    }
}
