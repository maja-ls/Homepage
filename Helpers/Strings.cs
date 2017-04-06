using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homepage.Helpers
{

    public static class Strings
    {
        public static MvcHtmlString HtmlString(this HtmlHelper helper, string encodedString)
        {
            return MvcHtmlString.Create(encodedString);
        }
    }

}