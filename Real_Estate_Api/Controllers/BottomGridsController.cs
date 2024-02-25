using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Dtos.BottomGridDtos;
using Real_Estate_Api.Repositories.BottomGridRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var value = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetBottomGridByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            await _bottomGridRepository.CreateBottomGridAsync(createBottomGridDto);

            return Ok("BottomGrid Eklendi...");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            await _bottomGridRepository.UpdateBottomGridAsync(updateBottomGridDto);
            return Ok($"{updateBottomGridDto.Id} Nolu BottomGrid Güncellendi...");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridRepository.DeleteBottomGridAsync(id);
            return Ok($"{id} Nolu BottomGrid Silindi...");
        }
    }
}
