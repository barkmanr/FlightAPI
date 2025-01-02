using FlightServiceClient_991690389.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FlightServiceClient_991690389.Controllers
{
    public class FlightController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7174/api");
        private readonly HttpClient _httpClient;

        public FlightController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public ActionResult Flights()
        {
            List<Flight> flights = new List<Flight>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/FlightAPI/GetFlight").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                flights = JsonConvert.DeserializeObject<List<Flight>>(data);
            }
            return View(flights);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddFlight()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddFlight(Flight f)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string data = JsonConvert.SerializeObject(f);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync(_httpClient.BaseAddress + "/FlightAPI/AddFlight", content).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Flights");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Destination()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Destination(SearchView<string> dest)
        {
            List<Flight> flights = new List<Flight>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/FlightAPI/DestinationFlight/" + dest.Search).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                flights = JsonConvert.DeserializeObject<List<Flight>>(data);
            }
            dest.flights = flights;
            return View(dest);
        }
    }
}
