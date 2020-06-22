using System;
using System.Collections.Generic;
using System.Text;

namespace Multi_Planner.DataModel.ViewModels
{
    public class LoginViewModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class LoginResponseViewModel
    {
        public LoginResponseViewModel() { }

        public LoginResponseViewModel(User user)
        {
            name = user.FullName;
        }

        public string name { get; set; }
    }
}
