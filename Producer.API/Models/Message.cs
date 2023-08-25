namespace Producer.API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? PassportName { get; set; }
        public string? PassportNumber { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Status { get; set; }
    }
}
