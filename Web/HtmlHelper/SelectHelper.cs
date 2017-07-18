using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class SelectHelper
    {

        public static HtmlString GenerateSelectHtml(this IHtmlHelper _html, List<SelectListItem> model,string name)
        {
            StringBuilder html = new StringBuilder("<select name=\"" + name + "\" id=\"" + name + "\" class=\"form-control input-sm\">");
            foreach (var item in model)
            {
                string selected = item.Selected? "selected" : "";
                html.Append("<option " + selected + " value=\"" + item.Value + "\">");
                html.Append( item.Text);
                html.Append("</option>");
            }
            html.Append("</select>");
            return new HtmlString(html.ToString());
        }

        public static HtmlString RenderPortalContent(this IHtmlHelper htmlHelper, string parameter)
        {
            return new HtmlString(parameter.ToString());
        }
    }
}