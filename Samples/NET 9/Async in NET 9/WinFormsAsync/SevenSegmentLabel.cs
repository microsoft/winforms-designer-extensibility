using CommunityToolkit.WinForms.Extensions;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WinFormsAsync;

/// <summary>
///  Represents a seven-segment timer control.
/// </summary>
public partial class SevenSegmentTimer : Control
{
    private const float ColorCount = 50;

    private static PrivateFontCollection? s_fontCollection;
    private static Color[]? s_colors;

    private readonly int _fontSize = 128;
    private Font _segmentFont;
    private Font _standardFont;
    private Label[]? _separatorLabels;
    private Label[]? _segmentLabels;
    private readonly Color _defaultForeColor;

    /// <summary>
    ///  Initializes a new instance of the <see cref="SevenSegmentTimer"/> class.
    /// </summary>
    public SevenSegmentTimer()
    {
        InitializeComponent();

        if (Application.IsDarkModeEnabled)
        {
            _defaultForeColor = Color.Green;
        }
        else
        {
            _defaultForeColor = Color.Red;
        }

        ForeColor = _defaultForeColor;
    }

    /// <summary>
    ///  Gets or sets the foreground color of the control.
    /// </summary>
    public override Color ForeColor
    {
        get => base.ForeColor;
        set => base.ForeColor = value;
    }

    /// <summary>
    ///  Determines whether the <see cref="ForeColor"/> property should be serialized.
    /// </summary>
    /// <returns><c>true</c> if the <see cref="ForeColor"/> property value has changed from its default; otherwise, <c>false</c>.</returns>
    private bool ShouldSerializeForeColor() => ForeColor != _defaultForeColor;

    /// <summary>
    ///  Initializes the component.
    /// </summary>
    [MemberNotNull(nameof(_segmentFont), nameof(_standardFont))]
    private void InitializeComponent()
    {
        SuspendLayout();

        if (s_fontCollection is null)
        {
            SetupFont();
            if (s_fontCollection is null)
            {
                throw new InvalidOperationException("Font not loaded.");
            }
        }

        _segmentFont = new(
            family: s_fontCollection.Families[0],
            emSize: FontSize,
            style: FontStyle.Regular,
            unit: GraphicsUnit.Pixel);

        _standardFont = new(
            family: Font.FontFamily,
            emSize: FontSize,
            style: FontStyle.Regular,
            unit: GraphicsUnit.Pixel);

        // Create a TableLayoutPanel to hold Hour, :, Minute, : , Second, :, Millisecond
        TableLayoutPanel innerTableLayout = new()
        {
            Anchor = AnchorStyles.None,
            ColumnCount = 7,
            RowCount = 1,
            Padding = new Padding(0),
            Margin = new Padding(0),
            AutoSize = true
        };

        for (int i = 0; i < 7; i++)
        {
            innerTableLayout.ColumnStyles.Add(
                new ColumnStyle(
                    sizeType: SizeType.AutoSize));

            Label label = new()
            {
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            (label.Text, label.Font) = i switch
            {
                0 => ("00", _segmentFont),
                1 => (":", _standardFont),
                2 => ("00", _segmentFont),
                3 => (":", _standardFont),
                4 => ("00", _segmentFont),
                5 => (":", _standardFont),
                6 => ("0", _segmentFont),
                _ => (label.Text, label.Font),
            };

            innerTableLayout.Controls.Add(label, i, 0);
        }

        TableLayoutPanel outerTableLayout = new()
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(0),
            Margin = new Padding(0),
        };

        outerTableLayout.Controls.Add(innerTableLayout);
        Controls.Add(outerTableLayout);
        ResumeLayout();
    }

    /// <summary>
    ///  Gets or sets the font of the control. This property is hidden to prevent changing the font.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Font Font
    {
        get => base.Font;
        set => base.Font = value;
    }

    /// <summary>
    ///  Updates the time displayed on the control and delays for a specified duration.
    /// </summary>
    /// <param name="time">The time to display.</param>
    /// <param name="cancellation">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task UpdateTimeAndDelayAsync(TimeOnly time, CancellationToken cancellation = default)
    {
        int count = 0;

        foreach (Label label in this.DescendantControls<Label>())
        {
            label.Text = count++ switch
            {
                0 => time.Hour.ToString("00"),
                2 => time.Minute.ToString("00"),
                4 => time.Second.ToString("00"),
                6 => (time.Millisecond / 100).ToString("0"),
                _ => label.Text,
            };
        }

        return Task.Delay(75, cancellation);
    }

    /// <summary>
    ///  Gets or sets the delay in milliseconds between updates.
    /// </summary>
    [DefaultValue(75)]
    public int UpdateDelay { get; set; } = 75;

    /// <summary>
    ///  Gets the segment labels.
    /// </summary>
    public Label[] SegmentLabels
        => _segmentLabels
            ??= [.. this.DescendantControls<Label>().Where(label => label.Text != ":")];

    /// <summary>
    ///  Gets the separator labels.
    /// </summary>
    public Label[] SeparatorLabels
        => _separatorLabels
        ??= [.. this.DescendantControls<Label>().Where(label => label.Text == ":")];

    /// <summary>
    ///  Fades the separator labels out asynchronously.
    /// </summary>
    /// <param name="cancellation">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task FadeSeparatorsOutAsync(CancellationToken cancellation = default)
    {
        s_colors ??= DefineGradientColors(BackColor, ForeColor);

        for (int i = 0; i < (int)ColorCount; i++)
        {
            Array.ForEach(SeparatorLabels, (label) => label.ForeColor = s_colors[i]);
            await Task.Delay(1, cancellation).ConfigureAwait(false);
        }
    }

    /// <summary>
    ///  Fades the separator labels in asynchronously.
    /// </summary>
    /// <param name="cancellation">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task FadeSeparatorsInAsync(CancellationToken cancellation = default)
    {
        s_colors ??= DefineGradientColors(BackColor, ForeColor);

        for (int i = (int)ColorCount - 1; i >= 0; i--)
        {
            Array.ForEach(SeparatorLabels, (label) => label.ForeColor = s_colors[i]);
            await Task.Delay(1, cancellation).ConfigureAwait(false);
        }
    }

    /// <summary>
    ///  Gets or sets the font size of the control.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int FontSize
    {
        get => _fontSize;
        set => Font = new Font(Font.FontFamily, value, Font.Style, Font.Unit);
    }

    /// <summary>
    ///  Defines gradient colors between the background color and the foreground color.
    /// </summary>
    /// <param name="backColor">The background color.</param>
    /// <param name="ForeColor">The foreground color.</param>
    /// <returns>An array of gradient colors.</returns>
    private static Color[] DefineGradientColors(Color backColor, Color ForeColor)
    {
        var colors = new Color[(int)ColorCount];

        for (int i = 0; i < (int)ColorCount; i++)
        {
            colors[i] = Color.FromArgb(
                red: ForeColor.R + (int)((backColor.R - ForeColor.R) * i / ColorCount),
                green: ForeColor.G + (int)((backColor.G - ForeColor.G) * i / ColorCount),
                blue: ForeColor.B + (int)((backColor.B - ForeColor.B) * i / ColorCount));
        }

        return colors;
    }

    /// <summary>
    ///  Sets up the font by loading it from the embedded resources and installing it in the private fonts.
    /// </summary>
    private static void SetupFont()
    {
        // Load the Segment7Standard font from the embedded resources
        // and install it in the private fonts
        var assembly = Assembly.GetExecutingAssembly();
        string resourceName = "WinFormsAsync.Resources.Segment7Standard.otf";

        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException("Font resource not found.");

        int dataLength = (int)stream.Length;

        byte[] fontData = new byte[stream.Length];
        stream.ReadExactly(fontData);

        IntPtr fontPtr = Marshal.AllocCoTaskMem(dataLength);
        Marshal.Copy(fontData, 0, fontPtr, dataLength);

        uint cFonts = 0;
        AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref cFonts);

        s_fontCollection = new PrivateFontCollection();
        s_fontCollection.AddMemoryFont(fontPtr, fontData.Length);
    }

    [LibraryImport("gdi32.dll", EntryPoint = "AddFontMemResourceEx")]
    private static partial IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, ref uint pcFonts);
}
