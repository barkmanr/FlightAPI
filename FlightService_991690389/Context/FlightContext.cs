using FlightService_991690389.Model;
using Microsoft.EntityFrameworkCore;

namespace FlightService_991690389.Context
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
    }
}

