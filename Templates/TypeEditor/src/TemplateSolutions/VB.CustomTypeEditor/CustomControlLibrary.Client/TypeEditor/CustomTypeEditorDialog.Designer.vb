<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomTypeEditorDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me._errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me._mainTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me._customEnumValueLabel = New System.Windows.Forms.Label()
        Me._listOfStringsLabel = New System.Windows.Forms.Label()
        Me._dateCreatedLabel = New System.Windows.Forms.Label()
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me._okButton = New System.Windows.Forms.Button()
        Me._cancelButton = New System.Windows.Forms.Button()
        Me._dateCreated = New System.Windows.Forms.DateTimePicker()
        Me._customEnumValueListBox = New System.Windows.Forms.ComboBox()
        Me._requiredIdLabel = New System.Windows.Forms.Label()
        Me._requiredIdTextBox = New System.Windows.Forms.TextBox()
        Me._listOfStringTextBox = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me._errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._mainTableLayoutPanel.SuspendLayout()
        Me.flowLayoutPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_errorProvider
        '
        Me._errorProvider.ContainerControl = Me
        '
        '_mainTableLayoutPanel
        '
        Me._mainTableLayoutPanel.ColumnCount = 3
        Me._mainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me._mainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me._mainTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me._mainTableLayoutPanel.Controls.Add(Me._customEnumValueLabel, 0, 3)
        Me._mainTableLayoutPanel.Controls.Add(Me._listOfStringsLabel, 0, 2)
        Me._mainTableLayoutPanel.Controls.Add(Me._dateCreatedLabel, 0, 1)
        Me._mainTableLayoutPanel.Controls.Add(Me.flowLayoutPanel1, 2, 0)
        Me._mainTableLayoutPanel.Controls.Add(Me._dateCreated, 1, 1)
        Me._mainTableLayoutPanel.Controls.Add(Me._customEnumValueListBox, 1, 3)
        Me._mainTableLayoutPanel.Controls.Add(Me._requiredIdLabel, 0, 0)
        Me._mainTableLayoutPanel.Controls.Add(Me._requiredIdTextBox, 1, 0)
        Me._mainTableLayoutPanel.Controls.Add(Me._listOfStringTextBox, 1, 2)
        Me._mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me._mainTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me._mainTableLayoutPanel.Margin = New System.Windows.Forms.Padding(2)
        Me._mainTableLayoutPanel.Name = "_mainTableLayoutPanel"
        Me._mainTableLayoutPanel.RowCount = 2
        Me._mainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me._mainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me._mainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me._mainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me._mainTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me._mainTableLayoutPanel.Size = New System.Drawing.Size(494, 322)
        Me._mainTableLayoutPanel.TabIndex = 1
        '
        '_customEnumValueLabel
        '
        Me._customEnumValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._customEnumValueLabel.AutoSize = True
        Me._customEnumValueLabel.Location = New System.Drawing.Point(4, 301)
        Me._customEnumValueLabel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._customEnumValueLabel.Name = "_customEnumValueLabel"
        Me._customEnumValueLabel.Size = New System.Drawing.Size(104, 13)
        Me._customEnumValueLabel.TabIndex = 6
        Me._customEnumValueLabel.Text = "Custom Enum value:"
        '
        '_listOfStringsLabel
        '
        Me._listOfStringsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._listOfStringsLabel.AutoSize = True
        Me._listOfStringsLabel.Location = New System.Drawing.Point(4, 168)
        Me._listOfStringsLabel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._listOfStringsLabel.Name = "_listOfStringsLabel"
        Me._listOfStringsLabel.Size = New System.Drawing.Size(73, 13)
        Me._listOfStringsLabel.TabIndex = 4
        Me._listOfStringsLabel.Text = "List of Strings:"
        '
        '_dateCreatedLabel
        '
        Me._dateCreatedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._dateCreatedLabel.AutoSize = True
        Me._dateCreatedLabel.Location = New System.Drawing.Point(4, 35)
        Me._dateCreatedLabel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._dateCreatedLabel.Name = "_dateCreatedLabel"
        Me._dateCreatedLabel.Size = New System.Drawing.Size(72, 13)
        Me._dateCreatedLabel.TabIndex = 2
        Me._dateCreatedLabel.Text = "Date created:"
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flowLayoutPanel1.AutoSize = True
        Me.flowLayoutPanel1.Controls.Add(Me._okButton)
        Me.flowLayoutPanel1.Controls.Add(Me._cancelButton)
        Me.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(407, 2)
        Me.flowLayoutPanel1.Margin = New System.Windows.Forms.Padding(11, 2, 2, 2)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me._mainTableLayoutPanel.SetRowSpan(Me.flowLayoutPanel1, 5)
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(85, 70)
        Me.flowLayoutPanel1.TabIndex = 0
        '
        '_okButton
        '
        Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me._okButton.Location = New System.Drawing.Point(2, 2)
        Me._okButton.Margin = New System.Windows.Forms.Padding(2)
        Me._okButton.Name = "_okButton"
        Me._okButton.Size = New System.Drawing.Size(81, 28)
        Me._okButton.TabIndex = 0
        Me._okButton.Text = "OK"
        Me._okButton.UseVisualStyleBackColor = True
        '
        '_cancelButton
        '
        Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me._cancelButton.Location = New System.Drawing.Point(2, 40)
        Me._cancelButton.Margin = New System.Windows.Forms.Padding(2, 8, 2, 2)
        Me._cancelButton.Name = "_cancelButton"
        Me._cancelButton.Size = New System.Drawing.Size(81, 28)
        Me._cancelButton.TabIndex = 1
        Me._cancelButton.Text = "Cancel"
        Me._cancelButton.UseVisualStyleBackColor = True
        '
        '_dateCreated
        '
        Me._dateCreated.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._dateCreated.Location = New System.Drawing.Point(116, 32)
        Me._dateCreated.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._dateCreated.Name = "_dateCreated"
        Me._dateCreated.Size = New System.Drawing.Size(276, 20)
        Me._dateCreated.TabIndex = 3
        '
        '_customEnumValueListBox
        '
        Me._customEnumValueListBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._customEnumValueListBox.FormattingEnabled = True
        Me._customEnumValueListBox.Location = New System.Drawing.Point(116, 297)
        Me._customEnumValueListBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._customEnumValueListBox.Name = "_customEnumValueListBox"
        Me._customEnumValueListBox.Size = New System.Drawing.Size(276, 21)
        Me._customEnumValueListBox.TabIndex = 7
        '
        '_requiredIdLabel
        '
        Me._requiredIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me._requiredIdLabel.AutoSize = True
        Me._requiredIdLabel.Location = New System.Drawing.Point(4, 7)
        Me._requiredIdLabel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._requiredIdLabel.Name = "_requiredIdLabel"
        Me._requiredIdLabel.Size = New System.Drawing.Size(72, 13)
        Me._requiredIdLabel.TabIndex = 0
        Me._requiredIdLabel.Text = "A required ID:"
        '
        '_requiredIdTextBox
        '
        Me._requiredIdTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._requiredIdTextBox.Location = New System.Drawing.Point(116, 4)
        Me._requiredIdTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me._requiredIdTextBox.Name = "_requiredIdTextBox"
        Me._requiredIdTextBox.Size = New System.Drawing.Size(276, 20)
        Me._requiredIdTextBox.TabIndex = 1
        '
        '_listOfStringTextBox
        '
        Me._listOfStringTextBox.AcceptsReturn = True
        Me._listOfStringTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._listOfStringTextBox.Location = New System.Drawing.Point(114, 58)
        Me._listOfStringTextBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me._listOfStringTextBox.Multiline = True
        Me._listOfStringTextBox.Name = "_listOfStringTextBox"
        Me._listOfStringTextBox.Size = New System.Drawing.Size(280, 233)
        Me._listOfStringTextBox.TabIndex = 5
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'CustomTypeEditorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 322)
        Me.Controls.Add(Me._mainTableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomTypeEditorDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CustomTypeEditorDialog"
        CType(Me._errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me._mainTableLayoutPanel.ResumeLayout(False)
        Me._mainTableLayoutPanel.PerformLayout()
        Me.flowLayoutPanel1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents _errorProvider As Windows.Forms.ErrorProvider
    Private WithEvents _mainTableLayoutPanel As Windows.Forms.TableLayoutPanel
    Private WithEvents _customEnumValueLabel As Windows.Forms.Label
    Private WithEvents _listOfStringsLabel As Windows.Forms.Label
    Private WithEvents _dateCreatedLabel As Windows.Forms.Label
    Private WithEvents flowLayoutPanel1 As Windows.Forms.FlowLayoutPanel
    Private WithEvents _okButton As Windows.Forms.Button
    Private WithEvents _cancelButton As Windows.Forms.Button
    Private WithEvents _dateCreated As Windows.Forms.DateTimePicker
    Private WithEvents _customEnumValueListBox As Windows.Forms.ComboBox
    Private WithEvents _requiredIdLabel As Windows.Forms.Label
    Private WithEvents _requiredIdTextBox As Windows.Forms.TextBox
    Private WithEvents _listOfStringTextBox As Windows.Forms.TextBox
    Private WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
End Class
