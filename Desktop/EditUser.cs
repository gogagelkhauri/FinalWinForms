using App.Services;
using Domain.Entities;
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
    public partial class EditUser : Form
    {
        private readonly UserService _userService;
        private User currentUser;
        public EditUser(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        public async void InitializeForm(int id)
        {
            currentUser = await _userService.GetById(id);
            userInput.Text = currentUser.UserName;
            passwordInput.Text = currentUser.Password;
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UserName.Text))
            {
                string message = "Invalid credentials";
                string title = "Username is required";
                MessageBox.Show(message, title);
            }

            if (String.IsNullOrEmpty(Password.Text))
            {
                string message = "Invalid credentials";
                string title = "Password is required";
                MessageBox.Show(message, title);
            }
            else
            {
                currentUser.UserName = userInput.Text;
                currentUser.Password = passwordInput.Text;
                await _userService.UpdateUser(currentUser);
            }

            this.Close();
        }
    }
}
