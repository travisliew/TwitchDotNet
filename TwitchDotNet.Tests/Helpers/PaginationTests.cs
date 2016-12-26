
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
            // Initialise (limit = 25, offset = 0)
            var pagination = new Pagination();
            var oldLimit = pagination.Limit;
            var oldOffset = pagination.Offset;

            pagination.NextPage(); // Increment page (limit = 25, offset = 25)

            // Assert that NextPage increments offset by limit, leaving limit as-is
            Assert.IsTrue(pagination.Limit == oldLimit && pagination.Offset == oldOffset + oldLimit);
        }
    }
}
