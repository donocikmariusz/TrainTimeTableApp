
namespace LokApp.Entities
{
    public class Train : EntityBase
    {
        public int? Number { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public override string ToString() => $"Id: {Id}, Number: {Number}, From: {From}, To: {To}";        
    }
}