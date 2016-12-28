using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDotNet.Helpers {

    /// <summary>
    /// Helper class to perform Pagination with API requests
    /// </summary>
    public class Pagination {

        private long _limit = 25;
        private long _offset = 0;

        /// <summary>
        /// Limit
        /// </summary>
        public long Limit {
            get { return _limit; }
        }

        /// <summary>
        /// Offset
        /// </summary>
        public long Offset {
            get { return _offset; }
            set { _offset = value; }
        }

        /// <summary>
        /// Increments the offset by limit value to provide next page Pagination info
        /// </summary>
        public void NextPage() {
            this.Offset += this.Limit;
        }
    }
}
