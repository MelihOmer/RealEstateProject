using Dapper;
using Real_Estate_Api.Dtos.TodoDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.TodoRepositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTodoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultTodoDto>> GetAllTodoAsync()
        {
            string query = "select * from Todo";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTodoDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdTodoDto> GetTodoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoAsync(UpdateTodoDto updateTodoDto)
        {
            throw new NotImplementedException();
        }
    }
}
