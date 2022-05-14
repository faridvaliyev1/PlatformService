using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _conf;
        public HttpCommandDataClient(HttpClient httpClient,IConfiguration conf)
        {
            _httpClient=httpClient;
            _conf=conf;
        }
        public async Task SendPlatformToCommand(PlatformReadDto platform)
        {
            var httpContent=new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "application/json"
            );

            var response=await _httpClient.PostAsync(_conf["CommandService"],httpContent);

            if (response.IsSuccessStatusCode)
                Console.WriteLine("--> Sync Post to CommandService was okey");
            else
                Console.WriteLine("-->Sync Post to CommandService was not okey");
        }
    }
}