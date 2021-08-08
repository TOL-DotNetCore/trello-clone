using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace todoist_red_gate.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrelloAuthenticationController : ControllerBase
    {
        private const string RequestUrl = "https://trello.com/1/OAuthGetRequestToken";
        private const string RequestAccessTokenUrl = "https://trello.com/1/OAuthGetAccessToken";

        private const string ConsumerKey = "07e57a8c0ff7205b8202479a1d9ed50d";
        private const string ConsumerSecret = "1be445cdc1c935e7639a29314f3e17eee5c915ac4e1458f44ffd32dcc7ab248b";
        private static string TokenSecret { get; set; }

        [HttpGet]
        public IActionResult Login()
        {
            var client = new OAuthRequest
            {
                Method = "GET",
                Type = OAuthRequestType.RequestToken,
                SignatureMethod = OAuth.OAuthSignatureMethod.HmacSha1,
                ConsumerKey = ConsumerKey,
                ConsumerSecret = ConsumerSecret,
                RequestUrl = RequestUrl,
                CallbackUrl = "https://localhost:44395/api/trelloauthentication/callback"
            };

            var url = client.RequestUrl + "?" + client.GetAuthorizationQuery();
            var request = (HttpWebRequest)WebRequest.Create(url);  
            var response = (HttpWebResponse)request.GetResponse();

            using var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();

            // Parse login_url and oauth_token_secret from response
            var OauthToken = HttpUtility.ParseQueryString(responseFromServer).Get("oauth_token");
            TokenSecret = HttpUtility.ParseQueryString(responseFromServer).Get("oauth_token_secret");

            return Redirect("https://trello.com/1/OAuthAuthorizeToken?oauth_token=" + OauthToken);
        }

        public static string OAuthToken { get; set; }
        public static string OAuthTokenSecret { get; set; }
        [HttpGet]
        public IActionResult Callback()
        {
            // Read token and verifier
            string token = Request.Query["oauth_token"];
            string verifier = Request.Query["oauth_verifier"];

            // Create access token request
            var client = new OAuthRequest
            {
                Method = "GET",
                Type = OAuthRequestType.RequestToken,
                SignatureMethod = OAuth.OAuthSignatureMethod.HmacSha1,
                ConsumerKey = ConsumerKey,
                ConsumerSecret = ConsumerSecret,
                Token = token,
                TokenSecret = TokenSecret,
                RequestUrl = RequestAccessTokenUrl,
                Verifier = verifier
            };

            // Build request url and send the request
            var url = client.RequestUrl + "?" + client.GetAuthorizationQuery();
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();

            // Parse and save access token and secret
            OAuthToken = HttpUtility.ParseQueryString(responseFromServer).Get("oauth_token");
            OAuthTokenSecret = HttpUtility.ParseQueryString(responseFromServer).Get("oauth_token_secret");

            return Ok("Login success!");
        }
    }
}
