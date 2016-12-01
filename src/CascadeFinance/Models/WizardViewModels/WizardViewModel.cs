using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using CascadeFinance.Plaid.Response;

namespace CascadeFinance.Models.WizardViewModels
{
    public class WizardViewModel
    {
        [Required]
        [Display(Name = "Monthly Income")]
        public double MonthlyIncome { get; set; }

        [Required]
        [Display(Name = "Housing Expenses")]
        public double HousingExpenses { get; set; }

        [Required]
        [Display(Name = "Grocery Expenses")]
        public double GroceryExpenses { get; set; }

        [Required]
        [Display(Name = "Essential Expenses")]
        public double EssentialExpenses { get; set; }

        [Required]
        [Display(Name = "Income Earning Expenses")]
        public double IncomeEarningExpenses { get; set; }

        [Required]
        [Display(Name = "Healthcare Expenses")]
        public double HealthcareExpenses { get; set; }

        [Required]
        [Display(Name = "Minimum Debt Payments")]
        public double MinDebtExpenses { get; set; }

        [Required]
        [Display(Name = "Other Expenses")]
        public double OtherExpenses { get; set; }

        [Required]
        [Display(Name = "Total Budget")]
        public double TotalExpenses { get; set; }

        [Required]
        [Display(Name = "Housing Priority")]
        public int HousingPriority { get; set; }

        [Required]
        [Display(Name = "Grocery Priority")]
        public int GroceryPriority { get; set; }

        [Required]
        [Display(Name = "Essential Priority")]
        public int EssentialPriority { get; set; }

        [Required]
        [Display(Name = "Income Earning Priority")]
        public int IncomeEarningPriority { get; set; }

        [Required]
        [Display(Name = "Healthcare Priority")]
        public int HealthcarePriority { get; set; }

        [Required]
        [Display(Name = "Minimum Debt Priority")]
        public int MinDebtPriority { get; set; }

        [Required]
        [Display(Name = "Other Priority")]
        public int OtherPriority { get; set; }

        public IList<Transaction> transactions { get; set; }
    }
}