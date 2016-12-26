
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitchDotNet.Helpers;
using Windows.Web.Http;

namespace TwitchDotNet.Tests
{
    [TestClass]
    public class HttpHelperTests {

        [TestMethod]
        public void ValidQueryString()
        {
            var httpHelper = new HttpHelper("http://www.travisliew.com", "");
            var request = httpHelper.CreateHttpRequest("users/travis", HttpMethod.Get);

            // Add some dummy query string data
            httpHelper.AddQueryString(request, "game", "123");
            httpHelper.AddQueryString(request, "id", "1");
            httpHelper.AddQueryString(request, new Pagination());

            // Assert that AddQueryString creates a valid query string
            string query = "?game=123&id=1&limit=25&offset=0";
            Assert.IsTrue(request.RequestUri.Query.Equals(query));
        }
    }
}
