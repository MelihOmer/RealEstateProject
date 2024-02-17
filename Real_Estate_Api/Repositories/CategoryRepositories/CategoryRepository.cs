using Dapper;
using Real_Estate_Api.Dtos.CategoryDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(int id)
        {
            string query = "select * from category where Id=@categoryId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query,parameters);
                return values;
            }
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into category (Name,Status) values (@categoryName,@categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDto.Name);
            parameters.Add("@categoryStatus", true);
            using(var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "update category set Name=@categoryName,Status=@categoryStatus where Id=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategoryDto.Name);
            parameters.Add("@categoryStatus", updateCategoryDto.Status);
            parameters.Add("@categoryId", updateCategoryDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "delete from category where Id=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
