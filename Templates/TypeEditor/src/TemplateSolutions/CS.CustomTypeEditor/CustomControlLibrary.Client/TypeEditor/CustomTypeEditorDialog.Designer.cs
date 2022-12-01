namespace CustomControlLibrary.Designer.Client
{
    partial class CustomTypeEditorDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._customEnumValueLabel = new System.Windows.Forms.Label();
            this._listOfStringsLabel = new System.Windows.Forms.Label();
            this._dateCreatedLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._dateCreated = new System.Windows.Forms.DateTimePicker();
            this._customEnumValueListBox = new System.Windows.Forms.ComboBox();
            this._requiredIdLabel = new System.Windows.Forms.Label();
            this._requiredIdTextBox = new System.Windows.Forms.TextBox();
            this._listOfStringTextBox = new System.Windows.Forms.TextBox();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._mainTableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainTableLayoutPanel
            // 
            this._mainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mainTableLayoutPanel.ColumnCount = 3;
            this._mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._mainTableLayoutPanel.Controls.Add(this._customEnumValueLabel, 0, 3);
            this._mainTableLayoutPanel.Controls.Add(this._listOfStringsLabel, 0, 2);
            this._mainTableLayoutPanel.Controls.Add(this._dateCreatedLabel, 0, 1);
            this._mainTableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this._mainTableLayoutPanel.Controls.Add(this._dateCreated, 1, 1);
            this._mainTableLayoutPanel.Controls.Add(this._customEnumValueListBox, 1, 3);
            this._mainTableLayoutPanel.Controls.Add(this._requiredIdLabel, 0, 0);
            this._mainTableLayoutPanel.Controls.Add(this._requiredIdTextBox, 1, 0);
            this._mainTableLayoutPanel.Controls.Add(this._listOfStringTextBox, 1, 2);
            this._mainTableLayoutPanel.Location = new System.Drawing.Point(7, 6);
            this._mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this._mainTableLayoutPanel.Name = "_mainTableLayoutPanel";
            this._mainTableLayoutPanel.RowCount = 2;
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._mainTableLayoutPanel.Size = new System.Drawing.Size(511, 264);
            this._mainTableLayoutPanel.TabIndex = 0;
            // 
            // _customEnumValueLabel
            // 
            this._customEnumValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._customEnumValueLabel.AutoSize = true;
            this._customEnumValueLabel.Location = new System.Drawing.Point(4, 243);
            this._customEnumValueLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._customEnumValueLabel.Name = "_customEnumValueLabel";
            this._customEnumValueLabel.Size = new System.Drawing.Size(104, 13);
            this._customEnumValueLabel.TabIndex = 6;
            this._customEnumValueLabel.Text = "Custom Enum value:";
            // 
            // _listOfStringsLabel
            // 
            this._listOfStringsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._listOfStringsLabel.AutoSize = true;
            this._listOfStringsLabel.Location = new System.Drawing.Point(4, 139);
            this._listOfStringsLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._listOfStringsLabel.Name = "_listOfStringsLabel";
            this._listOfStringsLabel.Size = new System.Drawing.Size(73, 13);
            this._listOfStringsLabel.TabIndex = 4;
            this._listOfStringsLabel.Text = "List of Strings:";
            // 
            // _dateCreatedLabel
            // 
            this._dateCreatedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._dateCreatedLabel.AutoSize = true;
            this._dateCreatedLabel.Location = new System.Drawing.Point(4, 35);
            this._dateCreatedLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dateCreatedLabel.Name = "_dateCreatedLabel";
            this._dateCreatedLabel.Size = new System.Drawing.Size(72, 13);
            this._dateCreatedLabel.TabIndex = 2;
            this._dateCreatedLabel.Text = "Date created:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this._okButton);
            this.flowLayoutPanel1.Controls.Add(this._cancelButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(424, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(11, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this._mainTableLayoutPanel.SetRowSpan(this.flowLayoutPanel1, 5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(85, 70);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(2, 2);
            this._okButton.Margin = new System.Windows.Forms.Padding(2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(81, 28);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(2, 40);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(81, 28);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _dateCreated
            // 
            this._dateCreated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._dateCreated.Location = new System.Drawing.Point(116, 32);
            this._dateCreated.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._dateCreated.Name = "_dateCreated";
            this._dateCreated.Size = new System.Drawing.Size(293, 20);
            this._dateCreated.TabIndex = 3;
            // 
            // _customEnumValueListBox
            // 
            this._customEnumValueListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._customEnumValueListBox.FormattingEnabled = true;
            this._customEnumValueListBox.Location = new System.Drawing.Point(116, 239);
            this._customEnumValueListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._customEnumValueListBox.Name = "_customEnumValueListBox";
            this._customEnumValueListBox.Size = new System.Drawing.Size(293, 21);
            this._customEnumValueListBox.TabIndex = 7;
            // 
            // _requiredIdLabel
            // 
            this._requiredIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._requiredIdLabel.AutoSize = true;
            this._requiredIdLabel.Location = new System.Drawing.Point(4, 7);
            this._requiredIdLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._requiredIdLabel.Name = "_requiredIdLabel";
            this._requiredIdLabel.Size = new System.Drawing.Size(72, 13);
            this._requiredIdLabel.TabIndex = 0;
            this._requiredIdLabel.Text = "A required ID:";
            // 
            // _requiredIdTextBox
            // 
            this._requiredIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._requiredIdTextBox.Location = new System.Drawing.Point(116, 4);
            this._requiredIdTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._requiredIdTextBox.Name = "_requiredIdTextBox";
            this._requiredIdTextBox.Size = new System.Drawing.Size(293, 20);
            this._requiredIdTextBox.TabIndex = 1;
            // 
            // _listOfStringTextBox
            // 
            this._listOfStringTextBox.AcceptsReturn = true;
            this._listOfStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listOfStringTextBox.Location = new System.Drawing.Point(114, 58);
            this._listOfStringTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._listOfStringTextBox.Multiline = true;
            this._listOfStringTextBox.Name = "_listOfStringTextBox";
            this._listOfStringTextBox.Size = new System.Drawing.Size(297, 175);
            this._listOfStringTextBox.TabIndex = 5;
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // CustomTypeEditorDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(524, 273);
            this.Controls.Add(this._mainTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomTypeEditorDialog";
            this.Text = "CustomTypeEditorDialog";
            this._mainTableLayoutPanel.ResumeLayout(false);
            this._mainTableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _dateCreatedLabel;
        private System.Windows.Forms.DateTimePicker _dateCreated;
        private System.Windows.Forms.Label _listOfStringsLabel;
        private System.Windows.Forms.Label _requiredIdLabel;
        private System.Windows.Forms.Label _customEnumValueLabel;
        private System.Windows.Forms.ComboBox _customEnumValueListBox;
        private System.Windows.Forms.TextBox _requiredIdTextBox;
        private System.Windows.Forms.TextBox _listOfStringTextBox;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}