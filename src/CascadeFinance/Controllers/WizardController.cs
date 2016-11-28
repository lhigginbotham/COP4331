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

        public IActionResult AddAccount()
        {
            var model = new BankAccountViewModel();
            return View(model);
        }

        public IActionResult Submit()
        {
            return View();
        }
    }
}