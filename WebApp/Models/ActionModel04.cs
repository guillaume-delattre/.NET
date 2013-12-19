using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApp.Models
{
    [Bind(Exclude = "Info2")]
    public class ActionModel04
    {
        [Required(ErrorMessage = "Le paramètre [info1] est requis")]
        public string Info1 { get; set; }

        public string Info2 { get; set; }
    }
}