namespace One_more_time.Models.Table
{
    public class Brand
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}
