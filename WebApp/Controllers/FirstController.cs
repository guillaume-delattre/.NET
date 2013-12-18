using System.Text;
using System.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp.Controllers
{
    public class FirstController : Controller
    {
        //
        // GET: /First/Index
        public ViewResult Index()
        {
            return View();
        }

        // First/Action01 : raw text
        public ContentResult Action01()
        {
            return Content("<h1>Action [Action01]</h1>", "text/plain", Encoding.UTF8);
        }

        // First/Action02 : XML
        public ContentResult Action02()
        {
            string data = "<action><name>Action02</name><description>renvoie un texte XML</description></action>";
            return Content(data, "text/xml", Encoding.UTF8);
        }

        // First/Action03 : JSON
        public JsonResult Action03()
        {
            dynamic person = new ExpandoObject();
            person.name = "someOne";
            person.age = 20;
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        // Redirection
        public RedirectResult Action04()
        {
            return new RedirectResult("/First/Action01");
        }

        // Redirection with usage of Routes
        public RedirectToRouteResult Action05()
        {
            return new RedirectToRouteResult("Default", new RouteValueDictionary(new{ controller = "First", action = "Action01" }));
        }

        // return void
        public void Action06()
        {
            string name = Request.QueryString["name"] ?? "Unknown";
            Response.AddHeader("Content-Type", "text/plain");
            Response.Write(string.Format("<h3>Action 06</h3>name={0}", name));
        }
	}
}