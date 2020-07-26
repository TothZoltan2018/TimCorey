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
    /// <summary>
    /// 1. I installed SQLLiteBrowser in WIndows and created an DemoDB Database and 
    /// an empty Person DB Table under path of our WinFormUI directory.
    /// 2. In the FileExplorer I included the DemoDB.db into the project.
    /// 3. Right click on DemoDB.db --> Properties --> Build Action: Content, 
    /// Copy to Output directory: Copy if newer (copy it to the bin directory if we change this file)
    /// 4. In the App.config fill out the connectionString.
    /// 5. Install nuget packages for DemoLibrary: System.Data.SQLite.Core and Dapper
    /// 6. Install System.Data.SQLite.Core nuget package for WinFormUI, too. 
    /// 7. Right click on DemoLibrary's References --> Add new Reference in Assemblies: System.Configuration of the WinFormUI. 
    /// This allows to talk to App.config. We also need to add: 'using System.Configuration;' in SqliteDataAccess.cs
    /// 8. We nned to add 'using System.Data;' in SqliteDataAccess.cs, 'using System.Data.SQLite;', 'using Dapper;'
    /// 
    /// </summary>
    public partial class PeopleForm : Form
    {
        List<PersonModel> people = new List<PersonModel>();

        public PeopleForm()
        {
            InitializeComponent();

            LoadPeopleList();
        }

        private void LoadPeopleList()
        {            
            people = SqliteDataAccess.LoadPeople();

            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            listPeopleListBox.DataSource = null;
            listPeopleListBox.DataSource = people;
            listPeopleListBox.DisplayMember = "FullName";
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            PersonModel p = new PersonModel();

            p.FirstName = firstNameText.Text;
            p.LastName = lastNameText.Text;

            // TODO - do something with this item
            SqliteDataAccess.SavePerson(p);
            LoadPeopleList();

            firstNameText.Text = "";
            lastNameText.Text = "";
        }
    }
}
