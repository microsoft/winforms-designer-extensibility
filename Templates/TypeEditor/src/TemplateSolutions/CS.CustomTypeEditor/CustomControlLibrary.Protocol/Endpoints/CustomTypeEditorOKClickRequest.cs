using System;
using System.Diagnostics.CodeAnalysis;
using CustomControlLibrary.Protocol.DataTransport;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Protocol.Endpoints
{
    /// <summary>
    ///  Request class for the <see cref="CustomTypeEditorOKClick"/> endpoint. This passes the necessary
    ///  context (ViewModel, content of custom property) from the Client to the Server.
    /// </summary>
    public class CustomTypeEditorOKClickRequest : Request
    {
        [AllowNull]
        public object ViewModel { get; private set; }

        [AllowNull]
        public CustomPropertyStoreData PropertyStoreData { get; private set; }

        public CustomTypeEditorOKClickRequest(object? viewModel, CustomPropertyStoreData? propertyStoreData)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            PropertyStoreData = propertyStoreData;
        }

        public CustomTypeEditorOKClickRequest(IDataPipeReader reader)
            : base(reader)
        {
        }

        protected override void ReadProperties(IDataPipeReader reader)
        {
            ViewModel = reader.ReadObject(nameof(ViewModel));
            PropertyStoreData = reader.ReadDataPipeObjectOrNull<CustomPropertyStoreData>(nameof(PropertyStoreData));
        }

        protected override void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(ViewModel), ViewModel);
            writer.WriteDataPipeObjectIfNotNull<CustomPropertyStoreData>(nameof(PropertyStoreData), PropertyStoreData);
        }
    }
}
