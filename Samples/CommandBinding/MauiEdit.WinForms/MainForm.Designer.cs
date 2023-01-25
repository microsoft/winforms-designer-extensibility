namespace WinFormsCommandBindingDemo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _mainMenuStrip = new System.Windows.Forms.MenuStrip();
            _fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _mainFormControllerBindingSource = new System.Windows.Forms.BindingSource(components);
            _insertDemoTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            _quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            _convertToUpperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            _statusStrip = new System.Windows.Forms.StatusStrip();
            _wordCountStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            _rowNumberStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            _columnNumberStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            _editorSurface = new EditorControl();
            trackBar1 = new System.Windows.Forms.TrackBar();
            _rewrapButton = new System.Windows.Forms.Button();
            _charWrapThreshold = new System.Windows.Forms.Label();
            _mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainFormControllerBindingSource).BeginInit();
            _statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // _mainMenuStrip
            // 
            _mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            _mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _fileToolStripMenuItem, toolStripMenuItem3, toolsToolStripMenuItem });
            _mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            _mainMenuStrip.Name = "_mainMenuStrip";
            _mainMenuStrip.Size = new System.Drawing.Size(760, 28);
            _mainMenuStrip.TabIndex = 0;
            _mainMenuStrip.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            _fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _newToolStripMenuItem, _insertDemoTextToolStripMenuItem, toolStripMenuItem1, _quitToolStripMenuItem });
            _fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            _fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            _fileToolStripMenuItem.Text = "&File";
            // 
            // _newToolStripMenuItem
            // 
            _newToolStripMenuItem.DataBindings.Add(new System.Windows.Forms.Binding("Command", _mainFormControllerBindingSource, "NewDocumentCommand", true));
            _newToolStripMenuItem.Name = "_newToolStripMenuItem";
            _newToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            _newToolStripMenuItem.Text = "New...";
            // 
            // _mainFormControllerBindingSource
            // 
            _mainFormControllerBindingSource.DataSource = typeof(MauiEdit.ViewModels.MainFormController);
            // 
            // _insertDemoTextToolStripMenuItem
            // 
            _insertDemoTextToolStripMenuItem.DataBindings.Add(new System.Windows.Forms.Binding("Command", _mainFormControllerBindingSource, "InsertDemoTextCommand", true));
            _insertDemoTextToolStripMenuItem.Name = "_insertDemoTextToolStripMenuItem";
            _insertDemoTextToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            _insertDemoTextToolStripMenuItem.Text = "&Insert demo text";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
            // 
            // _quitToolStripMenuItem
            // 
            _quitToolStripMenuItem.Name = "_quitToolStripMenuItem";
            _quitToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            _quitToolStripMenuItem.Text = "&Quit";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _convertToUpperToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(49, 24);
            toolStripMenuItem3.Text = "&Edit";
            // 
            // _convertToUpperToolStripMenuItem
            // 
            _convertToUpperToolStripMenuItem.DataBindings.Add(new System.Windows.Forms.Binding("Command", _mainFormControllerBindingSource, "ToUpperCommand", true));
            _convertToUpperToolStripMenuItem.Name = "_convertToUpperToolStripMenuItem";
            _convertToUpperToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            _convertToUpperToolStripMenuItem.Text = "Convert to upper";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _optionsToolStripMenuItem, toolStripMenuItem2 });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // _optionsToolStripMenuItem
            // 
            _optionsToolStripMenuItem.DataBindings.Add(new System.Windows.Forms.Binding("Command", _mainFormControllerBindingSource, "ShowToolsOptionsCommand", true));
            _optionsToolStripMenuItem.Name = "_optionsToolStripMenuItem";
            _optionsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            _optionsToolStripMenuItem.Text = "&Options...";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // _statusStrip
            // 
            _statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            _statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _wordCountStatusStripLabel, _rowNumberStatusLabel, _columnNumberStatusLabel, toolStripStatusLabel1 });
            _statusStrip.Location = new System.Drawing.Point(0, 567);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Size = new System.Drawing.Size(760, 26);
            _statusStrip.TabIndex = 1;
            _statusStrip.Text = "statusStrip1";
            // 
            // _wordCountStatusStripLabel
            // 
            _wordCountStatusStripLabel.Name = "_wordCountStatusStripLabel";
            _wordCountStatusStripLabel.Size = new System.Drawing.Size(419, 20);
            _wordCountStatusStripLabel.Spring = true;
            // 
            // _rowNumberStatusLabel
            // 
            _rowNumberStatusLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", _mainFormControllerBindingSource, "SelectionRow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "Line:\\ 000"));
            _rowNumberStatusLabel.Name = "_rowNumberStatusLabel";
            _rowNumberStatusLabel.Size = new System.Drawing.Size(79, 20);
            _rowNumberStatusLabel.Text = "Line: ####";
            // 
            // _columnNumberStatusLabel
            // 
            _columnNumberStatusLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", _mainFormControllerBindingSource, "SelectionColumn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "Col:\\ 00000"));
            _columnNumberStatusLabel.Name = "_columnNumberStatusLabel";
            _columnNumberStatusLabel.Size = new System.Drawing.Size(94, 20);
            _columnNumberStatusLabel.Text = "Column: ###";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", _mainFormControllerBindingSource, "SelectionLength", true));
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(153, 20);
            toolStripStatusLabel1.Text = "Selection Length: ###";
            // 
            // _editorSurface
            // 
            _editorSurface.AcceptsReturn = true;
            _editorSurface.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            _editorSurface.DataBindings.Add(new System.Windows.Forms.Binding("CursorPosition", _mainFormControllerBindingSource, "SelectionIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            _editorSurface.DataBindings.Add(new System.Windows.Forms.Binding("SelectionLength", _mainFormControllerBindingSource, "SelectionLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            _editorSurface.DataBindings.Add(new System.Windows.Forms.Binding("Text", _mainFormControllerBindingSource, "TextDocument", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            _editorSurface.Location = new System.Drawing.Point(15, 66);
            _editorSurface.Margin = new System.Windows.Forms.Padding(4);
            _editorSurface.Multiline = true;
            _editorSurface.Name = "_editorSurface";
            _editorSurface.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            _editorSurface.Size = new System.Drawing.Size(732, 488);
            _editorSurface.TabIndex = 2;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar1.AutoSize = false;
            trackBar1.DataBindings.Add(new System.Windows.Forms.Binding("Value", _mainFormControllerBindingSource, "CharCountWrapThreshold", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            trackBar1.Location = new System.Drawing.Point(12, 29);
            trackBar1.Margin = new System.Windows.Forms.Padding(2);
            trackBar1.Maximum = 80;
            trackBar1.Minimum = 20;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(591, 31);
            trackBar1.TabIndex = 3;
            trackBar1.Value = 60;
            // 
            // _rewrapButton
            // 
            _rewrapButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            _rewrapButton.DataBindings.Add(new System.Windows.Forms.Binding("Command", _mainFormControllerBindingSource, "RewrapCommand", true));
            _rewrapButton.Location = new System.Drawing.Point(660, 29);
            _rewrapButton.Margin = new System.Windows.Forms.Padding(2);
            _rewrapButton.Name = "_rewrapButton";
            _rewrapButton.Size = new System.Drawing.Size(87, 31);
            _rewrapButton.TabIndex = 4;
            _rewrapButton.Text = "&Rewrap";
            _rewrapButton.UseVisualStyleBackColor = true;
            // 
            // _charWrapThreshold
            // 
            _charWrapThreshold.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            _charWrapThreshold.AutoSize = true;
            _charWrapThreshold.DataBindings.Add(new System.Windows.Forms.Binding("Text", _mainFormControllerBindingSource, "CharCountWrapThreshold", true));
            _charWrapThreshold.Location = new System.Drawing.Point(612, 34);
            _charWrapThreshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            _charWrapThreshold.Name = "_charWrapThreshold";
            _charWrapThreshold.Size = new System.Drawing.Size(36, 20);
            _charWrapThreshold.TabIndex = 5;
            _charWrapThreshold.Text = "###";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(760, 593);
            Controls.Add(_charWrapThreshold);
            Controls.Add(_rewrapButton);
            Controls.Add(trackBar1);
            Controls.Add(_editorSurface);
            Controls.Add(_statusStrip);
            Controls.Add(_mainMenuStrip);
            MainMenuStrip = _mainMenuStrip;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "WinForms/MAUI Edit";
            DataContextChanged += MainForm_DataContextChanged;
            _mainMenuStrip.ResumeLayout(false);
            _mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_mainFormControllerBindingSource).EndInit();
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip _mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _optionsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _wordCountStatusStripLabel;
        private EditorControl _editorSurface;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem _convertToUpperToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel _rowNumberStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel _columnNumberStatusLabel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button _rewrapButton;
        private System.Windows.Forms.Label _charWrapThreshold;
        private System.Windows.Forms.ToolStripMenuItem _insertDemoTextToolStripMenuItem;
        private System.Windows.Forms.BindingSource _mainFormControllerBindingSource;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

