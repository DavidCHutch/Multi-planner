using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Multi_Planner.DataModel;
using Multi_Planner.Services.Interfaces;
using System.Net.Http;

namespace Multi_Planner.Services.Services
{
    public class FacebookService : IFacebookService
    {
        //TODO Secure this so it isnt hardcoded.
        private readonly string APP_ID = "3269841343029131";

        //TODO Make this better, eg not hardcoded
        private readonly string STATE_TOKEN = "0910";

        private readonly HttpClient httpClient;

        public FacebookService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<ServiceResponse<Uri>> GetLoginUrl(Uri redirectUri)
        {
            //https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow/
            string facebookDialogPath = "https://www.facebook.com/v7.0/dialog/oauth";

            var dialogUrl = new UriBuilder(facebookDialogPath);

            string idParam = @"client_id=" + APP_ID;
            string redirectParam = @"redirect_uri=" + redirectUri;
            string stateParam = @"state=" + STATE_TOKEN;

            dialogUrl.Query = $"{idParam}&{redirectParam}&{stateParam}";

            return new ServiceResponse<Uri>(ServiceResponseStatus.Ok, dialogUrl.Uri);
        }

        public async Task<ServiceResponse<bool>> GetAccessToken(string code, Uri redirectUri)
        {
            //TODO !! Do NOT have this hardcoded, use environment variables. !!
            string SECRET = "b5d125998c783165f4211dbe6688c580";

            //TODO: save the code, if we dont we will have to ask the user again when the token expires.

            //https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow/
            string facebookExchangePath = "https://graph.facebook.com/v7.0/oauth/access_token";

            var exchangeUrl = new UriBuilder(facebookExchangePath);

            string idParam = @"client_id=" + APP_ID;
            string redirectParam = @"redirect_uri=" + redirectUri;
            string secretParam = @"client_secret=" + SECRET;
            string codeParam = @"code=" + code;

            exchangeUrl.Query = $"{idParam}&{redirectParam}&{secretParam}&{codeParam}";

            var response = await httpClient.GetAsync(exchangeUrl.Uri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                throw new NotImplementedException();
            }
            else
            {
                return new ServiceResponse<bool>(ServiceResponseStatus.Error);
            }

        }

        public async Task<ServiceResponse<bool>> SaveToken(FacebookAccessToken token)
        {
            throw new NotImplementedException();
        }
    }
}
