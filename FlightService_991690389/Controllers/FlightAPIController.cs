using FlightService_991690389.Context;
using FlightService_991690389.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightService_991690389.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlightAPIController : ControllerBase
    {
        private FlightContext Context;

        public FlightAPIController(FlightContext context) 
        {
            Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlight()
        {
            var flights = await Context.Flights.ToListAsync();
            var list = new List<FlightDTO>();
            foreach (var f in flights)
            {
                list.Add(new FlightDTO()
                {
                    Destination = f.Destination,
                    Cost = f.Cost
                });
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight(Flight F)
        {
            await Context.Flights.AddAsync(F);
            await Context.SaveChangesAsync();
            var flights = await Context.Flights.ToListAsync();
            return Ok(flights);
        }

        [HttpGet("{dest}")]
        public async Task<IActionResult> DestinationFlight(string dest)
        {
            var flights = await Context.Flights.Where(f => f.Destination == dest).ToListAsync();
            var list = new List<FlightDTO>();
            foreach (var f in flights)
            {
                list.Add(new FlightDTO()
                {
                    Destination = f.Destination,
                    Cost = f.Cost
                });
            }
            return Ok(list);
        }
    }
}
