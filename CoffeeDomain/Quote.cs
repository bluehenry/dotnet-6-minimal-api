namespace CoffeeApp.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Coffee Coffee { get; set; }
        public int CoffeeId { get; set; }
    }
}
