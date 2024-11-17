using System.ComponentModel;
using System.ComponentModel.Design;

namespace SampleRootDesigner
{
    // The following attribute associates the SampleRootDesigner designer 
    // with the SampleComponent component.
    [Designer(typeof(SampleRootDesigner), typeof(IRootDesigner))]
    public class RootDesignedComponent : Component
    {
        public RootDesignedComponent()
        {
        }

        private void InitializeComponent()
        {
        }
    }
}
