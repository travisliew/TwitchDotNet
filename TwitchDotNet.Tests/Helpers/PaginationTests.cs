
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitchDotNet.Helpers;
using Windows.Web.Http;

namespace TwitchDotNet.Tests
{
    [TestClass]
    public class PaginationTests {

        [TestMethod]
        public void ValidPagination()
        {
            var pagination = new Pagination();
            pagination.NextPage(); // Increment page

            // Assert that NextPage increments offset by 25, leaving limit as-is
            Assert.IsTrue(pagination.Limit == 25 && pagination.Offset == 25);
        }
    }
}
