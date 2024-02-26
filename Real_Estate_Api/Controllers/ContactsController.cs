using Microsoft.AspNetCore.Mvc;
using Real_Estate_Api.Repositories.ContactRepositories;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpGet("GetLast4ContactAsync")]
        public async Task<IActionResult> GetLast4ContactAsync()
        {
            var values = await _contactRepository.GetLast4ContactAsync();
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _contactRepository.GetAllContactAsync();
            return Ok(values);
        }
    }
}
