
using System.Xml.Linq;

namespace LokApp.Entities
{
    public class TrainWithName : Train
    {
        public string? Name { get; set; }
        public override string ToString() => base.ToString() + $"Name: {Name}";
    }
}

