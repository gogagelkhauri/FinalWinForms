using App.Services;
using Desktop.Service;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Main : Form
    {
        //private readonly UserLogin userLogin;
        private readonly UserService _userService;
        private readonly NavigationService _navigationService;
        private readonly LoginContext _loginContext;
        private readonly EditUser _editUser;

        public Main(UserService userService, NavigationService navigationService, LoginContext loginContext, EditUser editUser)
        {
            _userService = userService;
            _navigationService = navigationService;
            InitializeComponent();
            _loginContext = loginContext;
            if (!_loginContext.Roles.Any(x => x.Contains("Admin")))
            {
                CreateUser.Enabled = false;
            }
            _editUser = editUser;
            LoggedInUser.Text = loginContext.UserName;
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            var users = await _userService.GetAllUsers();
            usersDataGrid.DataSource = users;

            // Add the "Edit" button column to the DataGridView
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Name = "EditButtonColumn";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            usersDataGrid.Columns.Add(editButtonColumn);

            // Add the "Delete" button column to the DataGridView
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            usersDataGrid.Columns.Add(deleteButtonColumn);
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            _navigationService.NavigateToAddUser();
            RefreshDataGridView();
            // var adduser = new AddUser();

            //adduser.ShowDialog();
        }

        private async void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "Edit" button column
            if (e.ColumnIndex == usersDataGrid.Columns["EditButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the ID of the corresponding row
                int id = Convert.ToInt32(usersDataGrid.Rows[e.RowIndex].Cells["Id"].Value);
                // Pass the ID to the EditForm
                _editUser.InitializeForm(id);
                _editUser.ShowDialog();
                // After the EditForm is closed, refresh the DataGridView
                RefreshDataGridView();
            }

            if (e.ColumnIndex == usersDataGrid.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
            {
                // Get the selected user from the DataGridView
                int id = Convert.ToInt32(usersDataGrid.Rows[e.RowIndex].Cells["Id"].Value);
                User selectedUser = await _userService.GetById(id);

                // Confirm the deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                    "Confirm Deletion", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Delete the user from the repository
                    await _userService.DeleteUser(selectedUser);

                    // Refresh the DataGridView to reflect the updated user list
                    RefreshDataGridView();
                }
            }
        }

        private async void RefreshDataGridView()
        {
            usersDataGrid.DataSource = null; // Clear the data source
            usersDataGrid.DataSource = await _userService.GetAllUsers(); ; // Rebind the data source
            MoveColumnToLast("EditButtonColumn");
            MoveColumnToLast("DeleteButtonColumn");
        }


        private void LogOut_Click(object sender, EventArgs e)
        {
            _loginContext.Clear();
            _navigationService.NavigateToLogin();
            Close();
        }

        private void MoveColumnToLast(string columnName)
        {
            if (usersDataGrid.Columns.Contains(columnName))
            {
                DataGridViewColumn column = usersDataGrid.Columns[columnName];
                column.DisplayIndex = usersDataGrid.Columns.Count - 1;
            }
        }
    }
}
