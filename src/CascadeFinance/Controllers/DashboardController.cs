using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CascadeFinance.Data;
using CascadeFinance.Models.Dashboard;

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
                /*var table = _context.Expenses;
                //var model = new ;
                var expense = new Models.Expenses { Name ="test", Value = 100.00m, ExpenseDate =new DateTime( 2010, 1, 18), Tag = "",  WidgetId = 1,  };
                _context.Expenses.Add(expense);

                _context.SaveChanges();

                
                */
            }
            var model = new DrilldownViewModel();

            model.MonthlyIncome = 4000.00;

            return View(model);
            
        }
        public IActionResult VisualAnalytics()


        {

            return View();
        }
    }

}