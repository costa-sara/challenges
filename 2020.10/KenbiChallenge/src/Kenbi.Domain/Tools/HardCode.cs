using System.Collections.Generic;

namespace Kenbi.Domain.Tools
{
    public static class HardCode
    {
        public static class Errors
        {
            public static class Standard
            {
                public static KeyValuePair<int, string> InvalidObject => new KeyValuePair<int, string>(400, "Invalid object");
            }
        }
    }
}
