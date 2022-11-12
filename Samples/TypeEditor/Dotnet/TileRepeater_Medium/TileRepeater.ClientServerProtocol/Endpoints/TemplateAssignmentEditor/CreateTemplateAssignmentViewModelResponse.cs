using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;
using System;
using System.Diagnostics.CodeAnalysis;
using WinForms.Tiles.ClientServerProtocol;

namespace WinForms.Tiles.Designer.Protocol.Endpoints
{
    public class CreateTemplateAssignmentViewModelResponse : Response
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        [AllowNull]
        public TypeInfoData[] TemplateServerTypes { get; private set; }

        [AllowNull]
        public TypeInfoData[] TileServerTypes { get; private set; }

        public CreateTemplateAssignmentViewModelResponse() { }

        public CreateTemplateAssignmentViewModelResponse(object viewModel, TypeInfoData[] templateServerTypes, TypeInfoData[] tileServerTypes)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            TemplateServerTypes = templateServerTypes ?? throw new ArgumentNullException(nameof(templateServerTypes));
            TileServerTypes = tileServerTypes ?? throw new ArgumentNullException(nameof(tileServerTypes));
        }

        public CreateTemplateAssignmentViewModelResponse(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            TemplateServerTypes = reader.ReadDataPipeObjectArray<TypeInfoData>(nameof(TemplateServerTypes));
            TileServerTypes = reader.ReadDataPipeObjectArray<TypeInfoData>(nameof(TileServerTypes));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.WriteDataPipeObjectArray(nameof(TemplateServerTypes), TemplateServerTypes);
            writer.WriteDataPipeObjectArray(nameof(TileServerTypes), TileServerTypes);
        }
    }
}