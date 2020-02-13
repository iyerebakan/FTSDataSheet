using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static void RenderPartialIf(this IHtmlHelper htmlHelper, string partialViewName, bool condition)
        {
            if (!condition)
                return;

            htmlHelper.RenderPartial(partialViewName);
        }

        public static IHtmlContent RouteIf(this IHtmlHelper helper, string value, string attribute)
        {
            var currentController =
                (helper.ViewContext.RouteData.Values["controller"] ?? string.Empty).ToString().UnDash();
            var currentAction =
                (helper.ViewContext.RouteData.Values["action"] ?? string.Empty).ToString().ChangeValue();

            var hasController = value.Equals(currentController, StringComparison.InvariantCultureIgnoreCase);
            var hasAction = value.Equals(currentAction, StringComparison.InvariantCultureIgnoreCase);

            return hasAction || hasController ? new HtmlString(attribute) : new HtmlString(string.Empty);
        }
    }
}
