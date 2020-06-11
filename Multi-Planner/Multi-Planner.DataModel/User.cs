using System;
using System.Collections.Generic;
using System.Text;

namespace Multi_Planner.DataModel
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime LastLogin { get; set; }

        public string FacebookUserID { get; set; }
        public FacebookUserToken FacebookAcessToken { get; set; }
    }
}
