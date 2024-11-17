namespace SampleRootDesigner
{
    // This sample demonstrates how to provide the root designer view, or
    // design mode background view, by overriding IRootDesigner.GetView().

    // This sample component inherits from RootDesignedComponent which 
    // uses the SampleRootDesigner.
    public class ShapeDocument : ShapeDocumentBase
    {
        public ShapeDocument()
        {
        }
    }
}
