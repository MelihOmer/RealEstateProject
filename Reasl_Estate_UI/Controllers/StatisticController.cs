using Microsoft.AspNetCore.Mvc;

namespace Reasl_Estate_UI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult>Index()
        {
            //
            var client = _httpClientFactory.CreateClient();
            #region ActiveCategoryCount
            var responseMessage = await client.GetAsync("https://localhost:44347/api/Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion
            #region ActiveEmployeeCount
            var responseMessage2 = await client.GetAsync("https://localhost:44347/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion
            #region ApartmentCount
            var responseMessage3 = await client.GetAsync("https://localhost:44347/api/Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;
            #endregion
            #region AverageProductPriceByRent
            var responseMessage4 = await client.GetAsync("https://localhost:44347/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion
            #region AverageProductPriceBySale
            var responseMessage5 = await client.GetAsync("https://localhost:44347/api/Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = jsonData5;
            #endregion
            #region AverageRoomCount
            var responseMessage6 = await client.GetAsync("https://localhost:44347/api/Statistics/AverageRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.averageRoomCount = jsonData6;
            #endregion
            #region CategoryCount
            var responseMessage7 = await client.GetAsync("https://localhost:44347/api/Statistics/CategoryCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData7;
            #endregion
            #region CategoryNameByMaxProductCount
            var responseMessage8 = await client.GetAsync("https://localhost:44347/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData8;
            #endregion

            return View();
        }
    }
}
