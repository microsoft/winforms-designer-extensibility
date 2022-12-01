using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.DotNet.DesignTools.Protocol.DataPipe;

namespace CustomControlLibrary.Protocol.DataTransport
{
    /// <summary>
    ///  Transport class to carry the content of the CustomPropertyStore 
    ///  from the DesignToolServer's server process to the client (Visual Studio)
    ///  and back.
    /// </summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class CustomPropertyStoreData : IDataPipeObject
    {
        [AllowNull]
        public string SomeMustHaveId { get; private set; }

        public DateTime DateCreated { get; private set; }
        public string[]? ListOfStrings { get; private set; }
        public byte CustomEnumValue { get; private set; }

        public CustomPropertyStoreData()
        {
        }

        public CustomPropertyStoreData(
            string someMustHaveId,
            DateTime dateCreated,
            string[]? listOfStrings,
            byte customEnumValue)
        {
            // We use this extension method here, which works also for .NET Framework and
            // lower than .NET 7 versions; it's defined in GlobalUtilities.cs.
            SomeMustHaveId = someMustHaveId.OrThrowIfArgumentIsNullOrEmpty();
            DateCreated = dateCreated;
            ListOfStrings = listOfStrings;
            CustomEnumValue = customEnumValue;
        }

        public void ReadProperties(IDataPipeReader reader)
        {
            SomeMustHaveId = reader.ReadString(nameof(SomeMustHaveId));
            DateCreated = reader.ReadDateTimeOrDefault(nameof(DateCreated));

            ListOfStrings = reader.ReadArrayOrNull(
                nameof(ListOfStrings), 
                (reader) => reader.ReadString()!);

            CustomEnumValue = reader.ReadByte(nameof(CustomEnumValue));
        }

        public void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(SomeMustHaveId), SomeMustHaveId);
            writer.WriteIfNotDefault(nameof(DateCreated), DateCreated);

            writer.WriteArrayIfNotNull(
                nameof(ListOfStrings),
                ListOfStrings,
                (writer, value) => writer.Write(value));

            writer.Write(nameof(CustomEnumValue), CustomEnumValue);
        }

        private string GetDebuggerDisplay()
            => $"ID: {SomeMustHaveId}; {nameof(DateCreated)}: {DateCreated}";
    }
}
