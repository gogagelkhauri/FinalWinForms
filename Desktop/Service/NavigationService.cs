using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Service
{
    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private Form _activeForm;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateToMain()
        {
            HideActiveForm();

            var main = _serviceProvider.GetRequiredService<Main>();
            _activeForm = main;
            main.Show();
        }

        public void NavigateToLogin()
        {
            var login = _serviceProvider.GetRequiredService<Login>();
            _activeForm = login;
            login.Show();
        }

        public void NavigateToAddUser()
        {
            var addUser = _serviceProvider.GetRequiredService<AddUser>();
            //_activeForm = addUser;
            addUser.ShowDialog();
        }

        private void HideActiveForm()
        {
            _activeForm?.Hide();
        }
    }
}
