using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.ViewComponents.DashBoard
{
    public class _DashBoardStatisticsComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashBoardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region ProductCount
            var responseMessage1 = await client.GetAsync("https://localhost:44347/api/Statistics/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            #endregion

            #region EmployeeNameByMaxProductCount
            var responseMessage2 = await client.GetAsync("https://localhost:44347/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount = jsonData2;
            #endregion

            #region DifferentCityCount
            var responseMessage3 = await client.GetAsync("https://localhost:44347/api/Statistics/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount = jsonData3;
            #endregion

            #region AverageProductPriceByRent
            var responseMessage4 = await client.GetAsync("https://localhost:44347/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4.Replace(".",",");
            #endregion

            return View();
        }
    }
}
