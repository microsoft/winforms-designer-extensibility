Imports CustomControlLibrary.Protocol.DataTransport
Imports Microsoft.DotNet.DesignTools.Protocol.DataPipe
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Endpoints
    ''' <summary>
    '''  Request class for the <see cref="CustomTypeEditorOKClick"/> endpoint. This passes the necessary
    '''  context (ViewModel, content of custom property) from the Client to the Server.
    ''' </summary>
    Public Class CustomTypeEditorOKClickRequest
        Inherits Request

        Private _viewModel As Object
        Private _propertyStoreData As CustomPropertyStoreData

        Public Property ViewModel() As Object
            Get
                Return _viewModel
            End Get
            Private Set(ByVal value As Object)
                _viewModel = value
            End Set
        End Property

        Public Property PropertyStoreData() As CustomPropertyStoreData
            Get
                Return _propertyStoreData
            End Get
            Private Set(ByVal value As CustomPropertyStoreData)
                _propertyStoreData = value
            End Set
        End Property

        Public Sub New(ByVal viewModel As Object, ByVal propertyStoreData As CustomPropertyStoreData)
            Me.ViewModel = GlobalUtilities.OrThrowIfNull(viewModel)
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
            DataPipeWriterExtensions.WriteObject(writer, NameOf(ViewModel), ViewModel)
            writer.WriteDataPipeObjectIfNotNull(Of CustomPropertyStoreData)(NameOf(PropertyStoreData), PropertyStoreData)
        End Sub
    End Class
End Namespace
