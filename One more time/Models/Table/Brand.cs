using System.Collections.Generic;

namespace One_more_time.Models.Table
{
    public class Brand
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}

