using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reasl_Estate_UI.Dtos.ServiceDtos;
using Reasl_Estate_UI.Dtos.WhoWeAreDtos;

namespace Reasl_Estate_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44347/api/WhoWeAreDetails");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);
                ViewBag.title = value.Select(r => r.title).FirstOrDefault();
                ViewBag.subTitle = value.Select(r => r.subTitle).FirstOrDefault();
                ViewBag.description1 = value.Select(r => r.description1).FirstOrDefault();
                ViewBag.description2 = value.Select(r => r.description2).FirstOrDefault();
            }
            var responseMessagService = await client.GetAsync("https://localhost:44347/api/Services");
            if (responseMessagService.IsSuccessStatusCode)
            {
                var jsonDataService = await responseMessagService.Content.ReadAsStringAsync();
                var valueService = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonDataService);
                return View(valueService);
            }
            return View();
        }
    }
}
