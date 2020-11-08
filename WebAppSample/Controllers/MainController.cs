using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppSample.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            ViewData["main"] = "이것은 메인화면입니다.";
            return View();
        }
    }
}
