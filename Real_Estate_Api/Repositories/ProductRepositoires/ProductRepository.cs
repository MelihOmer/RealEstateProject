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

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "select top(5)c.name as 'categoryName',p.Id,p.Title,p.Price,p.City,p.District,p.advertisementDate from product p join Category c on c.Id=p.CategoryId" +
                " where type= 'Kiralık' order by p.Id desc";
            using (var connection = _appDbContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsync(int id)
        {
            string query = " select c.Name categoryName,p.* from product p join Category c on c.Id = p.CategoryId where EmployeeId=@empId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@empId", id);
            using (var connection = _appDbContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,parameters);
                return values.ToList();
            }
        }

        public async Task<ResultProductDto> GetProductByIdAsync(int id)
        {
            string query = "select * from product where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using(var connection = _appDbContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultProductDto>(query,parameters);
                return value;
            }

        }

        public async Task ProductDealOfTheDayStatusChange(int id)
        {
            var product = await GetProductByIdAsync(id);
            string query = "update product set DealOfTheDay=@dealOfDayValue where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@dealOfDayValue", !product.DealOfTheDay);
            parameters.Add("@id", id);
            using (var connection = _appDbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
