using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Repositories.TodoRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodosController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> TodoList()
        {
            var values = await _todoRepository.GetAllTodoAsync();
            return Ok(values);
        }
    }
}
