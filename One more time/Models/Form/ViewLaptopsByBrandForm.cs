using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace One_more_time.Models.Form
{
    public class ViewLaptopsByBrandForm
    {

        [Required]
        [Display(Name = "Brand")]

        public int Brand { get; set; }
        [Required]
        [Display(Name = "Ordering")]
        public string Ordering{ get; set; }

        [Display(Name = "Price min")]
        public int? NumberMin { get; set; }

        [Display(Name = "Price Max")]
        public int? NumberMax { get; set; }

        [Display(Name = "Year min")]
        public int? YearMin { get; set; } 

        [Display(Name = "Year Max")]
        public int? YearMax { get; set; } 
    }
}
