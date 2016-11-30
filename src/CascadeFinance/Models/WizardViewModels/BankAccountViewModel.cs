using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Bank")]
        public string Bank { get; set; }

        [Required]
        public List<SelectListItem> Banks { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "bofa", Text = "Bank of America" },
            new SelectListItem { Value = "capone360", Text = "Capital One 360"  },
            new SelectListItem { Value = "chase", Text = "Chase" },
            new SelectListItem { Value = "wells", Text = "Wells Fargo"},
        };

        [Display(Name = "Challenge Question")]
        public string ChallengeQuestion { get; set; }
    }
}
