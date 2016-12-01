using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CascadeFinance.Data;
using Microsoft.AspNetCore.Identity;
using CascadeFinance.Models;
using CascadeFinance.Models.Dashboard;

namespace CascadeFinance.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Drilldown()
        {

            using (_context)
            {
                var table = _context.Expenses;

                var model = new DrilldownViewModel();

                model.MonthlyIncome = 4000.10;


                ViewData["MonthlyIncome"] = model.MonthlyIncome;




            }

            return View();
            
        }
        public IActionResult VisualAnalytics()
        {
            /* Gather user data */
            var user = GetCurrentUserAsync();

            /* grab data from db */
            //var widgetsDb = _context.Widgets
                                    //.Where(b => b.ApplicationUserId == user.Id)
                                    //.ToList();

            /* Create feaux data */
            Models.Widgets[] widgets = new Models.Widgets[]
            {
                new Models.Widgets { WidgetId = 0, Name = "Housing", Priority = 1, Total = 100, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 },
                new Models.Widgets { WidgetId = 0, Name = "Food", Priority = 2, Total = 50, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 },
                new Models.Widgets { WidgetId = 0, Name = "Essentials", Priority = 1, Total = 100, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 },
                new Models.Widgets { WidgetId = 0, Name = "Earning", Priority = 2, Total = 50, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 },
                new Models.Widgets { WidgetId = 0, Name = "Health", Priority = 3, Total = 75, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 },
                new Models.Widgets { WidgetId = 0, Name = "Debts", Priority = 3, Total = 75, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 }
            };
            //[858.12, 80, 200, 200, 60, 553, 233.45]
            /* Store data in view-accessible variable (global) !!! */
            ViewData["Data"] = widgets;

            return View();
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }

}