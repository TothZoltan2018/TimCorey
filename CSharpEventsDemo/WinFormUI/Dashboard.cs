using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        Customer customer = new Customer();

        public Dashboard()
        {
            InitializeComponent();
                        
            LoadTestingData();

            WireUpForm();
        }

        private void LoadTestingData()
        {
            customer.CustomerName = "Tim Corey";
            customer.CheckingAccount = new Account();
            customer.SavingsAccount = new Account();

            customer.CheckingAccount.AccountName = "Tim's Checking Account";
            customer.SavingsAccount.AccountName = "Tim's Savings Account";

            customer.CheckingAccount.AddDeposit("Initial Balance", 155.43M);
            customer.SavingsAccount.AddDeposit("Initial Balance", 98.45M);
        }

        private void WireUpForm()
        {
            customerText.Text = customer.CustomerName;
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);

            // A bekovetkezo esemenyre felirakozik egy esemenykezelo fgv
            customer.CheckingAccount.TransactionApprovedEvent += CheckingAccount_TransactionApprovedEvent;

            // Enyem
            customer.CheckingAccount.TransactionApprovedEvent += CheckingAccount_TransactionApprovedEvent1;
            customer.SavingsAccount.TransactionApprovedEvent += SavingsAccount_TransactionApprovedEvent;
            customer.CheckingAccount.OverDraftEvent += CheckingAccount_OverDraftEvent;
        }

        private void CheckingAccount_TransactionApprovedEvent1(object sender, string e)
        {
            MessageBox.Show("Zoli's event handler added to the list.");
        }

        //Listener
        private void CheckingAccount_OverDraftEvent(object sender, OverdraftEventArgs e)
        {
            errorMessage.Text = $"You had an overdraft protection transfer of {string.Format("{0:C2}", e.AmountOverdrafted)}";
            e.CancelTransaction = denyOverdraft.Checked;
            errorMessage.Visible = true;
        }

        //Listener: if TransactionApprovedEvent event happened, do this code
        private void SavingsAccount_TransactionApprovedEvent(object sender, string e)
        {
            savingsTransactions.DataSource = null;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;            
            savingsBalanceValue.Text = string.Format("{0:C2}", customer.SavingsAccount.Balance);
        }

        //Listener: if TransactionApprovedEvent event happened, do this code
        private void CheckingAccount_TransactionApprovedEvent(object sender, string e)
        {
            checkingTransactions.DataSource = null;
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            checkingBalanceValue.Text = string.Format("{0:C2}", customer.CheckingAccount.Balance);
        }

        //It's the listener to an event handler
        private void recordTransactionsButton_Click(object sender, EventArgs e)
        {
            Transactions transactions = new Transactions(customer);
            transactions.Show();
        }

        private void errorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }
    }
}
