using Newtonsoft.Json;
using TicketsSearch.Models;
namespace TicketsSearch.Extensions
{
    public static class DeserialiseExtensions
    {
        public static Organization[] Deserialise(this string json)
        {
            return JsonConvert.DeserializeObject<Organization[]>(json);
        }
    }
}
