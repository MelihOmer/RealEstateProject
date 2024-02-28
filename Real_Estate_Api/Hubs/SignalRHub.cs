using Microsoft.AspNetCore.SignalR;

namespace Real_Estate_Api.Hubs
{
    
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44347/api/Statistics/CategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount",jsonData);
        }
    }
}
