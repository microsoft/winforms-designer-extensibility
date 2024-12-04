namespace CommunityToolkit.WinForms.Extensions;

public static class FormExtensions
{
    /// <summary>
    ///  Retrieves the direct child controls of the specified control.
    /// </summary>
    /// <param name="control">The control whose child controls are retrieved.</param>
    /// <returns>An enumerable of child controls.</returns>
    public static IEnumerable<Control> ChildControls(this Control control)
        => control.Controls.Cast<Control>();

    /// <summary>
    ///  Retrieves the direct child controls of the specified control that are of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the child controls to retrieve.</typeparam>
    /// <param name="control">The control whose child controls are retrieved.</param>
    /// <returns>An enumerable of child controls of the specified type.</returns>
    public static IEnumerable<T> ChildControls<T>(this Control control) where T : Control
        => control.Controls.Cast<T>();

    /// <summary>
    ///  Enumerates all descendant controls of the specified control.
    /// </summary>
    /// <param name="control">The control to retrieve descendants from.</param>
    /// <returns>An enumerable of descendant controls.</returns>
    public static IEnumerable<Control> DescendantControls(this Control control)
        => control.DescendantControls<Control>();

    /// <summary>
    ///  Enumerates all descendant controls of the specified control that are of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the descendant controls to retrieve.</typeparam>
    /// <param name="control">The control to retrieve descendants from.</param>
    /// <param name="predicate">The condition to match.</param>
    /// <returns>An enumerable of descendant controls of the specified type.</returns>
    public static IEnumerable<T> DescendantControls<T>(this Control control, Func<Control, bool>? predicate = default)
        where T : Control
    {
        foreach (Control childControl in control.ChildControls())
        {
            if (childControl is T t && (predicate == null || predicate(t)))
            {
                yield return t;
            }

            foreach (T grandChildControl in childControl.DescendantControls<T>(predicate))
            {
                yield return grandChildControl;
            }
        }
    }
}
