using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootDesignerDemo.HostingComponents
{
    public partial class SimpleBoxComponent : Component
    {
        public SimpleBoxComponent()
        {
            InitializeComponent();
        }

        public SimpleBoxComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
