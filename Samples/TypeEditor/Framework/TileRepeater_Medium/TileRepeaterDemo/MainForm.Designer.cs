namespace TileRepeaterDemo
{
    partial class MainForm
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
            this.tileRepeater1 = new WinForms.Tiles.TileRepeater();
            this.SuspendLayout();
            // 
            // tileRepeater1
            // 
            this.tileRepeater1.DataSource = null;
            this.tileRepeater1.ItemTemplate = null;
            this.tileRepeater1.Location = new System.Drawing.Point(29, 28);
            this.tileRepeater1.Name = "tileRepeater1";
            this.tileRepeater1.SeparatorTemplate = null;
            this.tileRepeater1.Size = new System.Drawing.Size(421, 252);
            this.tileRepeater1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tileRepeater1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinForms.Tiles.TileRepeater tileRepeater1;
    }
}

