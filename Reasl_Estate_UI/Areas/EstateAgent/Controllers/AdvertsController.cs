using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reasl_Estate_UI.Dtos.ProductDtos;

namespace Reasl_Estate_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class AdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdvertsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //ResultProductAdvertListWithCategoryByEmployeeDto
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44347/api/Products/ProductAdvertsListByEmployee?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
