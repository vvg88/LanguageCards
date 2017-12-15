using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Helpers
{
    public static class JsTimeProvider
    {
        public static long GetJsTimeInMilliseconds()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}
