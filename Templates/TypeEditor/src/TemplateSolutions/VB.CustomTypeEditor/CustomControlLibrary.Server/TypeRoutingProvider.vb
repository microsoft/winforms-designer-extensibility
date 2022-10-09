Imports Microsoft.DotNet.DesignTools.TypeRouting

Namespace CustomControlLibrary.Designer.Server
    ''' <summary>
    '''  Class holding the TypeRoutings for resolving the control designer type on the server.
    ''' </summary>
    <ExportTypeRoutingDefinitionProvider>
    Friend Class TypeRoutingProvider
        Inherits TypeRoutingDefinitionProvider

        Public Overrides Function GetDefinitions() As IEnumerable(Of TypeRoutingDefinition)
            Return {New TypeRoutingDefinition(TypeRoutingKinds.Designer, NameOf(CustomControlDesigner), GetType(CustomControlDesigner))}
        End Function
    End Class
End Namespace
