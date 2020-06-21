using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi_Planner.DataModel.ViewModels
{
    public class CreateUserViewModel
    {
        public string firstName;
        public string lastName;
        public string password;
        public string email;
    }
    
    public class CreateUserResponseViewModel
    {
        public string firstName;
        public string lastName;
        public string email;
    }
}
