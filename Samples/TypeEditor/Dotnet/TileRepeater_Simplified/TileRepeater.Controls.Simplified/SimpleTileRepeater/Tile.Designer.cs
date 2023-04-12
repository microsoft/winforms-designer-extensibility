namespace WinForms.Tiles.Simplified
{
    partial class Tile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._contentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _contentPanel
            // 
            this._contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentPanel.Location = new System.Drawing.Point(32, 32);
            this._contentPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(136, 136);
            this._contentPanel.TabIndex = 0;
            // 
            // Tile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this._contentPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Tile";
            this.Padding = new System.Windows.Forms.Padding(32, 32, 32, 32);
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);

        }

        #endregion

        protected Panel _contentPanel;
    }
}
