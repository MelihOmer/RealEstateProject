using Real_Estate_Api.Dtos.ProductDtos;

namespace Real_Estate_Api.Repositories.ProductRepositoires
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsync(int id);
        Task<ResultProductDto> GetProductByIdAsync(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task ProductDealOfTheDayStatusChange(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();
    }
}
