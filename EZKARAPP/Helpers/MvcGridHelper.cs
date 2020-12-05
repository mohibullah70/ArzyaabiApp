using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZKARAPP.Helpers
{
    public static class MvcGridHelper
    {
        public static Dictionary<int, string> PageSizes
        {
            get
            {
                return new Dictionary<int, string> { { 0, "ALL" }, { 5, "5" }, { 10, "10" }, { 25, "25" }, { 50, "50" }, { 100, "100" }, { 250, "250" }, { 500, "500" }, { 1000, "1000" } };
            }
        }
    }
}