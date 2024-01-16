
namespace LokApp.Entities
{
    public class Train : IEntity
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string? Platform { get; set; }
        public string? Track { get; set; }
        public override string ToString() => $"Id: {Id}, Number: {Number}, Arrival Time: {ArrivalTime?.ToString("HH:mm")}, From: {From}, To: {To}, Departure Time: {DepartureTime?.ToString("HH:mm")}, Platform: {Platform}, Track: {Track} ";        
    }
}