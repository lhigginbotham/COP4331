using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CascadeFinance.Models.WizardViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CascadeFinance.Controllers
{
    public class WizardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Submit()
        {
            return View();
        }
    }
}