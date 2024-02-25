using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Dtos.PopulerLocationDtos;
using Real_Estate_Api.Repositories.PopularLocationRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _locationRepository;

        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var values = await _locationRepository.GetAllPopularLocationAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var values = await _locationRepository.GetPopularLocationByIdAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            await _locationRepository.CreatePopularLocationAsync(createPopularLocationDto);
            return Ok("Popüler Lokasyon Eklendi...");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            await _locationRepository.UpdatePopularLocationAsync(updatePopularLocationDto);
            return Ok($"{updatePopularLocationDto.Id} Nolu Popüler Lokasyon Güncellendi...");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            await _locationRepository.DeletePopularLocationAsync(id);
            return Ok($"{id} Nolu Popüler Lokasyon Silindi...");
        }
    }
}
