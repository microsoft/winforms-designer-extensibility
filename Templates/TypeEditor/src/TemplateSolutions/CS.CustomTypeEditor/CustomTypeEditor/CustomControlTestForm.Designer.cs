namespace CustomTypeEditorTest
{
    partial class CustomControlTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomControlTestForm));
            this.customControl1 = new CustomControlLibrary.CustomControl();
            this.SuspendLayout();
            // 
            // customControl1
            // 
            this.customControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customControl1.CustomPropertyStoreProperty = new CustomControlLibrary.CustomPropertyStore();
            this.customControl1.CustomPropertyStoreProperty.CustomEnumValue = CustomControlLibrary.CustomPropertyStoreEnum.SecondValue;
            this.customControl1.CustomPropertyStoreProperty.DateCreated = new System.DateTime(2022, 7, 13, 0, 0, 0, 0);
            this.customControl1.CustomPropertyStoreProperty.ListOfStrings = ((System.Collections.Generic.List<string>)(resources.GetObject("resource.ListOfStrings")));
            this.customControl1.CustomPropertyStoreProperty.SomeMustHaveId = "123";
            this.customControl1.Location = new System.Drawing.Point(20, 16);
            this.customControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.customControl1.Name = "customControl1";
            this.customControl1.Size = new System.Drawing.Size(1264, 686);
            this.customControl1.TabIndex = 0;
            this.customControl1.Text = "customControl1";
            // 
            // CustomControlTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.customControl1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "CustomControlTestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControlLibrary.CustomControl customControl1;
    }
}