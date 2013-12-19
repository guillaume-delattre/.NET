using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Dynamic;
using WebApp.Models;

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
	}
}