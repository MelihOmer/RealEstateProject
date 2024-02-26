using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reasl_Estate_UI.Dtos.ContactDtos;

namespace Reasl_Estate_UI.ViewComponents.DashBoard
{
    public class _DashBoardLast4ContactListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashBoardLast4ContactListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44347/api/Contacts/GetLast4ContactAsync");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject <List<Last4ContactResultDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
