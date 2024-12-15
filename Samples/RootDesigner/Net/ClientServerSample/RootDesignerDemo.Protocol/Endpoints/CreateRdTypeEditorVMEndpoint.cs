using System.Composition;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using Microsoft.DotNet.DesignTools.Protocol.Endpoints;

namespace RootDesignerDemo.Protocol.Endpoints
{
    /// <summary>
    ///  Endpoint for the method to create the RdTypeEditor's ViewModel.
    /// </summary>
    /// <remarks>
    ///  'ViewModel' in this context is a class which holds the logic/properties to control the UI. There is a 
    ///  server-side and a client-side part of that view model. The server-side provides the logic based on the actual
    ///  types of RdTypeEditor, running in the context of the custom control's TFM. It communicates to the 
    ///  client-side view model, which then controls the client-side hosted UI, running in the context of 
    ///  Visual Studio.
    ///  For every endpoint there is a request class and a response class for transporting the necessary data
    ///  to the respective context. There is also an additional endpoint handler, which holds the code that executes the actual
    ///  functionality of that endpoint. Request and response are located in the communications assembly; the actual handler is 
    ///  part of the server-side implementation of the RdControl, along with the actual control designer and the 
    ///  server-side view model.
    /// </remarks>
    [Shared]
    [ExportEndpoint]
    public class CreateRdTypeEditorVMEndpoint 
        : Endpoint<CreateRdTypeEditorVMRequest, CreateRdTypeEditorVMResponse>
    {
        public override string Name => EndpointNames.CreateRdTypeEditorVM;

        protected override CreateRdTypeEditorVMRequest CreateRequest(IDataPipeReader reader)
            => new(reader);

        protected override CreateRdTypeEditorVMResponse CreateResponse(IDataPipeReader reader)
            => new(reader);
    }
}
