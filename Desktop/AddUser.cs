using App.Services;
using Infrastructure.Data;
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
    public partial class AddUser : Form
    {
        private readonly UserService _userService;
        public AddUser(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(UserName.Text))
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
                await _userService.AddUser(new Domain.Entities.User
                {
                    UserName = userInput.Text,
                    Password = passwordInput.Text,
                });
            }

            this.Close();
        }
    }
}
