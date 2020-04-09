using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Models;

namespace Sol_Demo.Controllers
{
    public class DemoController : Controller
    {
        public DemoController()
        {
            My = new MyModel();
        }

        [BindProperty]
        public MyModel My { get; set; }

        public IActionResult Index()
        {
            My.InputValue = "Input";
            return View(My);
        }

        [HttpPost]
        public IActionResult OnSubmit()
        {
            return View("OnSubmit");
        }
    }
}