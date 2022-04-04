namespace CoffeeApp.Domain
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; } = new List<Quote>();
    }
}