using System;
using RootDesignerDemo.Protocol;
using Microsoft.DotNet.DesignTools.ViewModels;

namespace RootDesignerDemo.Designer.Server
{
    internal partial class RdTypeEditorVM
    {
        /// <summary>
        /// Factory class which generates the RdTypeEditorViewModel.
        /// </summary>
        [ExportViewModelFactory(ViewModelNames.RdTypeEditorVM)]
        private class Factory : ViewModelFactory<RdTypeEditorVM>
        {
            protected override RdTypeEditorVM CreateViewModel(IServiceProvider provider)
                => new(provider);
        }
    }
}
