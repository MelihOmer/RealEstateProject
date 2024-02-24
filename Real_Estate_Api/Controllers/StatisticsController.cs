using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Repositories.StatisticRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticsController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }
        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
        {
            return Ok(await _statisticRepository.ActiveCategoryCount());
        }
        [HttpGet("ActiveEmployeeCount")]
        public async Task<IActionResult> ActiveEmployeeCount()
        {
            return Ok(await _statisticRepository.ActiveEmployeeCount());
        }
        [HttpGet("ApartmentCount")]
        public async Task<IActionResult> ApartmentCount()
        {
            return Ok(await _statisticRepository.ApartmentCount());
        }
        [HttpGet("AverageProductPriceByRent")]
        public async Task<IActionResult> AverageProductPriceByRent()
        {
            return Ok(await _statisticRepository.AverageProductPriceByRent());
        }
        [HttpGet("AverageProductPriceBySale")]
        public async Task<IActionResult> AverageProductPriceBySale()
        {
            return Ok(await _statisticRepository.AverageProductPriceBySale());
        }
        [HttpGet("AverageRoomCount")]
        public async Task<IActionResult> AverageRoomCount()
        {
            return Ok(await _statisticRepository.AverageRoomCount());
        }
        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            return Ok(await _statisticRepository.CategoryCount());
        }
        [HttpGet("CategoryNameByMaxProductCount")]
        public async Task<IActionResult> CategoryNameByMaxProductCount()
        {
            return Ok(await _statisticRepository.CategoryNameByMaxProductCount());
        }
        [HttpGet("CityNameByMaxProductCount")]
        public async Task<IActionResult> CityNameByMaxProductCount()
        {
            return Ok(await _statisticRepository.CityNameByMaxProductCount());
        }
        [HttpGet("DifferentCityCount")]
        public async Task<IActionResult> DifferentCityCount()
        {
            return Ok(await _statisticRepository.DifferentCityCount());
        }
        [HttpGet("EmployeeNameByMaxProductCount")]
        public async Task<IActionResult> EmployeeNameByMaxProductCount()
        {
            return Ok(await _statisticRepository.EmployeeNameByMaxProductCount());
        }
        [HttpGet("LastProductPrice")]
        public async Task<IActionResult> LastProductPrice()
        {
            return Ok(await _statisticRepository.LastProductPrice());
        }
        [HttpGet("NewestBuildingYear")]
        public async Task<IActionResult> NewestBuildingYear()
        {
            return Ok(await _statisticRepository.NewestBuildingYear());
        }
        [HttpGet("OldestBuildingYear")]
        public async Task<IActionResult> OldestBuildingYear()
        {
            return Ok(await _statisticRepository.OldestBuildingYear());
        }
        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            return Ok(await _statisticRepository.ProductCount());
        }
        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
        {
            return Ok(await _statisticRepository.PassiveCategoryCount());
        }
    }
}
