using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpProjectV3.Controllers
{
    public class HomeController : Controller
    {

        //Basic navigation controllers.  Add a contact controller here later if wanted (also create contact view).

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}