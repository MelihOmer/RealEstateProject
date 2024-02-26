using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reasl_Estate_UI.Dtos.TodoDtos;

namespace Reasl_Estate_UI.Controllers
{
    public class TodoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TodoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44347/api/Todos");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTodoDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
