using System.ComponentModel.DataAnnotations;

namespace One_more_time.Models.Table
{
    public class Laptop
    {
        public string Model { get; set; }
        [Key]
        public int Id { get; set; }
        public int BrandId { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public string Img { get; set; }
    }
}
