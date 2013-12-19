using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Dynamic;
using WebApp.Models;
using System.Web;

namespace WebApp.Controllers
{
    public class SecondController : Controller
    {
        //
        // GET: /Second/
        public ActionResult Index()
        {
            return View();
        }

        // /Second/Action01
        public ContentResult Action01()
        {
            return Content("Controller=Second, Action=Action01", "text/plain", Encoding.UTF8);
        }

        // /Second/Action02
        [HttpPost]
        public ContentResult Action02()
        {
            return Content("Controller=Second, Action=Action02", "text/plain", Encoding.UTF8);
        }

        // dynamic path parameters
        public ContentResult Action03()
        {
            string text = string.Format("Controller={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
            return Content(text, "text/plain", Encoding.UTF8);
        }

        // return error message
        private string getErrorMessagesFor(ModelStateDictionary state)
        {
            List<string> errors = new List<string>();
            string messages = string.Empty;
            if (!state.IsValid)
            {
                foreach (ModelState modelState in state.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(getErrorMessageFor(error));
                    }
                }
                foreach (string message in errors)
                {
                    messages += string.Format("[{0}]", message);
                }
            }

            return messages;
        }

        private string getErrorMessageFor(ModelError error)
        {
            if(error.ErrorMessage != null && error.ErrorMessage.Trim() !=string.Empty)
            {
            return error.ErrorMessage;
            }

            if(error.Exception != null && error.Exception.InnerException == null && error.Exception.Message != string.Empty)
            {
                return error.Exception.Message;
            }

            if(error.Exception != null && error.Exception.InnerException != null && error.Exception.InnerException.Message !=string.Empty)
            {
                return error.Exception.InnerException.Message;
            }
        return string.Empty;
        }

        // int GET query parameter
        public ContentResult Action04(int? age)
        {
            string errors = getErrorMessagesFor(ModelState);
            bool valid = ModelState.IsValid;
            string text = string.Format("Controller={0}, Action={1}, age={2}, valid={3}, errors={4}",
                                        RouteData.Values["controller"],
                                        RouteData.Values["action"],
                                        age,
                                        valid,
                                        errors);
            return Content(text, "text/plain", Encoding.UTF8);
        }

        public ContentResult Action05(ActionModel01 model, DateTime? date)
        {
            string errors = getErrorMessagesFor(ModelState);
            string text = string.Format("Controller={0}, Action={1}, weight={2}, age={3}, date={4}, valid={5}, errors={6}",
                                        RouteData.Values["controller"],
                                        RouteData.Values["action"],
                                        model.Weight,
                                        model.Age,
                                        date,
                                        ModelState.IsValid,
                                        errors);
            return Content(text, "text/plain", Encoding.UTF8);
        }

        // string pattern
        public ContentResult Action06(ActionModel02 model)
        {
           string errors = getErrorMessagesFor(ModelState);
           string texte = string.Format("email={0}, jour={1}, info1={2}, info2={3}, info3={4}, errors={5}",
             model.Email, model.Jour, model.Info1, model.Info2, model.Info3, errors);
           return Content(texte, "text/plain", Encoding.UTF8);
        }

        // IValidatableObject
        public ContentResult Action07(ActionModel03 model)
        {
            string errors = getErrorMessagesFor(ModelState);
            string texte = string.Format("taux={0}, errors={1}", model.Taux, errors);
            return Content(texte, "text/plain", Encoding.UTF8);
        }

        // Array of query parameters
        // http://localhost:50982/Second/Action08?data=a&data=b&data=c => data=[a,b,c]
        // Usage in case of multiple choices select
        public ContentResult Action08(string[] data)
        {
            string strData = "";
            if(data != null && data.Length != 0)
            {
                strData = string.Join(",", data);
            }
        string texte = string.Format("data=[{0}]", strData);
        return Content(texte, "text/plain", Encoding.UTF8);
        }

        // version with a List<int>
        public ContentResult Action09(List<int> data)
        {
            string errors = getErrorMessagesFor(ModelState);
            string strData = "";
            if(data != null && data.Count != 0)
            {
                strData = string.Join(",", data);
            }
        string text = string.Format("data=[{0}], errors=[{1}]", strData, errors);
        return Content(text, "text/plain", Encoding.UTF8);
        }

        // Filter query parameters
        public ContentResult Action10(ActionModel04 model)
        {
            string errors = getErrorMessagesFor(ModelState);
            string text = string.Format("valide={0}, info1={1}, info2={2}, errors={3}", 
            ModelState.IsValid, model.Info1, model.Info2, errors);
            return Content(text, "text/plain", Encoding.UTF8);
        }

        // Usage of HTTP context and session
        public ContentResult Action11()
        {
            //HTTP request context
            HttpContextBase context = ControllerContext.HttpContext;
            // infos from Application scope
            string infoApp = context.Application["infoApp"] as string;
            // and infos from Session scope
            int? counter = context.Session["counter"] as int?;
            counter++;
            context.Session["counter"] = counter;
            // client response
            string text = string.Format("infoApp={0}, counter={1}", infoApp, counter);
            return Content(text, "text/plain", Encoding.UTF8);
        }

        // Usage of ApplicationModel and SessionModel
        public ContentResult Action12(ApplicationModel applicationData, SessionModel sessionData)
        {
            // on récupère les infos de portée Application
            string infoApp = applicationData.InfoApp;
            // et celles de portée Session
            int counter = sessionData.Counter++;
            // la réponse au client
            string text = string.Format("infoApp={0}, counter={1}", infoApp, counter);
            return Content(text, "text/plain", Encoding.UTF8);
        }
	}
}