using System.Windows.Forms;

namespace WinForms.Tiles
{
    partial class Tile
    {
        /// <summary> 
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed, otherwise false.</param>
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
            this._contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._contentPanel.Location = new System.Drawing.Point(20, 16);
            this._contentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._contentPanel.Name = "_contentPanel";
            this._contentPanel.Size = new System.Drawing.Size(88, 68);
            this._contentPanel.TabIndex = 0;
            // 
            // Tile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this._contentPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Tile";
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.Size = new System.Drawing.Size(128, 100);
            this.ResumeLayout(false);

        }

        #endregion

        protected Panel _contentPanel;
    }
}
