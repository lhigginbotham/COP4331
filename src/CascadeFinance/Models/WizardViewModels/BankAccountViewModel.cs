using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Models.WizardViewModels
{
    public class BankAccountViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username;

        [Required]
        [Display(Name = "Password")]
        public string Password;

        [Required]
        [Display(Name = "Bank")]
        public string Bank;

        public List<SelectListItem> Banks { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "bofa", Text = "Bank of America" },
            new SelectListItem { Value = "capone360", Text = "Capital One 360"  },
            new SelectListItem { Value = "chase", Text = "Chase" },
        };

        [Display(Name = "Challange Question")]
        public string ChallangeQuestion;
    }
}
