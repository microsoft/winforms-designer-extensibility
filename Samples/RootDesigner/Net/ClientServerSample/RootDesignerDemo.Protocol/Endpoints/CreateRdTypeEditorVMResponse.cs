using System;
using System.Diagnostics.CodeAnalysis;
using RootDesignerDemo.Protocol.DataTransport;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Protocol.Endpoints
{
    /// <summary>
    ///  Response class, answering the request for that endpoint. This transports the requested data (Proxy of
    ///  the server-side ViewModel and the data of the custom property type <c>PropertyStore</c>) back to the client.
    /// </summary>
    public class CreateRdTypeEditorVMResponse : Response
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        public RdPropertyStoreData? PropertyStoreData { get; set; }

        public CreateRdTypeEditorVMResponse() { }

        public CreateRdTypeEditorVMResponse(
            object viewModel,
            RdPropertyStoreData? propertyStoreData)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            PropertyStoreData = propertyStoreData;
        }

        public CreateRdTypeEditorVMResponse(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            PropertyStoreData = reader.ReadDataPipeObjectOrNull<RdPropertyStoreData>(nameof(PropertyStoreData));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.WriteDataPipeObjectIfNotNull<RdPropertyStoreData>(nameof(PropertyStoreData), PropertyStoreData!);
        }
    }
}
