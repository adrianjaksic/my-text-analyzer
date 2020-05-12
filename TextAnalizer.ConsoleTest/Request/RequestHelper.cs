using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace TextAnalizer.ConsoleTest.Request
{
    public static class RequestHelper
    {
        public static R Post<T, R>(string url, T request)
        {
            using (var client = new HttpClient())
            {
                var json = JsonSerializer.Serialize(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, data).Result;
                string result = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<R>(result);
            }
        }
    }
}
