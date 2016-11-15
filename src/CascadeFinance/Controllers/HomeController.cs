using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CascadeFinance.Plaid;
using Microsoft.Extensions.Options;
using CascadeFinance.Services;

namespace CascadeFinance.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<SecretOptions> _optionsAccessor;

        public HomeController(IOptions<SecretOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public IActionResult Index()
        {
            string secret = _optionsAccessor.Value.PlaidSecret;
            if (secret == null)
            {
                secret = "test_secret";
            }
            TestPost test = new TestPost();
            test.PostRequest(secret);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
