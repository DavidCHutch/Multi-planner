using System;
using System.Collections.Generic;
using System.Text;

namespace Multi_Planner.DataModel
{
    public class FacebookAccessToken
    {
        string access_token;
        string expires_in;

        public TimeSpan GetTimeTillExpiration { get { throw new NotImplementedException(); /*TODO Implement*/ } }
    }
}
