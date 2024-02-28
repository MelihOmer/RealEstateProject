using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Tools;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateToken(GetCheckUserViewModel getCheckUserViewModel)
        {
            var values = JwtTokenGenerator.GenerateToken(getCheckUserViewModel);
            return Ok(values);
        }
    }
}
