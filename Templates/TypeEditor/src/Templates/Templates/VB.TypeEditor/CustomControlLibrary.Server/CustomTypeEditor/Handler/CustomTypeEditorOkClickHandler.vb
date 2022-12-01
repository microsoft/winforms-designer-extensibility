Imports CustomControlLibrary.Protocol
Imports CustomControlLibrary.Protocol.Endpoints
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Handlers

    <ExportRequestHandler(EndpointNames.CustomTypeEditorEditorOKClick)>
    Friend Class CustomTypeEditorOkClickHandler
        Inherits RequestHandler(Of CustomTypeEditorOKClickRequest, CustomTypeEditorOKClickResponse)

        ''' <summary>
        ''' Handler for the TypeEditor Dialog's OK-Click event.
        ''' </summary>
        ''' <param name="request">Contains the ViewModel reference and the new PropertyStoreData,
        ''' which contain the new values which have been edited/entered in the TypeEditor dialog.</param>
        ''' <returns>The response, which is empty in this case, but the conventions need to be honored.</returns>
        Public Overrides Function HandleRequest(ByVal request As CustomTypeEditorOKClickRequest) As CustomTypeEditorOKClickResponse
            ' Getting the ViewModel passed via the endpoint's request class.
            Dim viewModel = CType(request.ViewModel, CustomTypeEditorVM)

            ' Delegate the actual handling of the OKClick event to the server-side ViewModel.
            viewModel.OKClick(request.PropertyStoreData)

            ' Nothing really to return, just honoring the conventions.
            Return CustomTypeEditorOKClickResponse.Empty
        End Function
    End Class

End Namespace
