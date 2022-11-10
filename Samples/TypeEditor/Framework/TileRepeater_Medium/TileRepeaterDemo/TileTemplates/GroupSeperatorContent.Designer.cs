using System.Windows.Forms;

namespace TileRepeaterDemo.TileTemplates
{
    partial class GroupSeperatorContent
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
            this.components = new System.ComponentModel.Container();
            this._groupTextLabel = new System.Windows.Forms.Label();
            this._genericTemplateItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._genericTemplateItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupTextLabel
            // 
            this._groupTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._groupTextLabel.AutoSize = true;
            this._groupTextLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._genericTemplateItemBindingSource, "Label", true));
            this._groupTextLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this._groupTextLabel.Location = new System.Drawing.Point(20, 8);
            this._groupTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._groupTextLabel.Name = "_groupTextLabel";
            this._groupTextLabel.Size = new System.Drawing.Size(200, 25);
            this._groupTextLabel.TabIndex = 0;
            this._groupTextLabel.Text = "Group seperator text";
            this._groupTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _genericTemplateItemBindingSource
            // 
            this._genericTemplateItemBindingSource.DataSource = typeof(TileRepeater.Data.ListController.GenericTemplateItem);
            // 
            // GroupSeperatorContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._groupTextLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "GroupSeperatorContent";
            this.Size = new System.Drawing.Size(254, 36);
            ((System.ComponentModel.ISupportInitialize)(this._genericTemplateItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label _groupTextLabel;
        private BindingSource _genericTemplateItemBindingSource;
    }
}
