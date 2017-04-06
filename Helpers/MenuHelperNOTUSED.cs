using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using WAF.Presentation.Web;
using WAF.Engine.Query.Native;
using WAF.Engine.Content.Native;

namespace Homepage.Helpers
{
    public static class MenuHelper
    {
        
        public static MvcHtmlString Menu(this HtmlHelper helper)
        {
            StringBuilder html = new StringBuilder();
            HierarchicalContent hc = WAFContext.Session.GetContent<HierarchicalContent>(WAFContext.Session.SiteId);
            BuildMenu(hc, 1, html);

            return MvcHtmlString.Create(html.ToString());
        }

        private static void BuildMenu(HierarchicalContent parent, int level, StringBuilder html)
        {
            foreach (HierarchicalContent child in parent.Children.Query().Where(AqlHierarchicalContent.ShowInMenu == true).Execute())
            {
                bool onSelectedBranch = child.IsParentOrSame(WAFContext.Request.NodeId);
                html.Append("<div class=\"MenuItem");
                html.Append(level);
                if (onSelectedBranch) html.Append(" MenuItemSelected");
                html.Append("\"><a href=\"");
                html.Append(HttpUtility.HtmlAttributeEncode(WAFContext.GetUrl(child.NodeId)));
                html.Append("\">");
                html.Append(HttpUtility.HtmlEncode(child.Name));
                html.Append("</a></div>");
                if (onSelectedBranch) BuildMenu(child, level + 1, html);
            }
        }

    }

}
