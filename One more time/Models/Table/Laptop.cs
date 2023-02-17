using System.ComponentModel.DataAnnotations;

namespace One_more_time.Models.Table
{
    public class Laptop
    {
        public string? Model { get; set; } = null!;
        [Key]
        public int Id { get; set; } 
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public float? Price { get; set; } = null!;
        public int? Year { get; set; } = null!;
        public string? Img { get; set; } = null!;
    }
}
