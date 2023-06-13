using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop
{
    public class LoginContext
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }

        public void set(User user)
        {
            UserName= user.UserName;
            Roles = user.Roles.Select(x => x.Name).ToList();
        }

        public void Clear()
        {
            UserName = null;
            Roles = null;
        }
    }
}
