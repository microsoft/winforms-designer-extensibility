using System.CodeDom;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using Microsoft.DotNet.DesignTools.Serialization;
using RootDesignerDemo.Controls;

namespace RootDesignerDemo.Designer.Server.Serialization
{
    /// <summary>
    ///  Provides a generic content serializer for reference types, which - in contrast to 
    ///  DesignerSerializationVisibility.Content - also generates code which instantiates the property's 
    ///  custom type.
    /// </summary>
    internal class RdPropertyStoreCodeDomSerializer : CodeDomSerializer
    {
        public override object Serialize(
            IDesignerSerializationManager manager,
            object value)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            if (manager.Context.Current is ExpressionContext expressionContext)
            {
                RdPropertyStore propertyStore = (RdPropertyStore)value;

                // This is the left-side assignment target, we want to generate.
                // And it describes the current context, for which we need the
                // object generation.
                var contextExpression = expressionContext.Expression;
                CodeStatementCollection statements = new();

                // Now, we want to generate:
                //      this.customControl1.CustomProperty = new RootDesignerDemo.RdPropertyStore();
                //      this.customControl1.CustomProperty.CustomEnumValue = RootDesignerDemo.CustomEnum.FourthValue;
                //      this.customControl1.CustomProperty.DateCreated = new System.DateTime(2022, 7, 13, 0, 0, 0, 0);
                //      this.customControl1.CustomProperty.ListOfStrings = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.ListOfStrings")));
                //      this.customControl1.CustomProperty.SomeMustHaveId = "{C0E03E00-EFDA-47AA-9BA9-B69671F7A565}";

                // We start with 'new RdPropertyStore()';
                CodeObjectCreateExpression customPropertyCreateExpression = new(
                    new CodeTypeReference(typeof(RdPropertyStore)));

                // Then we do the assignment '{codeExpression} = new RdPropertyStore()';
                CodeAssignStatement contextAssignmentStatement = new(
                    contextExpression, customPropertyCreateExpression);

                // And from here on we're doing exactly that what the default serializer would be doing,
                // had it detected the DesignerSerializationVisibilityAttribute set to 'Content'.
                // It just traverses the property's object graph and creates the code for generating 
                // the respective value types, enums, arrays, etc.

                // To that end, we're _not_ getting this type's serializer, because then we would ending up with running 
                // this exact serializer. This is not what we want, we would end up in a recusion. Instead, we want to serialize 
                // the graph of property type, so we're getting object's default serializer...
                var serializer = (CodeDomSerializer)manager.GetSerializer(typeof(object), typeof(CodeDomSerializer));

                /// ...indicate, that we also want to generate code for setting the default values ...
                var absolute = manager.Context[typeof(SerializeAbsoluteContext)] as SerializeAbsoluteContext;

                /// ...and we finally make sure, we're not serializing things that have been serialized before and could just 
                /// get from the stack.
                var result = IsSerialized(manager, value, absolute != null)
                    ? GetExpression(manager, value)
                    : serializer.Serialize(manager, value);

                /// Now: Here is the difference to DesignerSerializationVisibility.Content: We are adding the instantiation code for our
                /// custom (complex) property. And now ...
                statements.Add(contextAssignmentStatement);

                /// ...we're adding all the statements, which the default (object) serializer generated, and which are at this point
                /// supposed to be all the statements for assigning our custom control's property's custom type's properties.
                if (result is CodeStatementCollection statementCollection)
                {
                    foreach (CodeStatement statement in statementCollection)
                    {
                        statements.Add(statement);
                    }
                }
                else
                {
                    if (result is CodeStatement statement)
                    {
                        statements.Add(statement);
                    }
                }

                return statements;
            };

            var baseResult = base.Serialize(manager, value);
            return baseResult;
        }
    }
}
