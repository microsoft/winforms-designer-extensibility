using System.ComponentModel;

namespace WinForms.Tiles.Simplified;

/// <summary>
///  UserControl, which is editable in the WinForms Designer and defines the visual representation
///  for each item of a data source bound to a <see cref="SimpleTileRepeater"/> control.
/// </summary>
/// <remarks>
///  <b>NOTE:</b>Don't user this class directly, but rather inherit this class into a new class,
///  which then can be edited in the WinForms Designer. Also note: Derived classes need to provide a
///  <see cref="BindingSource"/> component to manage the data binding of each individual item of the
///  <see cref="SimpleTileRepeater"/> control's data source. The SimpleTileRepeater control assigns
///  each data source item to each respective TileContent instance's <see cref="BindingSourceComponent"/>
///  property. A BindingSource component on the derived TileContent control assigned to this property
///  receives each data source item as an dedicated data source and passes the data along to whatever
///  controls inside the derived TileContent are bound to that BindingSource component. Thus, it's important
///  to create a BindingSource component based on the schema of the datasource, and then bind each respective
///  control on the derived TileContent against this BindingSource component.
/// </remarks>
public partial class TileContent : UserControl
{
    protected const int DefaultSelectionFramePadding = 20;

    public TileContent()
    {
        InitializeComponent();
    }

    public virtual bool IsSeparator => false;

    public virtual Padding SelectionFramePadding
        => new(DefaultSelectionFramePadding);

    /// <summary>
    ///  Gets or sets a BindingSource of a derived <see cref="TileContent"/> UserControl.
    /// </summary>
    /// <remarks>
    ///  Place a <see cref="BindingSource"/> component in the component tray of a derived TileContent control. Assign the schema 
    ///  of an item of the data source assigned to the <see cref="SimpleTileRepeater"/> control to that BindingSource component.
    ///  Assign that BindingSource component to this property either via the PropertyBrowser or via code directly after InitializeComponent
    ///  in the constructor.
    /// </remarks>
    public BindingSource? BindingSourceComponent { get; set; }

    /// <summary>
    ///  Called by <see cref="SimpleTileRepeater"/> control when one item of its datasource becomes visible and is due to be shown.
    /// </summary>
    /// <returns></returns>
    internal async Task LoadContentAsync() 
        => IsContentLoaded = await LoadContentCoreAsync();

    /// <summary>
    ///  In a derived class, override this method to load the content (e.g. a picture) asynchronously. 
    ///  This method is triggered when one item of the datasource becomes visible in the <see cref="SimpleTileRepeater"/> control.
    /// </summary>
    /// <returns><see langword="true"/> when the item could be loaded and can be reused for display.</returns>
    protected virtual async Task<bool> LoadContentCoreAsync() 
        => await Task.FromResult(false);

    /// <summary>
    ///  Indicates, if the content has already been loaded asynchronously.
    /// </summary>
    [Browsable(false)]
    internal bool IsContentLoaded { get; private set; }

    protected virtual void DisposeContent()
    { }
}
