using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW.MoviesList.Web.Helpers
{
    public static class CommonHelper
    {
        private static string src = "http://image.tmdb.org/t/p/w500";
        public static string GetFullSource(string posterPath)
        {
            return src + posterPath;
        }
    }
}