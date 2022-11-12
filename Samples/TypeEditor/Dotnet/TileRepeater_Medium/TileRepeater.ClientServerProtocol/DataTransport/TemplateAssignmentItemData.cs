using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using System;
using System.Diagnostics.CodeAnalysis;

namespace WinForms.Tiles.ClientServerProtocol.DataTransport
{
    public partial class TemplateAssignmentItemData : IDataPipeObject
    {
        [AllowNull]
        public object TemplateAssignment { get; private set; }

        [AllowNull]
        public string Text { get; private set; }

        public TemplateAssignmentItemData()
        {
        }

        public TemplateAssignmentItemData(
            object templateAssignment,
            string text)
        {
            TemplateAssignment = templateAssignment ?? throw new ArgumentNullException(nameof(templateAssignment));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public void ReadProperties(IDataPipeReader reader)
        {
            TemplateAssignment = reader.ReadObject(nameof(TemplateAssignment));
            Text = reader.ReadString(nameof(Text));
        }

        public void WriteProperties(IDataPipeWriter writer)
        {
            writer.WriteObject(nameof(TemplateAssignment), TemplateAssignment);
            writer.Write(nameof(Text), Text);
        }
    }
}
