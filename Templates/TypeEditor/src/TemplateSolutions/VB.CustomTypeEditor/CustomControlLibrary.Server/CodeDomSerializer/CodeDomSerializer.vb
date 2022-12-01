Imports System.CodeDom
Imports System.ComponentModel.Design.Serialization
Imports Microsoft.DotNet.DesignTools.Serialization

Namespace Serialization

    ''' <summary>
    '''  Provides a generic content serializer for reference types, which - in contrast to 
    '''  DesignerSerializationVisibility.Content - also generates code which instantiates the property's 
    '''  custom type.
    ''' </summary>
    Friend Class CustomPropertyStoreCodeDomSerializer
        Inherits CodeDomSerializer

        Public Overrides Function Serialize(ByVal manager As IDesignerSerializationManager, ByVal value As Object) As Object
            If Debugger.IsAttached Then
                Debugger.Break()
            End If

            Dim tempVar As Boolean = TypeOf manager.Context.Current Is ExpressionContext
            Dim expressionContext As ExpressionContext = If(tempVar, CType(manager.Context.Current, ExpressionContext), Nothing)
            If tempVar Then
                Dim propertyStore As CustomPropertyStore = DirectCast(value, CustomPropertyStore)

                ' This is the left-side assignment target, we want to generate.
                ' And it describes the current context, for which we need the
                ' object generation.
                Dim contextExpression = expressionContext.Expression
                Dim statements As New CodeStatementCollection()

                ' Now, we want to generate:
                '      Me.customControl1.CustomProperty = New CustomControlLibrary.CustomPropertyStore()
                '      Me.customControl1.CustomProperty.CustomEnumValue = CustomControlLibrary.CustomEnum.FourthValue
                '      Me.customControl1.CustomProperty.DateCreated = New System.DateTime(2022, 7, 13, 0, 0, 0, 0)
                '      Me.customControl1.CustomProperty.ListOfStrings = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.ListOfStrings")))
                '      Me.customControl1.CustomProperty.SomeMustHaveId = "{C0E03E00-EFDA-47AA-9BA9-B69671F7A565}"

                ' We start with 'new CustomPropertyStore()'
                Dim customPropertyCreateExpression As New CodeObjectCreateExpression(New CodeTypeReference(GetType(CustomPropertyStore)))

                ' Then we do the assignment '{codeExpression} = new CustomPropertyStore()'
                Dim contextAssignmentStatement As New CodeAssignStatement(contextExpression, customPropertyCreateExpression)

                ' And from here on we're doing exactly that what the default serializer would be doing,
                ' had it detected the DesignerSerializationVisibilityAttribute set to 'Content'.
                ' It just traverses the property's object graph and creates the code for generating 
                ' the respective value types, enums, arrays, etc.

                ' To that end, we're _not_ getting this type's serializer, because then we would ending up with running 
                ' this exact serializer. This is not what we want, we would end up in a recusion. Instead, we want to serialize 
                ' the graph of property type, so we're getting object's default serializer...
                Dim serializer = DirectCast(manager.GetSerializer(GetType(Object), GetType(CodeDomSerializer)), CodeDomSerializer)

                ''' ...indicate, that we also want to generate code for setting the default values ...
                Dim absolute = TryCast(manager.Context(GetType(SerializeAbsoluteContext)), SerializeAbsoluteContext)

                ''' ...and we finally make sure, we're not serializing things that have been serialized before and could just 
                ''' get from the stack.
                Dim result = If(
                    IsSerialized(manager, value, absolute IsNot Nothing),
                    GetExpression(manager, value),
                    serializer.Serialize(manager, value))

                ''' Now: Here is the difference to DesignerSerializationVisibility.Content: We are adding the instantiation code for our
                ''' custom (complex) property. And now ...
                statements.Add(contextAssignmentStatement)

                ''' ...we're adding all the statements, which the default (object) serializer generated, and which are at this point
                ''' supposed to be all the statements for assigning our custom control's property's custom type's properties.
                Dim tempVar2 As Boolean = TypeOf result Is CodeStatementCollection
                Dim statementCollection As CodeStatementCollection = If(tempVar2, CType(result, CodeStatementCollection), Nothing)

                If tempVar2 Then
                    For Each statement As CodeStatement In statementCollection
                        statements.Add(statement)
                    Next statement
                Else
                    Dim tempVar3 As Boolean = TypeOf result Is CodeStatement
                    Dim statement As CodeStatement = If(tempVar3, CType(result, CodeStatement), Nothing)
                    If tempVar3 Then
                        statements.Add(statement)
                    End If
                End If

                Return statements
            End If

            Dim baseResult = MyBase.Serialize(manager, value)
            Return baseResult
        End Function
    End Class
End Namespace
