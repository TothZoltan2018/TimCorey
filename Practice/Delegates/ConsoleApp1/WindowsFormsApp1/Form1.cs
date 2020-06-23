using EmployeeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<EmployeeModel> employees = new List<EmployeeModel>()
            {
                { new EmployeeModel { ID = 1, FirstName = "Zoltan", LastName = "Toth", Age = 43, IsMarried = true, Level = JobLevel.fellow, Location = WorkLocation.Hungary, NumberOfChildren = 2 } },
                { new EmployeeModel { ID = 2, FirstName = "Sarah", LastName = "Connor", Age = 50, IsMarried = false, Level = JobLevel.senior, Location = WorkLocation.US, NumberOfChildren = 0} },
                { new EmployeeModel { ID = 3, FirstName = "Bill", LastName = "Doe", Age = 22, IsMarried = true, Level = JobLevel.junior , Location = WorkLocation.Germany, NumberOfChildren = 1 } },
                { new EmployeeModel { ID = 4, FirstName = "Sue", LastName = "Wood", Age = 33, IsMarried = true, Level = JobLevel.mediore, Location = WorkLocation.Hungary, NumberOfChildren = 5 } },
            };
        HolidayCalculatorModel holidayCalculatorModel = new HolidayCalculatorModel();
        int ID;
        public Form1()
        {
            InitializeComponent();
            holidayCalculatorModel.Employees = employees;
            comboBox1.DataSource = employees;
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "LastName";
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                ID = (int)comboBox1.SelectedValue;
                EmployeeModel SelectedEmployee = (EmployeeModel)comboBox1.SelectedItem;
                int annualHolidays = holidayCalculatorModel.CalculateAnnualHolidaysForEmployeeWithDelegate(calculate, ID);
                //SelectedEmployee.AnnualHolidays = annualHolidays;
                //textBox1.Text = annualHolidays.ToString();

                holidayCalculatorModel.DisplayNumberOfHolidays(FillTheTextBox, ID);
                //holidayCalculatorModel.CalculateAnnualHolidaysForEmployeeWithFunc();
            }
        }

        private void FillTheTextBox(string v)
        {
            textBox1.Text = v + " (Special to WinForm)";
        }

        private int calculate(EmployeeModel e)
        {
            return 20 + e.Age / 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
                holidayCalculatorModel.DisplayNumberOfHolidays(PopUpMessageBox, ID);
            else
                MessageBox.Show("Please select an employee!");
        }

        private void PopUpMessageBox(string v)
        {
            v = v.Replace("holidays per year", "HAPPYDAYS annually");
            MessageBox.Show(v + " (Special to WinForm MessageBox)");
        }

}
}
