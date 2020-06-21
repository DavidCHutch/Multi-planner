using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multi_Planner.DataModel
{
    public class User
    {
        public Guid ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public DateTime LastLogin { get; set; }

        public DateTime DateCreated { get; set; }

        public string FacebookUserID { get; set; }

        public FacebookUserToken FacebookAcessToken { get; set; }

    }}
