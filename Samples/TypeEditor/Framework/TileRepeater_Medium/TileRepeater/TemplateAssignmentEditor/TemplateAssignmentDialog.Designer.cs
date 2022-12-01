namespace WinForms.Tiles.Designer
{
    partial class TemplateAssignmentDialog
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
            this._templateTypesListBox = new System.Windows.Forms.ListBox();
            this._INotifyPropertyChangedFilterCheckBox = new System.Windows.Forms.CheckBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._selectBindingSourceTemplateTypeLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._resultStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._clearSelectionsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._tileContentTilesListbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _templateTypesListBox
            // 
            this._templateTypesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._templateTypesListBox.FormattingEnabled = true;
            this._templateTypesListBox.IntegralHeight = false;
            this._templateTypesListBox.Location = new System.Drawing.Point(2, 2);
            this._templateTypesListBox.Margin = new System.Windows.Forms.Padding(2);
            this._templateTypesListBox.Name = "_templateTypesListBox";
            this._templateTypesListBox.Size = new System.Drawing.Size(379, 116);
            this._templateTypesListBox.TabIndex = 1;
            this._templateTypesListBox.SelectedIndexChanged += new System.EventHandler(this.TemplateTypeListBox_SelectedIndexChanged);
            // 
            // _INotifyPropertyChangedFilterCheckBox
            // 
            this._INotifyPropertyChangedFilterCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._INotifyPropertyChangedFilterCheckBox.AutoSize = true;
            this._INotifyPropertyChangedFilterCheckBox.Location = new System.Drawing.Point(17, 292);
            this._INotifyPropertyChangedFilterCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this._INotifyPropertyChangedFilterCheckBox.Name = "_INotifyPropertyChangedFilterCheckBox";
            this._INotifyPropertyChangedFilterCheckBox.Size = new System.Drawing.Size(255, 17);
            this._INotifyPropertyChangedFilterCheckBox.TabIndex = 4;
            this._INotifyPropertyChangedFilterCheckBox.Text = "Filter types implementing INotifyPropertyChanged";
            this._INotifyPropertyChangedFilterCheckBox.UseVisualStyleBackColor = true;
            this._INotifyPropertyChangedFilterCheckBox.CheckedChanged += new System.EventHandler(this.FilterTypesImplementingINotifyPropertyChangedCheckBox_CheckedChanged);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(405, 25);
            this._okButton.Margin = new System.Windows.Forms.Padding(2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(77, 25);
            this._okButton.TabIndex = 5;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(405, 53);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(77, 25);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _selectBindingSourceTemplateTypeLabel
            // 
            this._selectBindingSourceTemplateTypeLabel.AutoSize = true;
            this._selectBindingSourceTemplateTypeLabel.Location = new System.Drawing.Point(15, 7);
            this._selectBindingSourceTemplateTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._selectBindingSourceTemplateTypeLabel.Name = "_selectBindingSourceTemplateTypeLabel";
            this._selectBindingSourceTemplateTypeLabel.Size = new System.Drawing.Size(178, 13);
            this._selectBindingSourceTemplateTypeLabel.TabIndex = 0;
            this._selectBindingSourceTemplateTypeLabel.Text = "Select binding source template type:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._resultStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 310);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(482, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _resultStatusLabel
            // 
            this._resultStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._resultStatusLabel.Name = "_resultStatusLabel";
            this._resultStatusLabel.Size = new System.Drawing.Size(471, 17);
            this._resultStatusLabel.Spring = true;
            this._resultStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _clearSelectionsButton
            // 
            this._clearSelectionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._clearSelectionsButton.Enabled = false;
            this._clearSelectionsButton.Location = new System.Drawing.Point(405, 135);
            this._clearSelectionsButton.Margin = new System.Windows.Forms.Padding(2);
            this._clearSelectionsButton.Name = "_clearSelectionsButton";
            this._clearSelectionsButton.Size = new System.Drawing.Size(77, 25);
            this._clearSelectionsButton.TabIndex = 8;
            this._clearSelectionsButton.Text = "Clear";
            this._clearSelectionsButton.UseVisualStyleBackColor = true;
            this._clearSelectionsButton.Click += new System.EventHandler(this.ClearSelectionsButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._tileContentTilesListbox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._templateTypesListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 23);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(383, 261);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // _tileContentTilesListbox
            // 
            this._tileContentTilesListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tileContentTilesListbox.FormattingEnabled = true;
            this._tileContentTilesListbox.IntegralHeight = false;
            this._tileContentTilesListbox.Location = new System.Drawing.Point(2, 143);
            this._tileContentTilesListbox.Margin = new System.Windows.Forms.Padding(2);
            this._tileContentTilesListbox.Name = "_tileContentTilesListbox";
            this._tileContentTilesListbox.Size = new System.Drawing.Size(379, 116);
            this._tileContentTilesListbox.TabIndex = 4;
            this._tileContentTilesListbox.SelectedIndexChanged += new System.EventHandler(this.TileContentTilesListbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 8, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select binding source template type:";
            // 
            // TemplateAssignmentDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(482, 332);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this._clearSelectionsButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._selectBindingSourceTemplateTypeLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._INotifyPropertyChangedFilterCheckBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(366, 314);
            this.Name = "TemplateAssignmentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Template Types";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _templateTypesListBox;
        private System.Windows.Forms.CheckBox _INotifyPropertyChangedFilterCheckBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _selectBindingSourceTemplateTypeLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _resultStatusLabel;
        private System.Windows.Forms.Button _clearSelectionsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox _tileContentTilesListbox;
        private System.Windows.Forms.Label label1;
    }
}
