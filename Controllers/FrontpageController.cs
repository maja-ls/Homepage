using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAF.Engine.Content.Homepage;
using WAF.Engine.Content.Homepage.Site;
using WAF.Presentation.Web;

namespace Homepage.Controllers
{
    public class FrontpageController : Controller
    {
        // GET: Frontpage
        public ActionResult Index()
        {
            return View(WAFContext.Request.GetContent<Frontpage>());
        }
    }
}