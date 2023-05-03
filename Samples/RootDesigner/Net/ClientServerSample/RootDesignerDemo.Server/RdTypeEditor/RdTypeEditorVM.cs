using System;
using System.Linq;
using RootDesignerDemo.Protocol.DataTransport;
using RootDesignerDemo.Protocol.Endpoints;
using Microsoft.DotNet.DesignTools.ViewModels;
using RootDesignerDemo.Controls;

namespace RootDesignerDemo.Designer.Server
{
    /// <summary>
    /// The server-side ViewModel for controlling the RdTypeEditor UI.
    /// </summary>
    /// <remarks>
    /// 'ViewModel' in this context is a class which holds the logic/properties to control the UI. This is the 
    /// server-side part, but there is also a client-side part of that ViewModel. The server-side provides the logic based 
    /// on the real types of the RdTypeEditor, running in the context of the TFM of the custom control. It communicates 
    /// to the client-side ViewModel part, which _then_ controls the client-side hosted UI, which in turn runs in the 
    /// TFM-context of Visual Studio.
    /// </remarks>
    internal partial class RdTypeEditorVM : ViewModel
    {
        public RdTypeEditorVM(IServiceProvider provider)
            : base(provider)
        {
        }

        public CreateRdTypeEditorVMResponse Initialize(object propertyStoreObject)
        {
            var propertyStore = (RdPropertyStore)propertyStoreObject;

            return new CreateRdTypeEditorVMResponse(
                this,
                propertyStore is null
                ? null
                : new RdPropertyStoreData(
                     propertyStore.SomeMustHaveId,
                     propertyStore.DateCreated,
                     propertyStore.ListOfStrings?.ToArray(),
                     (byte)propertyStore.CustomEnumValue));
        }

        internal void OKClick(RdPropertyStoreData propertyStoreData)
        {
            // We're constructing the actual PropertyStore content based
            // on the data that the user edited and the View sent to the server.

            PropertyStore = new(
                propertyStoreData.SomeMustHaveId,
                propertyStoreData.DateCreated,
                propertyStoreData.ListOfStrings?.ToList(),
                (RdPropertyStoreEnum)propertyStoreData.CustomEnumValue);

            // So, the server-side ViewModel now holds the edited, commited result.
            // The question now is: How does the ViewModel property find the way back
            // to the control?
            // That's been done client-side: On the client, the client-side ViewModel holds the reference to the this
            // PropertyStore property over a ProxyObject. When the User clicks OK in the editor, that codeflow is
            // returned to the client-side part of the TypeEditor. That is, where the assignment from this ViewModel
            // to the actual Property of the Control happens.
        }

        public RdPropertyStore? PropertyStore { get; set; }
    }
}
