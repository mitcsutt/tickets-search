using System.Text.Json;
using TicketsSearch.Models;
namespace TicketsSearch.Extensions
{
    public static class DeserialiseExtensions
    {
        public static Organization[] Deserialise(this string json)
        {
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            return JsonSerializer.Deserialize<Organization[]>(json, options);
        }
    }
}
