using System;
using System.Collections.Generic;
using CascadeFinance.Models.WizardViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CascadeFinance.Services;
using CascadeFinance.Plaid.Request;
using CascadeFinance.Plaid.Response;

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

        [HttpGet]
        public IActionResult SetBudget(string message)
        {
            Parser parser = new Parser();
            var model = new WizardViewModel();
            model.transactions = parser.parseTransactions(message);
            model.transactions.Add(new Transaction("nban4wnPKEtnmEpaKzbYFYQvA7D7pnCaeDBMy", "moPE4dE1yMHJX5pmRzwrdsekxdopLxtEKPREYo", 
                843.12, new DateTime(2016, 11, 02, 11, 33, 0), "Advenir at Polos", false, new Dictionary<string, string>(), 
                new List<string> { "Rent" }, "2101000"));
            //Swap income and expenses types for sanity
            foreach (Transaction transaction in model.transactions)
            {
                transaction.amount = transaction.amount * -1d;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SetBudget(WizardViewModel wizardViewModel, string returnUrl = null)
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
                        if (bankAccountViewModel.ChallengeQuestion?.Length == 0)
                        {
                            throw new ArgumentNullException();
                        }
                        flag = true;
                    }
                }

                PlaidClient pclient = new PlaidClient("test_id", "test_secret");
                Credentials cred = new Credentials(bankAccountViewModel.Username, bankAccountViewModel.Password);
                var response = pclient.requestAllAccountData(cred, bankAccountViewModel.Bank);
                Parser parser = new Parser();
                IList<Transaction> transactions = parser.parseTransactions(response);
                
                return (RedirectToAction("SetBudget", new { message = response }));
            }
            return View();
        }

        public IActionResult Submit()
        {
            return View();
        }
    }
}