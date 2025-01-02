using System.ComponentModel.DataAnnotations;

namespace FlightService_991690389.Model
{
    public class Flight
    {
        [Key]
        public int flightId { get; set; }
        public string? Destination { get; set; }
        public double Cost { get; set; }
    }
}
