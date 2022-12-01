using System;
using CustomControlLibrary.Protocol;
using Microsoft.DotNet.DesignTools.ViewModels;

namespace CustomControlLibrary.Designer.Server
{
    internal partial class CustomTypeEditorVM
    {
        /// <summary>
        /// Factory class which generates the CustomTypeEditorViewModel.
        /// </summary>
        [ExportViewModelFactory(ViewModelNames.CustomTypeEditorVM)]
        private class Factory : ViewModelFactory<CustomTypeEditorVM>
        {
            protected override CustomTypeEditorVM CreateViewModel(IServiceProvider provider)
                => new(provider);
        }
    }
}
