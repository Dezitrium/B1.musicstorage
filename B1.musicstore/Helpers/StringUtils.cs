using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B1.musicstore.Views.Utils
{
    public static class StringUtils
    {
        public static HtmlString truncate(this string input, int length) 
        {
            if (input.Length <= length) {
                return new HtmlString(input);
            } else {
                return new HtmlString(input.Substring(0, length) + "...");
            }
        }

    }
}