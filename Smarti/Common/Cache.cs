using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Smarti.Models;
using static Smarti.Models.JsonModel;

namespace Smarti.Common
{
    public class Cache
    {
        private  readonly IMemoryCache _cache;

        public Cache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public  ResponseMessage<JsonData> GetPriorities()
        {
            if (_cache.TryGetValue("Priorities", out JsonData cachedData))
            {
                return new ResponseMessage<JsonData>(true, "success", cachedData);
            }

            string jsonFilePath = "Priorities.json";
            string relativePath = Path.Combine(Directory.GetCurrentDirectory(), jsonFilePath);

            if (File.Exists(relativePath))
            {
                try
                {
                    // Read the entire contents of the JSON file
                    string jsonContents = File.ReadAllText(jsonFilePath);

                    // Deserialize the JSON into an object
                    JsonData jsonObject = JsonConvert.DeserializeObject<JsonData>(jsonContents);
                    _cache.Set("Priorities", jsonObject, TimeSpan.FromMinutes(10)); 

                    return new ResponseMessage<JsonData>(true, "succses", jsonObject);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading JSON file: {ex.Message}");
                }
            }

            return new ResponseMessage<JsonData>(false, "JSON file does not exist", null);
        }
    }
}
