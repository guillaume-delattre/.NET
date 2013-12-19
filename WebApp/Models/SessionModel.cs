using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class SessionModel
    {
        public int Counter { get; set; }
        public SessionModel()
        {
            Counter = 0;
        }
    }
}