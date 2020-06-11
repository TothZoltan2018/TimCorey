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
            this.headerLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.customerText = new System.Windows.Forms.Label();
            this.checkingBalanceValue = new System.Windows.Forms.Label();
            this.checkingBalanceLabel = new System.Windows.Forms.Label();
            this.savingsBalanceValue = new System.Windows.Forms.Label();
            this.savingsBalanceLabel = new System.Windows.Forms.Label();
            this.checkingTransactions = new System.Windows.Forms.ListBox();
            this.savingsTransactions = new System.Windows.Forms.ListBox();
            this.checkingTransactionsLabel = new System.Windows.Forms.Label();
            this.savingsTransactionsLabel = new System.Windows.Forms.Label();
            this.recordTransactionsButton = new System.Windows.Forms.Button();
            this.errorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Open Sans", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(52, 54);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(275, 51);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Banking Demo";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.Location = new System.Drawing.Point(75, 162);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(132, 33);
            this.customerLabel.TabIndex = 1;
            this.customerLabel.Text = "Customer";
            // 
            // customerText
            // 
            this.customerText.AutoSize = true;
            this.customerText.Location = new System.Drawing.Point(304, 162);
            this.customerText.Name = "customerText";
            this.customerText.Size = new System.Drawing.Size(100, 33);
            this.customerText.TabIndex = 2;
            this.customerText.Text = "<none>";
            // 
            // checkingBalanceValue
            // 
            this.checkingBalanceValue.AutoSize = true;
            this.checkingBalanceValue.Location = new System.Drawing.Point(304, 230);
            this.checkingBalanceValue.Name = "checkingBalanceValue";
            this.checkingBalanceValue.Size = new System.Drawing.Size(77, 33);
            this.checkingBalanceValue.TabIndex = 4;
            this.checkingBalanceValue.Text = "$0.00";
            // 
            // checkingBalanceLabel
            // 
            this.checkingBalanceLabel.AutoSize = true;
            this.checkingBalanceLabel.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkingBalanceLabel.Location = new System.Drawing.Point(75, 230);
            this.checkingBalanceLabel.Name = "checkingBalanceLabel";
            this.checkingBalanceLabel.Size = new System.Drawing.Size(223, 33);
            this.checkingBalanceLabel.TabIndex = 3;
            this.checkingBalanceLabel.Text = "Checking Balance";
            // 
            // savingsBalanceValue
            // 
            this.savingsBalanceValue.AutoSize = true;
            this.savingsBalanceValue.Location = new System.Drawing.Point(304, 303);
            this.savingsBalanceValue.Name = "savingsBalanceValue";
            this.savingsBalanceValue.Size = new System.Drawing.Size(77, 33);
            this.savingsBalanceValue.TabIndex = 6;
            this.savingsBalanceValue.Text = "$0.00";
            // 
            // savingsBalanceLabel
            // 
            this.savingsBalanceLabel.AutoSize = true;
            this.savingsBalanceLabel.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingsBalanceLabel.Location = new System.Drawing.Point(75, 303);
            this.savingsBalanceLabel.Name = "savingsBalanceLabel";
            this.savingsBalanceLabel.Size = new System.Drawing.Size(204, 33);
            this.savingsBalanceLabel.TabIndex = 5;
            this.savingsBalanceLabel.Text = "Savings Balance";
            // 
            // checkingTransactions
            // 
            this.checkingTransactions.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkingTransactions.FormattingEnabled = true;
            this.checkingTransactions.ItemHeight = 22;
            this.checkingTransactions.Location = new System.Drawing.Point(454, 162);
            this.checkingTransactions.Name = "checkingTransactions";
            this.checkingTransactions.Size = new System.Drawing.Size(312, 356);
            this.checkingTransactions.TabIndex = 7;
            // 
            // savingsTransactions
            // 
            this.savingsTransactions.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingsTransactions.FormattingEnabled = true;
            this.savingsTransactions.ItemHeight = 22;
            this.savingsTransactions.Location = new System.Drawing.Point(793, 162);
            this.savingsTransactions.Name = "savingsTransactions";
            this.savingsTransactions.Size = new System.Drawing.Size(312, 356);
            this.savingsTransactions.TabIndex = 8;
            // 
            // checkingTransactionsLabel
            // 
            this.checkingTransactionsLabel.AutoSize = true;
            this.checkingTransactionsLabel.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkingTransactionsLabel.Location = new System.Drawing.Point(448, 126);
            this.checkingTransactionsLabel.Name = "checkingTransactionsLabel";
            this.checkingTransactionsLabel.Size = new System.Drawing.Size(283, 33);
            this.checkingTransactionsLabel.TabIndex = 9;
            this.checkingTransactionsLabel.Text = "Checking Transactions";
            // 
            // savingsTransactionsLabel
            // 
            this.savingsTransactionsLabel.AutoSize = true;
            this.savingsTransactionsLabel.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingsTransactionsLabel.Location = new System.Drawing.Point(787, 126);
            this.savingsTransactionsLabel.Name = "savingsTransactionsLabel";
            this.savingsTransactionsLabel.Size = new System.Drawing.Size(264, 33);
            this.savingsTransactionsLabel.TabIndex = 10;
            this.savingsTransactionsLabel.Text = "Savings Transactions";
            // 
            // recordTransactionsButton
            // 
            this.recordTransactionsButton.Location = new System.Drawing.Point(120, 373);
            this.recordTransactionsButton.Name = "recordTransactionsButton";
            this.recordTransactionsButton.Size = new System.Drawing.Size(198, 100);
            this.recordTransactionsButton.TabIndex = 11;
            this.recordTransactionsButton.Text = "Record Transactions";
            this.recordTransactionsButton.UseVisualStyleBackColor = true;
            this.recordTransactionsButton.Click += new System.EventHandler(this.recordTransactionsButton_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(448, 68);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(559, 33);
            this.errorMessage.TabIndex = 12;
            this.errorMessage.Text = "You had an overdraft protection transfer of $0.00";
            this.errorMessage.Visible = false;
            this.errorMessage.Click += new System.EventHandler(this.errorMessage_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 555);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.recordTransactionsButton);
            this.Controls.Add(this.savingsTransactionsLabel);
            this.Controls.Add(this.checkingTransactionsLabel);
            this.Controls.Add(this.savingsTransactions);
            this.Controls.Add(this.checkingTransactions);
            this.Controls.Add(this.savingsBalanceValue);
            this.Controls.Add(this.savingsBalanceLabel);
            this.Controls.Add(this.checkingBalanceValue);
            this.Controls.Add(this.checkingBalanceLabel);
            this.Controls.Add(this.customerText);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banking Dashboard - A C# Events Demo by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label customerText;
        private System.Windows.Forms.Label checkingBalanceValue;
        private System.Windows.Forms.Label checkingBalanceLabel;
        private System.Windows.Forms.Label savingsBalanceValue;
        private System.Windows.Forms.Label savingsBalanceLabel;
        private System.Windows.Forms.ListBox checkingTransactions;
        private System.Windows.Forms.ListBox savingsTransactions;
        private System.Windows.Forms.Label checkingTransactionsLabel;
        private System.Windows.Forms.Label savingsTransactionsLabel;
        private System.Windows.Forms.Button recordTransactionsButton;
        private System.Windows.Forms.Label errorMessage;
    }
}

