using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;

namespace RootDesignerDemo.Controls
{
    /// <summary>
    ///  An example for a custom type used by a property of a custom control.
    /// </summary>
    /// <remarks>
    ///  Since this type is composed from different sub types, there is no editor out of the box to enter data in a 
    ///  meaningful way when we are editing the value at design-time from within the property grid. That is the 
    ///  reason we need a dedicated editor (RdTypeEditor) deriving from <see cref="UITypeEditor"/> which does
    ///  that job.
    ///  Note for CodeDom serialization: since this is a complex type, serializing a property of this type in the 
    ///  custom control won't produce the correct code in the InitializeComponent method. Therefore, we need a 
    ///  custom serializer. Since we cannot refer to the types directly, we need to refer to them as full qualified names
    ///  and pass them to the <see cref="DesignerSerializerAttribute"/> as strings. 
    ///  The custom CodeDom serializer should by default be placed in the same assembly as the custom control's designer.
    /// </remarks>
    [DesignerSerializer("RootDesignerDemo.Designer.Server.Serialization.RdPropertyStoreCodeDomSerializer",
                        "Microsoft.DotNet.DesignTools.Serialization.CodeDomSerializer")]
    [Editor("RdTypeEditor", typeof(UITypeEditor))]
    public class RdPropertyStore
    {
        // We need the default constructor for the CodeDom serializer.
        public RdPropertyStore()
        {
            SomeMustHaveId = Guid.NewGuid().ToString();
        }

        public RdPropertyStore(
            string someMustHaveId,
            DateTime dateCreated,
            List<string>? listOfStrings,
            RdPropertyStoreEnum customEnumValue)
        {
            SomeMustHaveId = someMustHaveId;
            DateCreated = dateCreated;
            ListOfStrings = listOfStrings;
            CustomEnumValue = customEnumValue;
        }

        public string SomeMustHaveId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string>? ListOfStrings { get; set; }
        public RdPropertyStoreEnum CustomEnumValue { get; set; }

        public override string ToString()
            => $"{nameof(SomeMustHaveId)}: {SomeMustHaveId}" +
               $"{nameof(DateCreated)}: {DateCreated:yyyy-MM-dd HH:mm}" +
               $"{nameof(CustomEnumValue)}: {CustomEnumValue}" +
               $"{(ListOfStrings is null ? "No" : ListOfStrings?.Count ?? 0)} strings in list defined.";
    }
}
