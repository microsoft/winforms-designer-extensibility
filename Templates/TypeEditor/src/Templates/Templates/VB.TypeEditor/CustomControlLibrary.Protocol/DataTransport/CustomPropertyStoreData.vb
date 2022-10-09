Imports Microsoft.DotNet.DesignTools.Protocol.DataPipe

Namespace DataTransport

    ''' <summary>
    '''  Transport class to carry the content of the CustomPropertyStore 
    '''  from the DesignToolServer's server process to the client (Visual Studio)
    '''  and back.
    ''' </summary>
    <DebuggerDisplay("{GetDebuggerDisplay(),nq}")>
    Partial Public Class CustomPropertyStoreData
        Implements IDataPipeObject

        ' Backing fields for properties, since VB cannot have auto-properties with private setters.
        Private _someMustHaveId As String
        Private _dateCreated As DateTime
        Private _listOfStrings As String()
        Private _customEnumValue As Byte

        Public Sub New()
        End Sub

        Public Sub New(someMustHaveId As String, dateCreated As DateTime, listOfStrings As String(), customEnumValue As Byte)
            Me.SomeMustHaveId = someMustHaveId
            Me.DateCreated = dateCreated
            Me.ListOfStrings = listOfStrings
            Me.CustomEnumValue = customEnumValue
        End Sub

        Public Property SomeMustHaveId() As String
            Get
                Return _someMustHaveId
            End Get
            Private Set(ByVal value As String)
                _someMustHaveId = value
            End Set
        End Property

        Public Property DateCreated() As DateTime
            Get
                Return _dateCreated
            End Get
            Private Set(ByVal value As DateTime)
                _dateCreated = value
            End Set
        End Property

        Public Property ListOfStrings() As String()
            Get
                Return _listOfStrings
            End Get
            Private Set(ByVal value As String())
                _listOfStrings = value
            End Set
        End Property

        Public Property CustomEnumValue() As Byte
            Get
                Return _customEnumValue
            End Get
            Private Set(ByVal value As Byte)
                _customEnumValue = value
            End Set
        End Property

        Public Sub ReadProperties(ByVal reader As IDataPipeReader) Implements IDataPipeObject.ReadProperties
            SomeMustHaveId = reader.ReadString(NameOf(SomeMustHaveId))
            DateCreated = reader.ReadDateTimeOrDefault(NameOf(DateCreated))

            ListOfStrings = reader.ReadArrayOrNull(
                NameOf(ListOfStrings),
                Function(innerReader) innerReader.ReadString())

            CustomEnumValue = reader.ReadByte(NameOf(CustomEnumValue))
        End Sub

        Public Sub WriteProperties(ByVal writer As IDataPipeWriter) Implements IDataPipeObject.WriteProperties
            writer.Write(NameOf(SomeMustHaveId), SomeMustHaveId)
            writer.WriteIfNotDefault(NameOf(DateCreated), DateCreated)

            writer.WriteArrayIfNotNull(
                NameOf(ListOfStrings), ListOfStrings,
                Sub(innerWriter, value) innerWriter.Write(value))

            writer.Write(NameOf(CustomEnumValue), CustomEnumValue)
        End Sub

        Private Function GetDebuggerDisplay() As String
            Return $"ID: {SomeMustHaveId}; {NameOf(DateCreated)}: {DateCreated}"
        End Function
    End Class
End Namespace
