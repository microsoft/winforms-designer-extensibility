using Microsoft.DotNet.DesignTools.Client;
using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;
using System;
using WinForms.Tiles.ClientServerProtocol;
using WinForms.Tiles.Designer.Protocol;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Client
{
    internal partial class TemplateAssignmentViewModelClient : ViewModelClient
    {
        [ExportViewModelClientFactory(ViewModelNames.TemplateAssignmentViewModel)]
        private class Factory : ViewModelClientFactory<TemplateAssignmentViewModelClient>
        {
            protected override TemplateAssignmentViewModelClient CreateViewModelClient(ObjectProxy? viewModel)
                => new(viewModel);
        }

        private TemplateAssignmentViewModelClient(ObjectProxy? viewModel)
            : base(viewModel)
        {
            if (viewModel is null)
            {
                throw new NullReferenceException(nameof(viewModel));
            }
        }

        /// <summary>
        ///  Creates an instance of this ViewModelClient and initializes it with the ServerTypes 
        ///  from which the Data Sources can be generated.
        /// </summary>
        /// <param name="session">
        ///  The designer session to create the ViewModelClient server side.
        /// </param>
        /// <returns>
        ///  The ViewModelClient for controlling the NewObjectDataSource dialog.
        /// </returns>
        public static TemplateAssignmentViewModelClient Create(
            IServiceProvider provider,
            object? templateAssignmentProxy)
        {
            var session = provider.GetRequiredService<DesignerSession>();
            var client = provider.GetRequiredService<IDesignToolsClient>();

            var createViewModelEndpointSender = client.Protocol.GetEndpoint<CreateTemplateAssignmentViewModelEndpoint>().GetSender(client);

            var response = createViewModelEndpointSender.SendRequest(new CreateTemplateAssignmentViewModelRequest(session.Id, templateAssignmentProxy));
            var viewModel = (ObjectProxy)response.ViewModel!;

            var clientViewModel = provider.CreateViewModelClient<TemplateAssignmentViewModelClient>(viewModel);
            clientViewModel.Initialize(response.TemplateServerTypes, response.TileServerTypes);

            return clientViewModel;
        }

        private void Initialize(TypeInfoData[] templateServerTypes, TypeInfoData[] tileServerTypes)
        {
            TemplateServerTypes = templateServerTypes;
            TileServerTypes = tileServerTypes;
        }

        /// <summary>
        ///  Contains the types which have been discovered by the Server Process.
        /// </summary>
        public TypeInfoData[] TemplateServerTypes { get; private set; } = null!;

        /// <summary>
        ///  Contains the tile-based types which have been discovered by the Server Process.
        /// </summary>
        public TypeInfoData[] TileServerTypes { get; private set; } = null!;

        public string? TemplateQualifiedTypename
        {
            get => ViewModelProxy?.GetPropertyValue<string>(nameof(TemplateQualifiedTypename));
            set => ViewModelProxy?.SetPropertyValue(nameof(TemplateQualifiedTypename), value);
        }

        public string? TileContentQualifiedTypename
        {
            get => ViewModelProxy?.GetPropertyValue<string>(nameof(TileContentQualifiedTypename));
            set => ViewModelProxy?.SetPropertyValue(nameof(TileContentQualifiedTypename), value);
        }

        internal void ExecuteOkCommand()
        {
            var okClickEndpointSender = Client!.Protocol.GetEndpoint<TemplateAssignmentEditorOKClickEndpoint>().GetSender(Client);
            okClickEndpointSender.SendRequest(new TemplateAssignmentEditorOKClickRequest(ViewModelProxy!));
        }

        public object? TemplateAssignment
            => ViewModelProxy!.GetPropertyValue(nameof(TemplateAssignment));
    }
}
