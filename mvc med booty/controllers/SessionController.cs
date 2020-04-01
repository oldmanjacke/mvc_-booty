using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mvc_med_booty.controllers
{
    public class SessionController : Controller
    {
        public IActionResult LookAt()
        {
            ViewBag.Msg = HttpContext.Session.GetString("KeyName");
            return View();
        }
        public IActionResult SaveSession(string message)
        {
            HttpContext.Session.SetString("KeyName", message);
            return RedirectToAction("LookAt");
        }
    }
}