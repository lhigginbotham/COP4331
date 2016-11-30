using System;
using System.Collections.Generic;
using CascadeFinance.Models.WizardViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CascadeFinance.Services;
using CascadeFinance.Plaid.Request;

namespace CascadeFinance.Controllers
{
    public class WizardController : Controller
    {

        private readonly IOptions<SecretOptions> _optionsAccessor;

        public WizardController(IOptions<SecretOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAccount()
        {
            var model = new BankAccountViewModel();
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAccount(BankAccountViewModel bankAccountViewModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                bool flag = false;
                List<string> multiQuestion = new List<string> { "bbt", "bofa", "capone360", "citi", "pnc", "td", "us", "usaa" };
                foreach (string bank in multiQuestion)
                {
                    if (bank == bankAccountViewModel.Bank)
                    {
                        if (bankAccountViewModel.ChallengeQuestion.Length == 0)
                        {
                            throw new ArgumentNullException();
                        }
                        flag = true;
                    }
                }
                if (flag)
                {
                    PlaidClient pclient = new PlaidClient("5807c43cf5c9c9795f46a65c", _optionsAccessor.Value.PlaidSecret);
                    Credentials cred = new Credentials(bankAccountViewModel.Username, bankAccountViewModel.Password);
                    var response = pclient.requestAllAccountData(cred, bankAccountViewModel.Bank);

                }
            }
            return View();
        }

        public IActionResult Submit()
        {
            return View();
        }
    }
}