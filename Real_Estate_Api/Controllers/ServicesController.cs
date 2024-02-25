using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Dtos.ServiceDtos;
using Real_Estate_Api.Repositories.ServiceRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _serviceRepository.GetServiceByIdAsync(id);
            return Ok(value);

        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _serviceRepository.CreateServiceAsync(createServiceDto);
            return Ok("Service Eklendi...");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _serviceRepository.UpdateServiceAsync(updateServiceDto);
            return Ok($"{updateServiceDto.Id} Nolu Service Güncellendi...");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
            return Ok($"{id} Nolu Service Silindi...");
        }
    }
}
