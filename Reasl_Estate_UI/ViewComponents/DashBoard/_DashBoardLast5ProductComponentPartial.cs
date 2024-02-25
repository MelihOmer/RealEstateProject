using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reasl_Estate_UI.Dtos.ProductDtos;

namespace Reasl_Estate_UI.ViewComponents.DashBoard
{
    public class _DashBoardLast5ProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashBoardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region Last5ProductList
            var responseMessage1 = await client.GetAsync("https://localhost:44347/api/Products/Last5ProductList");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            if(responseMessage1.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsonData1);
                return View(values);
            }
            ViewBag.ProductCount = jsonData1;
            #endregion
            return View();
        }
    }
}
