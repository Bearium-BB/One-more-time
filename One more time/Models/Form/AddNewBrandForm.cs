using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace One_more_time.Models.Form
{
    public class AddNewBrandForm
    {
        [Required]
        [Display(Name = "Name For Brand")]
        public string Name { get; set; }
    }
}
