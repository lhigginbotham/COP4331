using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CascadeFinance.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Drilldown()
        {

            return View();
        }
        public IActionResult VisualAnalytics()
        {
            return View();
        }
    }

}