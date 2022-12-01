Imports CustomControlLibrary.Protocol.DataTransport
Imports CustomControlLibrary.Protocol.Endpoints
Imports Microsoft.DotNet.DesignTools.ViewModels

''' <summary>
''' The server-side ViewModel for controlling the CustomTypeEditor UI.
''' </summary>
''' <remarks>
''' 'ViewModel' in this context is a class which holds the logic/properties to control the UI. This is the 
''' server-side part, but there is also a client-side part of that ViewModel. The server-side provides the logic based 
''' on the real types of the CustomTypeEditor, running in the context of the TFM of the custom control. It communicates 
''' to the client-side ViewModel part, which _then_ controls the client-side hosted UI, which in turn runs in the 
''' TFM-context of Visual Studio.
''' </remarks>
Partial Friend Class CustomTypeEditorVM
    Inherits ViewModel

    Public Sub New(ByVal provider As IServiceProvider)
        MyBase.New(provider)
    End Sub

    Public Function Initialize(ByVal propertyStoreObject As Object) As CreateCustomTypeEditorVMResponse

        Dim propertyStore = DirectCast(propertyStoreObject, CustomPropertyStore)

        Return New CreateCustomTypeEditorVMResponse(
            Me,
            If(
                propertyStore Is Nothing,
                Nothing,
                New CustomPropertyStoreData(
                    propertyStore.SomeMustHaveId,
                    propertyStore.DateCreated,
                    propertyStore.ListOfStrings?.ToArray(),
                    CByte(Math.Truncate(propertyStore.CustomEnumValue)))))
    End Function

    Friend Sub OKClick(ByVal propertyStoreData As CustomPropertyStoreData)

        ' We're constructing the actual PropertyStore content based
        ' on the data that the user edited and the View sent to the server.
        PropertyStore = New CustomPropertyStore(
            propertyStoreData.SomeMustHaveId,
            propertyStoreData.DateCreated,
            propertyStoreData.ListOfStrings?.ToList(),
            CType(propertyStoreData.CustomEnumValue, CustomPropertyStoreEnum))

        ' So, the server-side ViewModel now holds the edited, commited result.
        ' The question now is: How does the ViewModel property find the way back
        ' to the control?
        ' That is done client-side: On the client, the client-side ViewModel holds the reference to the this
        ' PropertyStore property over a ProxyObject. When the user clicks OK in the editor, that codeflow is
        ' returned to the client-side part of the TypeEditor. That is where the assignment from this ViewModel
        ' to the actual property of the control happens.
    End Sub

    Public Property PropertyStore As CustomPropertyStore
End Class
