using CustomControlLibrary.Protocol;
using CustomControlLibrary.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace CustomControlLibrary.Designer.Server.Handlers
{
    [ExportRequestHandler(EndpointNames.CustomTypeEditorEditorOKClick)]
    internal class CustomTypeEditorOkClickHandler : RequestHandler<CustomTypeEditorOKClickRequest, CustomTypeEditorOKClickResponse>
    {
        /// <summary>
        /// Handler for the TypeEditor Dialog's OK-Click event.
        /// </summary>
        /// <param name="request">Contains the ViewModel reference and the new PropertyStoreData,
        /// which contain the new values which have been edited/entered in the TypeEditor dialog.</param>
        /// <returns>The response, which is empty in this case, but the conventions need to be honored.</returns>
        public override CustomTypeEditorOKClickResponse HandleRequest(CustomTypeEditorOKClickRequest request)
        {
            // Getting the ViewModel passed via the endpoint's request class.
            var viewModel = (CustomTypeEditorVM)request.ViewModel;

            // Delegate the actual handling of the OKClick event to the server-side ViewModel.
            viewModel.OKClick(request.PropertyStoreData);

            // Nothing really to return, just honoring the conventions.
            return CustomTypeEditorOKClickResponse.Empty;
        }
    }
}
