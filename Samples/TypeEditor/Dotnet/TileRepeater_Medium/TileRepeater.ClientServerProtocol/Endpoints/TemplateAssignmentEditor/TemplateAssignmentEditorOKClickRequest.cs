using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;
using System.Diagnostics.CodeAnalysis;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class TemplateAssignmentEditorOKClickRequest : Request
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        public TemplateAssignmentEditorOKClickRequest(object viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        public TemplateAssignmentEditorOKClickRequest(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
        }
    }
}
