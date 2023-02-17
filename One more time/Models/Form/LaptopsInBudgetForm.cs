using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace One_more_time.Models.Form
{
    public class LaptopsInBudgetForm
    {
        [Required]
        [Display(Name = "Price")]
        public int Number { get; set; }
    }
}
