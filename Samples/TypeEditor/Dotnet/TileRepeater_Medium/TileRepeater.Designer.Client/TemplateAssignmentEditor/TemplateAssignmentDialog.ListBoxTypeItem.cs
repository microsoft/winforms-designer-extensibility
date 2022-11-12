using WinForms.Tiles.ClientServerProtocol;

namespace WinForms.Tiles.Designer.Client
{
    internal partial class TemplateAssignmentDialog
    {
        private class ListBoxTypeItem
        {
            public ListBoxTypeItem(TypeInfoData typeInfo)
            {
                TypeInfo = typeInfo;
            }

            public TypeInfoData TypeInfo { get; }

            public override string ToString()
                => $"{TypeInfo.FullName}";
        }
    }
}
