using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace One_more_time.Models.Form
{
    public class CompareTwoLaptopsForm
    {
        [Required]
        [Display(Name = "Laptop One")]
        public int SelectedValue1 { get; set; }
        [Required]
        [Display(Name = "Laptop Two")]
        public int SelectedValue2 { get; set; }

    }
}
