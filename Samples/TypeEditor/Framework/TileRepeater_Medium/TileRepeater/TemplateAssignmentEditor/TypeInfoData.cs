using System;
using System.Diagnostics;

namespace WinForms.Tiles.Designer
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class TypeInfoData
    {
        public string AssemblyFullName { get; private set; }
        public string Namespace { get; private set; }
        public string FullName { get; private set; }
        public string AssemblyQualifiedName { get; private set; }
        public bool ImplementsINotifyPropertyChanged { get; private set; }
        public string Name { get; private set; }

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

        private string GetDebuggerDisplay()
            => $"{Name}: {Namespace}, {AssemblyFullName} INPC:{(ImplementsINotifyPropertyChanged ? "Yes" : "No")}";
    }
}
