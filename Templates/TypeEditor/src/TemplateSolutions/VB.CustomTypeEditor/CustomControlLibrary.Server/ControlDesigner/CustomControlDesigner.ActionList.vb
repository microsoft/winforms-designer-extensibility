Imports System.ComponentModel
Imports Microsoft.DotNet.DesignTools.Designers
Imports Microsoft.DotNet.DesignTools.Designers.Actions

Partial Friend Class CustomControlDesigner
    ''' <summary>
    '''  Action lists implementation for the <see cref="CustomControl"/>.
    ''' </summary>
    ''' <remarks>
    '''  Note: Action lists for the out-of-process Designer can be implemented exactly as they would be for the in-process
    '''  Designer, except: The control designer has to be compiled against the Winforms Designer Extensibility SDK, and ActionList
    '''  related classes must come from the <see cref="Microsoft.DotNet.DesignTools.Designers.Actions"/> namespace.
    ''' </remarks>
    Private Class ActionList
        Inherits DesignerActionList

        Private Const Behavior As String = NameOf(Behavior)

        Private ReadOnly _designer As ComponentDesigner

        Public Sub New(ByVal designer As CustomControlDesigner)
            MyBase.New(designer.Component)
            _designer = designer
        End Sub

        Public Property CustomProperty() As CustomPropertyStore
            Get
                Return If(
                    (CType(Component, CustomControl)) Is Nothing,
                    Nothing,
                    CType(Component, CustomControl).CustomPropertyStoreProperty)
            End Get

            Set(ByVal value As CustomPropertyStore)

                If Component IsNot Nothing Then
                    TypeDescriptor.GetProperties(Component)(NameOf(CustomProperty))?.SetValue(Component, value)
                End If
            End Set
        End Property

        Public Sub InvokeCustomTypeEditor()
            _designer.InvokePropertyEditor(NameOf(CustomControl.CustomPropertyStoreProperty))
        End Sub

        Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
            Dim actionItems As New DesignerActionItemCollection()

            actionItems.Add(New DesignerActionHeaderItem(Behavior))
            actionItems.Add(New DesignerActionPropertyItem(
                                NameOf(CustomProperty),
                                "CustomProperty definition",
                                Behavior,
                                "Controls the values of the CustomProperty Definition."))

            actionItems.Add(New DesignerActionMethodItem(
                                Me,
                                NameOf(InvokeCustomTypeEditor),
                                "Invokes the custom TypeEditor...",
                                True))

            Return actionItems
        End Function
    End Class
End Class
