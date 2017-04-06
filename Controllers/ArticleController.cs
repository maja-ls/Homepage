using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAF.Presentation.Web;
using WAF.Engine.Content.Native;

namespace Homepage.Controllers
{
    public class ArticleController : Controller {
        //
        // GET: /Content/

        public ActionResult Index() {
            return View(WAFContext.Request.GetContent<ArticleBase>());
        }

    }
}
