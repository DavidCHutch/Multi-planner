using System;
using System.Collections.Generic;
using System.Text;

namespace Multi_Planner.DataModel
{
    public class FacebookAccessToken
    {
        public FacebookAccessToken(string _accessToken, int _expiresIn)
        {
            accessToken = _accessToken;
            expiresIn = _expiresIn;
            timeCreated = DateTime.UtcNow;
        }

        string accessToken;
        int expiresIn;
        DateTime timeCreated;
        
        /// <summary>
        /// Checks if the token is expired. Imprecise up to a few seconds.
        /// </summary>
        public bool IsExpired { get { return timeCreated.AddSeconds((double)expiresIn) > DateTime.UtcNow; } }
    }
}
