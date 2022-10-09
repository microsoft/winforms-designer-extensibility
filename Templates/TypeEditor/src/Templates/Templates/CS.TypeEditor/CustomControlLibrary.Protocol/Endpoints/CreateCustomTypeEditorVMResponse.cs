using System;
using System.Diagnostics.CodeAnalysis;
using CustomControlLibrary.Protocol.DataTransport;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Protocol.Endpoints
{
    /// <summary>
    ///  Response class, answering the request for that endpoint. This transports the requested data (Proxy of
    ///  the server-side ViewModel and the data of the custom property type <c>PropertyStore</c>) back to the client.
    /// </summary>
    public class CreateCustomTypeEditorVMResponse : Response
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        public CustomPropertyStoreData? PropertyStoreData { get; set; }

        public CreateCustomTypeEditorVMResponse() { }

        public CreateCustomTypeEditorVMResponse(
            object viewModel,
            CustomPropertyStoreData? propertyStoreData)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            PropertyStoreData = propertyStoreData;
        }

        public CreateCustomTypeEditorVMResponse(IDataPipeReader reader) : base(reader) { }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            PropertyStoreData = reader.ReadDataPipeObjectOrNull<CustomPropertyStoreData>(nameof(PropertyStoreData));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.WriteDataPipeObjectIfNotNull<CustomPropertyStoreData>(nameof(PropertyStoreData), PropertyStoreData!);
        }
    }
}
