namespace WinFormsCommandBindingDemo
{
    partial class SimpleTestForm
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
            components = new System.ComponentModel.Container();
            _testCommandButton = new System.Windows.Forms.Button();
            _commandResultLabel = new System.Windows.Forms.Label();
            _commandAvailabilityCheckBox = new System.Windows.Forms.CheckBox();
            simpleCommandViewModelBindingSource = new System.Windows.Forms.BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)simpleCommandViewModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // _testCommandButton
            // 
            _testCommandButton.DataBindings.Add(new System.Windows.Forms.Binding("Command", simpleCommandViewModelBindingSource, "SampleCommand", true));
            _testCommandButton.Location = new System.Drawing.Point(101, 72);
            _testCommandButton.Name = "_testCommandButton";
            _testCommandButton.Size = new System.Drawing.Size(148, 39);
            _testCommandButton.TabIndex = 0;
            _testCommandButton.Text = "Execute Command";
            _testCommandButton.UseVisualStyleBackColor = true;
            // 
            // _commandResultLabel
            // 
            _commandResultLabel.AutoSize = true;
            _commandResultLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", simpleCommandViewModelBindingSource, "SampleCommandResult", true));
            _commandResultLabel.Location = new System.Drawing.Point(92, 127);
            _commandResultLabel.Name = "_commandResultLabel";
            _commandResultLabel.Size = new System.Drawing.Size(166, 20);
            _commandResultLabel.TabIndex = 1;
            _commandResultLabel.Text = "--- Command Result ---";
            // 
            // _commandAvailabilityCheckBox
            // 
            _commandAvailabilityCheckBox.AutoSize = true;
            _commandAvailabilityCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", simpleCommandViewModelBindingSource, "SampleCommandAvailability", true));
            _commandAvailabilityCheckBox.Location = new System.Drawing.Point(86, 32);
            _commandAvailabilityCheckBox.Name = "_commandAvailabilityCheckBox";
            _commandAvailabilityCheckBox.Size = new System.Drawing.Size(178, 24);
            _commandAvailabilityCheckBox.TabIndex = 2;
            _commandAvailabilityCheckBox.Text = "Command Availability";
            _commandAvailabilityCheckBox.UseVisualStyleBackColor = true;
            // 
            // simpleCommandViewModelBindingSource
            // 
            simpleCommandViewModelBindingSource.DataSource = typeof(WinFormsCommandBinding.Examples.SimpleCommandViewModel);
            // 
            // SimpleTestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(346, 185);
            Controls.Add(_commandAvailabilityCheckBox);
            Controls.Add(_commandResultLabel);
            Controls.Add(_testCommandButton);
            Name = "SimpleTestForm";
            Text = "Simple MVVM TestForm";
            ((System.ComponentModel.ISupportInitialize)simpleCommandViewModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button _testCommandButton;
        private System.Windows.Forms.Label _commandResultLabel;
        private System.Windows.Forms.CheckBox _commandAvailabilityCheckBox;
        private System.Windows.Forms.BindingSource simpleCommandViewModelBindingSource;
    }
}
