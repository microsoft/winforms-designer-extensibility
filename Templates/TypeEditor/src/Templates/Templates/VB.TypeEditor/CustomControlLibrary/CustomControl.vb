Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

''' <summary>
'''  Custom Control sample implementation.
''' </summary>
''' <remarks>
'''  This sample custom control implements one custom property named <see cref="CustomPropertyStoreProperty"/> 
'''  of type <see cref="CustomPropertyStore"/>. Its sole purpose is to demonstrate how to implement
'''  a custom TypeEditor for editing this property's content at design time with the Out-Of-Process
'''  WinForms Designer. 
''' </remarks>
<Designer("CustomControlDesigner")>
Public Class CustomControl
    Inherits Control

    ' Backing field for CustomProperty.
    Private _customProperty As CustomPropertyStore

    ''' <summary>
    '''  Raised when CustomProperty changes.
    ''' </summary>
    Public Event CustomPropertyStorePropertyChanged As EventHandler

    Public Sub New()
        DoubleBuffered = True
        ResizeRedraw = True
    End Sub

    ''' <summary>
    '''  Gets or sets a value of type <see cref="CustomPropertyStore"/> which is composed of different value types,
    '''  a custom enum and a string array.
    ''' </summary>
    <Description("A custom property composed of different value types, a custom enum and a string array."),
     DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property CustomPropertyStoreProperty() As CustomPropertyStore
        Get
            Return _customProperty
        End Get

        Set(ByVal value As CustomPropertyStore)
            If Not Equals(value, _customProperty) Then
                _customProperty = value
                OnCustomPropertyStoreProperty(EventArgs.Empty)

                ' We update this property only at design-time, not at runtime.
                If IsHandleCreated AndAlso IsAncestorSiteInDesignMode Then
                    Invalidate()
                End If
            End If
        End Set
    End Property

    ''' <summary>
    '''  Raises the <see cref="CustomPropertyStorePropertyChanged"/> event.
    ''' </summary>
    Protected Overridable Sub OnCustomPropertyStoreProperty(ByVal e As EventArgs)
        CustomPropertyStorePropertyChangedEvent?.Invoke(Me, e)
    End Sub

    ''' <summary>
    '''  Controls the Reset-Property function in the PropertyBrowser.
    ''' </summary>
    Private Sub ResetCustomPropertyStoreProperty()
        CustomPropertyStoreProperty = Nothing
    End Sub

    ''' <summary>
    '''  Controls the Serialization of the Property.
    ''' </summary>
    ''' <returns>
    '''  <see langword="true"/>, if the CodeDOM serializer should emit code for 
    '''  assigning a valid content to the property in InitializeComponent.
    ''' </returns>
    Private Function ShouldSerializeCustomPropertyStoreProperty() As Boolean
        Return CustomPropertyStoreProperty IsNot Nothing
    End Function

    ' The only function of this control is to draw a visual
    ' representation of the CustomPropertyStoreProperty at Design and Runtime.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' We show this only at Design time, not at runtime.
        If IsAncestorSiteInDesignMode Then

            ' Drawing a frame around the control's borders:
            Dim pen As New Pen(ForeColor)
            Dim brush = New SolidBrush(ForeColor)

            ' Drawing the contents of the CustomProperty.
            e.Graphics.DrawString(BuildContentString(CustomPropertyStoreProperty), Font, brush, point:=New Point(10, 10))

        End If
    End Sub

    ' Builds a long string with the text representation of 
    ' the CustomPropertyStoreProperty property of this control.
    Private Function BuildContentString(ByVal propertyData As CustomPropertyStore) As String
        Dim stringBuilder As New StringBuilder()

        If propertyData Is Nothing Then
            stringBuilder.Append("No CustomProperty Data defined.")
            Return stringBuilder.ToString()
        End If

        stringBuilder.AppendLine($"{NameOf(propertyData.SomeMustHaveId)}: {propertyData.SomeMustHaveId}")
        stringBuilder.AppendLine($"{NameOf(propertyData.DateCreated)}: {propertyData.DateCreated:yyyy-mm-dd (ddd)}")
        stringBuilder.AppendLine($"{NameOf(propertyData.CustomEnumValue)}: '{propertyData.CustomEnumValue}'")
        stringBuilder.AppendLine()
        stringBuilder.AppendLine("List of Strings:")
        stringBuilder.AppendLine("=============================")

        propertyData.ListOfStrings?.ForEach(Function(stringValue) stringBuilder.AppendLine($"* {stringValue}"))

        Return stringBuilder.ToString()
    End Function

End Class

