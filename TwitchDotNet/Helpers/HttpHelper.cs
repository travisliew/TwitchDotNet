using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;

namespace TwitchDotNet.Helpers {

    /// <summary>
    /// Helper class to perform Http REST Requests
    /// 26/12/2016 - RestSharp doesn't support UWP, hence creating my own (basic) helper class
    /// </summary>
    public class HttpHelper {

        private readonly string baseUrl;
        private readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Initialise httpClient
        /// </summary>
        /// <param name="_baseUrl">Base Url for all Http requests</param>
        /// <param name="_clientId">Client Id Header</param>
        public HttpHelper(string _baseUrl, string _clientId) {
            this.baseUrl = _baseUrl;

            // Attach default headers to Request
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.twitchtv.v5+json");
            httpClient.DefaultRequestHeaders.Add("Client-ID", _clientId);
        }

        /// <summary>
        /// Create a HttpRequest
        /// </summary>
        /// <param name="_url">HttpRequest url (+baseUrl)</param>
        /// <param name="_requestType">HttpRequest type <see cref="HttpMethod"/></param>
        /// <returns>A HttpRequest</returns>
        public HttpRequestMessage CreateHttpRequest(string _url, HttpMethod _requestType) {
            return new HttpRequestMessage(_requestType, new Uri($"{this.baseUrl}/{_url}"));
        }

        /// <summary>
        /// Send a HttpRequestMessage
        /// </summary>
        /// <param name="_request">HttpRequestMessage to send</param>
        /// <param name="_successCodes">HttpStatusCodes that indicate success</param>
        /// <returns>Object representing returned content</returns>
        public async Task<dynamic> ExecuteRequest(HttpRequestMessage _request, HttpStatusCode _successCodes = HttpStatusCode.OK) {
            var response = await httpClient.SendAsync(_request).ConfigureAwait(false);
            try {
                // Ensure successful response (indicated by _successCodes)
                 if ((_successCodes & response.StatusCode) == response.StatusCode) {
                    // Read response content as byte array and decode as UTF-8
                    var response_buffer = await response.Content.ReadAsByteArrayAsync();
                    var response_string = Encoding.UTF8.GetString(response_buffer, 0, response_buffer.Length);
                    return JsonConvert.DeserializeObject(response_string) ?? string.Empty; // Return empty string if get here, as it was expected (see: _successCodes)
                } else {
                    throw new Exception($"HttpRequest did not indicate success. Error Code: {response.StatusCode}");
                }
            } catch (Exception ex) {
                Debug.WriteLine($"An error occurred while sending off a HttpRequest.\n\n{ex.ToString()}");
            }
            return null;
        }

        /// <summary>
        /// Add header to HttpClient
        /// </summary>
        /// <param name="_key">Header Key</param>
        /// <param name="_value">Header Value</param>
        public void AddHttpClientHeader(string _key, string _value) {
            // Only add header if _value is not empty
            if (!string.IsNullOrEmpty(_value)) {
                httpClient.DefaultRequestHeaders.Add(_key, _value);
            }
        }

        /// <summary>
        /// Add Query String to a Http Request.
        /// </summary>
        /// <param name="_request">The HttpRequest</param>
        /// <param name="_key">Query String Key</param>
        /// <param name="_value">Query String Value</param>
        public void AddQueryString(HttpRequestMessage _request, string _key, string _value) {

            // Only add query string if _value is not empty
            if (!string.IsNullOrEmpty(_value)) {
                UriBuilder uriBuilder = new UriBuilder(_request.RequestUri);

                // URI Escape _value
                string _escapedValue = Uri.EscapeDataString(_value);

                // Build query string
                if (uriBuilder.Query != null && uriBuilder.Query.Length > 1) { // Append to existing query string
                    uriBuilder.Query = $"{uriBuilder.Query.Substring(1)}&{_key}={_escapedValue}"; // ..?..&key=value
                } else { // New query string
                    uriBuilder.Query = $"{_key}={_escapedValue}";
                }

                // Assign Uri to original request
                _request.RequestUri = uriBuilder.Uri;
            }
        }

        /// <summary>
        /// Adds pagination info as query string to a Http Request
        /// </summary>
        /// <param name="_request">The HttpRequest</param>
        /// <param name="_pagination">Pagination info</param>
        public void AddQueryString(HttpRequestMessage _request, Pagination _pagination) {
            this.AddQueryString(_request, "limit", _pagination.Limit.ToString());
            this.AddQueryString(_request, "offset", _pagination.Offset.ToString());
        }

        /// <summary>
        /// Adds cursor pagination info as query string to a Http Request
        /// </summary>
        /// <param name="_request">The HttpRequest</param>
        /// <param name="_pagination">Pagination info</param>
        public void AddQueryString(HttpRequestMessage _request, CursorPagination _pagination) {
            this.AddQueryString(_request, "limit", _pagination.Limit.ToString());
            this.AddQueryString(_request, "cursor", _pagination.Cursor);
        }
    }
}
