Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing.Design

''' <summary>
'''  An example for a custom type used by a property of a custom control.
''' </summary>
''' <remarks>
'''  Since this type is composed from different sub types, there is no editor out of the box to enter data in a 
'''  meaningfull way when we are editing the value at design-time from within the property grid. That is the 
'''  reason we need a dedidcated editor (CustomTypeEditor) deriving from <see cref="UITypeEditor"/> which does
'''  that job.
'''  Note for CodeDom serialization: Since this is a complex type, serializing a property of this type in the 
'''  custom control won't procude the correct code in the InitializeComponent method. Therefore, we need a 
'''  custom serializer. Since we cannot refer to the types directly, we need to refer to them as full qualified names
'''  and pass them to the <see cref="DesignerSerializerAttribute"/> as strings. 
'''  The custom CodeDom serializer should by default be placed in the same assembly as the custom control's designer.
''' </remarks>
<DesignerSerializer("CustomControlLibrary.Designer.Server.Serialization.CustomPropertyStoreCodeDomSerializer", "Microsoft.DotNet.DesignTools.Serialization.CodeDomSerializer")>
<Editor("CustomTypeEditor", GetType(UITypeEditor))>
Public Class CustomPropertyStore

    ' We need the default constructor for the CodeDom serializer.
    Public Sub New()
        SomeMustHaveId = Guid.NewGuid().ToString()
    End Sub

    Public Sub New(
        someMustHaveId As String,
        dateCreated As DateTime,
        listOfStrings As List(Of String),
        customEnumValue As CustomPropertyStoreEnum)

        Me.SomeMustHaveId = someMustHaveId
        Me.DateCreated = dateCreated
        Me.ListOfStrings = listOfStrings
        Me.CustomEnumValue = customEnumValue
    End Sub

    Public Property SomeMustHaveId As String
    Public Property DateCreated As DateTime
    Public Property ListOfStrings As List(Of String)
    Public Property CustomEnumValue As CustomPropertyStoreEnum

    Public Overrides Function ToString() As String

        Return $"{NameOf(SomeMustHaveId)}: {SomeMustHaveId}" &
            $"{NameOf(DateCreated)}: {DateCreated:yyyy-MM-dd HH:mm}" &
            $"{NameOf(CustomEnumValue)}: {CustomEnumValue}" &
            $"{(If(ListOfStrings Is Nothing, "No", If(ListOfStrings?.Count, 0)))} strings in list defined."

    End Function
End Class
