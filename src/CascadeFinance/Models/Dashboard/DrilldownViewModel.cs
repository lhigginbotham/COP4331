using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using CascadeFinance.Plaid.Response;

namespace CascadeFinance.Models.Dashboard
{
    public class DrilldownViewModel
    {
        public Double MonthlyIncome { get; set; }
        public Double RentAndMorgageSpent { get; set; }
        public Double RentAndMorgageAlocated { get; set; }
        public Double FoodAndGrocerySpent { get; set; }
        public Double FoodAndGroceryAlocated { get; set; }
        public Double EssentialItemsSpent { get; set; }
        public Double EssentialItemsAlocated { get; set; }
        public Double IncomeEarningSpent { get; set; }
        public Double IncomeEarningAlocated { get; set; }
        public Double HealthcareSpent { get; set; }
        public Double HealthcareAlocated { get; set; }
        public Double DebtsAndLoansSpent { get; set; }
        public Double DebtsAndLoansAlocated { get; set; }
        public Double OtherExpensesSpent { get; set; }
        public Double OtherExpensesAlocated { get; set; }
        public Double TotalSpent { get; set; }
        public Double TotalLeft { get; set; }
       

           
    }
}
