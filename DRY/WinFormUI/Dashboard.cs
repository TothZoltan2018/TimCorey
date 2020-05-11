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
        public Dashboard()
        {
            InitializeComponent();
        }

        private void generateEmployeeIdButton_Click(object sender, EventArgs e)
        {
            string employeeId = $@"{ firstNameText.Text.Substring(0, 4) }{ lastNameText.Text.Substring(0, 4) }{ DateTime.Now.Millisecond }";
            employeeIdText.Text = employeeId;
        }
    }
}
