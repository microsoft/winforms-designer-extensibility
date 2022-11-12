using System.Collections;
using System.ComponentModel;

namespace WinForms.Tiles
{
    [Designer("TileRepeaterDesigner"),
     System.ComponentModel.ComplexBindingProperties("DataSource")]
    public partial class TileRepeater : Panel
    {
        private const string AutoLayoutResizeDescription =
            "Gets or sets a value which determines, if the " +
            "Layout should be recalculated on resizing automatically.";

        private const string ItemTemplateDescription =
            "Gets or sets the type assignments, which determines based on the item type " +
            "in the data source what TileContent UserControl should be used for rendering " +
            "the data on binding.";

        private const string SeparatorTemplateDescription =
            "Gets or sets the type assignments, which determines based on the item type " +
            "in the data source what TileContent UserControl should be used for rendering " +
            "a visual separator on binding.";

        private const string DataSourceDescription =
            "Gets or sets the data source for the TileRepeater control.";

        private IBindingList? _dataSource;
        private Action? _listUnbinder;

        private int _previousListCount;
        private TemplateAssignment? _itemTemplate;
        private TemplateAssignment? _separatorTemplate;

        public TileRepeater()
        {
            base.AutoScroll = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll { get => true; set => base.AutoScroll = true; }

        /// <summary>
        ///  Gets or sets a value which determines if the layout should be recalculated automatically on resizing.
        /// </summary>
        [DefaultValue(false),
         Description(AutoLayoutResizeDescription)]
        public bool AutoLayoutOnResize { get; set; }

        /// <summary>
        ///  Gets or sets the collection of type assignments, which determine - based on the item type 
        ///  in the data source - what TileContent UserControl should be used for rendering 
        ///  the data on binding.
        /// </summary>
        [Description(ItemTemplateDescription)]
        public TemplateAssignment? ItemTemplate
        {
            get => _itemTemplate;
            set
            {
                if (_itemTemplate == value)
                {
                    return;
                }

                _itemTemplate = value;

                // We update the rendered content only at design-time, not at runtime.
                if (IsHandleCreated && this.IsAncestorSiteInDesignMode)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///  Gets or sets the template which should act as a separator indicator.
        /// </summary>
        [Description(SeparatorTemplateDescription)]
        public TemplateAssignment? SeparatorTemplate
        {
            get => _separatorTemplate;
            set
            {
                if (_separatorTemplate == value)
                {
                    return;
                }

                _separatorTemplate = value;

                // We update the rendered content only at design-time, not at runtime.
                if (IsHandleCreated && this.IsAncestorSiteInDesignMode)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///  Gets or sets the data source for the TileRepeater control.
        /// </summary>
        [Description(DataSourceDescription)]
        [AttributeProvider(typeof(IListSource)),
         Bindable(true)]
        public object? DataSource
        {
            get => _dataSource;

            set
            {
                if (!object.Equals(value, _dataSource))
                {
                    _listUnbinder?.Invoke();
                    _dataSource = value switch
                    {
                        null => null,
                        IBindingList bindingList => WireBindingList(bindingList),
                        _ => throw new ArgumentException(
                            nameof(DataSource),
                            "DataSource must be of type IBindingList"),
                    };
                }

                GenerateContent();
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            if (this.IsAncestorSiteInDesignMode)
            {
                PopulateDesignerContent();
            }
        }

        private void PopulateDesignerContent()
            => Controls.Clear();

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            if (AutoLayoutOnResize)
            {
                PerformLayout();
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            if ((levent.AffectedControl is Tile && levent.AffectedProperty == nameof(Parent)) ||
                (!AutoLayoutOnResize &&
                 levent.AffectedControl is TileRepeater &&
                 levent.AffectedProperty == nameof(DisplayRectangle)) || AutoLayoutOnResize)
            {
                LayoutInternal();
            }

            base.OnLayout(levent);
        }

        private IBindingList WireBindingList(IBindingList bindingList)
        {
            bindingList.ListChanged += BindingList_ListChanged;
            _listUnbinder = new Action(() => bindingList.ListChanged -= BindingList_ListChanged);
            return bindingList;
        }

        private void BindingList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (sender is IList list)
            {
                if (list.Count != _previousListCount)
                {
                    _previousListCount = list.Count;
                    GenerateContent();
                }
            }
        }

        private void GenerateContent()
        {
            SuspendLayout();
            Controls.Clear();

            var templateTypes = new[] { ItemTemplate, SeparatorTemplate };

            if (_dataSource is null ||
                ItemTemplate is null ||
                ItemTemplate.TileContentControlType is null)
            {
                ResumeLayout();
                return;
            }

            foreach (var item in _dataSource)
            {
                if (GetTemplateControlInstance(item.GetType(), templateTypes) is Tile tileControl &&
                    tileControl.TileContent.BindingSourceComponent is { })
                {
                    tileControl.TileContent.BindingSourceComponent.DataSource = item;
                    Controls.Add(tileControl);
                }
            }

            ResumeLayout();
        }

        private static Tile? GetTemplateControlInstance(Type templateType, TemplateAssignment?[] templateTypes)
        {
            // Get TileContentControl based on type:
            var tileContentType = templateTypes
                .Where(item => item?.TemplateType == templateType)
                .FirstOrDefault()?.TileContentControlType;

            Tile? tileControl = null;
            TileContent tileContentInstance;

            if (tileContentType is not null)
            {
                tileControl = new();

                try
                {
                    tileContentInstance = (TileContent)Activator.CreateInstance(tileContentType)!;
                    tileContentInstance.Size = tileContentInstance.PreferredSize;
                }
                catch (Exception)
                {
                    tileContentInstance = DefaultInstanceGetter();
                }

                tileControl.TileContent = tileContentInstance;
            }


            return tileControl;

            static TileContent DefaultInstanceGetter()
                => new() { BackColor = Color.Red };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _listUnbinder?.Invoke();
            }

            base.Dispose(disposing);
        }

        private void LayoutInternal()
        {
            if (Controls.Count == 0)
            {
                return;
            }

            Control lastControl = Controls[0];

            lastControl.Visible = true;
            lastControl.Tag = true;

            int currentX = Padding.Left;
            int currentY = Padding.Top + AutoScrollPosition.Y;
            int maxRowHeight = 0;
            int tilesInRow = 1;

            foreach (Control control in Controls)
            {
                // We only touching Tile controls.
                if (control is not Tile tileControl)
                {
                    continue;
                }

                tileControl.Size = control.PreferredSize;

                if (tileControl.TileContent.IsSeparator)
                {
                    currentY += maxRowHeight;
                    currentX = Padding.Left;
                    maxRowHeight = 0;

                    tileControl.Left = currentX;
                    tileControl.Top = currentY;

                    if (tileControl.TileContent.RequestFarSideAnchoring)
                    {
                        tileControl.Width = Right -
                            (Padding.Right + Padding.Left +
                             tileControl.Margin.Left + tileControl.Margin.Right +
                             SystemInformation.VerticalScrollBarWidth);

                        tileControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    }

                    currentY += tileControl.Margin.Top + tileControl.Height + tileControl.Margin.Bottom;
                }
                else
                {
                    if (currentX +
                        tileControl.Margin.Left +
                        tileControl.Width +
                        tileControl.Margin.Right > ClientSize.Width && tilesInRow > 1)
                    {
                        currentY += maxRowHeight;
                        currentX = Padding.Left;
                        maxRowHeight = 0;
                        tilesInRow = 1;
                    }

                    tileControl.Left = currentX;
                    tileControl.Top = currentY;

                    currentX += tileControl.Margin.Left + tileControl.Width + tileControl.Margin.Right;

                    maxRowHeight = Math.Max(
                        maxRowHeight,
                        tileControl.Margin.Top + tileControl.Height + tileControl.Margin.Bottom);

                    lastControl = tileControl;
                    tilesInRow++;
                }
            }

            lastControl.Visible = true;
            lastControl.Tag = true;
        }
    }
}
