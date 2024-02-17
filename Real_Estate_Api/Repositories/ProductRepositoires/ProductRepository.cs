using Dapper;
using Real_Estate_Api.Dtos.ProductDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.ProductRepositoires
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "select * from  product";
            using (var connection = _appDbContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = " select c.Name categoryName,p.* from product p join Category c on c.Id = p.CategoryId";
            using (var connection = _appDbContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
