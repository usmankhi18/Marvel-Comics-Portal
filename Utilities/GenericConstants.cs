using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class GenericConstants
    {
        public const string ConnectionStringKey = "MarvelComicsDBCon";
    }

    public struct Status {
        public const int PENDING = 1;
        public const int APPROVED = 2;
        public const int DECLINED = 3;
        public const int CANCELLED = 4;
    }
}
