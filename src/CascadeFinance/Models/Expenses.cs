using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Models
{
    public class Expenses
    {
        [Key]
        public int ExpensesId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public string Tag { get; set; }

        //Foreign Key
        public int WidgetId { get; set; }

        public Widgets Widget { get; set; }
    }
}
