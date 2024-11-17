using System;
using System.Diagnostics.CodeAnalysis;
using RootDesignerDemo.Protocol.DataTransport;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Protocol.Endpoints
{
    /// <summary>
    ///  Request class for the <see cref="RdTypeEditorOKClick"/> endpoint. This passes the necessary
    ///  context (ViewModel, content of custom property) from the Client to the Server.
    /// </summary>
    public class RdTypeEditorOKClickRequest : Request
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        [AllowNull]
        public RdPropertyStoreData PropertyStoreData { get; private set; }

        public RdTypeEditorOKClickRequest(object? viewModel, RdPropertyStoreData? propertyStoreData)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            PropertyStoreData = propertyStoreData;
        }

        public RdTypeEditorOKClickRequest(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            PropertyStoreData = reader.ReadDataPipeObjectOrNull<RdPropertyStoreData>(nameof(PropertyStoreData));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.WriteDataPipeObjectIfNotNull<RdPropertyStoreData>(nameof(PropertyStoreData), PropertyStoreData);
        }
    }
}
