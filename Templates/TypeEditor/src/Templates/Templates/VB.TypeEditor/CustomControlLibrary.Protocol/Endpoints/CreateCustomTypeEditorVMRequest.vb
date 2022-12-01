Imports Microsoft.DotNet.DesignTools.Protocol
Imports Microsoft.DotNet.DesignTools.Protocol.DataPipe
Imports Microsoft.DotNet.DesignTools.Protocol.Endpoints

Namespace Endpoints
    ''' <summary>
    '''  Request class for the CreateCustomTypeEditorViewModel endpoint. This passes the necessary
    '''  context  (<c>SessionId</c>, proxy of the <c>CustomControl</c>) from the client to the server.
    ''' </summary>
    Public Class CreateCustomTypeEditorVMRequest
        Inherits Request

        Private privateSessionId As SessionId
        Private privateCustomControlProxy As Object

        Public Property SessionId() As SessionId
            Get
                Return privateSessionId
            End Get
            Private Set(ByVal value As SessionId)
                privateSessionId = value
            End Set
        End Property

        Public Property CustomControlProxy() As Object
            Get
                Return privateCustomControlProxy
            End Get
            Private Set(ByVal value As Object)
                privateCustomControlProxy = value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal sessionId As SessionId, ByVal customControlProxy As Object)
            sessionId = sessionId.OrThrowIfNull()
            Me.CustomControlProxy = customControlProxy
        End Sub

        Public Sub New(ByVal reader As IDataPipeReader)
            MyBase.New(reader)
        End Sub

        Protected Overrides Sub ReadProperties(ByVal reader As IDataPipeReader)
            SessionId = reader.ReadSessionId(NameOf(SessionId))
            CustomControlProxy = reader.ReadObject(NameOf(CustomControlProxy))
        End Sub

        Protected Overrides Sub WriteProperties(ByVal writer As IDataPipeWriter)
            writer.Write(NameOf(SessionId), SessionId)
            'writer.WriteObject(NameOf(CustomControlProxy), CustomControlProxy)
            DataPipeWriterExtensions.WriteObject(writer, NameOf(CustomControlProxy), CustomControlProxy)
        End Sub
    End Class
End Namespace
