using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;

namespace WinForms.Tiles.Designer
{
    internal partial class TemplateAssignmentViewModel 
    {
        private ITypeDiscoveryService _typeResolutionService;
 
        private const string SystemNamespace = "System";
        private const string MicrosoftNamespace = "Microsoft";
        private const string AccessibilityNamespace = "Accessibility";

        private static readonly Type s_tileContentType = typeof(TileContent);
        private static readonly string[] s_systemAssembliesFilter = new[]
        {
            AccessibilityNamespace,
            $"{SystemNamespace}.",
            $"{MicrosoftNamespace}."
        };

        private TemplateAssignmentViewModel(IServiceProvider serviceProvider)
        {
            _typeResolutionService = (ITypeDiscoveryService)serviceProvider.GetService(typeof(ITypeDiscoveryService));
        }

        public TypeInfoData[]? TemplateTypes { get; private set; }
        public TypeInfoData[]? TileContentTypes { get; private set; }
        public string? TemplateQualifiedTypename { get; set; }
        public string? TileContentQualifiedTypename { get; set; }
        public TemplateAssignment? TemplateAssignment { get; set; }

        /// <summary>
        ///  Creates an instance of this ViewModelClient and initializes it with the ServerTypes 
        ///  from which the Data Sources can be generated.
        /// </summary>
        /// <param name="session">
        ///  The designer session to create the ViewModelClient server side.
        /// </param>
        /// <returns>
        ///  The ViewModelClient for controlling the NewObjectDataSource dialog.
        /// </returns>
        public static TemplateAssignmentViewModel Create(TemplateAssignment? templateAssignment, IServiceProvider serviceProvider)
        {
            TemplateAssignmentViewModel clientViewModel = new(serviceProvider);
            clientViewModel.Initialize(templateAssignment);
            return clientViewModel;
        }

        public void Initialize(TemplateAssignment? templateAssignment)
        {
            // We need the template type list...
            TemplateTypes = GetTemplateTypelist();

            // ...and then every type which is derived from 'Tile'.
            TileContentTypes = GetTileTypeList();

            TemplateAssignment = templateAssignment;
        }

        private TypeInfoData[] GetTemplateTypelist()
        {
            var types = _typeResolutionService.GetTypes(typeof(object), true)
                .Cast<Type>()

                .Where(typeItem => !typeItem.IsAbstract && !typeItem.IsInterface &&
                                   !typeItem.IsEnum && typeItem.IsPublic && !typeItem.IsGenericType &&

                                   // We have a few assemblies, whose types we never want.
                                   !s_systemAssembliesFilter.Any(
                                       notWantedPrefix => typeItem.FullName!.StartsWith(notWantedPrefix)))

                .Select(typeItem => new TypeInfoData(
                    typeItem.Assembly.FullName!,
                    typeItem.Namespace ?? string.Empty,
                    typeItem.FullName!,
                    typeItem.AssemblyQualifiedName!,
                    typeof(INotifyPropertyChanged).IsAssignableFrom(typeItem),
                    typeItem.Name))
                .OrderBy(typeItem => typeItem.Namespace)
                .ThenBy(typeItem => typeItem.Name);

            return types.ToArray();
        }

        private TypeInfoData[] GetTileTypeList()
        {
            var types = _typeResolutionService.GetTypes(typeof(object), true)
                .Cast<Type>()
                .Where(typeItem => !typeItem.IsAbstract && !typeItem.IsInterface &&
                                   !typeItem.IsEnum && typeItem.IsPublic && !typeItem.IsGenericType &&

                                   // We only want types derived from WinForms.Tiles.Tile.
                                   s_tileContentType.IsAssignableFrom(typeItem))

                .Select(typeItem => new TypeInfoData(
                    typeItem.Assembly.FullName!,
                    typeItem.Namespace ?? string.Empty,
                    typeItem.FullName!,
                    typeItem.AssemblyQualifiedName!,
                    typeof(INotifyPropertyChanged).IsAssignableFrom(typeItem),
                    typeItem.Name))
                .OrderBy(typeItem => typeItem.Namespace)
                .ThenBy(typeItem => typeItem.Name);

            return types.ToArray();
        }

        // When we reach this, TemplateQualifiedTypename as well as
        // TileContentQualifiedTypename have been set by the Client-
        // viewmodel (see there).
        public void OKClick()
        {
            // Create a new Instance of the TemplateAssignment:
            var templateType = Type.GetType(TemplateQualifiedTypename!);
            var tileContentType = Type.GetType(TileContentQualifiedTypename!);
            TemplateAssignment = new(templateType, tileContentType);
        }
    }
}
