namespace PathConverter
{
    partial class PathConverter
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.brwsInputButton = new System.Windows.Forms.Button();
            this.brwsOutputButton = new System.Windows.Forms.Button();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(29, 53);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(487, 22);
            this.inputFileTextBox.TabIndex = 0;
            // 
            // brwsInputButton
            // 
            this.brwsInputButton.Location = new System.Drawing.Point(532, 52);
            this.brwsInputButton.Name = "brwsInputButton";
            this.brwsInputButton.Size = new System.Drawing.Size(114, 23);
            this.brwsInputButton.TabIndex = 1;
            this.brwsInputButton.Text = "Browse...";
            this.brwsInputButton.UseVisualStyleBackColor = true;
            this.brwsInputButton.Click += new System.EventHandler(this.brwsInputButton_Click);
            // 
            // brwsOutputButton
            // 
            this.brwsOutputButton.Location = new System.Drawing.Point(532, 107);
            this.brwsOutputButton.Name = "brwsOutputButton";
            this.brwsOutputButton.Size = new System.Drawing.Size(114, 23);
            this.brwsOutputButton.TabIndex = 3;
            this.brwsOutputButton.Text = "Browse...";
            this.brwsOutputButton.UseVisualStyleBackColor = true;
            this.brwsOutputButton.Click += new System.EventHandler(this.brwsOutputButton_Click);
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Location = new System.Drawing.Point(29, 108);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.Size = new System.Drawing.Size(487, 22);
            this.outputFileTextBox.TabIndex = 2;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(249, 165);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(175, 36);
            this.convertButton.TabIndex = 4;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output File";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Enabled = false;
            this.outputTextBox.Location = new System.Drawing.Point(32, 251);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(614, 332);
            this.outputTextBox.TabIndex = 7;
            this.outputTextBox.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output";
            // 
            // PathConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 595);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.brwsOutputButton);
            this.Controls.Add(this.outputFileTextBox);
            this.Controls.Add(this.brwsInputButton);
            this.Controls.Add(this.inputFileTextBox);
            this.Name = "PathConverter";
            this.Text = "PathConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.Button brwsInputButton;
        private System.Windows.Forms.Button brwsOutputButton;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label3;
    }
}

