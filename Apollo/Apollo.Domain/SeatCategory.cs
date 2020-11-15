namespace Apollo.Domain
{
    public class SeatCategory
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public SeatCategory(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
