using Real_Estate_Api.Dtos.TodoDtos;

namespace Real_Estate_Api.Repositories.TodoRepositories
{
    public interface ITodoRepository
    {
        Task<List<ResultTodoDto>> GetAllTodoAsync();
        Task CreateTodoAsync(CreateTodoDto createTodoDto);
        Task UpdateTodoAsync(UpdateTodoDto updateTodoDto);
        Task DeleteTodoAsync(int id);
        Task<GetByIdTodoDto> GetTodoByIdAsync(int id);
    }
}
