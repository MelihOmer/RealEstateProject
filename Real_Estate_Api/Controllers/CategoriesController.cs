using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Dtos.CategoryDtos;
using Real_Estate_Api.Repositories.CategoryRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var values = await _categoryRepository.GetCategoryByIdAsync(id);
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return Ok($"{id} Nolu Kategori Silindi...");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryRepository.UpdateCategoryAsync(updateCategoryDto);
            return Ok($"{updateCategoryDto.Id} Nolu Kategori Güncellendi...");
        }
    }
}
