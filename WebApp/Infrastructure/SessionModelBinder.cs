using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Infrastructure
{
    public class SessionModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        // on rend les données de portée [Session]
        return controllerContext.HttpContext.Session["data"];
        }
    }
}