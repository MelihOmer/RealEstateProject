using Real_Estate_Api.Dtos.ProductDtos;

namespace Real_Estate_Api.Repositories.ProductRepositoires
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    }
}
