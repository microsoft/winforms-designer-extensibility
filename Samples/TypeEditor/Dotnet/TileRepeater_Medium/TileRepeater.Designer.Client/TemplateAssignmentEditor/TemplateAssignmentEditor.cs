using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinForms.Tiles.Designer.Client
{
    internal class TemplateAssignmentEditor : UITypeEditor
    {
        private TemplateAssignmentDialog? _templateAssignmentDialog;

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

            // value now holds the proxy of the TemplateAssignment object which is edited.
            var viewModelClient = TemplateAssignmentViewModelClient.Create(provider, value);

            _templateAssignmentDialog ??= new TemplateAssignmentDialog(provider, viewModelClient);
            _templateAssignmentDialog.Context = context;
            _templateAssignmentDialog.Host = designerHost;
            _templateAssignmentDialog.ViewModelClient = viewModelClient;

            // We don't need to do anything, since the Dialog has already set the
            // property server-side.
            var dialogResult = editorService.ShowDialog(_templateAssignmentDialog);
            if (dialogResult == DialogResult.OK)
            {
                value = viewModelClient.TemplateAssignment;
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;
    }
}
