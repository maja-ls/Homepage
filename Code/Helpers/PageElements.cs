using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAF.Engine.Content.Homepage.Site;
using WAF.Engine.Content.Native;
using WAF.Engine.Property;
using WAF.Engine.Query.Homepage.Site;
using WAF.Presentation.Web;

namespace Homepage.Helpers {
    public class PageElements {

        public static ControlPanel GetControlPanel() {
            var cp = WAFContext.Engine.SystemSession.Query<ControlPanel>()
                .Where(AqlControlPanel.SiteId == WAFContext.Session.SiteId)
                .Execute()
                .FirstOrDefault();

            return cp;
        }

        public static string GetBackgroundImage( HierarchicalContent hc, ControlPanel cp, out string bgPosition ) {
            var adjust = new ImageAdjustments();
            adjust.CanvasX = 1920;
            adjust.CanvasY = 1080;
            adjust.CanvasXMobile = 960;
            adjust.CanvasYMobile = 540;
            adjust.Quality = 80;

            if (hc is PageWithBackground && ((PageWithBackground) hc).Background.IsImage()) {
                var page = (PageWithBackground) hc;
                bgPosition = page.BackgroundPosition.ToString();
                return page.Background.GetUrl(adjust);
            }

            var frontpage = cp.Frontpage.Get();

            if (frontpage.Background.IsImage()) {
                bgPosition = frontpage.BackgroundPosition.ToString();
                return frontpage.Background.GetUrl(adjust);
            }

            bgPosition = "center";
            return null;
        }

        public static string GetBackgroundColor( HierarchicalContent hc, ControlPanel cp ) {
            if (hc is PageWithBackground && !string.IsNullOrWhiteSpace(((PageWithBackground) hc).BackgroundColor)) {
                var page = (PageWithBackground) hc;

                return page.BackgroundColor;
            }

            var fp = cp.Frontpage.Get();

            if (!string.IsNullOrWhiteSpace(fp.BackgroundColor))
                return fp.BackgroundColor;

            return "#000";
        }

        public static string GetNavBgColor( HierarchicalContent hc, ControlPanel cp ) {
            if (hc is PageWithBackground && !string.IsNullOrWhiteSpace(((PageWithBackground) hc).NavigationCssBackgroundColor)) {
                var page = (PageWithBackground) hc;

                return page.NavigationCssBackgroundColor;
            }

            var fp = cp.Frontpage.Get();

            if (!string.IsNullOrWhiteSpace(fp.NavigationCssBackgroundColor))
                return fp.NavigationCssBackgroundColor;

            return "#000";
        }

        public static string GetNavTextColor( HierarchicalContent hc, ControlPanel cp ) {
            if (hc is PageWithBackground && !string.IsNullOrWhiteSpace(((PageWithBackground) hc).NavigationCssColor)) {
                var page = (PageWithBackground) hc;

                return page.NavigationCssColor;
            }

            var fp = cp.Frontpage.Get();

            if (!string.IsNullOrWhiteSpace(fp.NavigationCssColor))
                return fp.NavigationCssColor;

            return "#fff";
        }

        public static string GetLogo() {
            return null;
        }
    }
}