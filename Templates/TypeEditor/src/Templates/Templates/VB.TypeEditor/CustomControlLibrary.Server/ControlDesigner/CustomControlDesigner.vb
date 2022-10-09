Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.DotNet.DesignTools.Designers
Imports Microsoft.DotNet.DesignTools.Designers.Actions

''' <summary>
'''  The control designer of the CustomControl.
''' </summary>
Partial Friend Class CustomControlDesigner
    Inherits ControlDesigner

    ''' <summary>
    '''  Attaches the action lists to the control designer.
    ''' </summary>
    ''' <remarks>
    '''  Note: Action lists for the out-of-process Designer can be implemented exactly as they would be for the in-process
    '''  designer, except: The control designer has to be compiled against the Winforms Designer Extensibility SDK, and ActionList
    '''  related classes must come from the <see cref="Microsoft.DotNet.DesignTools.Designers.Actions"/> namespace.
    ''' </remarks>
    Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
        Get
            Return New DesignerActionListCollection() From {New ActionList(Me)}
        End Get
    End Property

    Protected Overrides Sub OnPaintAdornments(ByVal paintEventArgs As PaintEventArgs)
        MyBase.OnPaintAdornments(paintEventArgs)

        ' If you want to paint custom adorner or other GDI+ based content,
        ' use the paintEventArgs' Graphics methods to render it.

        ' Drawing the frame around the ClientRectangle with a dotted brush...
        If Not (If(SelectionService?.GetComponentSelected(Control), False)) Then
            Using pen As New Pen(Control.ForeColor)

                ' ...if the control is not currently selected.
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot
                Using brush = New SolidBrush(Control.ForeColor)

                    Dim clientRect = Control.ClientRectangle
                    clientRect.Inflate(-1, -1)

                    paintEventArgs.Graphics.DrawRectangle(pen, clientRect)
                End Using
            End Using
        End If
    End Sub
End Class
