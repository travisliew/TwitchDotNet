using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchDotNet.Helpers {

    /// <summary>
    /// Helper class to perform Cursor Pagination with API requests
    /// </summary>
    public class CursorPagination {

        private long _limit = 25;
        private string _cursor = default(string);

        /// <summary>
        /// Limit
        /// </summary>
        public long Limit {
            get { return _limit; }
        }
        /// <summary>
        /// Cursor
        /// </summary>
        public string Cursor {
            get { return _cursor; }
            set { _cursor = value; }
        }
    }
}
