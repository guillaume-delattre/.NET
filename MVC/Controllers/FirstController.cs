using System;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class FirstController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Action01()
        {
            ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
            return View();
        }

        public ViewResult Action02()
        {
            return View(new ViewModel());
        }
	}
}