using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinForms.Tiles.Designer
{
    internal class TemplateAssignmentEditor : UITypeEditor
    {
        private TemplateAssignmentDialog? _templateAssignmentDialog;

        public override object? EditValue(
            ITypeDescriptorContext context,
            IServiceProvider provider,
            object? value)
        {
            if (provider is null || !(value is null or TemplateAssignment))
            {
                return value;
            }

            TemplateAssignment? templateAssignment = (TemplateAssignment?)value;
            var editorService = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
            var designerHost = (IDesignerHost)provider.GetService(typeof(IDesignerHost));

            // value now holds the proxy of the TemplateAssignment object which is edited.
            var viewModel = TemplateAssignmentViewModel.Create(templateAssignment, designerHost);

            _templateAssignmentDialog ??= new TemplateAssignmentDialog(provider, viewModel);
            _templateAssignmentDialog.Context = context;
            _templateAssignmentDialog.Host = designerHost;

            // We don't need to do anything, since the Dialog has already set the
            // property server-side.
            var dialogResult = editorService.ShowDialog(_templateAssignmentDialog);

            if (dialogResult == DialogResult.OK)
            {
                value = viewModel.TemplateAssignment;
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            => UITypeEditorEditStyle.Modal;
    }
}
