using System;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;

namespace WinForms.Tiles.Serialization
{
    internal class TemplateAssignmentCodeDomSerializer : CodeDomSerializer
    {
        private int _variableOccuranceCounter = 1;

        internal const string TemplateAssignmentNamespace = "WinForms.Tiles";

        public override object Serialize(
            IDesignerSerializationManager manager,
            object value)
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            if (manager.Context.Current is ExpressionContext expressionContext)
            {
                // This is the left-side assignment target we want to generate.
                // And it describes the current context for which we need the
                // object generation. Like:
                // this.tileRepeater1.TemplateAssignmentProperty
                var contextExpression = expressionContext.Expression;

                CodeStatementCollection statements = new CodeStatementCollection();

                // Let's get the actual typed instance first.
                TemplateAssignment templateAssignment = (TemplateAssignment)value;

                // Now, we want to generate:
                //    Type templateType1 = typeof(templateType);
                //    Type tileContentType1 = typeof(templateType);
                //    {codeExpression} = new TemplateAssignment(templateType1, tileContentType1);

                // We define the locale variables up front.
                string templateTypeVariableName = $"templateType{_variableOccuranceCounter}";
                string tileContentVariableName = $"tileContentType{_variableOccuranceCounter++}";

                // Type templateType1;
                CodeVariableDeclarationStatement templateTypeVarDeclStatement = new(
                    new CodeTypeReference(nameof(Type)),
                    templateTypeVariableName);

                // Type tileContentType1;
                CodeVariableDeclarationStatement tileContentTypeVarDeclStatement = new(
                    new CodeTypeReference(nameof(Type)),
                    tileContentVariableName);

                //  typeof(templateType);
                CodeTypeOfExpression getTypeOfTemplateExpression =
                    new CodeTypeOfExpression(new CodeTypeReference(templateAssignment.TemplateType!));

                //  typeof(tileType);
                CodeTypeOfExpression getTypeOfTileExpression = 
                    new CodeTypeOfExpression(new CodeTypeReference(templateAssignment.TileContentControlType!));

                // templateType1 = typeof(templateType);
                CodeAssignStatement templateTypeVariableAssignment = new(
                    new CodeVariableReferenceExpression(templateTypeVariableName),
                    getTypeOfTemplateExpression);

                // tileContentType1 = typeof(tileType);
                CodeAssignStatement tileContentTypeVariableAssignment = new(
                    new CodeVariableReferenceExpression(tileContentVariableName),
                    getTypeOfTileExpression);

                // new TemplateAssignment(templateType1, tileContentType1);
                CodeObjectCreateExpression templateAssignmentCreateExpression = new(
                    new CodeTypeReference($"{TemplateAssignmentNamespace}.{nameof(TemplateAssignment)}"),
                    new CodeVariableReferenceExpression(templateTypeVariableName),
                    new CodeVariableReferenceExpression(tileContentVariableName));

                // {codeExpression} = new TemplateAssignment(templateType1, tileContentType1);
                CodeAssignStatement contextAssignmentStatement = new(
                    contextExpression, templateAssignmentCreateExpression);

                statements.AddRange(new CodeStatementCollection
                {
                    templateTypeVarDeclStatement,
                    tileContentTypeVarDeclStatement,
                    templateTypeVariableAssignment,
                    tileContentTypeVariableAssignment,
                    contextAssignmentStatement
                });

                return statements;
            };

            var baseResult = base.Serialize(manager, value);
            return baseResult;
        }
    }
}
