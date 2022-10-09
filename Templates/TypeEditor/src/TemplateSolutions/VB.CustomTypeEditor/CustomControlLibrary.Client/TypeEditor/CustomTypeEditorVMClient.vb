Imports CustomControlLibrary.Protocol
Imports CustomControlLibrary.Protocol.DataTransport
Imports CustomControlLibrary.Protocol.Endpoints
Imports Microsoft.DotNet.DesignTools.Client
Imports Microsoft.DotNet.DesignTools.Client.Proxies
Imports Microsoft.DotNet.DesignTools.Client.Views

''' <summary>
''' Client-side implementation of the ViewModel to control the TypeEditor UI.
''' </summary>
Friend Class CustomTypeEditorVMClient
    Inherits ViewModelClient

    <ExportViewModelClientFactory(ViewModelNames.CustomTypeEditorVM)>
    Private Class Factory
        Inherits ViewModelClientFactory(Of CustomTypeEditorVMClient)

        Protected Overrides Function CreateViewModelClient(ByVal viewModel As ObjectProxy) As CustomTypeEditorVMClient
            Return New CustomTypeEditorVMClient(viewModel)
        End Function
    End Class

    Public Sub New(ByVal viewModel As ObjectProxy)
        MyBase.New(viewModel)

        If viewModel Is Nothing Then
            Throw New ArgumentNullException(NameOf(viewModel))
        End If
    End Sub

    ''' <summary>
    '''  Creates an instance of this VMClient and initializes it with the server types 
    '''  from which the data sources can be generated.
    ''' </summary>
    ''' <param name="session">
    '''  The designer session to create the VMClient server side.
    ''' </param>
    ''' <returns>
    '''  The VMClient for controlling the TypeEditor dialog.
    ''' </returns>
    Public Shared Function Create(ByVal provider As IServiceProvider, ByVal customPropertyStoreProxy As Object) As CustomTypeEditorVMClient
        Dim session = provider.GetRequiredService(Of DesignerSession)()
        Dim client = provider.GetRequiredService(Of IDesignToolsClient)()
        Dim response = client.SendRequest(Of CreateCustomTypeEditorVMResponse)(New CreateCustomTypeEditorVMRequest(session.Id, customPropertyStoreProxy))
        Dim viewModel = CType(response.ViewModel, ObjectProxy)
        Dim clientViewModel = provider.CreateViewModelClient(Of CustomTypeEditorVMClient)(viewModel)

        clientViewModel.Initialize(response.PropertyStoreData)

        Return clientViewModel
    End Function

    Private Sub Initialize(ByVal propertyStoreData As CustomPropertyStoreData)
        Me.PropertyStoreData = propertyStoreData
    End Sub

    ' Executes the OK Command when the user has clicked the OK button:
    ' It takes the _propertyStoreData, sends it to the server process along with the ViewModelProxy,
    ' so the server process can access it. The server then creates the actual PropertyStore object 
    ' from the passed data (remember: the client cannot do that, since it doesn't know about the
    ' CustomPropertyStore type which only exists server-side!), and stores it in its PropertyStore property.
    ' Now, when the TypeEditor continues with the codeflow in EditValue, it gets the updated value to return to
    ' the property grid from this client-side ViewModel, namely from its PropertyStore property. This property
    ' in turn uses the ViewModelProxy to call the server and get the proxy of the value from the server-side
    ' ViewModel, which our OKClickHandler has _just_ updated server-side and is therefore up-to-date.
    Friend Sub ExecuteOkCommand()
        Client.SendRequest(New CustomTypeEditorOKClickRequest(ViewModelProxy, PropertyStoreData))
    End Sub

    ' Get, when the TypeEditor's UI need to be update its controls to show the content of the custom property.
    ' Set, when the validation of the data passed, which was just entered by the user.
    Friend Property PropertyStoreData As CustomPropertyStoreData

    ''' <summary>
    ''' Returns the Proxy of the server-side ViewModel's PropertyStore property.
    ''' </summary>
    Public ReadOnly Property PropertyStore() As Object
        Get
            Return ViewModelProxy.GetPropertyValue(NameOf(PropertyStore))
        End Get
    End Property
End Class

