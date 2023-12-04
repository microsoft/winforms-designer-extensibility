using System.ComponentModel;
using System.ComponentModel.Design;

namespace SampleRootDesigner
{
    // The following attribute associates the SampleRootDesigner designer 
    // with the SampleComponent component.
    [Designer(typeof(ShapeRootDesigner), typeof(IRootDesigner)),
     ToolboxItem(false)]
    public class ShapeDocumentBase : Component
    {
        private IToolboxServiceExample.IToolboxServiceControl iToolboxServiceControl1;
        private RootDesignerDemo.HostingComponents.SimpleBoxComponent simpleBoxComponent1;
        private System.Windows.Forms.Button button1;
        private IContainer components;

        public ShapeDocumentBase()
        {
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.iToolboxServiceControl1 = new IToolboxServiceExample.IToolboxServiceControl();
            this.simpleBoxComponent1 = new RootDesignerDemo.HostingComponents.SimpleBoxComponent(this.components);
            this.button1 = new System.Windows.Forms.Button();
            // 
            // iToolboxServiceControl1
            // 
            this.iToolboxServiceControl1.BackColor = System.Drawing.Color.Beige;
            this.iToolboxServiceControl1.Location = new System.Drawing.Point(500, 400);
            this.iToolboxServiceControl1.Name = "iToolboxServiceControl1";
            this.iToolboxServiceControl1.Size = new System.Drawing.Size(771, 432);
            this.iToolboxServiceControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;

        }
    }
}
