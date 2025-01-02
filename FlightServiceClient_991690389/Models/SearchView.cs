namespace FlightServiceClient_991690389.Models
{
    public class SearchView<T>
    {
        public List<Flight>? flights { get; set; }
        public T? Search { get; set; }
    }
}
