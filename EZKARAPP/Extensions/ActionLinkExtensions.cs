using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EZKARAPP.Extensions
{
    public static class ActionLinkExtensions
    {
        public static MvcHtmlString PreviousLink(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ActionLink("< Back ", null, null, null, new
            {
                href = htmlHelper.ViewContext.HttpContext.Request.UrlReferrer,
                @class = "btn btn-outline-secondary btn-sm"
            });
        }
    }
}