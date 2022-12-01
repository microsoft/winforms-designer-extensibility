using System;
using CustomControlLibrary.Protocol;
using CustomControlLibrary.Protocol.DataTransport;
using CustomControlLibrary.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.Client;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;

namespace CustomControlLibrary.Designer.Client
{
    /// <summary>
    /// Client-side implementation of the ViewModel to control the TypeEditor UI.
    /// </summary>
    internal class CustomTypeEditorVMClient : ViewModelClient
    {
        [ExportViewModelClientFactory(ViewModelNames.CustomTypeEditorVM)]
        private class Factory : ViewModelClientFactory<CustomTypeEditorVMClient>
        {
            protected override CustomTypeEditorVMClient CreateViewModelClient(ObjectProxy? viewModel)
                => new(viewModel);
        }

        public CustomTypeEditorVMClient(ObjectProxy? viewModel) : base(viewModel)
        {
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }
        }

        /// <summary>
        ///  Creates an instance of this VMClient and initializes it with the server types 
        ///  from which the data sources can be generated.
        /// </summary>
        /// <param name="session">
        ///  The designer session to create the VMClient server side.
        /// </param>
        /// <returns>
        ///  The VMClient for controlling the TypeEditor dialog.
        /// </returns>
        public static CustomTypeEditorVMClient Create(
            IServiceProvider provider,
            object? customPropertyStoreProxy)
        {
            var session = provider.GetRequiredService<DesignerSession>();
            var client = provider.GetRequiredService<IDesignToolsClient>();

            var response = client.SendRequest<CreateCustomTypeEditorVMResponse>(
                new CreateCustomTypeEditorVMRequest(
                    session.Id,
                    customPropertyStoreProxy));

            var viewModel = (ObjectProxy)response.ViewModel!;

            var clientViewModel = provider.CreateViewModelClient<CustomTypeEditorVMClient>(viewModel);
            clientViewModel.Initialize(response.PropertyStoreData);

            return clientViewModel;
        }

        private void Initialize(CustomPropertyStoreData? propertyStoreData)
        {
            PropertyStoreData = propertyStoreData;
        }

        // Executes the OK Command when the user has clicked the OK button:
        // It takes the _propertyStoreData, sends it to the Server along with the ViewModelProxy,
        // so the server process can access it. The server process then creates the actual PropertyStore object 
        // from the passed data (remember: the client cannot do that, since it doesn't know about the
        // CustomPropertyStore type which only exists server-side!) and stores it in its PropertyStore property.
        // Now, when the TypeEditor continues with the codeflow in EditValue, it gets the updated value to return to
        // the property grid from this client-side ViewModel, namely from its PropertyStore property. This property
        // in turn uses the ViewModelProxy to call the server and get the Proxy of the value from the server-side
        // ViewModel, which our OKClickHandler has _just_ updated server-side and is therefore up-to-date.
        internal void ExecuteOkCommand()
        {
            Client!.SendRequest(new CustomTypeEditorOKClickRequest(ViewModelProxy, PropertyStoreData));
        }

        // Get, when the TypeEditor's UI need to be update its controls to show the content of the custom property.
        // Set, when the validation of the data passed, which was just entered by the User.
        internal CustomPropertyStoreData? PropertyStoreData { get; set; }

        /// <summary>
        /// Returns the Proxy of the server-side ViewModel's PropertyStore property.
        /// </summary>
        public Object? PropertyStore

            // See also comment on ExecuteOKCommand.
            => ViewModelProxy!.GetPropertyValue(nameof(PropertyStore));
    }
}
