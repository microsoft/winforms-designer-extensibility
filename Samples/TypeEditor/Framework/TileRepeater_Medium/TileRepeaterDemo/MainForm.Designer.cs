using System;

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
            Type templateType1;
            Type tileContentType1;
            this.tileRepeater1 = new WinForms.Tiles.TileRepeater();
            this.listView1 = new System.Windows.Forms.ListView();
            templateType1 = Type.GetType("WinForms.Tiles.Tile, TileRepeater, Version=1.0.0.0, Culture=neutral, PublicKeyTok" +
        "en=null");
            tileContentType1 = Type.GetType("WinForms.Tiles.TileContent, TileRepeater, Version=1.0.0.0, Culture=neutral, Publi" +
        "cKeyToken=null");
            this.SuspendLayout();
            // 
            // tileRepeater1
            // 
            this.tileRepeater1.DataSource = null;
            this.tileRepeater1.ItemTemplate = new WinForms.Tiles.TemplateAssignment(templateType1, tileContentType1);
            this.tileRepeater1.Location = new System.Drawing.Point(29, 28);
            this.tileRepeater1.Name = "tileRepeater1";
            this.tileRepeater1.SeparatorTemplate = null;
            this.tileRepeater1.Size = new System.Drawing.Size(421, 252);
            this.tileRepeater1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(531, 173);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(199, 182);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tileRepeater1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WinForms.Tiles.TileRepeater tileRepeater1;
        private System.Windows.Forms.ListView listView1;
    }
}

