using RootDesignerDemo.Protocol;
using RootDesignerDemo.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Designer.Server.Handlers
{
    [ExportRequestHandler(EndpointNames.RdTypeEditorEditorOKClick)]
    internal class RdTypeEditorOkClickHandler : RequestHandler<RdTypeEditorOKClickRequest, RdTypeEditorOKClickResponse>
    {
        /// <summary>
        /// Handler for the TypeEditor Dialog's OK-Click event.
        /// </summary>
        /// <param name="request">Contains the ViewModel reference and the new PropertyStoreData,
        /// which contain the new values which have been edited/entered in the TypeEditor dialog.</param>
        /// <returns>The response, which is empty in this case, but the conventions need to be honored.</returns>
        public override RdTypeEditorOKClickResponse HandleRequest(RdTypeEditorOKClickRequest request)
        {
            // Getting the ViewModel passed via the endpoint's request class.
            var viewModel = (RdTypeEditorVM)request.ViewModel;

            // Delegate the actual handling of the OKClick event to the server-side ViewModel.
            viewModel.OKClick(request.PropertyStoreData);

            // Nothing really to return, just honoring the conventions.
            return RdTypeEditorOKClickResponse.Empty;
        }
    }
}
