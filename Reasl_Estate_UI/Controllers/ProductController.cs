using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Reasl_Estate_UI.Dtos.CategoryDtos;
using Reasl_Estate_UI.Dtos.ProductDtos;
using System.Text;

namespace Reasl_Estate_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44347/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44347/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                List<SelectListItem> categoryValues = (from x in values.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.Id.ToString()
                                                       }).ToList();
                ViewBag.CategoryList = categoryValues;
            }
            return View(createProductDto);
        }
        [HttpGet("ProductDealOfTheDayChange/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayChange(int id)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent stringContent = new StringContent(id.ToString(),Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44347/api/Products/ProductDealOfTheDayChange/{id}", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
