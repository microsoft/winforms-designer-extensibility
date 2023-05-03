using System;
using RootDesignerDemo.Protocol;
using RootDesignerDemo.Protocol.DataTransport;
using RootDesignerDemo.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.Client;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;

namespace RootDesignerDemo.Designer.Client
{
    /// <summary>
    /// Client-side implementation of the ViewModel to control the TypeEditor UI.
    /// </summary>
    internal class RdTypeEditorVMClient : ViewModelClient
    {
        [ExportViewModelClientFactory(ViewModelNames.RdTypeEditorVM)]
        private class Factory : ViewModelClientFactory<RdTypeEditorVMClient>
        {
            protected override RdTypeEditorVMClient CreateViewModelClient(ObjectProxy? viewModel)
                => new(viewModel);
        }

        public RdTypeEditorVMClient(ObjectProxy? viewModel) : base(viewModel)
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
        public static RdTypeEditorVMClient Create(
            IServiceProvider provider,
            object? customPropertyStoreProxy)
        {
            var session = provider.GetRequiredService<DesignerSession>();
            var client = provider.GetRequiredService<IDesignToolsClient>();

            var response = client.SendRequest<CreateRdTypeEditorVMResponse>(
                new CreateRdTypeEditorVMRequest(
                    session.Id,
                    customPropertyStoreProxy));

            var viewModel = (ObjectProxy)response.ViewModel!;

            var clientViewModel = provider.CreateViewModelClient<RdTypeEditorVMClient>(viewModel);
            clientViewModel.Initialize(response.PropertyStoreData);

            return clientViewModel;
        }

        private void Initialize(RdPropertyStoreData? propertyStoreData)
        {
            PropertyStoreData = propertyStoreData;
        }

        // Executes the OK Command when the user has clicked the OK button:
        // It takes the _propertyStoreData, sends it to the Server along with the ViewModelProxy,
        // so the server process can access it. The server process then creates the actual PropertyStore object 
        // from the passed data (remember: the client cannot do that, since it doesn't know about the
        // RdPropertyStore type which only exists server-side!) and stores it in its PropertyStore property.
        // Now, when the TypeEditor continues with the codeflow in EditValue, it gets the updated value to return to
        // the property grid from this client-side ViewModel, namely from its PropertyStore property. This property
        // in turn uses the ViewModelProxy to call the server and get the Proxy of the value from the server-side
        // ViewModel, which our OKClickHandler has _just_ updated server-side and is therefore up-to-date.
        internal void ExecuteOkCommand()
        {
            Client!.SendRequest(new RdTypeEditorOKClickRequest(ViewModelProxy, PropertyStoreData));
        }

        // Get, when the TypeEditor's UI need to be update its controls to show the content of the custom property.
        // Set, when the validation of the data passed, which was just entered by the User.
        internal RdPropertyStoreData? PropertyStoreData { get; set; }

        /// <summary>
        /// Returns the Proxy of the server-side ViewModel's PropertyStore property.
        /// </summary>
        public Object? PropertyStore

            // See also comment on ExecuteOKCommand.
            => ViewModelProxy!.GetPropertyValue(nameof(PropertyStore));
    }
}
