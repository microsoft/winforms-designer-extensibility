﻿namespace RootDesignerDemo
{
    partial class Form1
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
            simpleCustomControl1 = new SimpleCustomControl();
            SuspendLayout();
            // 
            // simpleCustomControl1
            // 
            simpleCustomControl1.Location = new Point(90, 64);
            simpleCustomControl1.Name = "simpleCustomControl1";
            simpleCustomControl1.SampleProperty = true;
            simpleCustomControl1.Size = new Size(462, 283);
            simpleCustomControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(simpleCustomControl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private SimpleCustomControl simpleCustomControl1;
    }
}