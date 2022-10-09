Imports CustomControlLibrary.Protocol.DataTransport
Imports Microsoft.DotNet.DesignTools.Protocol.DataPipe
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Endpoints
    ''' <summary>
    '''  Response class, answering the request for that endpoint. This transports the requested data (Proxy of
    '''  the server-side ViewModel and the data of the custom property type <c>PropertyStore</c>) back to the client.
    ''' </summary>
    Public Class CreateCustomTypeEditorVMResponse
        Inherits Response

        Private privateViewModel As Object

        Public Property ViewModel() As Object
            Get
                Return privateViewModel
            End Get
            Private Set(ByVal value As Object)
                privateViewModel = value
            End Set
        End Property

        Public Property PropertyStoreData() As CustomPropertyStoreData

        Public Sub New()
        End Sub

        Public Sub New(viewModel As Object, propertyStoreData As CustomPropertyStoreData)
            Me.ViewModel = GlobalUtilities.OrThrowIfArgumentIsNull(viewModel)
            Me.PropertyStoreData = propertyStoreData
        End Sub

        Public Sub New(ByVal reader As IDataPipeReader)
            MyBase.New(reader)
        End Sub

        Protected Overrides Sub ReadProperties(ByVal reader As IDataPipeReader)
            ViewModel = reader.ReadObject(NameOf(ViewModel))
            PropertyStoreData = reader.ReadDataPipeObjectOrNull(Of CustomPropertyStoreData)(NameOf(PropertyStoreData))
        End Sub

        Protected Overrides Sub WriteProperties(ByVal writer As IDataPipeWriter)
            'Should be like this, but the compiler disagrees, so we use a workaround.
            DataPipeWriterExtensions.WriteObject(writer, NameOf(ViewModel), ViewModel)
            writer.WriteDataPipeObjectIfNotNull(Of CustomPropertyStoreData)(NameOf(PropertyStoreData), PropertyStoreData)
        End Sub
    End Class
End Namespace
