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
                table.SaveChanges();


            }

            return View();
            
        }
        public IActionResult VisualAnalytics()


        {

            return View();
        }
    }

}