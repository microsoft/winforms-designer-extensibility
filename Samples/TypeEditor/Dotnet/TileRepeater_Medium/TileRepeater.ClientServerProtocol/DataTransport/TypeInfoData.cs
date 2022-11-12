using Microsoft.DotNet.DesignTools.Protocol.DataPipe;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace WinForms.Tiles.ClientServerProtocol
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class TypeInfoData : IDataPipeObject
    {
        [AllowNull]
        public string AssemblyFullName { get; private set; }

        [AllowNull]
        public string Namespace { get; private set; }

        [AllowNull]
        public string FullName { get; private set; }

        [AllowNull]
        public string AssemblyQualifiedName { get; private set; }

        public bool ImplementsINotifyPropertyChanged { get; private set; }

        [AllowNull]
        public string Name { get; private set; }

        public TypeInfoData()
        {
        }

        public TypeInfoData(
            string assemblyFullName,
            string @namespace,
            string fullName,
            string assemblyQualifiedName,
            bool implementsINotifyPropertyChanged,
            string name)
        {
            AssemblyFullName = assemblyFullName ?? throw new ArgumentNullException(nameof(assemblyFullName));
            Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            AssemblyQualifiedName = assemblyQualifiedName ?? throw new ArgumentNullException(nameof(assemblyQualifiedName));
            ImplementsINotifyPropertyChanged = implementsINotifyPropertyChanged;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static TypeInfoData CreateMissingTypeInfoData(string assemblyQualifiedName, string name)
            => new(
                assemblyFullName: string.Empty,
                @namespace: string.Empty,
                fullName: string.Empty,
                assemblyQualifiedName: assemblyQualifiedName,
                implementsINotifyPropertyChanged: false,
                name: name);

        public void ReadProperties(IDataPipeReader reader)
        {
            AssemblyFullName = reader.ReadString(nameof(AssemblyFullName));
            FullName = reader.ReadString(nameof(FullName));
            AssemblyQualifiedName = reader.ReadString(nameof(AssemblyQualifiedName));
            Namespace = reader.ReadString(nameof(Namespace));
            ImplementsINotifyPropertyChanged = reader.ReadBooleanOrFalse(nameof(ImplementsINotifyPropertyChanged));
            Name = reader.ReadString(nameof(Name));
        }

        public void WriteProperties(IDataPipeWriter writer)
        {
            writer.Write(nameof(AssemblyFullName), AssemblyFullName);
            writer.Write(nameof(FullName), FullName);
            writer.Write(nameof(AssemblyQualifiedName), AssemblyQualifiedName);
            writer.Write(nameof(Namespace), Namespace);
            writer.WriteIfNotFalse(nameof(ImplementsINotifyPropertyChanged), ImplementsINotifyPropertyChanged);
            writer.Write(nameof(Name), Name);
        }

        private string GetDebuggerDisplay()
            => $"{Name}: {Namespace}, {AssemblyFullName} INPC:{(ImplementsINotifyPropertyChanged ? "Yes" : "No")}";
    }
}
