<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlTestForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlTestForm))
        Me.CustomControl1 = New CustomControlLibrary.CustomControl()
        Me.CustomControl2 = New CustomControlLibrary.CustomControl()
        Me.SuspendLayout()
        '
        'CustomControl1
        '
        Me.CustomControl1.Location = New System.Drawing.Point(0, 0)
        Me.CustomControl1.Name = "CustomControl1"
        Me.CustomControl1.Size = New System.Drawing.Size(0, 0)
        Me.CustomControl1.TabIndex = 0
        '
        'CustomControl2
        '
        Me.CustomControl2.CustomPropertyStoreProperty = New CustomControlLibrary.CustomPropertyStore()
        Me.CustomControl2.CustomPropertyStoreProperty.CustomEnumValue = CustomControlLibrary.CustomPropertyStoreEnum.ThirdValue
        Me.CustomControl2.CustomPropertyStoreProperty.DateCreated = New Date(2022, 10, 7, 0, 0, 0, 0)
        Me.CustomControl2.CustomPropertyStoreProperty.ListOfStrings = CType(resources.GetObject("resource.ListOfStrings"), System.Collections.Generic.List(Of String))
        Me.CustomControl2.CustomPropertyStoreProperty.SomeMustHaveId = "SomeID"
        Me.CustomControl2.Location = New System.Drawing.Point(38, 29)
        Me.CustomControl2.Name = "CustomControl2"
        Me.CustomControl2.Size = New System.Drawing.Size(995, 745)
        Me.CustomControl2.TabIndex = 0
        Me.CustomControl2.Text = "CustomControl2"
        '
        'ControlTestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 841)
        Me.Controls.Add(Me.CustomControl2)
        Me.Name = "ControlTestForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CustomControl1 As CustomControlLibrary.CustomControl
    Friend WithEvents CustomControl2 As CustomControlLibrary.CustomControl
End Class
