using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomControlLibrary.Designer.Client
{
    /// <summary>
    /// The actual client-side implementation of the CustomTypeEditor, which is called by 
    /// Visual Studio's Property Browser.
    /// </summary>
    public class CustomTypeEditor : UITypeEditor
    {
        CustomTypeEditorDialog? _customTypeEditorDialog;

        public override object? EditValue(
            ITypeDescriptorContext context,
            IServiceProvider provider,
            object? value)
        {
            if (provider is null)
            {
                return value;
            }

            var editorService = provider.GetRequiredService<IWindowsFormsEditorService>();
            var designerHost = provider.GetRequiredService<IDesignerHost>();

            // Value now holds the proxy of the CustomPropertyStore object the user wants to edit.
            var viewModelClient = CustomTypeEditorVMClient.Create(provider, value);

            _customTypeEditorDialog ??= new CustomTypeEditorDialog(provider, viewModelClient);
            _customTypeEditorDialog.Context = context;
            _customTypeEditorDialog.Host = designerHost;

            var dialogResult = editorService.ShowDialog(_customTypeEditorDialog);
            if (dialogResult == DialogResult.OK)
            {
                // By now, the UI of the Editor has asked its (client-side) ViewModel
                // to run the code which updates the property value. It passes the data to
                // the server, which in turn updates the server-side ViewModel.
                // When it's time to return the value from the client-side ViewModel back to the
                // Property Browser (which has called the TypeEditor in the first place), the client-side
                // ViewModel accesses its PropertyStore property, which in turn gets the required PropertyStore
                // proxy object directly from the server-side ViewModel.
                value = viewModelClient.PropertyStore;
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;
    }
}
