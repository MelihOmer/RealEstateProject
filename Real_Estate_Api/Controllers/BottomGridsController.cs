using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Repositories.BottomGridRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var value = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(value);
        }
    }
}
