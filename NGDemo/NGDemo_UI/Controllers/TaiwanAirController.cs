using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGDemo_UI.Controllers
{
    public class TaiwanAirController : Controller
    {
        // GET: TaiwanAir
        public ActionResult Index()
        {
            return PartialView();
        }

        // GET: TaiwanAir/View
        public new ActionResult View()
        {
            return PartialView();
        }

    }
}
