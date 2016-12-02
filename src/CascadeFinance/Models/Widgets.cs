using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Models
{
    public class Widgets
    {
        [Key]
        public int WidgetId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public decimal Total { get; set; }

        //Foreign Key
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public List<Expenses> Expenses { get; set; }

        public static implicit operator List<object>(Widgets v)
        {
            throw new NotImplementedException();
        }
    }
}
