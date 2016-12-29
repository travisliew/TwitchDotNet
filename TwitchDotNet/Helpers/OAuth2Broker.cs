using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Security.Authentication.Web;
using Windows.UI.Core;

namespace TwitchDotNet.Helpers {

    /// <summary>
    /// Broker for OAuth2 authentication
    /// </summary>
    public static class OAuth2Broker {
        
        /// <summary>
        /// Authenticate against OAuth2 using WebAuthenticationBroker for a valid access token
        /// </summary>
        /// <param name="_baseUrl">Base Twitch API Url</param>
        /// <param name="_clientId">Client Id</param>
        /// <param name="_redirectUri">Authentication Redirect Uri</param>
        /// <param name="_scopes">Authentication Scopes</param>
        /// <returns>An access token to use with API requests</returns>
        public static async Task<string> Authenticate(string _baseUrl, string _clientId, string _redirectUri, string _scopes) {
            // Create request (use httpHelper to build query string)
            var httpHelper = new HttpHelper(_baseUrl, _clientId);
            var request = httpHelper.CreateHttpRequest("kraken/oauth2/authenticate", HttpMethod.Get);
            httpHelper.AddQueryString(request, "client_id", _clientId); // Add client_id manually so it is part of the query string (required for WAB startUri below)
            httpHelper.AddQueryString(request, "action", "authorize");
            httpHelper.AddQueryString(request, "response_type", "token");
            httpHelper.AddQueryString(request, "redirect_uri", _redirectUri);
            httpHelper.AddQueryString(request, "scope", _scopes);
            //httpHelper.AddQueryString(request, "state", ""); // TODO?

            // Now use request.Uri to authenticate with WebAuthenticationBroker (OAuth2 for UWP applications)
            try {
                // Define where the WebAuthenticationBroker should start and end
                var startUri = request.RequestUri;
                var endUri = new Uri(_redirectUri);

                // Begin authorization process
                WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);
                if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success) {
                    // Success, so extract access token from result
                    string fragment = WebAuthenticationResult.ResponseData;

                    // Exit if user denies access (response was a twitch-cancel button (i.e. html user cancel))
                    // ?error=<error>&error_description=<description>
                    Match match = Regex.Match(fragment, "error=(?<reason>.*)&error_description");
                    string errorString = match.Groups["reason"].Value;
                    if (errorString.Equals("access_denied")) {
                        throw new Exception("Access denied");
                    }

                    // Attempt to retrieve access token (successfully logged in)
                    // #access_token=<token>
                    match = Regex.Match(fragment, "#access_token=(?<token>.*)&scope=");
                    string oauth_token = match.Groups["token"].Value;

                    // Return oauth_token
                    if (!string.IsNullOrEmpty(oauth_token)) {
                        return oauth_token;
                    } else {
                        throw new Exception("Returned OAuth Token was empty. Are you passing in the correct Client_Id?");
                    }
                } else if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.ErrorHttp) {
                    throw new Exception(WebAuthenticationResult.ResponseErrorDetail.ToString());
                } else if (WebAuthenticationResult.ResponseStatus != WebAuthenticationStatus.UserCancel) {
                    // Show error if not user cancel
                    throw new Exception(WebAuthenticationResult.ResponseStatus.ToString());
                }
            } catch (Exception ex) {
                Debug.WriteLine($"An error occurred while authenticating.\n\n{ex.ToString()}");
            }
            return string.Empty;
        }
    }
}
