using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Models.AccountViewModels
{
    public class EditPrioritizationViewModel
    {
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

    }
}
