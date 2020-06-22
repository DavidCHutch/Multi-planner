using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi_Planner.DataModel.ViewModels
{
    public class CreateUserViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
    
    public class CreateUserResponseViewModel
    {
        public CreateUserResponseViewModel() { }

        public CreateUserResponseViewModel(User user)
        {
            firstName = user.FirstName;
            lastName = user.LastName;
            email = user.Email;
        }

        public string firstName;
        public string lastName;
        public string email;
    }
}
