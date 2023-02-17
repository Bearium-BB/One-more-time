using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace One_more_time.Models.Form
{
    public class AddNewLaptopForm
    {
        [Required]
        [Display(Name = "Name For Laptop")]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Price")]
        public string Number { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Img")]
        public string ImgURL { get; set; }
    }
}
