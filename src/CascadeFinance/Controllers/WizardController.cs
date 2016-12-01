using System;
using System.Collections.Generic;
using CascadeFinance.Models.WizardViewModels;
using Microsoft.Extensions.Options;
using CascadeFinance.Services;
using CascadeFinance.Plaid.Request;
using CascadeFinance.Plaid.Response;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CascadeFinance.Data;
using Microsoft.AspNetCore.Identity;
using CascadeFinance.Models;
using System.Threading.Tasks;
using System.Linq;

namespace CascadeFinance.Controllers
{
    public class WizardController : Controller
    {

        private readonly IOptions<SecretOptions> _optionsAccessor;
        private ApplicationDbContext _context;
        private HandleReadDbContext _readContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public WizardController(IOptions<SecretOptions> optionsAccessor, ApplicationDbContext context, HandleReadDbContext readContext, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _readContext = readContext;
            _optionsAccessor = optionsAccessor;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SetBudget()
        {
            string response = HttpContext.Session.GetString("transactions");

            Parser parser = new Parser();
            var model = new WizardViewModel();
            model.transactions = parser.parseTransactions(response);
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
        public async Task<IActionResult> SetBudget(WizardViewModel wizardViewModel, string returnUrl = null)
        {
            var user = GetCurrentUserAsync();

            string response = HttpContext.Session.GetString("transactions");
            Parser parser = new Parser();
            IList<Transaction> transactions = parser.parseTransactions(response);
            transactions.Add(new Transaction("nban4wnPKEtnmEpaKzbYFYQvA7D7pnCaeDBMy", "moPE4dE1yMHJX5pmRzwrdsekxdopLxtEKPREYo",
                843.12, new DateTime(2016, 11, 02, 11, 33, 0), "Advenir at Polos", false, new Dictionary<string, string>(),
                new List<string> { "Rent" }, "2101000"));
            using (var db = _context)
            {
                Widgets incomeWidget = new Widgets { Name = "Income", Priority = 0, Total = (decimal)wizardViewModel.MonthlyIncome, ApplicationUserId = user.Id };
                Widgets housingWidget = new Widgets { Name = "Housing", Priority = wizardViewModel.HousingPriority, Total = (decimal)wizardViewModel.HousingExpenses, ApplicationUserId = user.Id };
                Widgets groceryWidget = new Widgets { Name = "Grocery", Priority = wizardViewModel.GroceryPriority, Total = (decimal)wizardViewModel.GroceryExpenses, ApplicationUserId = user.Id };
                Widgets essentialWidget = new Widgets { Name = "Essentials", Priority = wizardViewModel.EssentialPriority, Total = (decimal)wizardViewModel.EssentialExpenses, ApplicationUserId = user.Id };
                Widgets incomeEarningWidget = new Widgets { Name = "Income Earning", Priority = wizardViewModel.IncomeEarningPriority, Total = (decimal)wizardViewModel.IncomeEarningExpenses, ApplicationUserId = user.Id };
                Widgets healthcareWidget = new Widgets { Name = "Healthcare", Priority = wizardViewModel.HealthcarePriority, Total = (decimal)wizardViewModel.HealthcareExpenses, ApplicationUserId = user.Id };
                Widgets minDebtWidget = new Widgets { Name = "Minimum Debt Payments", Priority = wizardViewModel.MinDebtPriority, Total = (decimal)wizardViewModel.MinDebtExpenses, ApplicationUserId = user.Id };
                Widgets otherWidget = new Widgets { Name = "Other Expenses", Priority = wizardViewModel.OtherPriority, Total = (decimal)wizardViewModel.OtherExpenses, ApplicationUserId = user.Id };

                db.Widgets.Add(incomeWidget);
                db.Widgets.Add(housingWidget);
                db.Widgets.Add(groceryWidget);
                db.Widgets.Add(essentialWidget);
                db.Widgets.Add(incomeEarningWidget);
                db.Widgets.Add(healthcareWidget);
                db.Widgets.Add(minDebtWidget);
                db.Widgets.Add(otherWidget);
                var test = db.SaveChangesAsync();
                test.Wait();
            }
            using (var db = _readContext)
            { 
                var widgets = db.Widgets
                    .Where(b => b.ApplicationUserId == user.Id)
                    .ToList();
                Widgets incomeWidget = widgets.Find(x => x.Name.Contains("Income"));
                Widgets housingWidget = widgets.Find(x => x.Name.Contains("Housing"));
                Widgets groceryWidget = widgets.Find(x => x.Name.Contains("Grocery"));
                Widgets essentialWidget = widgets.Find(x => x.Name.Contains("Essentials"));
                Widgets incomeEarningWidget = widgets.Find(x => x.Name.Contains("Income Earning"));
                Widgets healthcareWidget = widgets.Find(x => x.Name.Contains("Healthcare"));
                Widgets minDebtWidget = widgets.Find(x => x.Name.Contains("Minimum Debt Payments"));
                Widgets otherWidget = widgets.Find(x => x.Name.Contains("Other Expenses"));
                foreach (Transaction transaction in transactions)
                {

                    bool? interest = transaction.category?.Contains("Interest");
                    bool? payroll = transaction.category?.Contains("Payroll");
                    bool? venmo = transaction.category?.Contains("Venmo");
                    if (interest.HasValue && payroll.HasValue && venmo.HasValue && (interest.Value == true || payroll.Value == true
                                                || (venmo.Value == true && @transaction.name.Contains("Cashout"))))
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount *-1,
                            ExpenseDate = transaction.date,
                            Tag = "Income",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }

                    bool? housing = transaction.category?.Contains("Rent");
                    if (housing.HasValue && housing.Value == true)
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount *-1,
                            ExpenseDate = transaction.date,
                            Tag = "Housing",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }

                    bool? food = transaction.category?.Contains("Food and Drink");
                    if (food.HasValue && (food.Value == true))
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount * -1,
                            ExpenseDate = transaction.date,
                            Tag = "Grocery",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }

                    bool? utilities = transaction.category?.Contains("Utilities");
                    if (utilities.HasValue && (utilities.Value == true))
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount * -1,
                            ExpenseDate = transaction.date,
                            Tag = "Essential",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }

                    bool? incomeExpense = transaction.category?.Contains("Computers and Electronics");
                    if (incomeExpense.HasValue && (incomeExpense.Value == true))
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount * -1,
                            ExpenseDate = transaction.date,
                            Tag = "IncomeExpense",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }

                    bool? healthcare = transaction.category?.Contains("Healthcare");
                    if (healthcare.HasValue && (healthcare.Value == true))
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount * -1,
                            ExpenseDate = transaction.date,
                            Tag = "Healthcare",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }

                    bool? debt = transaction.category?.Contains("Debt");
                    if (debt.HasValue && (debt.Value == true))
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount * -1,
                            ExpenseDate = transaction.date,
                            Tag = "Debt",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }

                    bool? venmo5 = transaction.category?.Contains("Venmo");
                    if (transaction.category == null || venmo5.HasValue && (venmo5.Value == true && transaction.name.Contains("Payment")))
                    {
                        db.Expenses.Add(new Expenses
                        {
                            Name = transaction.name,
                            Value = (decimal)transaction.amount * -1,
                            ExpenseDate = transaction.date,
                            Tag = "Other",
                            Widget = housingWidget,
                            WidgetId = housingWidget.WidgetId
                        });
                    }
                }
                db.SaveChanges();
                return RedirectToAction(nameof(DashboardController.Dashboard), "Dashboard");
            }
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
                HttpContext.Session.SetString("transactions", response);
                return (RedirectToAction("SetBudget"));
            }
            return View();
        }

        public IActionResult Submit()
        {
            return View();
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}