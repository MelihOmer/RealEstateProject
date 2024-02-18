using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Dtos.WhoWeAreDetailDtos;
using Real_Estate_Api.Repositories.WhoWeAreRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailsController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreRepository;

        public WhoWeAreDetailsController(IWhoWeAreDetailRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var values = await _whoWeAreRepository.GetWhoWeAreDetailByIdAsync(id);
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            await _whoWeAreRepository.CreateWhoWeAreDetailAsync(createWhoWeAreDetailDto);
            return Ok("Biz Kimiz Alanı Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            await _whoWeAreRepository.DeleteWhoWeAreDetailAsync(id);
            return Ok($"{id} Nolu Biz Kimiz Alanı Silindi...");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            await _whoWeAreRepository.UpdateWhoWeAreDetailAsync(updateWhoWeAreDetailDto);
            return Ok($"{updateWhoWeAreDetailDto.Id} Nolu Biz Kimiz Alanı Güncellendi...");
        }
    }
}
