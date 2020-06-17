namespace WinFormUI
{
    partial class Dashboard
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
            this.messageBoxDemoButton = new System.Windows.Forms.Button();
            this.textBoxDemoButton = new System.Windows.Forms.Button();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.subTotalLabel = new System.Windows.Forms.Label();
            this.subTotalTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // messageBoxDemoButton
            // 
            this.messageBoxDemoButton.Location = new System.Drawing.Point(76, 217);
            this.messageBoxDemoButton.Name = "messageBoxDemoButton";
            this.messageBoxDemoButton.Size = new System.Drawing.Size(231, 108);
            this.messageBoxDemoButton.TabIndex = 0;
            this.messageBoxDemoButton.Text = "MessageBox Demo";
            this.messageBoxDemoButton.UseVisualStyleBackColor = true;
            this.messageBoxDemoButton.Click += new System.EventHandler(this.messageBoxDemoButton_Click);
            // 
            // textBoxDemoButton
            // 
            this.textBoxDemoButton.Location = new System.Drawing.Point(330, 217);
            this.textBoxDemoButton.Name = "textBoxDemoButton";
            this.textBoxDemoButton.Size = new System.Drawing.Size(231, 108);
            this.textBoxDemoButton.TabIndex = 1;
            this.textBoxDemoButton.Text = "TextBox Demo";
            this.textBoxDemoButton.UseVisualStyleBackColor = true;
            this.textBoxDemoButton.Click += new System.EventHandler(this.textBoxDemoButton_Click);
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new System.Drawing.Point(330, 148);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(231, 40);
            this.totalTextBox.TabIndex = 2;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(324, 112);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(69, 33);
            this.totalLabel.TabIndex = 3;
            this.totalLabel.Text = "Total";
            // 
            // subTotalLabel
            // 
            this.subTotalLabel.AutoSize = true;
            this.subTotalLabel.Location = new System.Drawing.Point(324, 33);
            this.subTotalLabel.Name = "subTotalLabel";
            this.subTotalLabel.Size = new System.Drawing.Size(107, 33);
            this.subTotalLabel.TabIndex = 5;
            this.subTotalLabel.Text = "Subtotal";
            // 
            // subTotalTextBox
            // 
            this.subTotalTextBox.Location = new System.Drawing.Point(330, 69);
            this.subTotalTextBox.Name = "subTotalTextBox";
            this.subTotalTextBox.Size = new System.Drawing.Size(231, 40);
            this.subTotalTextBox.TabIndex = 4;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 361);
            this.Controls.Add(this.subTotalLabel);
            this.Controls.Add(this.subTotalTextBox);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.textBoxDemoButton);
            this.Controls.Add(this.messageBoxDemoButton);
            this.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "Dashboard";
            this.Text = "Delegates Demo by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button messageBoxDemoButton;
        private System.Windows.Forms.Button textBoxDemoButton;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label subTotalLabel;
        private System.Windows.Forms.TextBox subTotalTextBox;
    }
}

