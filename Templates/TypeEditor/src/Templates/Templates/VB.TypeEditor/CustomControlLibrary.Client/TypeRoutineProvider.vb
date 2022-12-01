Imports CustomControlLibrary.Protocol
Imports Microsoft.DotNet.DesignTools.Client.TypeRouting

''' <summary>
'''  Class holding the TypeRoutings for resolving the control designer type on the client.
''' </summary>
<ExportTypeRoutingDefinitionProvider>
Friend Class TypeRoutingProvider
    Inherits TypeRoutingDefinitionProvider

    Public Overrides Function GetDefinitions() As IEnumerable(Of TypeRoutingDefinition)

        ' We are returning an Array ("{ New... }") of TypeRoutingDefinitions, each of which contains the name of the type.
        Return _
        {
            New TypeRoutingDefinition(TypeRoutingKinds.Editor, NameOf(EditorNames.CustomTypeEditor), GetType(CustomTypeEditor))
        }
    End Function
End Class
