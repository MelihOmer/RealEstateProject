using Real_Estate_Api.Dtos.CategoryDtos;

namespace Real_Estate_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<GetByIdCategoryDto> GetCategoryByIdAsync(int id);
    }
}
