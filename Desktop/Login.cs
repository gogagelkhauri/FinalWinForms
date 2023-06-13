using App.Services;
using Desktop.Service;
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
    public partial class Login : Form
    {
        private readonly UserService _userService;
        private readonly NavigationService _navigationService;
        private readonly LoginContext _loginContext;
        public Login(UserService userService, NavigationService navigationService, LoginContext loginContext)
        {
            _userService = userService;
            _navigationService = navigationService;
            _loginContext = loginContext;
            InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(NameInput.Text))
            {
                string message = "Validation error";
                string title = "Username field is required";
                MessageBox.Show(message, title);
            }

            else if (String.IsNullOrEmpty(PasswordInput.Text))
            {
                string message = "Validation error";
                string title = "Password field is required";
                MessageBox.Show(message, title);
            }
            else
            {
                var user = await _userService.GetUserByName(NameInput.Text);
                if (user != null)
                {
                    if (user.Password == PasswordInput.Text)
                    {
                        _loginContext.set(user);
                        _navigationService.NavigateToMain();
                        Hide();
                        //var home = new Main(userLogin, _userService);
                        //home.Tag = this;
                        //home.Show();
                        //Hide();
                    }
                    else
                    {
                        string message = "Invalid credentials";
                        string title = "Incorrect password";
                        MessageBox.Show(message, title);
                    }

                }
                else
                {
                    string message = "Invalid credentials";
                    string title = "User with that Username not found";
                    MessageBox.Show(message, title);
                }
            }

        }
    }
}
