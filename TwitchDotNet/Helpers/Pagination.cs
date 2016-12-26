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

        private int _limit = 25;
        private int _offset = 0;

        /// <summary>
        /// Gets the Limit
        /// </summary>
        public int Limit {
            get { return _limit; }
        }

        /// <summary>
        /// Gets the Offset
        /// </summary>
        public int Offset {
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
