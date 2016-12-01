using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CascadeFinance.Data;

namespace CascadeFinance.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;

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

                var expense = new Models.Expenses { Name ="test", Value = 100.00m, ExpenseDate =new DateTime( 2010, 1, 18), Tag = "food",  WidgetId = 1,  };
                table.Add(expense);
                
                


            }

            return View();
            
        }
        public IActionResult VisualAnalytics()
        {
            /* Create feaux data */
            Models.Widgets[] widgets = new Models.Widgets[]
            {
                new Models.Widgets { WidgetId = 0, Name = "Potatoes", Priority = 1, Total = 100, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 },
                new Models.Widgets { WidgetId = 0, Name = "Tomatoes", Priority = 2, Total = 50, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 },
                new Models.Widgets { WidgetId = 0, Name = "Beans", Priority = 3, Total = 75, ApplicationUser = new Models.ApplicationUser { Widget = null, BankAccount = null }, ApplicationUserId = 0 }
            };

            /* Store data in view-accessible variable (global) !!! */
            ViewData["Data"] = widgets;

            return View();
        }
    }

}