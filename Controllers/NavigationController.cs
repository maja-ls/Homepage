using Homepage.Helpers;
using Homepage.Models;
using Homepage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAF.Engine.Content.Homepage;
using WAF.Engine.Content.Native;
using WAF.Engine.Property;
using WAF.Engine.Query.Homepage;
using WAF.Presentation.Web;

namespace Homepage.Controllers {
    public class NavigationController : Controller {
        // GET: Navigation
        public ActionResult MainMenu() {
            var cp = PageElements.GetControlPanel();

            List<NavLinkItem> links = new List<NavLinkItem>();
            if (cp.NavbarLinks != null && cp.NavbarLinks.Count > 0) {
                foreach (var containerItem in cp.NavbarLinks.GetAll()) {

                    if (containerItem.LinkItem.IsSet()) {
                        var item = containerItem.LinkItem.Get();
                        var name = !string.IsNullOrWhiteSpace(containerItem.DisplayText) ? containerItem.DisplayText : item.Name;
                        var url = WAFContext.GetUrl(item.NodeId);

                        var linkItem = new NavLinkItem();
                        linkItem.Title = name;
                        linkItem.Link = url;
                        linkItem.FontAwesomeString = containerItem.FontAwesomeClassString;

                        links.Add(linkItem);
                    }
                }
            }

            string logo = "";
            if (cp.SiteLogo.IsImage()) {
                var adjust = new ImageAdjustments();
                if (cp.LogoWidth > 0) adjust.CanvasX = cp.LogoWidth;
                if (cp.LogoHeight > 0) adjust.CanvasY = cp.LogoHeight;

                logo = cp.SiteLogo.GetUrl(adjust);
            }

            var vm = new NavigationViewModel() {
                Links = links,
                Logo = logo
            };


            return View(vm);

        }



        public ActionResult Index() {
            return new EmptyResult();
        }
    }
}